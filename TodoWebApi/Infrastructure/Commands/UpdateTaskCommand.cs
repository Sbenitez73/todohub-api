namespace Todo.WebApi.Infrastructure.Commands
{
    using Application.DTOs;
    using MediatR;

    public record UpdateTaskCommand(TaskDto Task): IRequest<TaskDto>;
    
}
