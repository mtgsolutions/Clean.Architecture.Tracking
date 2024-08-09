using Clean.Architecture.Tracking.Infrastructure.Messaging.Contracts;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Clean.Architecture.Tracking.Infrastructure.Messaging.Implementations;

public class RabbitMqService : IMessageBusService
{
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private const string _exchangeName = "clean-tracking-service";

    public RabbitMqService()
    {
        var factory = new ConnectionFactory
        {
            HostName = "localhost",
        };
        _connection = factory.CreateConnection("clean-tracking-service-publisher");
        _channel = _connection.CreateModel();
    }
    public void Publish(object data, string routingKey)
    {
        var payload = JsonConvert.SerializeObject(data);
        var body = Encoding.UTF8.GetBytes(payload);

        _channel.BasicPublish(_exchangeName, routingKey, null, body);
    }
}
