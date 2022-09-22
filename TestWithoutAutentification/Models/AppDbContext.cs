using Microsoft.EntityFrameworkCore;
using TestWithoutAutentification.Models.AdditionalModels;

namespace TestWithoutAutentification.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Resume> Resume { get; set; }

        public DbSet<Citizenship> Citizenship { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<EducationalInstitution> EducationalInstitution { get; set; }
        public DbSet<EducationLevel> EducationLevel { get; set; }
        public DbSet<ForeignLanguage> ForeignLanguage { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<LanguageLevel> LanguageLevel { get; set; }
        public DbSet<NativeLanguage> NativeLanguage { get; set; }
        public DbSet<PlaceOfWork> PlaceOfWork { get; set; }
        public DbSet<Salary> Salary { get; set; }
        public DbSet<Sex> Sex { get; set; }
        public DbSet<WorkExperience> WorkExperience { get; set; }

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
