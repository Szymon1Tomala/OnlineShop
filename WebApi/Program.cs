using Application.Interfaces.Services;
using Infrastructure.Services;
using Persistence.Context;
using WebApi.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IEmployeeService, EmployeeService>();

builder.Services.AddSqlServer<DatabaseContext>("Server=localhost;Database=Shop;Trusted_Connection=True;TrustServerCertificate=True;");
builder.Services.AddDbContext<DatabaseContext>();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapEmployeeEndpoints();
app.MapOrderEndpoints();

app.Run();
