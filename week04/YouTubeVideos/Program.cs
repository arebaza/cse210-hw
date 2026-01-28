/*
 * Creativity:
 * I added clean, consistent formatting (headers and separators) to make the output
 * easier to read and closer to how a real system might display video data and comments.
 * This improves readability without adding user interaction or changing requirements.
 */

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create 3+ videos
        Video video1 = new Video("How to Cook Lomo Saltado", "Chef Peru", 420);
        Video video2 = new Video("C# Basics: Classes and Objects", "BYU-I Helper", 600);
        Video video3 = new Video("Top 5 Places in Peru", "Travel Mundo", 510);

        // Add 3+ comments for each video
        video1.AgregarComentario(new Comment("Ana", "Looks delicious!"));
        video1.AgregarComentario(new Comment("Luis", "I will try this recipe today."));
        video1.AgregarComentario(new Comment("Marcos", "Great tips, thank you!"));

        video2.AgregarComentario(new Comment("Sofia", "This made classes so clear."));
        video2.AgregarComentario(new Comment("Diego", "Good explanation of instances."));
        video2.AgregarComentario(new Comment("Karen", "Please make more videos like this."));

        video3.AgregarComentario(new Comment("Cathy", "Peru is beautiful!"));
        video3.AgregarComentario(new Comment("Ben", "I want to visit Cusco."));
        video3.AgregarComentario(new Comment("Nina", "Great video and nice music."));

        // Put videos in a list (required)
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Iterate through list and display required info (required)
        foreach (Video video in videos)
        {
            Console.WriteLine("========================================");
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length (seconds): {video.GetLength()}");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($" - {comment.GetName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }

        Console.WriteLine("========================================");
    }
}
