using Clean.Architecture.Tracking.Core.Entities;

namespace Clean.Architecture.Tracking.Application.Models.Views;

public class ShippingOrderUpdateViewModel
{
    public ShippingOrderUpdateViewModel(ShippingOrderUpdate shippingOrderUpdate)
    {
        TrackingNumber = shippingOrderUpdate.TrackingNumber;
        Description = shippingOrderUpdate.Description;
        UpdatedAt = shippingOrderUpdate.UpdatedAt;
        ContactEmail = shippingOrderUpdate.ContactEmail;
    }
    public string TrackingNumber { get; private set; }
    public string Description { get; private set; }
    public string ContactEmail { get; private set; }
    public DateTime UpdatedAt { get; private set; }
}
