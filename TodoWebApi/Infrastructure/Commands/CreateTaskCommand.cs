

namespace Todo.WebApi.Infrastructure.Commands
{
    using Application.DTOs;
    using MediatR;

    public record CreateTaskCommand(TaskDto Task) : IRequest<TaskDto>;
    
}
