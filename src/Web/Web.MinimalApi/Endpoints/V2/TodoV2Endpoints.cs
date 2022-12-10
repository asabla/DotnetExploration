using DotnetExploration.Web.MinimalApi.Models.Responses;
using Microsoft.AspNetCore.Http.HttpResults;

namespace DotnetExploration.Web.MinimalApi.Endpoints.V2;

public static class TodoV2Endpoints
{
    public static IEndpointRouteBuilder MapTodoV2(this IEndpointRouteBuilder builder)
    {
        builder.MapGet("v2/items", GetAllItems)
            .WithName("GetAllTodoItems_v2")
            .WithDescription("Fetches all todo items currently registered")
            .WithGroupName("v2")
            .WithTags("Todo");

        return builder;
    }

    private static Ok<List<TodoItem>> GetAllItems()
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
}