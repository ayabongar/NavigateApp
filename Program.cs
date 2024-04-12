using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NavigationApp.Controllers; 
using System;

var builder = WebApplication.CreateBuilder(args);


// register controllers
builder.Services.AddControllers(); 
 

// Add Swagger 
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "NavigationApp", Version = "v1" });
});

var app = builder.Build();

// Configure CORS
app.UseCors(policy => policy
    .AllowAnyOrigin() 
    .AllowAnyMethod()
    .AllowAnyHeader()
);

//  the HTTP request pipeline config.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "NavigationApp v1");
        c.RoutePrefix = string.Empty; // Set Swagger UI at the root URL
    });
}

app.UseCors("AllowFrontend");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); // Map controllers to routes

app.Run();
