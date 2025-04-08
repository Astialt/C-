using System;
using System.ComponentModel.DataAnnotations;

namespace WorkoutLog.Models
{
    public class Workout
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        [Range(1, 1000, ErrorMessage = "Продолжительность должна быть положительным числом")]
        public int Duration { get; set; } // Продолжительность в минутах
    }
}
