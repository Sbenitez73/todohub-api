namespace Todo.WebApi.Application.DTOs
{
    using Enums;
    using System.Text.Json.Serialization;

    public class TaskDto
    {
        public int Id { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TodoStatusDto Status { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TodoCategoryDto Category { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}