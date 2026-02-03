public class WritingAssignment : Assignment
{
    // This variable stores the title of the writing assignment
    private string _titulo;

    // Constructor sets writing-specific data and uses the base constructor
    public WritingAssignment(string studentName, string topic, string titulo)
        : base(studentName, topic)
    {
        _titulo = titulo;
    }

    // This method returns the writing information
    public string GetWritingInformation()
    {
        // We cannot access the student name directly because it is private,
        // so we use the getter method from the base class
        return $"{_titulo} by {ObtenerNombreEstudiante()}";
    }
}
