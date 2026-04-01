using Microsoft.EntityFrameworkCore;
using ShoppingCart.Api.Middleware;
using ShoppingCart.Core;
using ShoppingCart.Data;
using ShoppingCart.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHealthChecks().AddDbContextCheck<AppDbContext>();

RepositoriesInitializer.Initialize(builder.Services);
CoreServicesInitializer.Initialize(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/health");

app.Run();
