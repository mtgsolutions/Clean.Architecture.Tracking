using Clean.Architecture.Tracking.Application.Models.Inputs;
using Clean.Architecture.Tracking.Application.Models.Views;
using Clean.Architecture.Tracking.Application.Services.Contracts;
using Clean.Architecture.Tracking.Core.Events;
using Clean.Architecture.Tracking.Core.Repositories.Contracts;
using Clean.Architecture.Tracking.Infrastructure.Messaging.Contracts;

namespace Clean.Architecture.Tracking.Application.Services.Implementations;

public class ShippingOrderUpdateService : IShippingOrderUpdateService
{
    private readonly IShippingOrderUpdateRepository _shippingOrderUpdateRepository;
    private readonly IMessageBusService _messageBusService;

    public ShippingOrderUpdateService(IShippingOrderUpdateRepository shippingOrderUpdateRepository, IMessageBusService messageBusService)
    {
        _shippingOrderUpdateRepository = shippingOrderUpdateRepository;
        _messageBusService = messageBusService;
    }

    public async Task AddUpdate(AddShippingOrderUpdateInputModel model)
    {
        var shippingOrderUpdate = model.ToEntity();
        await _shippingOrderUpdateRepository.AddAsync(shippingOrderUpdate);

        var orderUpdatedEvent = new ShippingOrderUpdatedEvent(shippingOrderUpdate.TrackingNumber, shippingOrderUpdate.Description, shippingOrderUpdate.ContactEmail);

        _messageBusService.Publish(orderUpdatedEvent, "shipping-order-updated");

        if(model.IsShippingCompleted)
        {
            var orderCompletedEvent = new ShippingOrderCompletedEvent(shippingOrderUpdate.TrackingNumber);
            _messageBusService.Publish(orderCompletedEvent, "shipping-order-completed");
        }
    }

    public async Task<List<ShippingOrderUpdateViewModel>> GetAllByCode(string number)
    {
        var shippingOrderUpdate = await _shippingOrderUpdateRepository.GetByTrackingNumberAsync(number);
        var shippingOrderUpdateViewModels = shippingOrderUpdate.Select(x => new ShippingOrderUpdateViewModel(x)).ToList();

        return shippingOrderUpdateViewModels;
    }
}
