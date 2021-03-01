using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SBSender.Services
{
    public class QueueService : IQueueService
    {
        public readonly IConfiguration _config;
        public QueueService(IConfiguration config)
        {
            this._config = config;
        }

        public async Task SendMessageAsync<T>(T servicebusMessage, string queueName)
        {
            var queueClient = new QueueClient(this._config.GetConnectionString("AzureServiceBus"), queueName);
            string messageBody = JsonSerializer.Serialize(servicebusMessage);
            var message = new Message(Encoding.UTF8.GetBytes(messageBody));

            await queueClient.SendAsync(message);
        }
    }
}
