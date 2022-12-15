using DotnetExploration.Web.MinimalApi.Models.Responses;
using Microsoft.AspNetCore.Http.HttpResults;

namespace DotnetExploration.Web.MinimalApi.Endpoints.V2;

public static class TodoV2Endpoints
{
    public static IEndpointRouteBuilder MapTodoV2(this IEndpointRouteBuilder builder, IConfiguration configuration)
    {
        builder.MapGet("v2/items", GetAllItems)
            .WithName("GetAllTodoItems_v2")
            .WithDescription("Fetches all todo items currently registered")
            .WithGroupName("v2")
            .WithTags("Todo");

        builder.MapGet("v2/todos/{todoId}",
                Results<Ok<TodoItem>, NotFound, NoContent>
                (Guid todoId) => todoId != default
                    ? TypedResults.Ok(GetTodoItem(todoId))
                    : TypedResults.NotFound())
            .WithName("GetTodoItem_v2")
            .WithDescription("Get specific todoitem based on it's id")
            .WithGroupName("v2")
            .WithTags("Todo");

        return builder;
    }

    private static Results<Ok<List<TodoItem>>, NoContent> GetAllItems()
    {
        return TypedResults.Ok(new List<TodoItem>
        {
            new()
            {
                Name = "TodoItem_v2 1",
                Content = "TodoItem_v2 1 Content"
            },
            new()
            {
                Name = "TodoItem_v2 2",
                Content = "TodoItem_v2 2 Content"
            }
        });
    }

    private static TodoItem GetTodoItem(Guid todoId)
    {
        return new()
        {
            Id = todoId,
            Name = "TodoItem_v2 1",
            Content = "TodoItem_v2 1"
        };
    }
}