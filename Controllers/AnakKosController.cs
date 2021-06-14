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
            AnakKosService.addAnakKos(anakKos);

            return CreatedAtAction(nameof(saveAnakKos), new { id = anakKos._id }, anakKos);
        }

        [HttpGet("{id}")]
        public AnakKos findAnakKos(string id)
        {
            return AnakKosService.findAnakKos(id);
        }

        [HttpPut("{id}")]
        public IActionResult updateAnakKos(AnakKos anakKos, string id)
        {
            AnakKosService.updateAnakKos(anakKos, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult deleteAnakKos(string id)
        {
            AnakKosService.deleteAnakKos(id);
            return NoContent();
        }


    }
}