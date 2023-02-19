using FirstWebApi.Entity;
using Microsoft.EntityFrameworkCore;

namespace FirstWebApi
{
    public class ApplicatonDbContext : DbContext
    {
        public ApplicatonDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Autor> Autores { get; set;}
        public DbSet<Libro> Libros { get; set;}
    }
}
