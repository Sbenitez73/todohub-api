namespace Todo.WebApi.Infrastructure.Queries
{
    using MediatR;
    using Application.DTOs;

    public record GetTaskByIdQuery(int Id): IRequest<TaskDto>;
}
