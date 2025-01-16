using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AgentieTurism.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Bookings");
    options.Conventions.AuthorizeFolder("/Reviews");
    options.Conventions.AllowAnonymousToPage("/Reviews/Index");
    options.Conventions.AllowAnonymousToPage("/Reviews/Details");
});
builder.Services.AddDbContext<AgentieTurismContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AgentieTurismContext") ?? throw new InvalidOperationException("Connection string 'AgentieTurismContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>().AddEntityFrameworkStores<TurismIdentityContext>();

builder.Services.AddDbContext<TurismIdentityContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("AgentieTurismContext") ?? throw new InvalidOperationException("Connectionstring 'AgentieTurismContext' not found.")));


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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
