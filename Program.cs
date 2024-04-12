using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NavigationApp.Controllers; 
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(); // Add this line to register controllers

// Add Swagger services
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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "NavigationApp v1");
        c.RoutePrefix = string.Empty; // Set Swagger UI at the root URL
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); // Map controllers to routes

app.Run();
