using System.Collections.Generic;
using WorkoutLog.Models;

namespace WorkoutLog.Services
{
    public interface IWorkoutService
    {
        IEnumerable<WorkoutViewModel> FilterWorkoutsByType(IEnumerable<WorkoutViewModel> workouts, string exerciseType);
    }
}
