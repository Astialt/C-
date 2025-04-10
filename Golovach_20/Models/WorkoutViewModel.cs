using System;
using System.ComponentModel.DataAnnotations;

namespace WorkoutLog.Models
{
    public class WorkoutViewModel
    {
        [Required(ErrorMessage = "Выберите тип упражнения")]
        public string ExerciseType { get; set; }

        [Required(ErrorMessage = "Укажите время тренировки")]
        [DataType(DataType.Time)]
        public TimeSpan Time { get; set; }

        [Required(ErrorMessage = "Укажите дату тренировки")]
        [DataType(DataType.Date)]
        [NotFutureDate(ErrorMessage = "Дата тренировки не может быть в будущем")]
        public DateTime Date { get; set; }
    }

    // Пользовательский атрибут валидации: дата не должна быть в будущем
    public class NotFutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime date)
            {
                return date <= DateTime.Today;
            }
            return false;
        }
    }
}
