using System.Globalization;
using Week9_1.Shared.Utilities;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependancy Injections

builder.Services.AddSingleton<PasswordGenerator>(new PasswordGenerator());
builder.Services.AddSingleton<RequestCountService>(new RequestCountService());

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
