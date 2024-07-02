using GestorPacientes.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestorPacientes.Insfrastructure.Persistence.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ResultadoLab> ResultadoLabs { get; set; }
        public DbSet<PruebaLab> PruebaLabs { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Doctor> Doctores { get; set; }
        public DbSet<Cita> Citas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region "Tablas"
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<ResultadoLab>().ToTable("ResultadoLabs");
            modelBuilder.Entity<PruebaLab>().ToTable("PruebaLabs");
            modelBuilder.Entity<Paciente>().ToTable("Pacientes");
            modelBuilder.Entity<Doctor>().ToTable("Doctores");
            modelBuilder.Entity<Cita>().ToTable("Citas");
            #endregion

            #region "Primary Key"
            modelBuilder.Entity<Usuario>().HasKey(u => u.UsuarioId);
            modelBuilder.Entity<ResultadoLab>().HasKey(r => r.ResultadosLabId);
            modelBuilder.Entity<PruebaLab>().HasKey(p => p.PruebaLabId);
            modelBuilder.Entity<Paciente>().HasKey(p => p.PacienteId);
            modelBuilder.Entity<Doctor>().HasKey(d => d.DoctorId);
            modelBuilder.Entity<Cita>().HasKey(c => c.CitaId);


            modelBuilder.Entity<Usuario>().Property(u => u.UsuarioId)
                .UseIdentityColumn();
            modelBuilder.Entity<ResultadoLab>().Property(r => r.ResultadosLabId)
                .UseIdentityColumn();
            modelBuilder.Entity<PruebaLab>().Property(p => p.PruebaLabId)
                .UseIdentityColumn();
            modelBuilder.Entity<Paciente>().Property(p => p.PacienteId)
                .UseIdentityColumn();
            modelBuilder.Entity<Doctor>().Property(d => d.DoctorId)
                .UseIdentityColumn();
            modelBuilder.Entity<Cita>().Property(c => c.CitaId)
                .UseIdentityColumn();


            #endregion

            #region "relationships"
            modelBuilder.Entity<PruebaLab>()
                .HasMany(pl => pl.ResultadosLabs)
                .WithOne(rl => rl.PruebaLab)
                .HasForeignKey(rl => rl.PruebaLabId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Paciente>()
                .HasMany(p => p.Citas)
                .WithOne(c => c.Paciente)
                .HasForeignKey(c => c.PacienteId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Doctor>()
                .HasMany(d => d.Citas)
                .WithOne(c => c.Doctor)
                .HasForeignKey(c => c.DoctorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Cita>()
                .HasMany(c => c.ResultadosLabs)
                .WithOne(rl => rl.Cita)
                .HasForeignKey(rl => rl.CitaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Paciente>()
                .HasMany(p => p.ResultadosLab)
                .WithOne(c => c.Paciente)
                .HasForeignKey(c => c.ResultadosLabId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

            modelBuilder.Entity<Usuario>()
                    .HasData(
                    new Usuario()
                    {
                        UsuarioId = 1,
                        Nombre = "Anchelo",
                        Apellido = "Roman",
                        Email = "ancheloroman23@gmail.com",
                        NombreUsuario = "ancheloroman23",
                        TipoUsuario = "Administrador",
                        Clave = "e82dd41da30648e8352b5a8490c6841638d11b38586a688a2ddf66b8e1092e63"  //coco100 ESA ES LA CLAVE
                    });

            modelBuilder.Entity<Usuario>()
                    .HasData(
                    new Usuario()
                    {
                        UsuarioId = 2,
                        Nombre = "rebeca",
                        Apellido = "Fernandez",
                        Email = "rebeca@gmail.com",
                        NombreUsuario = "rebeca23",
                        TipoUsuario = "Asistente",
                        Clave = "e82dd41da30648e8352b5a8490c6841638d11b38586a688a2ddf66b8e1092e63" //coco100 ESA ES LA CLAVE
                    });

            #region "property configuration"

            #region "Usuario"

            modelBuilder.Entity<Usuario>()
                    .Property(u => u.Nombre)
                    .HasMaxLength(50);

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Apellido)
                .HasMaxLength(60);

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Email)
                .HasMaxLength(80);

            modelBuilder.Entity<Usuario>()
                .Property(u => u.NombreUsuario)
                .HasMaxLength(60);

            #endregion

            #region "Paciente"

            modelBuilder.Entity<Paciente>()
                    .Property(p => p.Nombre)
                    .HasMaxLength(50);

            modelBuilder.Entity<Paciente>()
                .Property(p => p.Apellido)
                .HasMaxLength(60);

            modelBuilder.Entity<Paciente>()
                .Property(p => p.FechaNacimiento)
                .HasConversion(
                dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
                dateTime => DateOnly.FromDateTime(dateTime));

            #endregion

            #region "Doctor"

            modelBuilder.Entity<Doctor>()
                    .Property(d => d.Nombre)
                    .HasMaxLength(50);

            modelBuilder.Entity<Doctor>()
                .Property(doctor => doctor.Apellido)
                .HasMaxLength(60);

            #endregion


            #endregion
        }
    }
}
