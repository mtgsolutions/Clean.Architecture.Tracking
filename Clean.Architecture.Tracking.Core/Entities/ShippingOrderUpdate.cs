using Clean.Architecture.Tracking.Core.Entities.Base;

namespace Clean.Architecture.Tracking.Core.Entities;

public class ShippingOrderUpdate : EntityBase
{
    public ShippingOrderUpdate(string trackingNumber, string description, bool isShippingCompleted, string contactEmail): base()
    {
        TrackingNumber = trackingNumber;
        Description = description;
        IsShippingCompleted = isShippingCompleted;
        UpdatedAt = DateTime.UtcNow;
        ContactEmail = contactEmail;
    }

    public string TrackingNumber { get; private set; }
    public string Description { get; private set; }
    public bool IsShippingCompleted { get; private set; }
    public string ContactEmail { get; private set; }
    public DateTime UpdatedAt { get; private set; }
}
