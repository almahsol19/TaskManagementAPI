using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Data;
using TaskManagementAPI.Models; 

namespace TaskManagementAPI.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /*  This the issue */
    // public class TaskService
    // {
    //     private readonly DbContext _dbContext;
    // public TaskService(DbContext dbContext)
    //     {
    //         _dbContext = dbContext;
    //     }
    // public Task<Task> GetTask(int id)
    //     {
    //         return _dbContext.Tasks.FirstOrDefaultAsync(t => t.Id == id);
    //     }
    // public List<Task> GetAllTasks()
    //     {
    //         return _dbContext.Tasks.ToListAsync();
    //     }
    // }
     /*  This the dix using the asynchronous */ 
    public class TaskService
    {
        private readonly AppDbContext _db;

        public TaskService(AppDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<TaskItem?> GetTask(int id)
        {
            try
            {
                return await _db.Tasks.FirstOrDefaultAsync(t => t.Id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving task with ID {id}: {ex.Message}");
                return null;
            }
        }

        public async Task<List<TaskItem>> GetAllTasks()
        {
            try
            {
                return await _db.Tasks.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving all tasks: {ex.Message}");
                return new List<TaskItem>();
            }
        }
    }
}
