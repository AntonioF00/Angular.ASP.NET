using Angular.NET.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.Configure<ConfigurationModel>(builder.Configuration.GetSection("Configuration"));
builder.Services.AddLogging();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
                        name: "default",
                        pattern: "{controller}/{action=Index}/{id?}"
                       );

app.MapFallbackToFile("index.html"); ;

app.Run();