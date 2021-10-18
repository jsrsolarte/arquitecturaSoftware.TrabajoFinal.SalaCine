﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PracticaFinal.SalasCine.Infrastructure;

namespace PracticaFinal.SalasCine.Infrastructure.Migrations
{
    [DbContext(typeof(PersistenceContext))]
    [Migration("20211017001929_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("cinema")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PeliculaSalaDeCine", b =>
                {
                    b.Property<Guid>("PeliculasId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SalasCineId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PeliculasId", "SalasCineId");

                    b.HasIndex("SalasCineId");

                    b.ToTable("PeliculaSalaDeCine");
                });

            modelBuilder.Entity("PracticaFinal.SalasCine.Domain.Entities.Actor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Foto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PeliculaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PeliculaId");

                    b.ToTable("Actor");
                });

            modelBuilder.Entity("PracticaFinal.SalasCine.Domain.Entities.Genero", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PeliculaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PeliculaId");

                    b.ToTable("Genero");
                });

            modelBuilder.Entity("PracticaFinal.SalasCine.Domain.Entities.Pelicula", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaEstreno")
                        .HasColumnType("datetime2");

                    b.Property<string>("Poster")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Pelicula");
                });

            modelBuilder.Entity("PracticaFinal.SalasCine.Domain.Entities.SalaDeCine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("SalaDeCine");
                });

            modelBuilder.Entity("PeliculaSalaDeCine", b =>
                {
                    b.HasOne("PracticaFinal.SalasCine.Domain.Entities.Pelicula", null)
                        .WithMany()
                        .HasForeignKey("PeliculasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PracticaFinal.SalasCine.Domain.Entities.SalaDeCine", null)
                        .WithMany()
                        .HasForeignKey("SalasCineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PracticaFinal.SalasCine.Domain.Entities.Actor", b =>
                {
                    b.HasOne("PracticaFinal.SalasCine.Domain.Entities.Pelicula", null)
                        .WithMany("Actores")
                        .HasForeignKey("PeliculaId");
                });

            modelBuilder.Entity("PracticaFinal.SalasCine.Domain.Entities.Genero", b =>
                {
                    b.HasOne("PracticaFinal.SalasCine.Domain.Entities.Pelicula", null)
                        .WithMany("Generos")
                        .HasForeignKey("PeliculaId");
                });

            modelBuilder.Entity("PracticaFinal.SalasCine.Domain.Entities.Pelicula", b =>
                {
                    b.Navigation("Actores");

                    b.Navigation("Generos");
                });
#pragma warning restore 612, 618
        }
    }
}