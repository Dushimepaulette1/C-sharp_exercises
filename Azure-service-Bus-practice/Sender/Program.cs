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
var firstEmployee = new Employee
{
    Id = 1,
    Name = "John Doe",
    Department = "IT"
};
var msgInJson = new ServiceBusMessage(System.Text.Json.JsonSerializer.Serialize(firstEmployee));
await sender.SendMessageAsync(msgInJson);

// foreach(var character in Sentence)
// {
//   var message = new ServiceBusMessage(character.ToString());
//   await sender.SendMessageAsync(message);
//   Console.WriteLine($" Sent : {character}");
// }
// Close the sender
await sender.CloseAsync();
Console.WriteLine("Sent messages.");

class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
}