using System.ComponentModel.DataAnnotations;

namespace Device_Manager.API.Models
{
    public class Device
    {
        [Key]
        public Guid Iddev { get; set; }

        public string Name { get; set; }
        
        public string Manufacturer { get; set; }

        public string Type { get; set; }
        
        public string OS { get; set; }

        public string OS_Ver { get; set; }

        public string Processor { get; set; }

        public int Ram { get; set; }
      
    }


   
}
