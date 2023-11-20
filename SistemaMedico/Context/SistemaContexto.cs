using SistemaMedico.Models;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;
using SistemaMedico.Controllers;


namespace SistemaMedico.Context
{
    public class SistemaContexto : DbContext
    {
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Expediente> expedientes { get; set; }
        public DbSet<Consulta> consultas { get; set; }
        public DbSet<Historial> historiales { get; set; }
        public DbSet<Paciente> pacientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server = localhost; database = SistemaMedico; user=root;password = Pasword123456");
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(a => a.NombreUsuario);
                entity.Property(a => a.NombreCompleto);
                entity.Property(a => a.FechaNacimiento);
                entity.Property(a => a.Contrasena);
                entity.Property(a => a.CorreoElectronico);
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Nombre);
                entity.Property(a => a.Apellidos);
                entity.Property(a => a.FechaNacimiento);
                entity.Property(a => a.Genero);
                entity.Property(a => a.Direccion);
                entity.Property(a => a.NSS);
            });

            modelBuilder.Entity<Historial>(entity => 
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.MedicamentoActual);
                entity.Property(a => a.MedicamentoAnterior);
                entity.Property(a => a.CondicionesMedicasCronicas);
                entity.Property(a => a.Alergias);
                entity.Property(a => a.EnfermedadesPasadas);
            });

            modelBuilder.Entity<Expediente>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.IdPaciente);
                entity.Property(a => a.FechaCreacion);
                entity.Property(a => a.UltimaActualizacion);
                entity.Property(a => a.AntecedentesMedicosFam);
                entity.Property(a => a.HistorialVacunacion);
                entity.Property(a => a.ConsumoAlcohol);
                entity.Property(a => a.Fumador);
                entity.Property(a => a.ContactoEmergencia);
                entity.Property(a => a.FotosRadiografias);
            });

            modelBuilder.Entity<Consulta>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.IdPaciente);
                entity.Property(a => a.Sintomas);
                entity.Property(a => a.FechaCreacion);
                entity.Property(a => a.Diagnostico);
                entity.Property(a => a.Tratamiento);
            });
        }
    }
}
