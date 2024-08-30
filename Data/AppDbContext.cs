using clinic_management_dotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace clinic_management_dotnet.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<HealthPlan> HealthPlan { get; set; }

    }
}
