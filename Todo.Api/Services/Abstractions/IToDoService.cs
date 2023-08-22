using Todo.Api.Models;

namespace Todo.Api.Services.Abstractions;

public interface IToDoService
{
    IEnumerable<TodoListModel> GetAll();
    void CreateToDoList(TodoListModel todoListModel);
    void AddToDo(Guid toDoListId, TodoModel todoModel);
    void UpdateToDoList(TodoListModel todoListModel);
    void UpdateToDo(TodoModel todoModel);
}