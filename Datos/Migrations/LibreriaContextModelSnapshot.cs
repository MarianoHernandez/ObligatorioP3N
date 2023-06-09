﻿// <auto-generated />
using System;
using Datos.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Datos.Migrations
{
    [DbContext(typeof(LibreriaContext))]
    partial class LibreriaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Negocio.Entidades.Cabania", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CantidadPersonas")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Habilitada")
                        .HasColumnType("bit");

                    b.Property<bool>("Jacuzzi")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("TipoCabaniaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.HasIndex("TipoCabaniaId");

                    b.ToTable("Cabania");
                });

            modelBuilder.Entity("Negocio.Entidades.Mantenimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CabaniaId")
                        .HasColumnType("int");

                    b.Property<decimal>("costo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("trabajador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CabaniaId");

                    b.ToTable("Mantenimiento");
                });

            modelBuilder.Entity("Negocio.Entidades.TipoCabania", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Costo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.ToTable("TipoCabania");
                });

            modelBuilder.Entity("Negocio.Entidades.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("email")
                        .IsUnique();

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Negocio.EntidadesAuxiliares.Parametro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ValorMaximo")
                        .HasColumnType("int");

                    b.Property<int>("ValorMinimo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.ToTable("Parametro");
                });

            modelBuilder.Entity("Negocio.Entidades.Cabania", b =>
                {
                    b.HasOne("Negocio.Entidades.TipoCabania", "TipoCabania")
                        .WithMany()
                        .HasForeignKey("TipoCabaniaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoCabania");
                });

            modelBuilder.Entity("Negocio.Entidades.Mantenimiento", b =>
                {
                    b.HasOne("Negocio.Entidades.Cabania", "cabania")
                        .WithMany()
                        .HasForeignKey("CabaniaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cabania");
                });
#pragma warning restore 612, 618
        }
    }
}
