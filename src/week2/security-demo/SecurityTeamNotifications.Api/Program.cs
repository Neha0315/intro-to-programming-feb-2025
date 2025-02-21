using Scalar;
using Scalar.AspNetCore;
using SecurityTeamNotifications.Api.ResourceNotifications;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(p => { }); // builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapControllers();
app.MapResourceNotifications();
app.MapOpenApi();
app.MapScalarApiReference(); // app.UseSwaggerUi();
app.Run();
