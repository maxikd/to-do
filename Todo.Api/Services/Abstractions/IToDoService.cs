using Todo.Api.Models;

namespace Todo.Api.Services.Abstractions;

public interface IToDoService
{
    IEnumerable<ToDoListModel> GetAll();
    void CreateToDoList(ToDoListModel todoListModel);
    void AddToDo(Guid toDoListId, ToDoModel todoModel);
    void UpdateToDoList(ToDoListModel todoListModel);
    void UpdateToDo(ToDoModel todoModel);
}