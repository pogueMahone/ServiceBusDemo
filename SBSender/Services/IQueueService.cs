using System.Threading.Tasks;

namespace SBSender.Services
{
    public interface IQueueService
    {
        Task SendMessageAsync<T>(T servicebusMessage, string queueName);
    }
}