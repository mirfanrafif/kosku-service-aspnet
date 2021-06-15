using Microsoft.EntityFrameworkCore;

namespace Kosku.Model
{
    public class AnakKosContext: DbContext
    {
        public AnakKosContext(DbContextOptions<AnakKosContext> options): base(options) { }

        public DbSet<AnakKos> AnakKos { get; set; }
    }
}