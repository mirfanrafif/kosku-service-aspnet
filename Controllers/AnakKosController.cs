using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Kosku.Data.Model;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Kosku.Data.Entities;
using Kosku.Repositories;

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
        public List<AnakKos> getAllAnakKos() => _repository.GetAll();

        [HttpPost]
        public ActionResult<AnakKos> SaveAnakKos(AnakKos anakKos)
        {
            _repository.Add(anakKos);

            return CreatedAtAction(nameof(SaveAnakKos), new { anakKos.id }, anakKos);
        }

        [HttpGet("{id}")]
        public ActionResult<AnakKos> FindAnakKos(int id)
        {
            var data = _repository.Find(id);
            if (data == null) return NotFound();
            return data;
        }

        [HttpPut("{id}")]
        public ActionResult<AnakKos> UpdateAnakKos(AnakKos anakKos, int id)
        {
            if (id != anakKos.id) return BadRequest();

            var updatedData = _repository.Update(id, anakKos);
            if (updatedData == null) return NotFound();

            return updatedData;
        }

        [HttpDelete("{id}")]
        public ActionResult<AnakKos> DeleteAnakKos(int id)
        {
            var data = _repository.Delete(id);
            if (data == null) return NotFound();

            return data;
        }


    }
}