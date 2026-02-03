public class Assignment
{
    // These variables store common data shared by all assignments
    private string _studentName;
    private string _topic;

    // Constructor sets the student name and topic
    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    // This method returns a summary of the assignment
    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }

    // This method allows derived classes to safely access the student name
    public string ObtenerNombreEstudiante()
    {
        return _studentName;
    }
}
