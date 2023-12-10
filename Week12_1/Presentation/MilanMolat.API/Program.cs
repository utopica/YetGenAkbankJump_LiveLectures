using Week11_Assignment.Persistence.API.Services.Interfaces;
using Week11_Assignment.Persistence.API.Services;
using Week11_Assignment.Persistence.Infrastructure.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// IMPLEMENTATIONS

builder.Services.AddScoped<MilanMolatDbContext>();
builder.Services.AddScoped<IDefraudedPersonService, DefraudedPersonService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
