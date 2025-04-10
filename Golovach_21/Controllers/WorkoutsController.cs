using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WorkoutLog.Models;

namespace WorkoutLog.Controllers
{
    public class WorkoutsController : Controller
    {
        private readonly WorkoutDbContext _context;

        public WorkoutsController(WorkoutDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(DateTime? filterDate)
        {
            var workouts = _context.Workouts.AsQueryable();

            if (filterDate.HasValue)
            {
                DateTime dateOnly = filterDate.Value.Date;
                workouts = workouts.Where(w => w.Date.Date == dateOnly);
            }

            DateTime referenceDate = filterDate ?? DateTime.Today;

            int diff = (7 + ((int)referenceDate.DayOfWeek - (int)DayOfWeek.Monday)) % 7;
            DateTime weekStart = referenceDate.AddDays(-diff).Date;
            DateTime weekEnd = weekStart.AddDays(7);

            var weeklyWorkouts = _context.Workouts
                .Where(w => w.Date.Date >= weekStart && w.Date.Date < weekEnd)
                .ToList();

            int totalDuration = weeklyWorkouts.Sum(w => w.Duration);

            ViewBag.FilterDate = filterDate.HasValue ? filterDate.Value.ToString("yyyy-MM-dd") : "";
            ViewBag.WeekStart = weekStart.ToString("yyyy-MM-dd");
            ViewBag.WeekEnd = weekEnd.ToString("yyyy-MM-dd");
            ViewBag.TotalDuration = totalDuration;

            return View(workouts.OrderBy(w => w.Date).ToList());
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return StatusCode(400);

            var workout = _context.Workouts.Find(id);
            if (workout == null)
                return NotFound();

            return View(workout);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Date,Exercise,Duration,Notes")] Workout workout)
        {
            if (ModelState.IsValid)
            {
                _context.Workouts.Add(workout);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(workout);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
                return StatusCode(400);

            var workout = _context.Workouts.Find(id);
            if (workout == null)
                return NotFound();

            return View(workout);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Date,Exercise,Duration,Notes")] Workout workout)
        {
            if (id != workout.Id)
                return StatusCode(400);

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workout);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Workouts.Any(e => e.Id == workout.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(workout);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return StatusCode(400);

            var workout = _context.Workouts.Find(id);
            if (workout == null)
                return NotFound();

            return View(workout);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var workout = _context.Workouts.Find(id);
            if (workout != null)
            {
                _context.Workouts.Remove(workout);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
