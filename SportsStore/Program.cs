using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SportsStore.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IProductRepository, EFProductRepository>();
builder.Services.AddTransient<IOrderRepository, EFOrderRepository>();
builder.Services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddIdentity<AppUser, IdentityRole<Guid>>()
 .AddEntityFrameworkStores<ApplicationDbContext>()
 .AddDefaultTokenProviders();
builder.Services.AddMemoryCache();
builder.Services.AddSession();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
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
app.UseSession();
app.MapDefaultControllerRoute();
app.MapRazorPages();
app.Run();