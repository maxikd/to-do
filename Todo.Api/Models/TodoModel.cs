namespace Todo.Api.Models;

public class TodoModel
{
    public Guid Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public bool Completed { get; set; }
}