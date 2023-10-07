namespace Todo.WebApi.Application.Handlers
{
    using Abstractions;
    using AutoMapper;
    using DTOs;
    using Infrastructure.Queries;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetAllTasksHandler : IRequestHandler<GetAllTasksQuery, IEnumerable<TaskDto>>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public GetAllTasksHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TaskDto>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            var taskList = await _taskRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TaskDto>>(taskList);
        }
    }
}
