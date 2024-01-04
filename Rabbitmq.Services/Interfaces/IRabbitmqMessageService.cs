using Rabbitmq.Models;

namespace Rabbitmq.Services.Interfaces
{
    public interface IRabbitmqMessageService
    {
        void SendMessage(RabbitMessage message);
    }
}
