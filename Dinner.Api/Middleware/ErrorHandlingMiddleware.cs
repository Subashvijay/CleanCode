namespace Dinner.Api.Middleware
{
    using System.Net;

    using Newtonsoft.Json;

    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await this.next(context);
            }
            catch (System.Exception e)
            {
                await HandleExceptionAsync(context, e.Message);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, string exceptionMsg)
        {
            const HttpStatusCode errorCode = HttpStatusCode.InternalServerError;
            var content = JsonConvert.SerializeObject(new { error = exceptionMsg });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)errorCode;
            return context.Response.WriteAsync(content);
        }
    }
}