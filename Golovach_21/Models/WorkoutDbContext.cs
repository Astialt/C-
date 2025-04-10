using Microsoft.EntityFrameworkCore;

namespace WorkoutLog.Models
{
    public class WorkoutDbContext : DbContext
    {
        public WorkoutDbContext(DbContextOptions<WorkoutDbContext> options)
            : base(options)
        {
        }

        public DbSet<Workout> Workouts { get; set; }
    }
}
