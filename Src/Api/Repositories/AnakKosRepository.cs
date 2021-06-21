using Kosku.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kosku.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Kosku.Repositories
{

    public interface IAnakKosRepository
    {
        public Task<List<AnakKos>> GetAll();

        public Task<int> Add(AnakKos anakKos);

        public Task<AnakKos> Find(int id);

        public Task<AnakKos> Update(int id, AnakKos anakKos);

        public Task<AnakKos> Delete(int id);

    }
    public class AnakKosRepository : IAnakKosRepository
    {
        private AnakKosContext _context;
        public AnakKosRepository(AnakKosContext context)
        {
            _context = context;
        }

        public async Task<int> Add(AnakKos anakKos)
        {
            _context.AnakKos.Add(anakKos);
            return await _context.SaveChangesAsync();
        }

        public async Task<AnakKos> Delete(int id)
        {
            AnakKos anakKos = await Find(id);
            if (anakKos == null) return null;

            _context.AnakKos.Remove(anakKos);
            _context.SaveChanges();
            return anakKos;
        }

        public async Task<AnakKos> Find(int id)
        {
            return await _context.AnakKos.FindAsync(id);
        }

        public async Task<List<AnakKos>> GetAll()
        {
            return await _context.AnakKos.ToListAsync();
        }

        public async Task<AnakKos> Update(int id, AnakKos anakKos)
        {
            if (!await AnakKosExist(id)) return null;

            _context.Entry(anakKos).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return await Find(id);
        }

        private async Task<bool> AnakKosExist(int id)
        {
            return await _context.AnakKos.AnyAsync(e => e.id == id);
        }
    }
}
