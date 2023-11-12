namespace Students;

public class Course 
{

  private readonly String name;

  private readonly List<Double> grades = new();  

  public Course(String name) 
  {
    this.name = name;
  }  

  public String GetName() {
    return name;
  }

  public void AddGrade(Double grade)
  {
    grades.Add(grade);
  }

  public void Total() {
    var count = grades.Count;
    var avg = grades.Sum() / grades.Count;

    Console.WriteLine($"{name} - {count} exams - {avg} avg");
  }
}