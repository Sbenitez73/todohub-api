namespace Todo.DrivenAdapter.SqlServer.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Model.Enums;

    [Table("Todos")]
    public class Todo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public TodoStatus Status { get; set; }
        public TodoCategory Category { get; set; }
        public string Description { get; set; }
    }
}

