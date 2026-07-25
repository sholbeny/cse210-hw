using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Create the first video.
        Video video1 = new Video(
            "How to Make Chocolate Chip Cookies",
            "Sammi's Kitchen",
            625
        );

        video1.AddComment(new Comment(
            "Emily",
            "These cookies look delicious!"
        ));

        video1.AddComment(new Comment(
            "Jordan",
            "I tried this recipe and it turned out great."
        ));

        video1.AddComment(new Comment(
            "Michael",
            "Can I use dark chocolate chips instead?"
        ));

        videos.Add(video1);

        // Create the second video.
        Video video2 = new Video(
            "Top Places to Visit in Germany",
            "European Adventures",
            842
        );

        video2.AddComment(new Comment(
            "Anna",
            "Heidelberg is one of my favorite cities."
        ));

        video2.AddComment(new Comment(
            "David",
            "I would love to visit Cologne Cathedral."
        ));

        video2.AddComment(new Comment(
            "Sophie",
            "Germany has so many beautiful places."
        ));

        video2.AddComment(new Comment(
            "Chris",
            "Thank you for the travel suggestions!"
        ));

        videos.Add(video2);

        // Create the third video.
        Video video3 = new Video(
            "C# Classes for Beginners",
            "Coding Made Simple",
            734
        );

        video3.AddComment(new Comment(
            "Taylor",
            "This made classes much easier to understand."
        ));

        video3.AddComment(new Comment(
            "Alex",
            "The examples were very helpful."
        ));

        video3.AddComment(new Comment(
            "Morgan",
            "Could you make another video about encapsulation?"
        ));

        videos.Add(video3);

        // Create the fourth video.
        Video video4 = new Video(
            "Relaxing Piano Music",
            "Peaceful Sounds",
            3600
        );

        video4.AddComment(new Comment(
            "Grace",
            "This helps me focus while studying."
        ));

        video4.AddComment(new Comment(
            "Daniel",
            "The music is very peaceful."
        ));

        video4.AddComment(new Comment(
            "Olivia",
            "I listen to this before going to sleep."
        ));

        videos.Add(video4);

        // Display information about every video.
        foreach (Video video in videos)
        {
            Console.WriteLine("========================================");
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine();
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine(
                    $"- {comment.GetName()}: {comment.GetText()}"
                );
            }

            Console.WriteLine();
        }
    }
}