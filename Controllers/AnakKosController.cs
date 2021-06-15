using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Kosku.Data.Entities;
using Kosku.Repositories;
using System.Threading.Tasks;

namespace Kosku.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AnakKosController : ControllerBase
    {

        private IAnakKosRepository _repository;

        public AnakKosController(IAnakKosRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<List<AnakKos>> getAllAnakKos() => await _repository.GetAll();

        [HttpPost]
        public async Task<ActionResult<AnakKos>> SaveAnakKos(AnakKos anakKos)
        {
            await _repository.Add(anakKos);

            return CreatedAtAction(nameof(SaveAnakKos), new { anakKos.id }, anakKos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AnakKos>> FindAnakKos(int id)
        {
            var data = await _repository.Find(id);
            if (data == null) return NotFound();
            return data;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AnakKos>> UpdateAnakKos(AnakKos anakKos, int id)
        {
            if (id != anakKos.id) return BadRequest();

            var updatedData = await _repository.Update(id, anakKos);
            if (updatedData == null) return NotFound();

            return updatedData;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AnakKos>> DeleteAnakKos(int id)
        {
            var data = await _repository.Delete(id);
            if (data == null) return NotFound();

            return data;
        }


    }
}