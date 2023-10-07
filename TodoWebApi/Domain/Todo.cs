using Todo.WebApi.Application.DTOs.Enums;

namespace Todo.WebApi.Domain
{
    public class Todo
    {
        public int Id { get; set; }
        public TodoStatusDto Status { get; set; }
        public TodoCategoryDto Category { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
