using Azure.Messaging.ServiceBus;

string connectionString = Environment.GetEnvironmentVariable("SERVICEBUS_CONNECTION_STRING")
    ?? throw new InvalidOperationException("Set the SERVICEBUS_CONNECTION_STRING environment variable.");

string queueName = "learningqueue";
var client = new ServiceBusClient(connectionString);
var receiver = client.CreateReceiver(queueName);

Console.WriteLine("Receive messages...");

while (true)
{
    var message = await receiver.ReceiveMessageAsync();

    if (message != null)
    {
        Console.Write(message.Body.ToString());

        await receiver.CompleteMessageAsync(message);
    }
    else
    {
        Console.WriteLine();
        Console.WriteLine("All messages received.");
        break;
    }
}

await receiver.CloseAsync();
