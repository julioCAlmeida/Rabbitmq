using Rabbitmq.Models;
using Rabbitmq.Repositories;
using Rabbitmq.Repositories.Interfaces;
using Rabbitmq.Services.Interfaces;

namespace Rabbitmq.Services
{
    public class RabbitMessageService : IRabbitmqMessageService
    {
        private readonly IRabbitmqMessageRepository _repository;

        public RabbitMessageService(IRabbitmqMessageRepository repository)
        {
            _repository = repository;
        }

        public void SendMessage(RabbitMessage message)
        {
            _repository.SendMessage(message);
        }
    }
}
