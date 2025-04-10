using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WorkoutLog.Models;
using WorkoutLog.Services;

namespace WorkoutLog.Controllers
{
    public class WorkoutController : Controller
    {
        private readonly IWorkoutService _workoutService;

        private static List<WorkoutViewModel> _workoutList = new List<WorkoutViewModel>();


        public WorkoutController(IWorkoutService workoutService)
        {
            _workoutService = workoutService;
        }

        public ActionResult Index(string type)
        {
            IEnumerable<WorkoutViewModel> workouts = _workoutList;
            if (!string.IsNullOrEmpty(type))
            {
                workouts = _workoutService.FilterWorkoutsByType(workouts, type);
            }
            return View(workouts);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WorkoutViewModel model)
        {
            if (ModelState.IsValid)
            {
                _workoutList.Add(model);
                TempData["SuccessMessage"] = "Тренировка успешно сохранена!";
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
