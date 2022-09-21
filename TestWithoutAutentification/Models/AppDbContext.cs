using Microsoft.EntityFrameworkCore;

namespace TestWithoutAutentification.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Role> Roles { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string userRoleName = "user";
            string companyRoleName = "company";

            // добавляем роли
            Role userRole = new Role { Id = 1, Name = userRoleName };
            Role companyRole = new Role { Id = 2, Name = companyRoleName };

            modelBuilder.Entity<Role>().HasData(new Role[] { userRole, companyRole });
            base.OnModelCreating(modelBuilder);
        }
    }
}
