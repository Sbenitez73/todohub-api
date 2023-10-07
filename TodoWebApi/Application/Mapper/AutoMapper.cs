using AutoMapper;

namespace Todo.WebApi.Application.Mapper
{
    using Domain.Enums;
    public class AutoMapper: Profile
    {
        public AutoMapper()
        {
            CreateMap<Domain.Todo, DTOs.TaskDto>().ReverseMap();
            CreateMap<TodoCategory, DTOs.Enums.TodoCategoryDto>().ReverseMap();
            CreateMap<TodoStatus, DTOs.Enums.TodoStatusDto>().ReverseMap();
        }
    }
}