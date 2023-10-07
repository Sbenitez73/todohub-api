namespace Todo.WebApi.Application.Abstractions
{
    using Domain;

    public interface ITaskRepository
    {
        Task<IEnumerable<Todo>> GetAllAsync();
        Task<Todo> GetByIdAsync(int id);
        Task<Todo> AddTaskAsync(Todo task);
        Task<Todo> UpdateTaskAsync(Todo task);
        Task<bool> DeleteTaskAsync(int id);
    }
}
