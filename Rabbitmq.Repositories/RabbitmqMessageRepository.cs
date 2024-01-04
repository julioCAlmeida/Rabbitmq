using Rabbitmq.Models;
using Rabbitmq.Repositories.Interfaces;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Rabbitmq.Repositories
{
    public class RabbitmqMessageRepository : IRabbitmqMessageRepository
    {
        public void SendMessage(RabbitMessage message)
        {
            var factory = new ConnectionFactory { 
                HostName = "localhost" ,
                UserName = "admin" ,
                Password = "123456"
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            
            channel.QueueDeclare(queue: "rabbitmqMessageQueue",
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);

            string messageJson = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(messageJson);

            channel.BasicPublish(exchange: string.Empty,
                                    routingKey: "rabbitmqMessageQueue",
                                    basicProperties: null,
                                    body: body);           
            
        }
    }
}
