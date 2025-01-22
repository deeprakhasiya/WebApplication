using System.ComponentModel.DataAnnotations;

namespace WebApplicationAPI.Models.DTO
{
    public class VillaDTO
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; } 
        public int Occupancy { get; set; }
        public int Sqft { get; set; }

        [Required]
        [MaxLength(15)]
        public string Name { get; set; }
        
    }
}
