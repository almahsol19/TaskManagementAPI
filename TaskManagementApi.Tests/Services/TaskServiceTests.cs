using System;
using System.Threading.Tasks; // 👈 Needed for async/await
using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Data;
using TaskManagementAPI.Models;
using TaskManagementAPI.Services;
using Xunit;

namespace TaskManagementApi.Tests.Services
{
    public class TaskServiceTests
    {
        private AppDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Each test gets a fresh DB
                .Options;

            var dbContext = new AppDbContext(options);

            return dbContext;
        }

        [Fact]
        public async Task GetTask_ShouldReturnTask_WhenTaskExists()
        {
            // Arrange
            var dbContext = GetDbContext();
            dbContext.Tasks.Add(new TaskItem { Id = 1, Title = "Test Task", Description = "Test Desc" });
            await dbContext.SaveChangesAsync();

            var service = new TaskService(dbContext);

            // Act
            var result = await service.GetTask(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result!.Id);
            Assert.Equal("Test Task", result.Title);
        }

        [Fact]
        public async Task GetTask_ShouldReturnNull_WhenTaskDoesNotExist()
        {
            // Arrange
            var dbContext = GetDbContext();
            var service = new TaskService(dbContext);

            // Act
            var result = await service.GetTask(99);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetAllTasks_ShouldReturnAllTasks()
        {
            // Arrange
            var dbContext = GetDbContext();
            dbContext.Tasks.AddRange(
                new TaskItem { Id = 1, Title = "Task 1", Description = "Desc 1" },
                new TaskItem { Id = 2, Title = "Task 2", Description = "Desc 2" }
            );
            await dbContext.SaveChangesAsync();

            var service = new TaskService(dbContext);

            // Act
            var tasks = await service.GetAllTasks();

            // Assert
            Assert.NotNull(tasks);
            Assert.Equal(2, tasks.Count);
        }

        [Fact]
        public async Task GetAllTasks_ShouldReturnEmptyList_WhenNoTasksExist()
        {
            // Arrange
            var dbContext = GetDbContext();
            var service = new TaskService(dbContext);

            // Act
            var tasks = await service.GetAllTasks();

            // Assert
            Assert.NotNull(tasks);
            Assert.Empty(tasks);
        }
    }
}
