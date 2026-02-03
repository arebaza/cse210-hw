public class MathAssignment : Assignment
{
    // These variables store math-specific data
    private string _textbookSection;
    private string _problemas;

    // Constructor receives all values and calls the base constructor
    public MathAssignment(string studentName, string topic, string textbookSection, string problemas)
        : base(studentName, topic)
    {
        _textbookSection = textbookSection;
        _problemas = problemas;
    }

    // This method returns the math homework details
    public string GetHomeworkList()
    {
        return $"Section {_textbookSection} Problems {_problemas}";
    }
}
