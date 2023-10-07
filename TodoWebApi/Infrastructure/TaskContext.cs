namespace Todo.WebApi.Application;

using Microsoft.EntityFrameworkCore;
using Domain;
using System.Reflection.Metadata;

public class TaskContext: DbContext
{
    public TaskContext( DbContextOptions options )
        :base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Todo>()
            .HasKey(b => b.Id);
            
    }

    public DbSet<Todo> Todos { get; set; }
}

