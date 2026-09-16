# Azure Service Bus – Queue Starter

A minimal two-project starter for learning Azure Service Bus "brokered
messaging" with a queue: one console app sends messages, another receives
them. Each `Program.cs` is heavily commented to explain what every SDK call
does and why.

```
Sender/     -> produces messages, sends them to the queue
Receiver/   -> consumes messages from the queue
```

## Prerequisites

- .NET 8 SDK
- A Service Bus **namespace** and **queue** already created in Azure (you said
  you've done this already ✅)
- The namespace's connection string (Azure Portal → your Service Bus
  namespace → **Shared access policies** → `RootManageSharedAccessKey` →
  **Primary Connection String**)

## Configure

Both apps read the same two environment variables — no secrets are stored in
the code:

| Variable | Value |
|---|---|
| `SERVICEBUS_CONNECTION_STRING` | The connection string from the portal |
| `SERVICEBUS_QUEUE_NAME` | The name of the queue you created |

**PowerShell**
```powershell
$env:SERVICEBUS_CONNECTION_STRING = "Endpoint=sb://<your-namespace>.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=..."
$env:SERVICEBUS_QUEUE_NAME = "your-queue-name"
```

**bash / zsh**
```bash
export SERVICEBUS_CONNECTION_STRING="Endpoint=sb://<your-namespace>.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=..."
export SERVICEBUS_QUEUE_NAME="your-queue-name"
```

Set these in every terminal you use to run the apps (or add them to your
shell profile / a `.env` you load yourself).

## Run

Open two terminals.

**Terminal 1 – start the receiver first so it's listening:**
```bash
cd Receiver
dotnet run
```

**Terminal 2 – send some messages:**
```bash
cd Sender
dotnet run
```

You should see the Receiver print each message as it arrives. Press any key
in the Receiver terminal to stop it.

## What's actually happening

1. `Sender` creates a `ServiceBusClient`, gets a `ServiceBusSender` for the
   queue, batches up a few `ServiceBusMessage`s, and sends the batch. Once
   `SendMessagesAsync` returns, the messages are durably stored by the broker
   — the Sender's job is done, whether or not anyone is listening yet.
2. `Receiver` creates its own `ServiceBusClient` and a `ServiceBusProcessor`,
   which pulls messages from the queue in the background and invokes your
   handler for each one. The handler prints the message and then explicitly
   **completes** it (tells the broker "delete this, I'm done"). If the
   handler throws or you call `AbandonMessageAsync` instead, the message
   becomes available for redelivery.

## Where to go next

- **Dead-lettering**: after too many failed delivery attempts, Service Bus
  automatically moves a message to the queue's dead-letter sub-queue — try
  throwing an exception in the handler and inspecting the DLQ in the portal.
- **Topics & Subscriptions**: the pub-sub version of this pattern — one
  sender, many independent subscriptions each getting their own copy.
- **Sessions**: for when you need ordered/grouped message processing.
- **Managed Identity / `DefaultAzureCredential`**: for production code you'd
  typically avoid connection strings entirely and authenticate with Azure AD
  instead — worth exploring once you're comfortable with the basics here.
