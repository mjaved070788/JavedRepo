using DotNetCoreApplication.Data;
using DotNetCoreApplication.Interfaces;
using DotNetCoreApplication.Repository;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddRazorPages(options =>
{
    options.RootDirectory = "/Pages"; // Set to your custom folder path
});



builder.Services.AddControllersWithViews();
// Configure custom view location formats
builder.Services.Configure<RazorViewEngineOptions>(options =>
{
    options.ViewLocationFormats.Add("/Views/Home/{0}" + RazorViewEngine.ViewExtension);
});



builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddTransient<IEmployee, EmployeeRepo>();



//builder.Services.Configure<RazorViewEngineOptions>(o =>
//{
//    o.ViewLocationFormats.Add("/Views/Home/{1}/{0}" + RazorViewEngine.ViewExtension);
//});




var app = builder.Build();





// Configure the request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();



// Map Razor Pages endpoints
app.MapRazorPages();

/*============ To Run MVC Controller View ===============*/
app.MapControllers();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(name: "default",pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.MapGet("/", context =>
{
    context.Response.Redirect("/Default");
    return Task.CompletedTask;
});
/*=============== End of MVC Controller View ===========*/


app.Run();