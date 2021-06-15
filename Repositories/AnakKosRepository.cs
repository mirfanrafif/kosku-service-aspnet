using Kosku.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kosku.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Kosku.Repositories
{
    public class AnakKosRepository : IAnakKosRepository
    {
        private AnakKosContext _context;
        public AnakKosRepository( AnakKosContext context )
        {
            _context = context;
        }

        public void Add(AnakKos anakKos)
        {
            _context.AnakKos.Add(anakKos);
            _context.SaveChanges();
        }

        public AnakKos Delete(int id)
        {
            AnakKos anakKos = Find(id);
            if (anakKos == null) return null;

            _context.AnakKos.Remove(anakKos);
            _context.SaveChanges();
            return anakKos;
        }

        public AnakKos Find(int id)
        {   
            return _context.AnakKos.Find(id);
        }

        public List<AnakKos> GetAll()
        {
            return _context.AnakKos.ToList();
        }

        public AnakKos Update(int id, AnakKos anakKos)
        {
            if (!AnakKosExist(id)) return null;

            _context.Entry(anakKos).State = EntityState.Modified;
            _context.SaveChanges();
            return Find(id);
        }

        private bool AnakKosExist(int id)
        {
            return _context.AnakKos.Any(e => e.id == id);
        }
    }
}
