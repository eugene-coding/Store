using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using Store.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddLocalization();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IFaqService, FaqService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<ISocialService, SocialService>();
builder.Services.AddScoped<IRequisiteService, RequisiteService>();

await builder.Build().RunAsync();
