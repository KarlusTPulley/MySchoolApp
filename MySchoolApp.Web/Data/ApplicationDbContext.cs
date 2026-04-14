using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MySchoolApp.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //ApplicationUser
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<IdentityRole>().HasData(
            //    new IdentityRole
            //    {
            //        Id = "f5533b26-9e9c-485b-a8fc-acd0e5e15e25",
            //        Name = "Admin",
            //        NormalizedName = "ADMIN"
            //    },
            //    new IdentityRole
            //    {
            //        Id = "0047fcaf-2887-43e3-a7cd-85a0d746a6cb",
            //        Name = "User",
            //        NormalizedName = "USER"
            //    });

            
            //builder.Entity<ApplicationUser>().HasData(
            //    new ApplicationUser
            //    {
            //        Id = "80c325cd-fa1f-4e6d-89bb-600a8dbb557a",
            //        UserName = "admin",
            //        NormalizedUserName = "ADMIN",
            //        Email = "admin@example.com",
            //        NormalizedEmail = "ADMIN@EXAMPLE.COM",
            //        EmailConfirmed = true,
            //        PasswordHash = "AQAAAAIAAYagAAAAEJTLrxrwmd64bKp1kuH5qw72CykjOW9cga6XcQC0gRuPS1+nkPaFBTLTGX411Hh13A=="
            //    });
            //builder.Entity<IdentityUserRole<string>>().HasData(
            //    new IdentityUserRole<string>
            //    {
            //        UserId = "80c325cd-fa1f-4e6d-89bb-600a8dbb557a",
            //        RoleId = "f5533b26-9e9c-485b-a8fc-acd0e5e15e25"
            //    });
        }

        // Define DbSet properties for each entity
        //the database table for each DbSet will be named after the property name (e.g., "Students", "Teachers", etc.)
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseSection> CourseSections { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
    }

}
