using WorkoutLog.Services;

var builder = WebApplication.CreateBuilder(args);

// ������������ MVC
builder.Services.AddControllersWithViews();

// ��������� ����������� ��� ������� ����������
builder.Services.AddScoped<IWorkoutService, WorkoutService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// ��������� ��������� � �� ��������� ���������� Workout
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Workout}/{action=Index}/{id?}");

app.Run();
