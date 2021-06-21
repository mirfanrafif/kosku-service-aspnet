using Microsoft.EntityFrameworkCore;
using Kosku.Data.Entities;

namespace Kosku.Data.Model
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
    }
}