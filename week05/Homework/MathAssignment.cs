public class MathAssignment : Assignment
{
    private string _textbookSection;
    private string _problems;

    // Constructor requires all four values, calls base constructor
    public MathAssignment(string studentName, string topic, string textbookSection, string problems)
        : base(studentName, topic)
    {
        _textbookSection = textbookSection;
        _problems = problems;
    }

    // Returns "Section 7.3 Problems 8-19"
    public string GetHomeworkList()
    {
        return $"Section {_textbookSection} Problems {_problems}";
    }
}
