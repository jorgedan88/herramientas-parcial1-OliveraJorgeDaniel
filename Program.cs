using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Race_Track.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<VehiculoContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("VehiculoContext") ?? throw new InvalidOperationException("Connection string 'VehiculoContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

//Con este bloque de codigo se configura el servicio de autorizacion
builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
