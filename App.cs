using System.Runtime.CompilerServices;

namespace Students;

internal class App
{
  private static void help()
  {
    Console.WriteLine("Grading system");
    Console.WriteLine("add-student [name] - Add student");
    Console.WriteLine("select-student [name] - Select a student");
    Console.WriteLine("add-grade [course] [grade] - Add a grade for a course for the current selected student");
    Console.WriteLine("end - Stop the program");
  }

  private static void Main(string[] args)
  {
    Student? student = null;
    List<Student> students = new();

    while (true)
    {
      Console.Write("Input command:");
      string? command = Console.ReadLine();

      if (command == null)
      {
        Console.WriteLine("Please enter a valid command");
        help();
        continue;
      }
      if (command == "help")
      {
        help();
      }
      if (command == "end" || command == "quit")
      {
        break;
      }
      if (command.StartsWith("add-student"))
      {
        String name = command.Substring(11).Trim();
        student = new(name);
        students.Add(student);
      }
      if (command.StartsWith("select-student"))
      {
        String name = command.Substring(14).Trim();
        student = students.Find(p => p.GetName().Equals(name));

        if (student == null)
        {
          Console.WriteLine($"Student {name} not found");
        }
        else
        {
          Console.WriteLine($"Student {name} is selected");
        }
      }
      if (command.StartsWith("add-grade"))
      {
        String[] arguments = command.Substring(9).Trim().Split(" ");
        if (student == null)
        {
          Console.WriteLine("No student is selected");
        }
        else
        {
          student.AddGrade(arguments[0], Convert.ToDouble(arguments[1]));
        }
      }
    }

    students.ForEach(s => s.Totals());
  }
}