namespace Clean.Architecture.Tracking.Core.Events;

public class ShippingOrderUpdatedEvent
{
    public ShippingOrderUpdatedEvent(string trackingNumber, string description, string contactEmail)
    {
        TrackingNumber = trackingNumber;
        Description = description;
        ContactEmail = contactEmail;
    }

    public string TrackingNumber { get; private set; }
    public string Description { get; private set; }
    public string ContactEmail { get; private set; }
}
