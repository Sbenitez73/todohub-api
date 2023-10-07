namespace Todo.WebApi.Application.Handlers
{
    using Abstractions;
    using AutoMapper;
    using DTOs;
    using Infrastructure.Commands;
    using MediatR;

    public class UpdateTaskHandler : IRequestHandler<UpdateTaskCommand, TaskDto>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public UpdateTaskHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<TaskDto> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var todo = _mapper.Map<Domain.Todo>(request.Task);
            var addedTask = await _taskRepository.UpdateTaskAsync(todo);

            return _mapper.Map<TaskDto>(addedTask);
        }
    }
}
