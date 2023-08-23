namespace Todo.Api.Models;

public class ToDoListModel
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public ICollection<ToDoModel> ToDos { get; set; } = new List<ToDoModel>();
}