using FERREWEB.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CREAR_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Marca> Marcas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Marca>(tb => {
                tb.HasKey(col => col.idMarca);
                tb.Property(col => col.idMarca).UseIdentityColumn().ValueGeneratedOnAdd();
                tb.HasData(
                    new Marca { idMarca = 1, NombreMarca = "DeWALT" },
                    new Marca { idMarca = 2, NombreMarca = "TOPAC" },
                    new Marca { idMarca = 3, NombreMarca = "Truper" }
                    );
            });

            modelBuilder.Entity<Categoria>(tb => {
                tb.HasKey(col => col.idCategoria);
                tb.Property(col => col.idCategoria).UseIdentityColumn().ValueGeneratedOnAdd();
                tb.HasData(
                    new Categoria { idCategoria = 1, NombreCategoria = "Martillos" },
                    new Categoria { idCategoria = 2, NombreCategoria = "Clavos" },
                    new Categoria { idCategoria = 3, NombreCategoria = "Tubos" }
                    );
            });

            modelBuilder.Entity<Producto>(tb => {

                tb.HasKey(col => col.idProducto);

                tb.Property(col => col.idProducto).UseIdentityColumn().ValueGeneratedOnAdd();

                tb.HasOne(col => col.CategoriaRef).WithMany(p => p.ProductoRef)
                .HasForeignKey(col => col.idCategoria);

                tb.HasOne(col => col.MarcaRef).WithMany(m => m.ProductoRef)
                .HasForeignKey(col => col.idMarca);
            });
        }
    }
}
