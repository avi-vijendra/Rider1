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
}