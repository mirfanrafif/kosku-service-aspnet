using System.Text.Json.Serialization;

namespace Kosku.Data.Entities
{
    public class User
    {
        public int id { get; set; }
        public string nama { get; set; }

        public string username { get; set; }
        [JsonIgnore]
        public string password { get; set; }
    }
}