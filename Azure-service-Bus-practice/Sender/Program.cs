using Azure.Messaging.ServiceBus;

// TODO: Get the connection string from an environment variable (SERVICEBUS_CONNECTION_STRING)
string connectionString = Environment.GetEnvironmentVariable("SERVICEBUS_CONNECTION_STRING")
    ?? throw new InvalidOperationException("Set the SERVICEBUS_CONNECTION_STRING environment variable.");

// TODO: Get the queue name from an environment variable (SERVICEBUS_QUEUE_NAME)
string QueueName = "learningqueue";
string Sentence = "Microsoft Azure Service Bus";

// TODO: Create a Service Bus client
var client = new ServiceBusClient(connectionString);
// TODO: Create a sender for the queue
var sender = client.CreateSender(QueueName);
// TODO: Create a message batch
Console.WriteLine("Sending messages............");
foreach(var character in Sentence)
{
  var message = new ServiceBusMessage(character.ToString());
  await sender.SendMessageAsync(message);
  Console.WriteLine($" Sent : {character}");
}
// Close the sender
await sender.CloseAsync();
Console.WriteLine("Sent messages.");