using System;
using System.ComponentModel.DataAnnotations;

namespace WorkoutLog.Models
{
    public class Workout
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Укажите дату тренировки")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Укажите упражнение")]
        [Display(Name = "Упражнение")]
        public string Exercise { get; set; }

        [Required(ErrorMessage = "Укажите длительность тренировки (в минутах)")]
        [Display(Name = "Длительность")]
        public int Duration { get; set; }

        [Display(Name = "Примечания")]
        public string Notes { get; set; }
    }
}
