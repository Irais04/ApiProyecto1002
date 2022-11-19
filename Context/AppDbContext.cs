using ApiProyecto1002.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiProyecto1002.Context


{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }
        public DbSet<usuarios> usuarios { get; set; }
    }
}
