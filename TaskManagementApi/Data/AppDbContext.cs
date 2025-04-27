using Microsoft.EntityFrameworkCore;
using TaskManagementApi.Models;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<TaskItem> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "admin", Password = "admin123", Role = Role.Admin },
                new User { Id = 2, Username = "user1", Password = "user123", Role = Role.User }
            );

            modelBuilder.Entity<TaskItem>().HasData(
                new TaskItem { Id = 1, Title = "Test Task 1", Description = "First task for user1", UserId = 2 },
                new TaskItem { Id = 2, Title = "Test Task 2", Description = "Second task for user1", UserId = 2 }
            );
        }
    }
}
