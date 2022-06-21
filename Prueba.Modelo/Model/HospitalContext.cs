using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Prueba.Modelo.Model
{
    public partial class HospitalContext : DbContext
    {
        public HospitalContext()
        {
        }

        public HospitalContext(DbContextOptions<HospitalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Citum> Cita { get; set; }
        public virtual DbSet<Diagnostico> Diagnosticos { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Paciente> Pacientes { get; set; }
        public virtual DbSet<TipoDotor> TipoDotors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost; Database=Hospital; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Citum>(entity =>
            {
                entity.HasKey(e => e.CitaId)
                    .HasName("PK__Cita__F0E2D9F222C29879");

                entity.Property(e => e.CitaId).HasColumnName("CitaID");

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.FechaHora).HasColumnType("datetime");

                entity.Property(e => e.PacienteId).HasColumnName("PacienteID");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__Cita__FechaHora__2B3F6F97");

                entity.HasOne(d => d.Paciente)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.PacienteId)
                    .HasConstraintName("FK__Cita__PacienteID__2C3393D0");
            });

            modelBuilder.Entity<Diagnostico>(entity =>
            {
                entity.ToTable("Diagnostico");

                entity.Property(e => e.DiagnosticoId).HasColumnName("DiagnosticoID");

                entity.Property(e => e.CitaId).HasColumnName("CitaID");

                entity.Property(e => e.Resumen)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cita)
                    .WithMany(p => p.Diagnosticos)
                    .HasForeignKey(d => d.CitaId)
                    .HasConstraintName("FK__Diagnosti__Resum__2F10007B");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.ToTable("Doctor");

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TipoId).HasColumnName("TipoID");

                entity.HasOne(d => d.Tipo)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.TipoId)
                    .HasConstraintName("FK__Doctor__TipoID__286302EC");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.ToTable("Paciente");

                entity.Property(e => e.PacienteId).HasColumnName("PacienteID");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoDotor>(entity =>
            {
                entity.HasKey(e => e.TipoId)
                    .HasName("PK__TipoDoto__97099E9715BCE1E7");

                entity.ToTable("TipoDotor");

                entity.Property(e => e.TipoId).HasColumnName("TipoID");

                entity.Property(e => e.TipoDescripcion)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.TipoNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
