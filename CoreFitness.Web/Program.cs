using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using CoreFitness.Web.Areas.Identity.Data;
using CoreFitness.Infrastructure.Data;
using CoreFitness.Application.Dependencies;
using CoreFitness.Infrastructure.Dependencies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// Identity DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Domain DbContext
builder.Services.AddDbContext<CoreFitnessDbContext>(options =>
    options.UseSqlServer(connectionString));

// Identity
builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultUI();

builder.Services.AddControllersWithViews();

// Clean Architecture DI
builder.Services.AddInfrastructureServices();
builder.Services.AddApplicationServices();

var app = builder.Build();

// Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // ⭐ .NET 8 korrekt ersättning
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseStatusCodePagesWithReExecute("/Home/NotFound");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
