using Microsoft.AspNetCore.Mvc;
using WebApplicationAPI.Models;

namespace WebApplicationAPI.Controllers
{
    [Route("/api/VillaAPI")]
    [ApiController]
    public class VillaApiController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Villa> GetVillas() {
            return new List<Villa> {
                new Villa { Id = 1,Name = "Villa1" } ,
                new Villa { Id = 2, Name = "Villa2" }
            }; 
            }
    }
}
