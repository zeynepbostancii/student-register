namespace StudentRegister;

/// <summary>Signature of the methods that can listen to a student's <see cref="Student.OnMarkAdded"/> event.</summary>
/// <param name="msg">A message describing the mark that was added.</param>
public delegate void MarkHandler(string msg);

/// <summary>A student who receives marks in a course.</summary>
public class Student : Person
{
    private int _mark;

    /// <summary>Raised exactly once each time a valid mark is added with <see cref="AddMark"/>.</summary>
    public event MarkHandler? OnMarkAdded;

    /// <summary>The course this student is taking (stretch goal).</summary>
    public CourseCode Course { get; }

    /// <summary>The student's current mark. Only values from 0 to 100 are accepted.</summary>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the value is below 0 or above 100.</exception>
    public int Mark
    {
        get => _mark;
        set
        {
            if (value < 0 || value > 100)
                throw new ArgumentOutOfRangeException(nameof(value), value, "Mark must be between 0 and 100.");
            _mark = value;
        }
    }

    /// <summary>Creates a student and passes the name and id up to the <see cref="Person"/> base constructor.</summary>
    /// <param name="name">The student's full name.</param>
    /// <param name="id">The student number.</param>
    /// <param name="course">The course the student is taking.</param>
    public Student(string name, string id, CourseCode course) : base(name, id)
    {
        Course = course;
    }

    /// <summary>
    /// Sets a new mark and raises <see cref="OnMarkAdded"/> once.
    /// If the mark is invalid, the setter throws before the event is raised, so nothing fires.
    /// </summary>
    /// <param name="mark">The mark to add, from 0 to 100.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the mark is outside 0 to 100.</exception>
    public void AddMark(int mark)
    {
        Mark = mark; // validation happens here
        OnMarkAdded?.Invoke($"{Name} received {mark} in {Course}");
    }

    /// <summary>Prints the student's name, number, course and mark.</summary>
    public override void Describe()
    {
        // id is the protected field inherited from Person
        Console.WriteLine($"Student: {Name} (No: {id}) | Course: {Course} | Mark: {Mark}");
    }
}
