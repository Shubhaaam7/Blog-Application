using AspNetCoreHero.ToastNotification;
using BlogApplication.BlogService_Implemetation;
using BlogApplication.Data;
using BlogApplication.IBlogServices;

using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IBlog,BlogServiceImplementation>();// Added Dependency Injection

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer
(builder.Configuration.GetConnectionString("Blogs")));  //Injecting database connectionvity


//Added for toaster notification
builder.Services.AddNotyf(config =>
{
    config.DurationInSeconds = 5;
    config.IsDismissable = true;
    config.Position = NotyfPosition.TopRight;
});

//
builder.Services.AddRazorPages().
    AddRazorRuntimeCompilation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//Logger
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .MinimumLevel.Error()
    .WriteTo.File("Logs/BlogApplicationLoggs.txt", rollingInterval: RollingInterval.Month)
    .CreateLogger();



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Blogs}/{action=List}/{id?}");
app.MapAreaControllerRoute(
    name: "Edit",
    areaName: "Blogs",
    pattern: "{controller=Blogs}/{action=Edit}/{id?}"
    );
app.Run();
