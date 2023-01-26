using Microsoft.EntityFrameworkCore;
using WebApiLibros.Models;

namespace WebApiLibros.Data
{
    public class DbLibrosContext : DbContext
    {
        public DbLibrosContext(DbContextOptions<DbLibrosContext> options) : base(options) { }

        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }
    }
}
