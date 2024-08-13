using Clean.Architecture.Tracking.Infrastructure.Messaging.Contracts;
using Clean.Architecture.Tracking.Infrastructure.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Clean.Architecture.Tracking.Infrastructure.Messaging.Implementations;

public class RabbitMqService : IMessageBusService
{
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private const string _exchangeName = "notifications-service";
    private readonly RabbitMqOptions _options;

    public RabbitMqService(IOptions<RabbitMqOptions> options)
    {
        _options = options.Value;
        var factory = new ConnectionFactory
        {
            HostName = _options.HostName,
            UserName = _options.UserName,
            Password = _options.Password,
            Port = _options.Port,
            DispatchConsumersAsync = true
        };
        _connection = factory.CreateConnection("trackings-service-publisher");
        _channel = _connection.CreateModel();
        _channel.QueueDeclare("notifications-service/shipping-order-updated-exchange", true, false, false);
    }
    public void Publish(object data, string routingKey)
    {
        var payload = JsonConvert.SerializeObject(data);
        var body = Encoding.UTF8.GetBytes(payload);

        _channel.BasicPublish(_exchangeName, routingKey, null, body);
    }
}
