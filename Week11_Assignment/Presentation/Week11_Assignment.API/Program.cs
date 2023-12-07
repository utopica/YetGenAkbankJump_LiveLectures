using System.Text.Json.Serialization;
using Week11_Assignment.Persistence.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers()

    .AddJsonOptions(opt =>
    {
        opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;

    });
// Adding DbContext 

builder.Services.AddDbContext<AssignmentDbContext>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
