using Microsoft.EntityFrameworkCore;
using Logistics.Core.Entities;

namespace Logistics.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Shipment> Shipments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Shipment>(entity =>
            {
                // Configure Primary Key (Assuming Id is the standard convention)
                entity.HasKey(e => e.Id);

                // Configure TrackingNumber: Required and MaxLength 50
                entity.Property(e => e.TrackingNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                // Configure Status: Convert Enum to String for database readability
                entity.Property(e => e.Status)
                    .HasConversion<string>();
            });
        }
    }
}