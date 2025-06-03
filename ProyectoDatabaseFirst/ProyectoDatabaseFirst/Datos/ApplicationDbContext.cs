using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProyectoDatabaseFirst.Models;

namespace ProyectoDatabaseFirst.Datos;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ciudad> Ciudads { get; set; }

    public virtual DbSet<Continente> Continentes { get; set; }

    public virtual DbSet<Pai> Pais { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Usuario2> Usuario2s { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=(local);Database=BasePruebaReverse;User ID=sa;Password=Fernan_gosth;Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Modern_Spanish_CI_AS");

        modelBuilder.Entity<Ciudad>(entity =>
        {
            entity.HasKey(e => e.IdCiudad);

            entity.ToTable("Ciudad");

            entity.Property(e => e.IdCiudad).ValueGeneratedNever();
            entity.Property(e => e.Altura).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Latitud).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.Longitud).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.NombreCiudad)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Pais).WithMany(p => p.Ciudads)
                .HasForeignKey(d => d.PaisId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ciudad_Pais");
        });

        modelBuilder.Entity<Continente>(entity =>
        {
            entity.HasKey(e => e.IdContinente);

            entity.ToTable("Continente");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Pai>(entity =>
        {
            entity.HasKey(e => e.IdPais);

            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombrePais)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Continente).WithMany(p => p.Pais)
                .HasForeignKey(d => d.ContinenteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pais_Continente");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario2>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.ToTable("Usuario2");

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Telefono)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
