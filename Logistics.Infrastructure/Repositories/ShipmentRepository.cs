using System; // Required for Guid
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Logistics.Core.Entities;
using Logistics.Core.Interfaces;
using Logistics.Infrastructure.Data;

namespace Logistics.Infrastructure.Repositories
{
    // FIX 1: Implement the Interface, do NOT inherit the Entity
    public class ShipmentRepository : IShipmentRepository
    {
        private readonly ApplicationDbContext _context;

        public ShipmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // FIX 2: Change int to Guid to match the Domain Entity
        public async Task<Shipment?> GetByIdAsync(Guid id)
        {
            return await _context.Shipments
                .AsNoTracking() // Optimization for read-only
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        // Note: Check if IShipmentRepository has GetAllAsync. 
        // If not, remove this method or add it to the Interface in Core.
        public async Task<IEnumerable<Shipment>> GetAllAsync()
        {
            return await _context.Shipments
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task CreateAsync(Shipment shipment)
        {
            await _context.Shipments.AddAsync(shipment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Shipment shipment)
        {
            _context.Shipments.Update(shipment);
            await _context.SaveChangesAsync();
        }
    }
}