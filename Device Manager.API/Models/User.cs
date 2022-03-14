using System.ComponentModel.DataAnnotations;

namespace Device_Manager.API.Models
{
    public class User
    {
        [Key]
        public Guid Idusr { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }

        public string Location { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

    }
}
