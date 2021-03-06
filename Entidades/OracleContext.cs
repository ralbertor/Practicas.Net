using Microsoft.EntityFrameworkCore;

namespace Catalog.Entidades
{
    public class OracleContext : DbContext{
        public OracleContext(DbContextOptions<OracleContext> options)
        :base(options)
        {}
        public DbSet<Usuario> OracleUsuario{get;set;}
        public DbSet<Medico> OracleMedico{get;set;}
        public DbSet<Cita> OracleCita{get;set;}
        public DbSet<Paciente> OraclePaciente{get;set;}
        public DbSet<Diagnostico> OracleDiagnostico{get;set;}
        public DbSet<MedicoPaciente> OracleMedicoPaciente{get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Usuario>().ToTable("USUARIO");
            modelBuilder.Entity<Medico>().ToTable("MEDICO");
            modelBuilder.Entity<Paciente>().ToTable("PACIENTE");

            modelBuilder.Entity<Usuario>().Property(u => u.id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Cita>().Property(c => c.id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Diagnostico>().Property(d => d.id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Cita>()
                .HasOne<Diagnostico>(c =>c.diagnostico)
                    .WithOne(d => d.cita)
                    .HasForeignKey<Diagnostico>(d => d.citaId)
                        .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Cita>()
                .HasOne<Medico>(c =>c.medico)
                    .WithMany(m => m.citas)
                    .HasForeignKey(c => c.medicoId)
                        .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Cita>()
                .HasOne<Paciente>(c =>c.paciente)
                    .WithMany(p => p.citas)
                    .HasForeignKey(c => c.pacienteId)
                        .OnDelete(DeleteBehavior.Cascade);
        
            modelBuilder.Entity<MedicoPaciente>().HasKey(
                mp => new {mp.medicoId, mp.pacienteId}
            );

            modelBuilder.Entity<MedicoPaciente>()
                .HasOne<Medico>(mp =>mp.medico)
                    .WithMany(m => m.pacientes)
                    .HasForeignKey(mp  => mp.medicoId)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MedicoPaciente>()
                .HasOne<Paciente>(mp =>mp.paciente)
                    .WithMany(p => p.medicos)
                    .HasForeignKey(mp  => mp.pacienteId)
                        .OnDelete(DeleteBehavior.Cascade);            
        }
         
        public static readonly Microsoft.Extensions.Logging.LoggerFactory loggin =
        new Microsoft.Extensions.Logging.LoggerFactory(new[]{
            new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider()
        });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseLoggerFactory(loggin);
            optionsBuilder.EnableDetailedErrors();
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}