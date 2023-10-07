using AutoMapper;

namespace Todo.WebApi.Application.Mapper
{
    public class AutoMapper: Profile
    {
        public AutoMapper()
        {
            CreateMap<Domain.Todo, DTOs.TaskDto>();
        }
    }
}