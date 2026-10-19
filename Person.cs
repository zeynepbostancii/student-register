namespace StudentRegister;

/// <summary>
/// Base type for every person in the register.
/// It is abstract, so it cannot be instantiated directly (<c>new Person(...)</c> does not compile).
/// </summary>
public abstract class Person
{
    /// <summary>The person's full name.</summary>
    public string Name { get; }

    /// <summary>
    /// Identification number. Protected: visible to derived classes such as <see cref="Student"/>,
    /// but hidden from outside code.
    /// </summary>
    protected string id;

    /// <summary>Base constructor, called by every derived class.</summary>
    /// <param name="name">The person's full name.</param>
    /// <param name="id">The person's identification number.</param>
    protected Person(string name, string id)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty.", nameof(name));

        Name = name;
        this.id = id;
    }

    /// <summary>Prints a description of the person to the console. Each derived class decides how.</summary>
    public abstract void Describe();
}
