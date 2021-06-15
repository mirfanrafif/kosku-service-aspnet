using Microsoft.EntityFrameworkCore;
using Kosku.Data.Entities;

namespace Kosku.Data.Model
{
    public class AnakKosContext : DbContext
    {
        public AnakKosContext(DbContextOptions<AnakKosContext> options) : base(options) { }

        public DbSet<AnakKos> AnakKos { get; set; }
    }
}