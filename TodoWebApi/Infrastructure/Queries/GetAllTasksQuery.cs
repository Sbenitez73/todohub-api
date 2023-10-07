namespace Todo.WebApi.Infrastructure.Queries
{
    using MediatR;
    using Application.DTOs;

    public record GetAllTasksQuery: IRequest<IEnumerable<TaskDto>>;
}
