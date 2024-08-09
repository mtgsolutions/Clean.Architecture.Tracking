using Clean.Architecture.Tracking.Core.Entities;

namespace Clean.Architecture.Tracking.Core.Repositories.Contracts;

public interface IShippingOrderUpdateRepository
{
    Task AddAsync(ShippingOrderUpdate shippingOrderUpdate);
    Task<IEnumerable<ShippingOrderUpdate>> GetByTrackingNumberAsync(string trackingNumber);
}
