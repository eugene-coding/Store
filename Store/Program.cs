using Microsoft.EntityFrameworkCore;

using Store.Data;
using Store.Services;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
services.AddRazorPages();
services.AddServerSideBlazor();
services.AddLocalization();

var connectionString = builder.Configuration.GetConnectionString("Database");
var serverVersion = ServerVersion.AutoDetect(connectionString);
services.AddDbContextFactory<Database>(options =>
{
    options.UseMySql(connectionString, serverVersion, options =>
    {
        options.EnableRetryOnFailure();
    });
});

services.AddScoped<ISocialService, SocialService>();
services.AddScoped<IBadgeService, BadgeService>();

var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var serviceProvider = scope.ServiceProvider;

//    SeedData.Initialize(serviceProvider);
//}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
