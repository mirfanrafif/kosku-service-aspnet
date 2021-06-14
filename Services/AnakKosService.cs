using System.Collections.Generic;
using Kosku.Model;


namespace Kosku.Services
{
    public static class AnakKosService
    {
        static List<AnakKos> ListAnakKos { get; }

        static int id = 4;

        static AnakKosService()
        {
            ListAnakKos = new List<AnakKos> {
                new AnakKos {_id = "1", nama = "Irfan Rafif", asal = "Malang", nohp = "0238723482947"},
                new AnakKos {_id = "2", nama = "Irfan Rafif", asal = "Malang", nohp = "0238723482947"},
                new AnakKos {_id = "3", nama = "Irfan Rafif", asal = "Malang", nohp = "0238723482947"},
                new AnakKos {_id = "4", nama = "Irfan Rafif", asal = "Malang", nohp = "0238723482947"},
            };
        }

        public static List<AnakKos> getAllAnakKos() => ListAnakKos;

        public static AnakKos addAnakKos(AnakKos anakKos)
        {
            id++;
            var data = anakKos;
            data._id = id.ToString();

            ListAnakKos.Add(anakKos);

            return data;
        }

        public static AnakKos findAnakKos(string id)
        {
            return ListAnakKos.Find(a => a._id == id);
        }

        public static void updateAnakKos(AnakKos anakKos, string id)
        {
            var index = ListAnakKos.FindIndex(a => a._id == id);

            if (index == -1) return;

            ListAnakKos[index] = anakKos;
        }

        public static void deleteAnakKos(string id)
        {
            var anakKos = findAnakKos(id);

            if (anakKos == null) return;
            ListAnakKos.Remove(anakKos);
        }
    }
}