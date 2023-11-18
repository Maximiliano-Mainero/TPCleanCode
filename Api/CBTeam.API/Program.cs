using CBTeam.Application;
using CBTeam.Infrastructure;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.InstallRepositories(connectionString);

builder.Services.AddInfrasctucture();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
options.AddPolicy("Default",
policy =>
{
    policy.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod();
}));

var app = builder.Build(); 

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseCors("Default");
app.MapControllers();

app.Run();
