using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TeachNotifyApi.Modelos
{
    public partial class itesrcne_teachnotifyContext : DbContext
    {
        public itesrcne_teachnotifyContext()
        {
        }

        public itesrcne_teachnotifyContext(DbContextOptions<itesrcne_teachnotifyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alumno> Alumnos { get; set; } = null!;
        public virtual DbSet<Docente> Docentes { get; set; } = null!;
        public virtual DbSet<Mensaje> Mensajes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8");

            modelBuilder.Entity<Alumno>(entity =>
            {
                entity.HasKey(e => e.IdAlumno)
                    .HasName("PRIMARY");

                entity.ToTable("alumnos");

                entity.Property(e => e.IdAlumno)
                    .HasColumnType("int(11)")
                    .HasColumnName("idAlumno");

                entity.Property(e => e.NombreAlumno)
                    .HasMaxLength(45)
                    .HasColumnName("nombreAlumno");
            });

            modelBuilder.Entity<Docente>(entity =>
            {
                entity.HasKey(e => e.IdDocente)
                    .HasName("PRIMARY");

                entity.ToTable("docentes");

                entity.Property(e => e.IdDocente)
                    .HasColumnType("int(11)")
                    .HasColumnName("idDocente");

                entity.Property(e => e.NombreDocente)
                    .HasMaxLength(45)
                    .HasColumnName("nombreDocente");
            });

            modelBuilder.Entity<Mensaje>(entity =>
            {
                entity.HasKey(e => e.IdMensajes)
                    .HasName("PRIMARY");

                entity.ToTable("mensajes");

                entity.HasIndex(e => e.IdAlumno, "fk_mensajes_alumnos_idx");

                entity.HasIndex(e => e.IdDocente, "fk_mensajes_docentes_idx");

                entity.Property(e => e.IdMensajes)
                    .HasColumnType("int(11)")
                    .HasColumnName("idMensajes");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdAlumno)
                    .HasColumnType("int(11)")
                    .HasColumnName("idAlumno");

                entity.Property(e => e.IdDocente)
                    .HasColumnType("int(11)")
                    .HasColumnName("idDocente");

                entity.Property(e => e.Mensajes)
                    .HasMaxLength(200)
                    .HasColumnName("mensajes");

                entity.HasOne(d => d.IdAlumnoNavigation)
                    .WithMany(p => p.Mensajes)
                    .HasForeignKey(d => d.IdAlumno)
                    .HasConstraintName("fk_mensajes_alumnos");

                entity.HasOne(d => d.IdDocenteNavigation)
                    .WithMany(p => p.Mensajes)
                    .HasForeignKey(d => d.IdDocente)
                    .HasConstraintName("fk_mensajes_docentes");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
