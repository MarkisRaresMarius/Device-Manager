using Device_Manager.API.Data;
using Device_Manager.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Device_Manager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserControler : Controller
    {
        private readonly DeviceDBContext devicesDbContext;

        public UserControler(DeviceDBContext devicesDbContext)
        {
            this.devicesDbContext = devicesDbContext;
        }

        //Get All Users
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await devicesDbContext.users.ToListAsync();
            return Ok(users);
        }

        //Get a single user
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetUser")]
        public async Task<IActionResult> GetUser([FromRoute] Guid id)
        {
            var user = await devicesDbContext.users.FirstOrDefaultAsync(x => x.Idusr == id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound("User not found!");
        }

        //Add a user
        [HttpPost]

        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            user.Idusr = Guid.NewGuid();
            await devicesDbContext.users.AddAsync(user);
            await devicesDbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUser), new { id = user.Idusr }, user);
        }
        // Updating a user
        [HttpPut]
        [Route("{id:guid}")]

        public async Task<IActionResult> UpdateUser([FromRoute] Guid id, [FromBody] User user)
        {
            var existingUser = await devicesDbContext.users.FirstOrDefaultAsync(x => x.Idusr == id);
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Role = user.Role;
                existingUser.Location = user.Location;
                existingUser.Email = user.Email;
                existingUser.Password = user.Password;
                await devicesDbContext.SaveChangesAsync();
                return Ok(existingUser);
            }
            return NotFound("User not found!");
        }

        // Delete a user
        [HttpDelete]
        [Route("{id:guid}")]

        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            var existingUser = await devicesDbContext.users.FirstOrDefaultAsync(x => x.Idusr == id);
            if (existingUser != null)
            {
                devicesDbContext.users.Remove(existingUser);
                await devicesDbContext.SaveChangesAsync();
                return Ok(existingUser);
            }
            return NotFound("User not found!");
        }


    }
}
