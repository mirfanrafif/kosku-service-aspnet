using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kosku.Data.Entities
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }

        public UserResponse(User user, string token) {
            Id = user.id;
            Nama = user.nama;
            Username = user.username;
            Token = token;
        }
    }
}
