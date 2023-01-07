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
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=204.93.216.11;user=itesrcne_jacob;password=jacob1;database=itesrcne_teachnotify", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.3.29-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8");

            modelBuilder.Entity<Alumno>(entity =>
            {
                entity.HasKey(e => e.IdAlumnos)
                    .HasName("PRIMARY");

                entity.ToTable("alumnos");

                entity.Property(e => e.IdAlumnos)
                    .HasColumnType("int(11)")
                    .HasColumnName("idAlumnos");

                entity.Property(e => e.IdDocentes)
                    .HasColumnType("int(11)")
                    .HasColumnName("idDocentes");

                entity.Property(e => e.IdMensajes)
                    .HasColumnType("int(11)")
                    .HasColumnName("idMensajes");

                entity.Property(e => e.NombreAlumnos)
                    .HasMaxLength(45)
                    .HasColumnName("nombreAlumnos");
            });

            modelBuilder.Entity<Docente>(entity =>
            {
                entity.HasKey(e => e.IdDocentes)
                    .HasName("PRIMARY");

                entity.ToTable("docentes");

                entity.Property(e => e.IdDocentes)
                    .HasColumnType("int(11)")
                    .HasColumnName("idDocentes");

                entity.Property(e => e.IdAlumnos)
                    .HasColumnType("int(11)")
                    .HasColumnName("idAlumnos");

                entity.Property(e => e.IdMensajes)
                    .HasColumnType("int(11)")
                    .HasColumnName("idMensajes");

                entity.Property(e => e.NombreDocente)
                    .HasMaxLength(45)
                    .HasColumnName("nombreDocente");
            });

            modelBuilder.Entity<Mensaje>(entity =>
            {
                entity.HasKey(e => e.IdMensajes)
                    .HasName("PRIMARY");

                entity.ToTable("mensajes");

                entity.HasIndex(e => e.IdAlumnos, "fk_mensajes_alumnos_idx");

                entity.HasIndex(e => e.IdDocentes, "fk_mensajes_docentes_idx");

                entity.Property(e => e.IdMensajes)
                    .HasColumnType("int(11)")
                    .HasColumnName("idMensajes");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdAlumnos)
                    .HasColumnType("int(11)")
                    .HasColumnName("idAlumnos");

                entity.Property(e => e.IdDocentes)
                    .HasColumnType("int(11)")
                    .HasColumnName("idDocentes");

                entity.Property(e => e.Mensajes)
                    .HasMaxLength(200)
                    .HasColumnName("mensajes");

                entity.HasOne(d => d.IdAlumnosNavigation)
                    .WithMany(p => p.Mensajes)
                    .HasForeignKey(d => d.IdAlumnos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_mensajes_alumnos");

                entity.HasOne(d => d.IdDocentesNavigation)
                    .WithMany(p => p.Mensajes)
                    .HasForeignKey(d => d.IdDocentes)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_mensajes_docentes");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
