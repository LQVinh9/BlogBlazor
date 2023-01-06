using Microsoft.EntityFrameworkCore;
using WebBlog.Data;
using WebBlog.Models;

var builder = WebApplication.CreateBuilder(args);

/*var conStrBuilder = new SqlConnectionStringBuilder(
        builder.Configuration.GetConnectionString("ConnectKey"));
conStrBuilder.Password = builder.Configuration["DbPassword"];
var connection = conStrBuilder.ConnectionString;*/

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

/*builder.Services.AddDbContext<BlogDBContext>(options =>
options.UseSqlServer(connection));*/

builder.Services.AddDbContext<BlogDBContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("BloggingDatabase")));

builder.Services.AddServerSideBlazor().AddCircuitOptions(options => { options.DetailedErrors = true; });

var app = builder.Build();

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
