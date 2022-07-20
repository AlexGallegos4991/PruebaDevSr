using Microsoft.EntityFrameworkCore;
using PracticaBrive.Models;

namespace PracticaBrive.Datos
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<Sucursal> Sucursal { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Compra> Compra { get; set; }
    }
}
