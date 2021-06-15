using System.Collections.Generic;
using Kosku.Model;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Linq;

namespace Kosku.Services
{
    public class AnakKosService: IAnakKosService
    {

        private readonly AnakKosContext _context;
        private readonly IConfiguration _configuration;

        List<AnakKos> _ListAnakKos { get; }

        int currentId = 4;

        public AnakKosService(AnakKosContext context, IConfiguration configuration)
        {
            _ListAnakKos = new List<AnakKos> {
                        new AnakKos {id = 1, nama = "Irfan Rafif", asal = "Malang", nohp = "0238723482947"},
                        new AnakKos {id = 2, nama = "Irfan Rafif", asal = "Malang", nohp = "0238723482947"},
                        new AnakKos {id = 3, nama = "Irfan Rafif", asal = "Malang", nohp = "0238723482947"},
                        new AnakKos {id = 4, nama = "Irfan Rafif", asal = "Malang", nohp = "0238723482947"},
                    };
            _context = context;
            _configuration = configuration;
        }

        public List<AnakKos> GetAllAnakKos()
        {
            List<AnakKos> listAnakKos = new List<AnakKos>();

            string query = @"select * from anakkos";
            DataTable table = new DataTable();
            string con = _configuration.GetConnectionString("KoskuConnections");
            SqlDataReader reader;
            using(SqlConnection sqlCon= new SqlConnection(con))
            {
                sqlCon.Open();
                using(SqlCommand command = new SqlCommand(query, sqlCon))
                {
                    reader = command.ExecuteReader();
                    table.Load(reader);
                    foreach(DataRow row in table.Rows)
                    {
                        AnakKos anakKos = new AnakKos() {
                            id = (int)row["id"],
                            nama = row["nama"].ToString(),
                            asal = row["asal"].ToString(),
                            nohp = row["nohp"].ToString()
                        };
                        listAnakKos.Add(anakKos);
                    }
                    reader.Close();
                    sqlCon.Close();
                }
            }
            return listAnakKos;
        }

        public AnakKos AddAnakKos(AnakKos anakKos)
        {
            currentId++;
            var data = anakKos;
            data.id = currentId;

            _ListAnakKos.Add(anakKos);

            return data;
        }

        public AnakKos FindAnakKos(int id)
        {
            return _ListAnakKos.Find(a => a.id == id);
        }

        public void UpdateAnakKos(AnakKos anakKos, int id)
        {
            var index = _ListAnakKos.FindIndex(a => a.id == id);

            if (index == -1) return;

            _ListAnakKos[index] = anakKos;
        }

        public void DeleteAnakKos(int id)
        {
            var anakKos = FindAnakKos(id);

            if (anakKos == null) return;
            _ListAnakKos.Remove(anakKos);
        }
    }
}