using Rabbitmq.Models;

namespace Rabbitmq.Repositories.Interfaces
{
    public interface IRabbitmqMessageRepository
    {
        void SendMessage(RabbitMessage message);
    }
}
