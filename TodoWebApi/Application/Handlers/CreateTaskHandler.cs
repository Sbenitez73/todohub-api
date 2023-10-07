namespace Todo.WebApi.Application.Handlers
{
    using Abstractions;
    using Application.DTOs;
    using AutoMapper;
    using Infrastructure.Commands;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateTaskHandler: IRequestHandler<CreateTaskCommand, TaskDto>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public CreateTaskHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<TaskDto> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var todo = _mapper.Map<Domain.Todo>(request.Task);
            var addedTask = await _taskRepository.AddTaskAsync(todo);
            return _mapper.Map<TaskDto>(addedTask);
        }
    }
}
