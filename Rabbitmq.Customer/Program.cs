using Rabbitmq.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

var factory = new ConnectionFactory { 
    HostName = "localhost" ,
    UserName = "admin" ,
    Password = "123456" ,
};

using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(queue: "rabbitmqMessageQueue",
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

var consumer = new EventingBasicConsumer(channel);

consumer.Received += (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);

    System.Threading.Thread.Sleep(1000);
   
    RabbitMessage messageJson = JsonSerializer.Deserialize<RabbitMessage>(message) ?? throw new JsonException("Falha na deserialização");

    Console.WriteLine($"Titulo: {messageJson.Title}; Texto: {messageJson.Message}; Id: {messageJson.Id}");

};

channel.BasicConsume(queue: "rabbitmqMessageQueue",
                     autoAck: true,
                     consumer: consumer);

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();
