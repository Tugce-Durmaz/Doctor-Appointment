using Doctor_Appointment.Models;
using Microsoft.EntityFrameworkCore;

namespace Doctor_Appointment.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets for entities
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Policlinic> Policlinics { get; set; }
        public DbSet<Login> Login { get; set; }

        // OnModelCreating method for configuring relationships
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships for Appointment
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Policlinic)
                .WithMany(p => p.Appointments)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete
        }
    }
}
