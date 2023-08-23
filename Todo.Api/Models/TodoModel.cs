namespace Todo.Api.Models;

public class ToDoModel
{
    public Guid Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public bool Completed { get; set; }
}