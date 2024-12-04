﻿// <auto-generated />
using CREAR_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FERREWEB.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241204023806_4ta Migracion")]
    partial class _4taMigracion
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FERREWEB.Data.Models.Categoria", b =>
                {
                    b.Property<int>("idCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idCategoria"));

                    b.Property<string>("NombreCategoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idCategoria");

                    b.ToTable("Categorias");

                    b.HasData(
                        new
                        {
                            idCategoria = 1,
                            NombreCategoria = "Martillos"
                        },
                        new
                        {
                            idCategoria = 2,
                            NombreCategoria = "Clavos"
                        },
                        new
                        {
                            idCategoria = 3,
                            NombreCategoria = "Tubos"
                        });
                });

            modelBuilder.Entity("FERREWEB.Data.Models.Marca", b =>
                {
                    b.Property<int>("idMarca")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idMarca"));

                    b.Property<string>("NombreMarca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idMarca");

                    b.ToTable("Marcas");

                    b.HasData(
                        new
                        {
                            idMarca = 1,
                            NombreMarca = "DeWALT"
                        },
                        new
                        {
                            idMarca = 2,
                            NombreMarca = "TOPAC"
                        },
                        new
                        {
                            idMarca = 3,
                            NombreMarca = "Truper"
                        });
                });

            modelBuilder.Entity("FERREWEB.Data.Models.Producto", b =>
                {
                    b.Property<int>("idProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idProducto"));

                    b.Property<string>("Costo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreProducto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Stock")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idCategoria")
                        .HasColumnType("int");

                    b.Property<int>("idMarca")
                        .HasColumnType("int");

                    b.HasKey("idProducto");

                    b.HasIndex("idCategoria");

                    b.HasIndex("idMarca");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("FERREWEB.Data.Models.Producto", b =>
                {
                    b.HasOne("FERREWEB.Data.Models.Categoria", "CategoriaRef")
                        .WithMany("ProductoRef")
                        .HasForeignKey("idCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FERREWEB.Data.Models.Marca", "MarcaRef")
                        .WithMany("ProductoRef")
                        .HasForeignKey("idMarca")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoriaRef");

                    b.Navigation("MarcaRef");
                });

            modelBuilder.Entity("FERREWEB.Data.Models.Categoria", b =>
                {
                    b.Navigation("ProductoRef");
                });

            modelBuilder.Entity("FERREWEB.Data.Models.Marca", b =>
                {
                    b.Navigation("ProductoRef");
                });
#pragma warning restore 612, 618
        }
    }
}
