using System;
using System.Collections.Generic;
using System.Linq;
using WorkoutLog.Models;

namespace WorkoutLog.Services
{
    public class WorkoutService : IWorkoutService
    {
        public IEnumerable<WorkoutViewModel> FilterWorkoutsByType(IEnumerable<WorkoutViewModel> workouts, string exerciseType)
        {
            if (string.IsNullOrWhiteSpace(exerciseType))
                return workouts;

            return workouts.Where(w => w.ExerciseType.Equals(exerciseType, StringComparison.OrdinalIgnoreCase));
        }
    }
}
