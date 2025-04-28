using TaskManagementAPI.Models;

namespace TaskManagementAPI.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User { Id = 1, Username = "admin", Password = "admin123", Role = Role.Admin },
                    new User { Id = 2, Username = "user1", Password = "user123", Role = Role.User }
                );
                context.SaveChanges();
            }

            if (!context.Tasks.Any())
            {
                context.Tasks.AddRange(
                    new TaskItem
                    {
                        Id = 1,
                        Title = "Test Task 1",
                        Description = "First task for user1",
                        UserId = 2
                    },
                    new TaskItem
                    {
                        Id = 2,
                        Title = "Test Task 2",
                        Description = "Second task for user1",
                        UserId = 2
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
