using Microsoft.AspNetCore.Mvc;
using WebApplicationAPI.Data;
using WebApplicationAPI.Models;
using WebApplicationAPI.Models.DTO;

namespace WebApplicationAPI.Controllers
{
    [Route("/api/VillaAPI")]
    [ApiController]
    public class VillaApiController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<VillaDTO> GetVillas() {
            return VillaStore.VillaList;
        }

        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDTO> GetVilla(int id)
        {
            if ( id == 0)
            {
                return BadRequest();
            }
            var villa = VillaStore.VillaList.FirstOrDefault(u => u.Id == id);
            
            if( villa == null)
            {
                return NotFound();
            }

            return Ok(villa);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDTO> CreateVilla( [FromBody] VillaDTO villobj)
        {
            if( villobj == null)
            {
                return BadRequest(villobj);
            }
            if( villobj.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            villobj.Id = VillaStore.VillaList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
            
            VillaStore.VillaList.Add(villobj);

            return Ok(villobj);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var villa = VillaStore.VillaList.FirstOrDefault(u => u.Id == id);

            if (villa == null)
            {
                return NotFound();
            }

            VillaStore.VillaList.Remove(villa);

            return Ok($"Villa with ID {id} has been deleted.");
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateVilla(int id, [FromBody] VillaDTO updatedVilla)
        {
            if (updatedVilla == null || id != updatedVilla.Id)
            {
                return BadRequest();
            }

            var existingVilla = VillaStore.VillaList.FirstOrDefault(u => u.Id == id);

            if (existingVilla == null)
            {
                return NotFound();
            }

            existingVilla.Name = updatedVilla.Name;
            existingVilla.Sqft = updatedVilla.Sqft;
            existingVilla.Occupancy = updatedVilla.Occupancy;

            return Ok(existingVilla);
        }


    }
}
