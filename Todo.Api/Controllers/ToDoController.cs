using Microsoft.AspNetCore.Mvc;
using Todo.Api.Models;
using Todo.Api.Services.Abstractions;

namespace Todo.Api.Controllers;

[Route("api/todos")]
[ApiController]
public class ToDoController : ControllerBase
{
    public ToDoController(
        IToDoService toDoService)
    {
        ToDoService = toDoService ?? throw new ArgumentNullException(nameof(toDoService));
    }

    public IToDoService ToDoService { get; }

    [HttpGet]
    [Route("/")]
    public IActionResult GetAll()
    {
        var todos = ToDoService.GetAll();

        return Ok(todos);
    }

    [HttpPost]
    [Route("/")]
    public IActionResult Create(
        [FromBody] ToDoListModel todoListModel)
    {
        ToDoService.CreateToDoList(todoListModel);
        return Created("", todoListModel);
    }

    [HttpPost]
    [Route("/{listId}")]
    public IActionResult Add(
        [FromRoute] Guid listId,
        [FromBody] ToDoModel todo)
    {
        ToDoService.AddToDo(listId, todo);
        return Created("", todo);
    }

    [HttpPut]
    [Route("/{listId}")]
    public IActionResult Update(
        [FromRoute] Guid listId,
        [FromBody] ToDoListModel todoListModel)
    {
        ToDoService.UpdateToDoList(todoListModel);
        return Ok(todoListModel);
    }

    [HttpPut]
    [Route("/{listId}/{todoId}")]
    public IActionResult Update(
        [FromRoute] Guid listId,
        [FromRoute] Guid todoId,
        [FromBody] ToDoModel todo)
    {
        ToDoService.UpdateToDo(todo);
        return Ok(todo);
    }
}