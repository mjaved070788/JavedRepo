using ProductMicroservices.DBContexts;
using Microsoft.EntityFrameworkCore;
using ProductMicroservices.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProductContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProductDB"));
});

builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoriesRepository>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();
app.MapGet("/", () => "Hello World!");

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
////app.UseAuthorization();

//app.MapAreaControllerRoute(
//                     name: "Categories",
//                     areaName: "Categories",
//                     pattern: "Categories/{controller=Categories}/{action=Index}/{id?}"
//               );
//app.MapControllerRoute(
//      name: "areaRoute",
//      pattern: "{area:exists}/{controller}/{action}/{id}"

//);

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Product}/{action=Index}/{id?}");



app.Run();
