using Microsoft.EntityFrameworkCore;
using WorkoutLog.Models;

var builder = WebApplication.CreateBuilder(args);

// Регистрируем контекст EF Core с SQL Server.
// Метод UseSqlServer доступен благодаря пакету Microsoft.EntityFrameworkCore.SqlServer
builder.Services.AddDbContext<WorkoutDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Регистрируем MVC-сервисы
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Если URL не указан, по умолчанию запускается контроллер Workouts, действие Index
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Workouts}/{action=Index}/{id?}");

app.Run();
