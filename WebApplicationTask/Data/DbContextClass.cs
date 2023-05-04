using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApplicationTask.Models.Entity;
//using System.Data.Entity;

namespace WebApplicationTask.Data
{
    public class DbContextClass : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DbContextClass(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Student>()
                .HasKey(s => s.Id);
            builder.Entity<Student>().Property(s => s.Email).IsRequired();
            builder.Entity<Student>().Property(s => s.Name).HasMaxLength(15);

            builder.Entity<Course>()
                .HasKey(c => c.Id);
            builder.Entity<Course>().Property(c => c.Code).IsRequired();

            builder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            builder.Entity<StudentCourse>()
                .HasOne<Student>(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentId);


            builder.Entity<StudentCourse>()
                .HasOne<Course>(sc => sc.Course)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.CourseId);

        }

    }
}
