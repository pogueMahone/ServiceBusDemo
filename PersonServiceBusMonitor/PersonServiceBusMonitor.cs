using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using SBShared.Models;

namespace PersonServiceBusMonitor
{
    public static class PersonServiceBusMonitor
    {
        [FunctionName("PersonServiceBusMonitor")]
        public static void Run([ServiceBusTrigger("personqueue", Connection = "AzureServiceBus")]string jsonPerson, ILogger log)
        {
            PersonModel person = JsonSerializer.Deserialize<PersonModel>(jsonPerson);
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {person.FirstName} {person.LastName}");
        }
    }
}
