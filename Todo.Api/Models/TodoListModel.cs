namespace Todo.Api.Models;

public class TodoListModel
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public ICollection<TodoModel> ToDos { get; set; } = new List<TodoModel>();
}