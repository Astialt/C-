using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WorkoutLog.Models;

namespace WorkoutLog.Controllers
{
    [Route("Workouts")]
    public class WorkoutsController : Controller
    {

        private static List<Workout> _workouts = new List<Workout>
        {
            new Workout { Id = 1, Date = new DateTime(2025, 4, 3), Type = "Кардиотренировка", Duration = 30 },
            new Workout { Id = 2, Date = new DateTime(2025, 4, 3), Type = "Силовая тренировка", Duration = 45 },
            new Workout { Id = 3, Date = new DateTime(2025, 4, 4), Type = "Пилатес", Duration = 60 }
        };

        [HttpGet("Day/{date}")]
        public IActionResult Day(string date)
        {
            if (!DateTime.TryParse(date, out DateTime dt))
            {
                return BadRequest("Некорректная дата");
            }


            var workoutsForDay = _workouts
                .Where(w => w.Date.Date == dt.Date)
                .OrderBy(w => w.Id)
                .ToList();

            ViewBag.Date = dt.ToString("yyyy-MM-dd");
            return View(workoutsForDay);
        }


        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

 
        [HttpPost("Create")]
        public IActionResult Create(Workout workout)
        {
            if (ModelState.IsValid)
            {
                workout.Id = (_workouts.Count > 0) ? _workouts.Max(w => w.Id) + 1 : 1;
                _workouts.Add(workout);
     
                return RedirectToAction("Day", new { date = workout.Date.ToString("yyyy-MM-dd") });
            }
            return View(workout);
        }
    }
}
