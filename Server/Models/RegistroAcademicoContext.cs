using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AppNetS22021.Server.Models
{
    public partial class RegistroAcademicoContext : DbContext
    {
        public RegistroAcademicoContext()
        {
        }

        public RegistroAcademicoContext(DbContextOptions<RegistroAcademicoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Seccion> Seccion { get; set; }
        public virtual DbSet<Facultad> Facultad { get; set; }
        public virtual DbSet<Estudiantes> Estudiantes { get; set; }
        public virtual DbSet<DireccionEstudiante> DireccionEstudiantes { get; set; }
        public virtual DbSet<Maestros> Maestros { get; set; }
        public virtual DbSet<Grado> Grado { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("server=LAPTOP-74AJBVCC\\SQLEXPRESS;database=RegistroAcademico;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            modelBuilder.Entity<Seccion>(entity =>
            {
                entity.HasKey(e => e.IdSeccion);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
