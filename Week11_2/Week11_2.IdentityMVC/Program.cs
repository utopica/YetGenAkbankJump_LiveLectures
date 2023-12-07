using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Week10_1.Domain.Identity;
using Week10_1.Persistence.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. Adding toast
builder.Services.AddControllersWithViews()
    .AddNToastNotifyToastr();

// Adding DbContexts

var connectionString = builder.Configuration.GetSection("YetgenPostgreSQLDB").Value;

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(connectionString);
});
builder.Services.AddDbContext<IdentityContext>(options =>
{
    options.UseNpgsql(connectionString);
});


// Activating the session structure 

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddIdentity<User,Role>(options =>
{
    // User password options 

    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;

    // User name and Email options
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@$";

}).AddEntityFrameworkStores<IdentityContext>();

builder.Services.Configure<SecurityStampValidatorOptions>(options =>
{
    options.ValidationInterval = TimeSpan.FromMinutes(15);

});

// Cookie Setting

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = new PathString("/Auth/Login");
    options.LogoutPath = new PathString("/Auth/Logout");
    options.Cookie = new CookieBuilder
    {
        Name = "YetgenJump",
        HttpOnly = true,
        SameSite = SameSiteMode.Strict,
        SecurePolicy = CookieSecurePolicy.SameAsRequest // Always
    };
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = System.TimeSpan.FromDays(7);
    options.AccessDeniedPath = new PathString("/Auth/AccessDenied");
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.UseNToastNotify();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
