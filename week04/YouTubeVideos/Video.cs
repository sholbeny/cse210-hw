using System.Collections.Generic;

public class Video
{
    private string _title;
    private string _author;
    private int _length;
    private int _likes;
    private int _views;
    private List<Comment> _comments;

    public Video(
        string title,
        string author,
        int length,
        int likes,
        int views
    )
    {
        _title = title;
        _author = author;
        _length = length;
        _likes = likes;
        _views = views;
        _comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return _comments.Count;
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

    public int GetLikes()
    {
        return _likes;
    }

    public int GetViews()
    {
        return _views;
    }

    public List<Comment> GetComments()
    {
        return _comments;
    }
}