namespace Todo.WebApi.Infrastructure.Commands
{
    using MediatR;

    public record DeleteTaskCommand(int Id): IRequest<bool>;
}
