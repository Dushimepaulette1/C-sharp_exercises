using Azure.Messaging.ServiceBus;

string connectionString = Environment.GetEnvironmentVariable("SERVICEBUS_CONNECTION_STRING")
    ?? throw new InvalidOperationException("Set the SERVICEBUS_CONNECTION_STRING environment variable.");

string queueName = "learningqueue";
var client = new ServiceBusClient(connectionString);
var receiver = client.CreateReceiver(queueName);

Console.WriteLine("Receive messages...");
var message = await receiver.ReceiveMessageAsync();


if (message != null)
{
    // Console.Write(message.Body.ToString());
    //completing the message will remove it from the queue
    // await receiver.CompleteMessageAsync(message);
    // Abandoning the message will make it available for reprocessing
    // await receiver.AbandonMessageAsync(message);
    // Deferring the message will make it available for processing later
    // await receiver.DeferMessageAsync(message);
    // var deferredMessage = await receiver.ReceiveDeferredMessageAsync(message.SequenceNumber);
    // Console.WriteLine($"Deferred message: {deferredMessage.Body.ToString()}");
    // Move the message from the active queue into the dead-letter sub-queue
    await receiver.DeadLetterMessageAsync(message);
    Console.WriteLine($"Dead-lettered message: {message.Body}");

    // Reading a dead-lettered message requires a separate receiver pointed
    // at the dead-letter sub-queue (there's no ReceiveMode.DeadLetter option
    // on ReceiveMessageAsync in this SDK, unlike the older library).
    var dlqReceiver = client.CreateReceiver(queueName, new ServiceBusReceiverOptions
    {
        SubQueue = SubQueue.DeadLetter
    });

    // var messageInDeadLetterQueue = await dlqReceiver.ReceiveMessageAsync();
    if (messageInDeadLetterQueue != null)
    {
        Console.WriteLine($"Message in dead letter queue: {messageInDeadLetterQueue.Body}");

        // Complete it here too, otherwise it stays locked in the DLQ and
        // reappears there again once the lock expires.
        // await dlqReceiver.CompleteMessageAsync(messageInDeadLetterQueue);
    }

    await dlqReceiver.CloseAsync();

    // Employee employee = System.Text.Json.JsonSerializer.Deserialize<Employee>(message.Body.ToString());
    // Console.WriteLine($"Received employee: {employee.Name}, {employee.Department}");
}
else
{
    Console.WriteLine("No messages received.");
}

// while (true)
// {
//     var message = await receiver.ReceiveMessageAsync();

//     if (message != null)
//     {
//         Console.Write(message.Body.ToString());

//         await receiver.CompleteMessageAsync(message);
//     }
//     else
//     {
//         Console.WriteLine();
//         Console.WriteLine("All messages received.");
//         break;
//     }
// }

await receiver.CloseAsync();
class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
}
