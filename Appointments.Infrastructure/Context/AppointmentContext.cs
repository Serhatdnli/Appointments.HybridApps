using Appointments.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Appointments.Infrastructure.Context
{
    public class AppointmentContext : DbContext
    {
        public DbSet<User> Users { get; set; }

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
                var connectionString = "Data Source=DESKTOP-OVR1F6F\\SQLEXPRESS;Initial Catalog=Appointments;Integrated Security=True;TrustServerCertificate=True"; //Serhat
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
