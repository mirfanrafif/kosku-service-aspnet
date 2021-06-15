using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kosku.Data.Entities;

namespace Kosku.Repositories
{
    public interface IAnakKosRepository
    {
        public List<AnakKos> GetAll();

        public void Add(AnakKos anakKos);

        public AnakKos Find(int id);

        public AnakKos Update(int id, AnakKos anakKos);

        public AnakKos Delete(int id);

    }
}
