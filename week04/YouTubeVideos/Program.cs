using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Video 1
        Video video1 = new Video(
            "Learn C# in 30 Minutes",
            "Code Academy",
            1800
        );

        video1.Comments.Add(new Comment("John", "This tutorial was very helpful!"));
        video1.Comments.Add(new Comment("Sarah", "I learned a lot from this video."));
        video1.Comments.Add(new Comment("Mike", "Great explanation of C#."));

        // Video 2
        Video video2 = new Video(
            "How to Build a Website",
            "Web Dev Channel",
            2400
        );

        video2.Comments.Add(new Comment("David", "This helped me build my first website."));
        video2.Comments.Add(new Comment("Emma", "Very easy to understand."));
        video2.Comments.Add(new Comment("James", "Please make more tutorials like this."));

        // Video 3
        Video video3 = new Video(
            "Introduction to Python",
            "Programming World",
            2100
        );

        video3.Comments.Add(new Comment("Daniel", "Python is easier than I expected."));
        video3.Comments.Add(new Comment("Grace", "Excellent introduction."));
        video3.Comments.Add(new Comment("Peter", "I will definitely watch the next lesson."));
        video3.Comments.Add(new Comment("Mary", "Very useful video!"));

        // Video 4
        Video video4 = new Video(
            "Understanding Databases",
            "Tech Tutorials",
            2700
        );

        video4.Comments.Add(new Comment("Alex", "Now I understand databases better."));
        video4.Comments.Add(new Comment("Chris", "Great tutorial!"));
        video4.Comments.Add(new Comment("Linda", "The examples were really helpful."));

        // Put all videos into a list
        List<Video> videos = new List<Video>
        {
            video1,
            video2,
            video3,
            video4
        };

        // Display each video and its comments
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");

            Console.WriteLine("Comments:");

            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine($"- {comment.Name}: {comment.Text}");
            }

            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine();
        }
    }
}