using Microsoft.EntityFrameworkCore;
using MRJCommerce.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IProductRepository, EFProductRepository>();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.MapGet("/hi", () => "Hello!");
app.MapControllerRoute(
name: null,
pattern: "{category}/Page{page:int}",
defaults: new { Controller = "Product", action = "List" });
app.MapControllerRoute(
name: null,
pattern: "Page{page:int}",
defaults: new { Controller = "Product", action = "List", page = 1 });
app.MapControllerRoute(
name: null,
pattern: "{category}",
defaults: new { Controller = "Product", action = "List", page = 1 });
app.MapControllerRoute(
name: null,
pattern: "",
defaults: new { Controller = "Product", action = "List", page = 1 });
app.MapControllerRoute(
name: "default",
pattern: "{controller=Product}/{action=List}/{id?}");
app.MapDefaultControllerRoute();
app.MapRazorPages();
app.Run();