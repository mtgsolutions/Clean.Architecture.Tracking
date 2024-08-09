using Clean.Architecture.Tracking.Core.Entities;
using Clean.Architecture.Tracking.Core.Repositories.Contracts;
using MongoDB.Driver;
using System.Runtime.CompilerServices;

namespace Clean.Architecture.Tracking.Infrastructure.Persistence.Repositories.Implementations;

public class ShippingOrderUpdateRepository : IShippingOrderUpdateRepository
{
    private readonly IMongoCollection<ShippingOrderUpdate> _shippingOrderUpdateCollection;

    public ShippingOrderUpdateRepository(IMongoDatabase mongoDatabase)
    {
        _shippingOrderUpdateCollection = mongoDatabase.GetCollection<ShippingOrderUpdate>("shipping-order-updates");
    }

    public async Task AddAsync(ShippingOrderUpdate shippingOrderUpdate)
    {
        await _shippingOrderUpdateCollection.InsertOneAsync(shippingOrderUpdate);
    }

    public async Task<IEnumerable<ShippingOrderUpdate>> GetByTrackingNumberAsync(string trackingNumber)
    {
        return await _shippingOrderUpdateCollection.Find(x => x.TrackingNumber == trackingNumber).ToListAsync();
    }
}
