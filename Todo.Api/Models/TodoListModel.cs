namespace Todo.Api.Models;

public record class TodoListModel(ICollection<TodoModel> Todos);