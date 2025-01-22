using WebApplicationAPI.Models.DTO;

namespace WebApplicationAPI.Data
{
    public static class VillaStore
    {
        public static List<VillaDTO> VillaList = new List<VillaDTO>{
            new VillaDTO{ Id = 1 , Name = "Villa1" , Occupancy= 4 , Sqft = 1000},
            new VillaDTO { Id = 2 , Name = "Villa2" , Occupancy = 5 , Sqft = 1200}
        };

    }
}
