using ApiRestExamen.MyDb.Tablas;
using Microsoft.EntityFrameworkCore;

namespace ApiRestExamen.MyDb.Contexts
{
    public class MyDbContext: DbContext
    {
        // DbContextOptions < EF_DataContext > options ) : base ( options 
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Marca> Marcas { get; set; }


    }
}
