using System.Globalization;
using Week9_1.Shared.Utilities;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using Week9_1.Shared.Services;
using Week9_1.WebApi.Services;
using Microsoft.Extensions.DependencyInjection;
using Week10_1.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependancy Injections

builder.Services.AddSingleton<PasswordGenerator>();
builder.Services.AddSingleton<RequestCountService>(new RequestCountService());

var textPath = builder.Configuration.GetSection("TextPath").Value;

//builder.Services.AddSingleton<TextService>(new TextService(textPath));

builder.Services.AddSingleton<ITextService,TextService>();

builder.Services.AddSingleton<IIPService, IPService>();

// Localization

builder.Services.AddLocalization(options =>
{
	options.ResourcesPath = "Resources";
});

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
	var trCulture = new CultureInfo("tr-TR");

	List<CultureInfo> cultureInfos = new()
	{
		trCulture,
		new("en-GB"),
	};

	options.SupportedCultures = cultureInfos;
	options.SupportedUICultures = cultureInfos;
	options.DefaultRequestCulture = new RequestCulture(trCulture);
	options.ApplyCurrentCultureToResponseHeaders = true;

});

//Adding DbContext for project Week10_1

var connectionString = builder.Configuration.GetSection("YetgenPosgreSQLDB").Value;

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));

var app = builder.Build();

var requestLocalizationOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>();

if(requestLocalizationOptions is not null) app.UseRequestLocalization(requestLocalizationOptions.Value);

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
