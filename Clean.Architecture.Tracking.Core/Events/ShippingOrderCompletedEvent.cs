namespace Clean.Architecture.Tracking.Core.Events;

public class ShippingOrderCompletedEvent
{
    public ShippingOrderCompletedEvent(string trackingNumber)
    {
        TrackingNumber = trackingNumber;
    }

    public string TrackingNumber { get; private set; }
}
