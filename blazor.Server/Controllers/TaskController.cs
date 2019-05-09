using blazor.Server.Data;
using blazor.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace blazor.Server.Controllers
{
    [Route("api/[controller]")]
    public class TaskController : Controller
    {
        private readonly TaskContext taskContext;

        public TaskController(TaskContext taskContext)
        {
            this.taskContext = taskContext;
        }

        [HttpGet]
        public async Task<IEnumerable<TaskEntity>> GetTasks()
        {
            taskContext.Database.EnsureCreated();
            return taskContext.Tasks;
        }

        [HttpPost("{id}")]
        public async Task UpdateTask(int id, [FromBody] TaskEntity task)
        {
            task.Id = id;
            taskContext.Tasks.Update(task);
            await taskContext.SaveChangesAsync();
        }

        [HttpPut]
        public async Task CreateTask([FromBody] TaskEntity task)
        {
            taskContext.Tasks.Add(task);
            await taskContext.SaveChangesAsync();
        }

        [HttpDelete("{id}")]
        public async Task DeleteTask(int id)
        {
            var task = await taskContext.Tasks.FindAsync(id);
            taskContext.Tasks.Remove(task);
            await taskContext.SaveChangesAsync();
        }
    }
}
