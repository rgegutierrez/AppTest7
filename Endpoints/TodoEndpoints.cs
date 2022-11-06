using AppTest7.Models;
using AppTest7.Data;
using Microsoft.EntityFrameworkCore;

namespace AppTest7.Endpoints;
public static class TodoEndpoints
{
    public static WebApplication MapTodoEndpoints(this WebApplication app)
    {
        _ = app.MapGet("/todoitems", async (DalContext db) => 
        await db.Todos.ToListAsync());

        _ = app.MapGet("/todoitems/complete", async (DalContext db) => 
        await db.Todos.Where(t => t.IsComplete).ToListAsync());

        _ = app.MapGet("/todoitems/{id}", async (int id, DalContext db) =>
        await db.Todos.FindAsync(id) 
        is Todo todo ? Results.Ok(todo) : Results.NotFound());

        _ = app.MapPost("/todoitems", async (Todo todo, DalContext db) =>
        {
            db.Todos.Add(todo);
            await db.SaveChangesAsync();

            return Results.Created($"/todoitems/{todo.Id}", todo);
        });

        _ = app.MapPut("/todoitems/{id}", async (int id, Todo inputTodo, DalContext db) =>
        {
            var todo = await db.Todos.FindAsync(id);

            if (todo is null) return Results.NotFound();

            todo.Name = inputTodo.Name;
            todo.IsComplete = inputTodo.IsComplete;

            await db.SaveChangesAsync();

            return Results.NoContent();
        });

        _ = app.MapDelete("/todoitems/{id}", async (int id, DalContext db) =>
        {
            if (await db.Todos.FindAsync(id) is Todo todo)
            {
                db.Todos.Remove(todo);
                await db.SaveChangesAsync();
                return Results.Ok(todo);
            }

            return Results.NotFound();
        }).WithOpenApi();

        return app;
    }
}