using clinic_management_dotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace clinic_management_dotnet.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<PatientModel> Patients { get; set; }
        public DbSet<AddressModel> Address { get; set; }
        public DbSet<HealthPlanModel> HealthPlan { get; set; }
        public DbSet<PatientHealthPlanModel> PatientHealthPlan { get; set;}
    }
}
