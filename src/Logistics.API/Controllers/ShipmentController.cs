using Microsoft.AspNetCore.Mvc;
using Logistics.Core.Interfaces;
using System;
using System.Threading.Tasks;
using Logistics.Core.Entities;
using Logistics.API.DTOs;

namespace Logistics.API.Controllers
{
    // IShipmentRepository injected via Primary Constructor
    [ApiController]
    [Route("api/[controller]")]
    public class ShipmentsController(IShipmentRepository repository) : ControllerBase
    {
        /// <summary>
        /// Creates a new Shipment in the system.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateShipment([FromBody] CreateShipmentDto dto)
        {
            try
            {
                // 1. DTO to Domain Entity Mapping: 
                var shipment = new Shipment(dto.TrackingNumber, dto.Weight);

                // 2. Persistence Delegation: 
                await repository.CreateAsync(shipment);

                // 3. Domain Entity to Response DTO Mapping:
                var responseDto = new ShipmentResponseDto(
                    shipment.Id,
                    shipment.TrackingNumber,
                    shipment.Weight,
                    shipment.Status.ToString()
                );

                // 4. Return 201 Created:
                return CreatedAtAction(nameof(GetShipment), new { id = responseDto.Id }, responseDto);
            }
            catch (ArgumentException ex)
            {
                // Catch exceptions thrown by the Domain Entity constructor (LOG-001 validation)
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                // General error handling fallback 
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred during shipment creation.");
            }
        }

        /// <summary>
        /// Retrieves a Shipment by its globally unique identifier (GUID).
        /// </summary>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetShipment(Guid id)
        {
            // 1. Retrieve data via repository
            var shipment = await repository.GetByIdAsync(id);

            // 2. Handle 404 Not Found state
            if (shipment == null)
            {
                return NotFound($"Shipment with ID {id} not found.");
            }

            // 3. Map Domain Entity to Response DTO
            var responseDto = new ShipmentResponseDto(
                shipment.Id,
                shipment.TrackingNumber,
                shipment.Weight,
                shipment.Status.ToString()
            );

            // 4. Return 200 OK
            return Ok(responseDto);
        }
    }
}