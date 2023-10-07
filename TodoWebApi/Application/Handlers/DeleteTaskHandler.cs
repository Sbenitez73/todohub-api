namespace Todo.WebApi.Application.Handlers
{
    using Application.Abstractions;
    using Infrastructure.Commands;
    using MediatR;

    public class DeleteTaskHandler : IRequestHandler<DeleteTaskCommand, bool>
    {
        private readonly ITaskRepository _taskRepository;

        public DeleteTaskHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<bool> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            return await _taskRepository.DeleteTaskAsync(request.Id);
        }
    }
}
