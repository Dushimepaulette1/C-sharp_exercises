using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;
var connectionString = Environment.GetEnvironmentVariable("SERVICEBUS_CONNECTION_STRING")
    ?? throw new InvalidOperationException("Set the SERVICEBUS_CONNECTION_STRING environment variable.");
var topciName = "firsttopic";

var serviceBusClient = new ServiceBusClient(connectionString);

var serviceBusSender = serviceBusClient.CreateSender(topciName);
//create service bus admin client
var serviceBusAdminClient = new ServiceBusAdministrationClient(connectionString);

// create subscription s3 with Correlation filter(Property: City = Kigali) using service bus admin client
var S3Details = new CreateSubscriptionOptions("firsttopic", "s3");
var S3Rule = new CreateRuleOptions("s3Rule", new CorrelationRuleFilter { ApplicationProperties = { { "City", "Kigali" } } });
await serviceBusAdminClient.CreateSubscriptionAsync(S3Details, S3Rule);
