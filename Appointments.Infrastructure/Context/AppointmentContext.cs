using Appointments.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Appointments.Infrastructure.Context
{
    public class AppointmentContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
		public DbSet<Clinic> Clinics{ get; set; }
		public DbSet<Payment> Payments{ get; set; }
		public DbSet<Appointment> Appointments { get; set; }

		public AppointmentContext(DbContextOptions options) : base(options)
        {

        }

        public AppointmentContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "Data Source=DESKTOP-9RMO5H8;Initial Catalog=Appointments;Integrated Security=True;TrustServerCertificate=True"; //Boyraz
                //var connectionString = "Data Source=DESKTOP-OVR1F6F\\SQLEXPRESS;Initial Catalog=Appointments;Integrated Security=True;TrustServerCertificate=True"; //Serhat
                optionsBuilder.UseSqlServer(connectionString, opt =>
                {
                    opt.EnableRetryOnFailure();
                });
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
