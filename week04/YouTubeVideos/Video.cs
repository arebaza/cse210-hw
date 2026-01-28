using System.Collections.Generic;

public class Video
{
    private string _title;
    private string _author;
    private int _length; // seconds
    private List<Comment> _comments;

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }

    // Spanish method name is OK as long as it follows TitleCase (rubric naming convention)
    public void AgregarComentario(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        // Required behavior: return the number of comments based on storage (Count)
        return _comments.Count;
    }

    public List<Comment> GetComments()
    {
        return _comments;
    }

    public string GetTitle()
    {
        return _title;
    }

    public string GetAuthor()
    {
        return _author;
    }

    public int GetLength()
    {
        return _length;
    }
}
