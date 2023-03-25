using Dinner.Application;
using Dinner.Infrastructure;

using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

{
    // Add services to the container.
    builder.Services.AddControllers();
    /// builder.Services.AddControllers(opt => opt.Filters.Add<ExceptionHandlingFilter>()); --> 2)using filters
    builder.Services.AddApplicationServices().AddInfraService(builder.Configuration);
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();

{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    /***** error handling ways*********/
    // app.UseMiddleware<ErrorHandlingMiddleware>(); --> 1)using middleware
    // app.UseExceptionHandler("/error");// --> 3) using Exception Route
    // app.Map("/error", (HttpContext context) =>
    // {
    //     var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
    //     return Results.Problem(statusCode: 400, title: exception?.Message);
    // }); // --> 4) using map to avoid controller.
    /*********************************/

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
}

app.Run();
