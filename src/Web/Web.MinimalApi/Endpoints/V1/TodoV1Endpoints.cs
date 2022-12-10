using DotnetExploration.Web.MinimalApi.Models.Responses;
using Microsoft.AspNetCore.Http.HttpResults;

namespace DotnetExploration.Web.MinimalApi.Endpoints.V1;

public static class TodoV1Endpoints
{
    public static IEndpointRouteBuilder MapTodoV1(this IEndpointRouteBuilder builder)
    {
        builder.MapGet("v1/items", GetAllItems)
            .WithName("GetAllTodoItems_v1")
            .WithDescription("Fetches all todo items currently registered")
            .WithGroupName("v1")
            .WithTags("Todo");

        return builder;
    }

    private static Ok<List<TodoItem>> GetAllItems()
    {
        return TypedResults.Ok(new List<TodoItem>
        {
            new()
            {
                Name = "TodoItem 1",
                Content = "TodoItem 1 Content"
            },
            new()
            {
                Name = "TodoItem 2",
                Content = "TodoItem 2 Content"
            }
        });
    }
}