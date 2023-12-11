﻿// <auto-generated />
using System;
using ComunidadeLivrosAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ComunidadeLivros.DataAccess.Migrations
{
    [DbContext(typeof(LivroContext))]
    [Migration("20231204150935_AdicionaTituloAResenha")]
    partial class AdicionaTituloAResenha
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ComunidadeLivros.Core.Entities.Autor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("GeneroId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("GeneroId");

                    b.ToTable("Autores");
                });

            modelBuilder.Entity("ComunidadeLivros.Core.Entities.Genero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.HasKey("Id");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("ComunidadeLivros.Core.Entities.Livro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AutorId")
                        .HasColumnType("int");

                    b.Property<int>("GeneroId")
                        .HasColumnType("int");

                    b.Property<int>("QntPag")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(90)
                        .HasColumnType("varchar(90)");

                    b.HasKey("Id");

                    b.HasIndex("AutorId");

                    b.HasIndex("GeneroId");

                    b.ToTable("Livros");
                });

            modelBuilder.Entity("ComunidadeLivros.Core.Entities.Resenha", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("LivroId")
                        .HasColumnType("int");

                    b.Property<string>("TextoResenha")
                        .IsRequired()
                        .HasMaxLength(3000)
                        .HasColumnType("varchar(3000)");

                    b.Property<string>("TituloResenha")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.HasKey("Id");

                    b.HasIndex("LivroId");

                    b.ToTable("Resenhas");
                });

            modelBuilder.Entity("ComunidadeLivros.Core.Entities.Autor", b =>
                {
                    b.HasOne("ComunidadeLivros.Core.Entities.Genero", "GeneroAutor")
                        .WithMany()
                        .HasForeignKey("GeneroId");

                    b.Navigation("GeneroAutor");
                });

            modelBuilder.Entity("ComunidadeLivros.Core.Entities.Livro", b =>
                {
                    b.HasOne("ComunidadeLivros.Core.Entities.Autor", "Autor")
                        .WithMany()
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComunidadeLivros.Core.Entities.Genero", "Genero")
                        .WithMany()
                        .HasForeignKey("GeneroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autor");

                    b.Navigation("Genero");
                });

            modelBuilder.Entity("ComunidadeLivros.Core.Entities.Resenha", b =>
                {
                    b.HasOne("ComunidadeLivros.Core.Entities.Livro", "Livro")
                        .WithMany("Resenhas")
                        .HasForeignKey("LivroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Livro");
                });

            modelBuilder.Entity("ComunidadeLivros.Core.Entities.Livro", b =>
                {
                    b.Navigation("Resenhas");
                });
#pragma warning restore 612, 618
        }
    }
}
