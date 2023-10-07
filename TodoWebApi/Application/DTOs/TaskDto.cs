namespace Todo.WebApi.Application.DTOs
{
    using Enums;

    public class TaskDto
    {
        public int Id { get; set; }
        public TodoStatusDto Status { get; set; }
        public TodoCategoryDto Category { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}