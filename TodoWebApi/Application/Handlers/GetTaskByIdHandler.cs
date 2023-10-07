namespace Todo.WebApi.Application.Handlers
{
    using Abstractions;
    using AutoMapper;
    using DTOs;
    using Infrastructure.Queries;
    using MediatR;

    public class GetTaskByIdHandler : IRequestHandler<GetTaskByIdQuery, TaskDto>
    {
        private readonly IMapper _mapper;
        private readonly ITaskRepository _taskRepository;

        public GetTaskByIdHandler(IMapper mapper, ITaskRepository taskRepository)
        {
            _mapper = mapper;
            _taskRepository = taskRepository;
        }

        public async Task<TaskDto> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetByIdAsync(request.Id);
            return _mapper.Map<TaskDto>(task);
        }
    }
}
