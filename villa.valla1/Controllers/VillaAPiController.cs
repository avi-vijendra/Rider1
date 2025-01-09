using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using villa.valla1.Data;
using villa.valla1.Models;
using villa.valla1.Models.DTOs;

namespace villa.valla1.Controllers;
[Route("api/[controller]")]
[ApiController]
public class VillaAPiController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<VillaDTO>> GetVillas()
    {
        return Ok(VillaStore.vilalList);

    }
    [HttpGet("{Id:int}")]   
   // [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VillaDTO))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<VillaDTO> GetVilla(int Id)
    {
        if (Id == 0)
        {
            return BadRequest();
        }
        var villa = VillaStore.vilalList.FirstOrDefault(v => v.Id == Id);
        if (villa == null)
        {
            return NotFound();
        }
        return Ok(villa);

    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<VillaDTO> CreateVilla([FromBody]VillaDTO villa)
    {
        if (villa == null)
        {
            return BadRequest(villa);
        }

        if (villa.Id > 0)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
        villa.Id = VillaStore.vilalList.OrderByDescending(u=>u.Id).FirstOrDefault(v => v.Id == villa.Id).Id+1;
        VillaStore.vilalList.Add(villa);
        return Ok(villa);
    }
}