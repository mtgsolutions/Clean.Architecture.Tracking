using Clean.Architecture.Tracking.Core.Entities;

namespace Clean.Architecture.Tracking.Application.Models.Inputs;

public class AddShippingOrderUpdateInputModel
{

    public ShippingOrderUpdate ToEntity()
    {
        return new ShippingOrderUpdate(TrackingNumber, Description, IsShippingCompleted, ContactEmail);
    }

    public string TrackingNumber { get; set; }
    public string Description { get; set; }
    public bool IsShippingCompleted { get; set; }
    public string ContactEmail { get; set; }
}
