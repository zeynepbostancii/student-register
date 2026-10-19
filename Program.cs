namespace StudentRegister;

/// <summary>Entry point of the Student Register console app.</summary>
public static class Program
{
    /// <summary>Creates two students, subscribes to their events, adds marks and prints them.</summary>
    public static void Main()
    {
        // Person p = new Person("X", "0");  // does not compile: Person is abstract

        var visual = new CourseCode("CPE 317", 3);

        // 1) Create 2 students
        var zeynep = new Student("Zeynep Bostancı", "2310213066", visual);
        var melih = new Student("Melih Şafak", "2310213099", visual);

        // 2) Subscribe
        zeynep.OnMarkAdded += PrintNotification;
        melih.OnMarkAdded += PrintNotification;

        // 3) Add marks
        Console.WriteLine("--- Adding marks ---");
        zeynep.AddMark(85);
        melih.AddMark(92);

        // An invalid mark is rejected and the event does not fire
        try
        {
            zeynep.AddMark(150);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Rejected: {ex.Message.Split(Environment.NewLine)[0]}");
        }

        // 4) Print, through the base type (polymorphism: the override runs)
        Console.WriteLine();
        Console.WriteLine("--- Register ---");
        Person[] register = { zeynep, melih };
        foreach (Person person in register)
            person.Describe();
    }

    /// <summary>Handler that matches the <see cref="MarkHandler"/> delegate.</summary>
    /// <param name="msg">The message sent by the event.</param>
    private static void PrintNotification(string msg)
    {
        Console.WriteLine($"[Event] {msg}");
    }
}
