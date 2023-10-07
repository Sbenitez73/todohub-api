namespace Todo.WebApi.Domain
{
    using Application.DTOs.Enums;
    using System.ComponentModel.DataAnnotations;

    public class Todo
    {
        [Key]
        public int Id { get; set; }
        public TodoStatusDto Status { get; set; }
        public TodoCategoryDto Category { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
