//using Blazored.Toast;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Sotsera.Blazor.Toaster.Core.Models;
using System.Globalization;
using Week9_1.BlazorDI;
using Week9_1.BlazorDI.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


//builder.Services.AddScoped<IToasterService, BlazoredToastService>();
builder.Services.AddScoped<IToasterService, SotseraToastService>();

//builder.Services.AddBlazoredToast();

builder.Services.AddToaster(config =>
{
	config.PositionClass = Defaults.Classes.Position.TopRight;
	config.PreventDuplicates = true;
	config.NewestOnTop = true;
});

// Localization

builder.Services.AddLocalization(options =>
{
	options.ResourcesPath = "Resources";
});

var trCulture = new CultureInfo("en-GB");

CultureInfo.DefaultThreadCurrentCulture= trCulture;
CultureInfo.DefaultThreadCurrentUICulture = trCulture;


await builder.Build().RunAsync();
