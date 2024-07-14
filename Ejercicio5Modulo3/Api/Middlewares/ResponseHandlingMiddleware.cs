using Newtonsoft.Json;

namespace Ejercicio5Modulo3.Api.Middlewares;

public class ResponseHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ResponseHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {


                var modifiedResponse = ModifyResponse(context.Response.StatusCode, context.Response.Body.ToString());

                context.Response.Headers.ContentLength = null; // Let ASP.NET Core recalculate it
                await context.Response.WriteAsync(modifiedResponse);
                await _next(context);
   
    }
    private string ModifyResponse(int statusCode, string originalResponseBody)
    {
        var responseObj = new
        {
            statuscode = statusCode,
            data = originalResponseBody
        };

        return JsonConvert.SerializeObject(responseObj);
    }
}