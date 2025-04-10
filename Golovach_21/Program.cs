using Microsoft.EntityFrameworkCore;
using WorkoutLog.Models;

var builder = WebApplication.CreateBuilder(args);

// ������������ �������� EF Core � SQL Server.
// ����� UseSqlServer �������� ��������� ������ Microsoft.EntityFrameworkCore.SqlServer
builder.Services.AddDbContext<WorkoutDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ������������ MVC-�������
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

// ���� URL �� ������, �� ��������� ����������� ���������� Workouts, �������� Index
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Workouts}/{action=Index}/{id?}");

app.Run();
