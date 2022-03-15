using Device_Manager.API.Data;
using Device_Manager.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Device_Manager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DevicesController : Controller
    {
        private readonly DeviceDBContext devicesDbContext;

        public DevicesController(DeviceDBContext devicesDbContext)
        {
            this.devicesDbContext = devicesDbContext;
        }

        //Get All Devices
        [HttpGet]
        public async Task<IActionResult> GetAllDevices()
        {
            var devices = await devicesDbContext.devices.ToListAsync();
            return Ok(devices);
        }

        //Get a single device
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetDevice")]
        public async Task<IActionResult> GetDevice([FromRoute] Guid id)
        {
            var device = await devicesDbContext.devices.FirstOrDefaultAsync(x => x.Iddev == id);
            if (device != null)
            {
                return Ok(device);
            }
            return NotFound("Device not found!");
        }

        //Add a device
        [HttpPost]

        public async Task<IActionResult> AddDevice([FromBody] Device device)
        {
            device.Iddev = Guid.NewGuid();
            await devicesDbContext.devices.AddAsync(device);
            await devicesDbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetDevice), new { id = device.Iddev }, device);
        }
        // Updating a device
        [HttpPut]
        [Route("{id:guid}")]

        public async Task<IActionResult> UpdateDevice([FromRoute] Guid id, [FromBody] Device device)
        {
            var existingDevice = await devicesDbContext.devices.FirstOrDefaultAsync(x => x.Iddev == id);
            if (existingDevice != null)
            {
                existingDevice.Name = device.Name;
                existingDevice.Manufacturer = device.Manufacturer;
                existingDevice.Type = device.Type;
                existingDevice.OS = device.OS;
                existingDevice.Osver = device.Osver;
                existingDevice.Processor = device.Processor;
                existingDevice.Ram = device.Ram;
                await devicesDbContext.SaveChangesAsync();
                return Ok(existingDevice);
            }
            return NotFound("Device not found!");
        }

        // Delete a device
        [HttpDelete]
        [Route("{id:guid}")]

        public async Task<IActionResult> DeleteDevice([FromRoute] Guid id)
        {
            var existingDevice = await devicesDbContext.devices.FirstOrDefaultAsync(x => x.Iddev == id);
            if (existingDevice != null)
            {
                devicesDbContext.devices.Remove(existingDevice);
                await devicesDbContext.SaveChangesAsync();
                return Ok(existingDevice);
            }
            return NotFound("Device not found!");
        }


    }
}
