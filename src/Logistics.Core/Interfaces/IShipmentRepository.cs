using System;
using System.Threading.Tasks;
using Logistics.Core.Entities;

namespace Logistics.Core.Interfaces
{
    public interface IShipmentRepository
    {
        Task<Shipment?> GetByIdAsync(Guid id);
        Task CreateAsync(Shipment shipment);
        Task UpdateAsync(Shipment shipment);
    }
}