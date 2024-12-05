using FERREWEB.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FERREWEB.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Marca> Marcas { get; set; }        
        public DbSet<Carro> Carros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

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

            modelBuilder.Entity<Carro>(tb =>
            {
                tb.HasKey(col => col.idCarro);

                tb.Property(col => col.idCarro)
                  .UseIdentityColumn()
                  .ValueGeneratedOnAdd();

                // Relación uno-a-uno: Carro -> Usuario
                tb.HasOne(col => col.UsuarioRef)
                  .WithOne(p => p.CarroRef)
                  .HasForeignKey<Carro>(col => col.idUsuario); // Clave foránea en Carro

                // Relación uno-a-uno: Carro -> Producto
                tb.HasOne(col => col.ProductoRef)
                  .WithMany()
                  .HasForeignKey(col => col.idProducto);
            });

            modelBuilder.Entity<Usuario>(tb =>
            {
                tb.HasKey(col => col.idUsuario);

                tb.Property(col => col.idUsuario).UseIdentityColumn().ValueGeneratedOnAdd();

                tb.HasOne(col => col.CarroRef).WithOne(p => p.UsuarioRef)
                .HasForeignKey<Carro>(col => col.idUsuario);
            });
        }
    }
}
