
using Marten;
using Todos.Api.Todos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(pol =>
{
    // this is demo code - refer to your local authorities here.
    pol.AddDefaultPolicy(c =>
    {
        c.AllowAnyHeader();
        c.AllowAnyMethod();
        c.AllowAnyOrigin();
    });
});

// Add services to the container.
builder.Services.AddAuthorization();

var connectionString = builder.Configuration.GetConnectionString("todos") ?? 
    throw new Exception("CAn't start the api without a connection string");
builder.Services.AddMarten(builder =>
{
    builder.Connection(connectionString);
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// above this line is configuration for the services inside our application
var app = builder.Build();

app.UseCors();
// after this line is configuration for how HTTP requests and responses and handled.

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();
app.MapTodos();

app.Run(); // "Blocked" here. 

public partial class Program { }