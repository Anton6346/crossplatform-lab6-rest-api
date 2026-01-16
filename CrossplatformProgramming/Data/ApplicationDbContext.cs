using CrossplatformProgramming.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Course> Courses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Programming" },
            new Category { Id = 2, Name = "Databases" }
        );

        modelBuilder.Entity<Teacher>().HasData(
            new Teacher { Id = 1, FullName = "John Smith" },
            new Teacher { Id = 2, FullName = "Anna Brown" }
        );

        modelBuilder.Entity<Course>().HasData(
            new Course
            {
                Id = 1,
                Title = "ASP.NET Core",
                StartDate = DateTime.Now,
                CategoryId = 1,
                TeacherId = 1
            },
            new Course
            {
                Id = 2,
                Title = "PostgreSQL Basics",
                StartDate = DateTime.Now,
                CategoryId = 2,
                TeacherId = 2
            }
        );
    }
}
