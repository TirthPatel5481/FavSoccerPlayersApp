using Microsoft.EntityFrameworkCore;
using FavSoccerPlayersApp.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<SoccerPlayersDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MidtermDB")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=SoccerPlayer}/{action=Index}/{id?}"); 

app.Run();
