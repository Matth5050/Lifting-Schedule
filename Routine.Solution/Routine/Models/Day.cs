using System.Collections.Generic;

namespace Routine.Models
{
  public class Day
  {
    private static List<Day> _instances = new List<Day> {};
    public string Name { get; set; }
    public int Id { get; }
    public List <Exercise> Exercises { get; set; }
  

    public Day(string dayName)
    {
        Name = dayName;
        _instances.Add(this);
        Id = _instances.Count;
        Exercises = new List<Exercise> { };
    }

    public static List<Day> GetAll()
    {
      return _instances;
    }

    public static Day Find(int searchId)
    {
      return _instances[searchId - 1];
    }

    public void AddExercise(Exercise exercise)
    {
      Exercises.Add(exercise);
    }
  }
}