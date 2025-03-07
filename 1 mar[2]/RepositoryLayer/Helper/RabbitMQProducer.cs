using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System;
using System.Text;

public class RabbitMQProducer
{
    private readonly string _hostname;
    private readonly int _port;
    private readonly string _username;
    private readonly string _password;
    private readonly string _queueName;

    public RabbitMQProducer(IConfiguration configuration)
    {
        // Read from appsettings.json
        _hostname = configuration["RabbitMQ:HostName"];
        _port = int.Parse(configuration["RabbitMQ:Port"]);
        _username = configuration["RabbitMQ:UserName"];
        _password = configuration["RabbitMQ:Password"];
        _queueName = configuration["RabbitMQ:QueueName"];
    }

    public void PublishMessage(string message)
    {
        var factory = new ConnectionFactory()
        {
            HostName = _hostname,
            Port = _port,
            UserName = _username,
            Password = _password
        };

        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

        var body = Encoding.UTF8.GetBytes(message);
        channel.BasicPublish(exchange: "", routingKey: _queueName, basicProperties: null, body: body);

        Console.WriteLine($"Message Sent: {message}");
    }
}
