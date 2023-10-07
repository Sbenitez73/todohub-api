namespace Todo.WebApi.Infrastructure.Repositories
{
    using Application;
    using Application.Abstractions;
    using AutoMapper;
    using Domain;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class TaskRepository : ITaskRepository
    {
        private readonly TaskContext _context;

        public TaskRepository(TaskContext context)
        {
            _context = context;
        }

        public async Task<Todo>AddTaskAsync(Todo task)
        {
            if (task == null || task.Id > 0) return null;


            _context.Todos.Add(task);
            await _context.SaveChangesAsync();

            return task;
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            var task = _context.Todos.FirstOrDefault(t => t.Id == id);
            if (task is null) return false;

            _context.Todos.Remove(task);
            var deletedTask = await _context.SaveChangesAsync();

            return deletedTask > 0;
        }

        public async Task<IEnumerable<Todo>> GetAllAsync()
        {
            return await _context.Todos.ToListAsync();
        }

        public async Task<Todo> GetByIdAsync(int id)
        {
            var task = await _context.Todos.FirstOrDefaultAsync(t => Equals(t.Id, id) );
            return task is null ? null : task;
        }

        public async Task<Todo> UpdateTaskAsync(Todo task)
        {
            var updateTask = await _context.Todos.FirstOrDefaultAsync(t => Equals(t.Id, task.Id));
            if (updateTask is null) return null;

            updateTask.Status = task.Status;
            updateTask.Title = task.Title;
            updateTask.Description = task.Description;
            updateTask.Category = task.Category;

            _context.Update(updateTask);
            await _context.SaveChangesAsync();

            return updateTask;
        }
    }
}
