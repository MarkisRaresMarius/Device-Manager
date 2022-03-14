using Device_Manager.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Device_Manager.API.Data
{
    public class DeviceDBContext: DbContext
    {

        public DeviceDBContext(DbContextOptions options) : base(options)
        { 

        }

        //DBset
        public DbSet<Device> devices { get; set; }

        public DbSet<User> users { get; set; }

       public DbSet<Log> log { get; set; } 
    }
}
