using Microsoft.EntityFrameworkCore;
using Logistics.Infrastructure.Data;
using Logistics.Core.Interfaces;
using Logistics.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// --- 1. CONFIGURATION AND SERVICES ---

// Register ApplicationDbContext with SQL Server
// CRITICAL: Connection string must use the Docker Hostname (nexus-sqldb)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString)
);

// Register Repository as Scoped Service (DI Configuration)
// When IShipmentRepository is requested, provide ShipmentRepository implementation.
builder.Services.AddScoped<IShipmentRepository, ShipmentRepository>();

// Add Controllers and Swagger/OpenAPI support
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// --- 2. MIDDLEWARE PIPELINE ---

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();