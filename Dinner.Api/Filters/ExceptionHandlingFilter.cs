namespace Dinner.Api.Filters
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    public class ExceptionHandlingFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            var problemDetails = new ProblemDetails
            {
                Status = 500,
                Title = exception.Message
            };

            context.Result = new ObjectResult(problemDetails);
            //  new ObjectResult(new { error = exception.Message })
            // {
            //     StatusCode = 500
            // };
            context.ExceptionHandled = true;
        }
    }
}