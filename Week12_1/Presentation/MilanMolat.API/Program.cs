using MilanMolat.API.Services.Interfaces;
using MilanMolat.API.Services;
using MilanMolat.Infrastructure.Contexts;
using MilanMolat.Application.Abstract.DefraudedPersonRepositories;
using MilanMolat.Infrastructure.Repositories.DefraudedPerson;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// IMPLEMENTATIONS

builder.Services.AddScoped<MilanMolatDbContext>();

builder.Services.AddScoped<IDefraudedPersonService, DefraudedPersonService>();

builder.Services.AddScoped<IDefraudedPersonReadRepository, DefraudedPersonReadRepository>();

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
