using System.Collections.Generic;

namespace Routine.Models
{
  public class Exercise
  {
    public string Description { get; set; }
    public int Id { get; }
    private static List<Exercise> _instances = new List<Exercise> {};

    public Exercise (string description)
    {
      Description = description;
      _instances.Add(this);
      Id = _instances.Count;
    }

    public static List<Exercise> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static Exercise Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}
