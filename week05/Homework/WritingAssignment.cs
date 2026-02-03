public class WritingAssignment : Assignment
{
    private string _title;

    // Constructor requires student name, topic, title
    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        _title = title;
    }

    // Returns "The Causes of World War II by Mary Waters"
    public string GetWritingInformation()
    {
        // Can't access _studentName directly because it's private in the base class,
        // so we use the public getter method.
        return $"{_title} by {GetStudentName()}";
    }
}
