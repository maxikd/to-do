using Todo.Api.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHealthChecks();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapHealthChecks("healthcheck");

app.MapGet("/todos", () =>
{
    var todos = Enumerable.Range(1, 5)
        .Select(i => new TodoModel($"This is To-Do {i}", i % 2 == 0))
        .ToList();
    var todoList = new TodoListModel(todos);

    return Results.Ok(todoList);
})
.WithName("GetToDos")
.WithOpenApi();

await app.RunAsync();
