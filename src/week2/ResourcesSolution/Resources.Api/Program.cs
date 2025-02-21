using FluentValidation;
using Marten;
using Resources.Api.Resources;
using Resources.Api.Resources.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var securityUrl = builder.Configuration.GetConnectionString("security-api") ?? throw new Exception("Need a Security API Url");
builder.Services.AddHttpClient<SecurityApi>(client =>
{
  client.BaseAddress = new Uri(securityUrl);

}); //Any calls to the origin (server) for the security team should be done with this.
builder.Services.AddScoped<INotifytheSecurityReviewTeam>(sp =>
{
  return sp.GetRequiredService<SecurityApi>(); // MAKE A NOTE OF THIS.

});

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
  // classroom demonstration - probably ok, but check with your local authorities. ;)
  options.AddDefaultPolicy(pol =>
  {
    pol.AllowAnyHeader();
    pol.WithMethods();
    pol.AllowAnyOrigin();
  });
});

builder.Services.AddScoped<IValidator<ResourceListItemCreateModel>, ResourceListItemCreateModelValidationsService>();
builder.Services.AddScoped<UserInformationProvider>(); // tells the API that if you need to inject this somewhere, (class, method) it's cool with us.
var connectionString = builder.Configuration.GetConnectionString("resources") ?? throw new Exception("No Connection String Found! Bailing!");
builder.Services.AddMarten(options =>
{
  options.Connection(connectionString);
}).UseLightweightSessions();
var app = builder.Build();

app.UseCors();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.MapOpenApi();
}

app.UseAuthorization();

// This uses "reflection" to scan our entire project and create the route table based on attributes.
app.MapControllers();

app.Run();

public partial class Program { }
