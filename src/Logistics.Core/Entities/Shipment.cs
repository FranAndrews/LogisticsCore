using System;

namespace Logistics.Core.Entities
{
    public class Shipment
    {
        public Guid Id { get; private set; }
        public string TrackingNumber { get; private set; }
        public ShipmentStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public double Weight { get; private set; }

        public Shipment(string trackingNumber, double weight)
        {
            //checking if it is empty
            if (string.IsNullOrWhiteSpace(trackingNumber))
                throw new ArgumentException("Tracking number cannot be empty.", nameof(trackingNumber));

            //checking if the shipment weight is equal or bigger than zero
            if (weight <= 0)
                throw new ArgumentException("Weight must be greater than zero.", nameof(weight));

            Id = Guid.NewGuid();
            TrackingNumber = trackingNumber;
            Status = ShipmentStatus.Pending;
            CreatedAt = DateTime.UtcNow;
            Weight = weight;
        }

        // Domain method to update status
        public void UpdateStatus(ShipmentStatus newStatus)
        {
            Status = newStatus;
        }
    }
}