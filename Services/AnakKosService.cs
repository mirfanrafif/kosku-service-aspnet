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
                new AnakKos {id = 1, nama = "Irfan Rafif", asal = "Malang", nohp = "0238723482947"},
                new AnakKos {id = 2, nama = "Irfan Rafif", asal = "Malang", nohp = "0238723482947"},
                new AnakKos {id = 3, nama = "Irfan Rafif", asal = "Malang", nohp = "0238723482947"},
                new AnakKos {id = 4, nama = "Irfan Rafif", asal = "Malang", nohp = "0238723482947"},
            };
    }

    public static List<AnakKos> getAllAnakKos() => ListAnakKos;

    public static AnakKos addAnakKos(AnakKos anakKos)
    {
      id++;
      var data = anakKos;
      data.id = id;

      ListAnakKos.Add(anakKos);

      return data;
    }

    public static AnakKos findAnakKos(int id)
    {
      return ListAnakKos.Find(a => a.id == id);
    }

    public static void updateAnakKos(AnakKos anakKos, int id)
    {
      var index = ListAnakKos.FindIndex(a => a.id == id);

      if (index == -1) return;

      ListAnakKos[index] = anakKos;
    }

    public static void deleteAnakKos(int id)
    {
      var anakKos = findAnakKos(id);

      if (anakKos == null) return;
      ListAnakKos.Remove(anakKos);
    }
  }
}