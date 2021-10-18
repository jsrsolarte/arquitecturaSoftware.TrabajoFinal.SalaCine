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
    [Migration("20211018042544_AddFunciones")]
    partial class AddFunciones
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("cinema")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ActorPelicula", b =>
                {
                    b.Property<Guid>("ActoresId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PeliculasId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ActoresId", "PeliculasId");

                    b.HasIndex("PeliculasId");

                    b.ToTable("ActorPelicula");
                });

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

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Actor");
                });

            modelBuilder.Entity("PracticaFinal.SalasCine.Domain.Entities.Funcion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("PeliculaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SalaCineId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PeliculaId");

                    b.HasIndex("SalaCineId");

                    b.ToTable("Funcion");
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

            modelBuilder.Entity("PracticaFinal.SalasCine.Domain.Entities.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Calificacion")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PeliculaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PeliculaId");

                    b.ToTable("Review");
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

            modelBuilder.Entity("ActorPelicula", b =>
                {
                    b.HasOne("PracticaFinal.SalasCine.Domain.Entities.Actor", null)
                        .WithMany()
                        .HasForeignKey("ActoresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PracticaFinal.SalasCine.Domain.Entities.Pelicula", null)
                        .WithMany()
                        .HasForeignKey("PeliculasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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

            modelBuilder.Entity("PracticaFinal.SalasCine.Domain.Entities.Funcion", b =>
                {
                    b.HasOne("PracticaFinal.SalasCine.Domain.Entities.Pelicula", "Pelicula")
                        .WithMany()
                        .HasForeignKey("PeliculaId");

                    b.HasOne("PracticaFinal.SalasCine.Domain.Entities.SalaDeCine", "SalaCine")
                        .WithMany()
                        .HasForeignKey("SalaCineId");

                    b.Navigation("Pelicula");

                    b.Navigation("SalaCine");
                });

            modelBuilder.Entity("PracticaFinal.SalasCine.Domain.Entities.Genero", b =>
                {
                    b.HasOne("PracticaFinal.SalasCine.Domain.Entities.Pelicula", null)
                        .WithMany("Generos")
                        .HasForeignKey("PeliculaId");
                });

            modelBuilder.Entity("PracticaFinal.SalasCine.Domain.Entities.Review", b =>
                {
                    b.HasOne("PracticaFinal.SalasCine.Domain.Entities.Pelicula", "Pelicula")
                        .WithMany()
                        .HasForeignKey("PeliculaId");

                    b.Navigation("Pelicula");
                });

            modelBuilder.Entity("PracticaFinal.SalasCine.Domain.Entities.Pelicula", b =>
                {
                    b.Navigation("Generos");
                });
#pragma warning restore 612, 618
        }
    }
}
