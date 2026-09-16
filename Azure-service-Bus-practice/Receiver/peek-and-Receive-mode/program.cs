using Azure.Messaging.ServiceBus;

string connectionString = Environment.GetEnvironmentVariable("SERVICEBUS_CONNECTION_STRING")
    ?? throw new InvalidOperationException("Set the SERVICEBUS_CONNECTION_STRING environment variable.");

string queueName = "learningqueue";
var client = new ServiceBusClient(connectionString);
// creating service bus receiver in peek mode, which allows you to look at messages without locking or removing them from the queue
var serviceBusReceiverPeekMode = client.CreateReceiver(queueName, new ServiceBusReceiverOptions
{
    ReceiveMode = ServiceBusReceiveMode.PeekLock
});
var messageReceivedFromPeekMode = await serviceBusReceiverPeekMode.ReceiveMessageAsync();
Console.WriteLine($"Message received in peek mode: {messageReceivedFromPeekMode.Body.ToString()}");

