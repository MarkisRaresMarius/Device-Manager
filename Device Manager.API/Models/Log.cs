using System.ComponentModel.DataAnnotations;

namespace Device_Manager.API.Models
{
    public class Log
    {
        [Key]

        public Guid Idlog { get; set; }

        public int devid { get; set; }

        public int usrid { get; set; }

        public DateTime date { get; set; }
    }
}
