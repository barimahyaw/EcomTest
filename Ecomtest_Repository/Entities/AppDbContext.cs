using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ecomtest_Repository.Entities
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Disbursement_Dtl> Disbursement_Dtl { get; set; }
        public DbSet<Schedule_Dtl> Schedule_Dtl { get; set; }
    }
}
