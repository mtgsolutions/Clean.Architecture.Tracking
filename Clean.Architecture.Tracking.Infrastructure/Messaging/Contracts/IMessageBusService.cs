namespace Clean.Architecture.Tracking.Infrastructure.Messaging.Contracts;

public interface IMessageBusService
{
    void Publish(object data, string routingKey);
}
