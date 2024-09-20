using Appointments.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Appointments.Infrastructure.Context
{
    public class AppointmentContex: DbContext
    {
        DbSet<Test> Tests { get; set; }

        public AppointmentContex(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //var connectionString = "Data Source=DESKTOP-D4VGLVA;Initial Catalog=FootballMates;Integrated Security=True;TrustServerCertificate=True";
                var connectionString = "Data Source=DESKTOP-OVR1F6F\\SQLEXPRESS;Initial Catalog=Appointments;Integrated Security=True;TrustServerCertificate=True"; //Serhat
                //var connectionString = "Data Source=37.187.220.18;User Id=Kursad;Password=Kumkuat_15987532;Initial Catalog=FootballMates;TrustServerCertificate=True";
                //var connectionString = "Data Source=176.31.202.255;User Id=Kursad;Password=Kumkuat_15987532;Initial Catalog=FootballMates;TrustServerCertificate=True";
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
