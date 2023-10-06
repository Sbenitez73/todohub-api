using Microsoft.EntityFrameworkCore;

namespace Todo.DrivenAdapter.SqlServer;

public class TodoContext: DbContext
{
    public TodoContext( DbContextOptions options )
        :base(options)
    {
    }

    public DbSet<Model.Todo> Todos { get; set; }


}

