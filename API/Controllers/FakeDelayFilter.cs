using Microsoft.AspNetCore.Mvc.Filters;

public class FakeDelayFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(
        ActionExecutingContext context,
        ActionExecutionDelegate next)
    {
        await Task.Delay(1500);
        await next();
    }
}