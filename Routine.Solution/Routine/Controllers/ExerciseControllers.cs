using Microsoft.AspNetCore.Mvc;
using Routine.Models;
using System.Collections.Generic;

namespace Routine.Controllers
{
  public class ExercisesController : Controller
  {

   [HttpGet("/days/{dayId}/exercises/new")]
    public ActionResult New(int dayId)
    {
      Day day = Day.Find(dayId);
      return View(day);
    }

    [HttpGet("/days/{dayId}/exercises/{exerciseId}")]
    public ActionResult Show(int dayId, int exerciseId)
    {
      Exercise exercise = Exercise.Find(exerciseId);
      Day day = Day.Find(dayId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("exercise", exercise);
      model.Add("day", day);
      return View(model);
    }

  }
}