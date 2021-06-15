using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Kosku.Model;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Kosku.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AnakKosController : ControllerBase
    {

        private AnakKosContext _context;

        public AnakKosController(AnakKosContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IQueryable<AnakKos> getAllAnakKos() {
            return _context.AnakKos; 
        }


        [HttpPost]
        public async Task<ActionResult<AnakKos>> SaveAnakKos(AnakKos anakKos)
        {
            _context.AnakKos.Add(anakKos);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(SaveAnakKos), new { anakKos.id }, anakKos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AnakKos>> FindAnakKos(int id)
        {
            var data = await _context.AnakKos.FindAsync(id);
            if (data == null) return NotFound();
            return data;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AnakKos>> UpdateAnakKos(AnakKos anakKos, int id)
        {
            if (id != anakKos.id)
            {
                return BadRequest();
            }

            _context.Entry(anakKos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                if(!AnakKosExist(id)) {
                    return NotFound();
                }else
                {
                    throw;
                }
            }

            return await _context.AnakKos.FindAsync(id);
        }

        private bool AnakKosExist(int id)
        {
            return _context.AnakKos.Any(e => e.id == id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AnakKos>> DeleteAnakKos(int id)
        {
            var data = await _context.AnakKos.FindAsync(id);
            if (data == null) return NotFound();

            _context.AnakKos.Remove(data);
            await _context.SaveChangesAsync();

            return data;
        }


    }
}