using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HealthClinic.Models
{
    public class HealthClinicDbContext : IdentityDbContext<AppUser>
    {
        public HealthClinicDbContext(DbContextOptions<HealthClinicDbContext> options) : base(options) { }
    }
}
