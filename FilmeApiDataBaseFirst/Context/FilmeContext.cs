﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using FilmeApiDataBaseFirst.Models;

#nullable disable

namespace FilmeApiDataBaseFirst.Context
{
    public partial class FilmeContext : DbContext
    {
        public FilmeContext()
        {
        }

        public FilmeContext(DbContextOptions<FilmeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Filme> Filmes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=FilmesDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Filme>(entity =>
            {
                entity.Property(e => e.Diretor)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Genero)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
