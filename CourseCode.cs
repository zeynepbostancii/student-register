namespace StudentRegister;

/// <summary>A course identifier together with its credit value (stretch goal: a value type).</summary>
public struct CourseCode
{
    /// <summary>The course code, e.g. "CPE 317".</summary>
    public string Code { get; }

    /// <summary>The number of credits the course is worth.</summary>
    public int Credits { get; }

    /// <summary>Creates a course code.</summary>
    /// <param name="code">The course code, e.g. "CPE 317".</param>
    /// <param name="credits">The number of credits.</param>
    public CourseCode(string code, int credits)
    {
        Code = code;
        Credits = credits;
    }

    /// <summary>Returns the course as text, e.g. "CPE 317 (3 cr)".</summary>
    /// <returns>A short text form of the course.</returns>
    public override string ToString() => $"{Code} ({Credits} cr)";
}
