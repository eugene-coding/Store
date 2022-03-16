using Microsoft.EntityFrameworkCore;

using Store.Server.Data;
using Store.Server.Services;

using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;

services.AddLocalization();

services.AddControllersWithViews().AddJsonOptions(options =>
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
services.AddRazorPages();

services.AddDbContextFactory<Context>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("Store"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("Store")));
});

services.AddScoped<IFaqService, FaqService>();
services.AddScoped<IProjectService, ProjectService>();
services.AddScoped<ISocialService, SocialService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToPage("/_Host");

app.Run();
