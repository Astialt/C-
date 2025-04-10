using WorkoutLog.Services;

var builder = WebApplication.CreateBuilder(args);

// Регистрируем MVC
builder.Services.AddControllersWithViews();

// Внедрение зависимости для сервиса тренировок
builder.Services.AddScoped<IWorkoutService, WorkoutService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Настройка маршрутов – по умолчанию контроллер Workout
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Workout}/{action=Index}/{id?}");

app.Run();
