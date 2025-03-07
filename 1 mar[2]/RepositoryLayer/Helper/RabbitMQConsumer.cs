using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;

public class RabbitMQConsumer
{
    private readonly string _hostname;
    private readonly int _port;
    private readonly string _username;
    private readonly string _password;
    private readonly string _queueName;
    private readonly ILogger<RabbitMQConsumer> _logger;

    public RabbitMQConsumer(IConfiguration configuration, ILogger<RabbitMQConsumer> logger)
    {
        _hostname = configuration["RabbitMQ:HostName"];
        _port = int.Parse(configuration["RabbitMQ:Port"]);
        _username = configuration["RabbitMQ:UserName"];
        _password = configuration["RabbitMQ:Password"];
        _queueName = configuration["RabbitMQ:QueueName"];
        _logger = logger;
    }

    public void ConsumeMessages()
    {
        try
        {
            var factory = new ConnectionFactory()
            {
                HostName = _hostname,
                Port = _port,
                UserName = _username,
                Password = _password
            };

            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, eventArgs) =>
            {
                var body = eventArgs.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                _logger.LogInformation($"Received message: {message}");
            };

            channel.BasicConsume(queue: _queueName, autoAck: true, consumer: consumer);

            _logger.LogInformation("RabbitMQ Consumer started. Listening for messages...");
            Thread.Sleep(Timeout.Infinite); // Keep listening
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error in RabbitMQ Consumer: {ex.Message}");
        }
    }
}
