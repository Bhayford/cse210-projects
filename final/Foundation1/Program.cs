using System;
using System.Collections.Generic;

// Define the Comment class
class Comment
{
    private string _author;
    private string _text;

    public Comment(string author, string text)
    {
        _author = author;
        _text = text;
    }

    public string GetAuthor()
    {
        return _author;
    }

    public string GetText()
    {
        return _text;
    }
}

// Define the Video class
class Video
{
    private string _title;
    private string _author;
    private int _length; // Length in seconds
    private List<Comment> _comments;

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
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

    public List<Comment> GetComments()
    {
        return _comments;
    }
}

// Main Program
class Program
{
    static void Main(string[] args)
    {
        // Create videos
        var video1 = new Video("Exploring the Galaxy", "Space Explorer", 900);
        var video2 = new Video("Deep Sea Adventures", "Ocean Diver", 1500);
        var video3 = new Video("Mountain Hiking Tips", "Nature Lover", 1100);

        // Add comments to videos
        video1.AddComment(new Comment("Ethan", "Amazing video!"));
        video1.AddComment(new Comment("Olivia", "Very informative, thanks!"));
        video1.AddComment(new Comment("Liam", "Loved the visuals."));

        video2.AddComment(new Comment("Sophia", "Great content but a bit lengthy."));
        video2.AddComment(new Comment("James", "Perfect for underwater enthusiasts."));
        video2.AddComment(new Comment("Amelia", "Very detailed and engaging."));

        video3.AddComment(new Comment("Lucas", "Hiking tips explained well."));
        video3.AddComment(new Comment("Mia", "I finally understand the essentials!"));
        video3.AddComment(new Comment("Henry", "Clear and concise."));

        // Store videos in a list
        var videos = new List<Video> { video1, video2, video3 };

        // Display video details and comments
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");

            Console.WriteLine("Comments:");
            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.GetAuthor()}: {comment.GetText()}");
            }
            Console.WriteLine();
        }
    }
}
