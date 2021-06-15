using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Kosku.Model;
using Kosku.Services;
using Microsoft.Extensions.Configuration;

namespace Kosku.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AnakKosController : ControllerBase
    {


        private IAnakKosService _service;
        public AnakKosController(IAnakKosService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<AnakKos> GetAll() => _service.GetAllAnakKos();

        [HttpPost]
        public IActionResult saveAnakKos(AnakKos anakKos)
        {
            var result = _service.AddAnakKos(anakKos);

            return CreatedAtAction(nameof(saveAnakKos), new { id = result.id }, anakKos);
        }

        [HttpGet("{id}")]
        public AnakKos findAnakKos(int id)
        {
            return _service.FindAnakKos(id);
        }

        [HttpPut("{id}")]
        public IActionResult updateAnakKos(AnakKos anakKos, int id)
        {
            _service.UpdateAnakKos(anakKos, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult deleteAnakKos(int id)
        {
            _service.DeleteAnakKos(id);
            return NoContent();
        }


    }
}