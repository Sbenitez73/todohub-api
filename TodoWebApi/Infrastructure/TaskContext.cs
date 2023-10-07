namespace Todo.WebApi.Application;

using Microsoft.EntityFrameworkCore;
using Domain;

public class TaskContext: DbContext
{
    public TaskContext( DbContextOptions options )
        :base(options)
    {
    }

    public DbSet<Todo> Todos { get; set; }
}

