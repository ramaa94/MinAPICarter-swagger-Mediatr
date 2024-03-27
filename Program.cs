using Bogus;
using Carter;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyCarterApp;
//using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);
// all our dependancies and other services goes here
builder.Services.AddCarter();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddLogging();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( c=>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo {Title="My API",Version="v1" });
});
var app = builder.Build();

app.UseRouting();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapGet("/", async context =>
//    {
//        await context.Response.WriteAsync("Hello, World!");
//    });

//    // Refer to routes from UserModule
//    endpoints.MapCarterModule<UserModule>();
//});
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyAPI v1");
    });
}
app.MapCarter();
app.Run();