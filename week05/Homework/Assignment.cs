public class Assignment
{
    private string _studentName;
    private string _topic;

    // Constructor requires student name and topic
    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    // Returns "Student Name - Topic"
    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }

    // Getter method so derived classes can access student name safely
    public string GetStudentName()
    {
        return _studentName;
    }
}
