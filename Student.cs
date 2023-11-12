namespace Students;

public class Student
{
  private readonly String name;

  private readonly List<Course> courses = new();

  public Student(String name)
  {
    this.name = name;
  }

  public String GetName()
  {
    return name;
  }

  public void AddGrade(String course, Double grade)
  {
    Course? c = courses.Find(p => p.GetName().Equals(course));

    if (c == null)
    {
      c = new(course);
      courses.Add(c);
    }

    c.AddGrade(grade);
  }

  public void Totals()
  {
    Console.WriteLine($"Grades for {name}");
    courses.ForEach(c => c.Total());
  }
}