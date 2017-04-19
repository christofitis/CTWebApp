using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CriticalWebApp.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Repair> Repairs { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<SerialNumber> SerialNumbers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductionTotals> ProductTotals { get; set; }
        public DbSet<RepairRouter> RepairRouters { get; set; }
        public DbSet<ProductionOutputTotals> ProductionOutputTotals { get; set; }
        public DbSet<ProductReceived> ProductReceived { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<ProductAssembly> ProductAssemblies { get; set; }
        public DbSet<AssemblyHouse> AssemblyHouses { get; set; }
        public DbSet<OffsiteJob> OffsiteJobs { get; set; }
        public DbSet<JobInventory> JobInventories { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}