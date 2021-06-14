using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Kosku.Model;
using Kosku.Services;

namespace Kosku.Controllers
{

  [ApiController]
  [Route("[controller]")]
  public class AnakKosController : ControllerBase
  {
    [HttpGet]
    public List<AnakKos> getAll()
    {
      return AnakKosService.getAllAnakKos();
    }

    [HttpPost]
    public IActionResult saveAnakKos(AnakKos anakKos)
    {
      var result = AnakKosService.addAnakKos(anakKos);

      return CreatedAtAction(nameof(saveAnakKos), new { id = result.id }, anakKos);
    }

    [HttpGet("{id}")]
    public AnakKos findAnakKos(int id)
    {
      return AnakKosService.findAnakKos(id);
    }

    [HttpPut("{id}")]
    public IActionResult updateAnakKos(AnakKos anakKos, int id)
    {
      AnakKosService.updateAnakKos(anakKos, id);
      return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult deleteAnakKos(int id)
    {
      AnakKosService.deleteAnakKos(id);
      return NoContent();
    }


  }
}