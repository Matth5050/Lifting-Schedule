using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Routine.Models;


namespace Routine.Controllers
{
  public class DaysController : Controller
  {
    [HttpGet("/days")]
    public ActionResult Index()
    {
      List<Day> allDays = Day.GetAll();
      return View(allDays);
    }

    [HttpGet("/days/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/days")]
    public ActionResult Create(string dayName)
    {
      Day newDay = new Day(dayName);
      return RedirectToAction("Index");
    }

    [HttpGet("/days/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Day selectedDay = Day.Find(id);
      List<Exercise> dayExercises = selectedDay.Exercises;
      model.Add("day", selectedDay);
      model.Add("exercises", dayExercises);
      return View(model);
    }
    // this one creates new exercises within a given day, not new days;
    [HttpPost("/days/{dayId}/exercises")]
    public ActionResult Create(int dayId, string exerciseDescription)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Day foundDay = Day.Find(dayId);
      Exercise newExercise = new Exercise(exerciseDescription);
      foundDay.AddExercise(newExercise);
      List<Exercise> dayExercises = foundDay.Exercises;
      model.Add("exercises", dayExercises);
      model.Add("day", foundDay);
      return View("Show", model);
    }
  }
}