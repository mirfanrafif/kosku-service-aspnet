using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kosku.Model
{
    public interface IAnakKosService
    {
        public List<AnakKos> GetAllAnakKos();
        public AnakKos AddAnakKos(AnakKos anakKos);

        public AnakKos FindAnakKos(int id);

        public void UpdateAnakKos(AnakKos anakKos, int id);

        public void DeleteAnakKos(int id);

    }
}
