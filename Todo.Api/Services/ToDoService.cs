using Todo.Api.Models;
using Todo.Api.Services.Abstractions;

namespace Todo.Api.Services;

public class ToDoService : IToDoService
{
    private List<ToDoListModel> _todos = new List<ToDoListModel>();

    public ToDoService()
    {
        var todos = Enumerable.Range(1, 5)
            .Select(i => new ToDoModel
            {
                Id = Guid.NewGuid(),
                Text = $"This is To-Do {i}",
                Completed = i % 2 == 0
            })
            .ToList();

        var todoList = new ToDoListModel
        {
            Id = Guid.NewGuid(),
            Title = "My first to-do",
            ToDos = todos
        };

        _todos.Add(todoList);
    }

    public IEnumerable<ToDoListModel> GetAll()
    {
        return _todos;
    }

    public void CreateToDoList(
        ToDoListModel todoListModel)
    {
        todoListModel.Id = Guid.NewGuid();
        _todos.Add(todoListModel);
    }

    public void AddToDo(
        Guid toDoListId,
        ToDoModel todoModel)
    {
        var toDoList = _todos.FirstOrDefault(model => model.Id == toDoListId);
        if (toDoList is null)
            throw new ArgumentOutOfRangeException(nameof(toDoListId), toDoListId, "Cannot find To Do list with this Id");

        toDoList.ToDos.Add(todoModel);
    }

    public void UpdateToDoList(
        ToDoListModel todoListModel)
    {
        var toDoList = _todos.FirstOrDefault(model => model.Id == todoListModel.Id);
        if (toDoList is null)
            throw new ArgumentOutOfRangeException(nameof(todoListModel.Id), todoListModel.Id, "Cannot find To Do list with this Id");

        toDoList.Title = todoListModel.Title;
    }

    public void UpdateToDo(
        ToDoModel todoModel)
    {
        var toDo = _todos.SelectMany(toDos => toDos.ToDos).FirstOrDefault(toDo => toDo.Id == todoModel.Id);
        if (toDo is null)
            throw new ArgumentOutOfRangeException(nameof(todoModel.Id), todoModel.Id, "Cannot find To Do with this Id");

        toDo.Completed = todoModel.Completed;
        toDo.Text = todoModel.Text;
    }
}