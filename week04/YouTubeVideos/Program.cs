/*
 * Creativity:
 * I added clean, structured formatting to the output so each video and its comments
 * are clearly separated and easy to read. This simulates how a real system might
 * present information while keeping the program simple and aligned with requirements.
 */

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Video v1 = new Video("How to Cook Lomo Saltado", "Chef Peru", 420);
        v1.AgregarComentario(new Comment("Ana", "Looks delicious!"));
        v1.AgregarComentario(new Comment("Luis", "I will try this recipe today."));
        v1.AgregarComentario(new Comment("Marcos", "Great tips, thank you!"));

        Video v2 = new Video("C# Basics: Classes and Objects", "BYU-I Helper", 600);
        v2.AgregarComentario(new Comment("Sofia", "This made classes so clear."));
        v2.AgregarComentario(new Comment("Diego", "Good explanation of instances."));
        v2.AgregarComentario(new Comment("Karen", "Please make more videos like this."));

        Video v3 = new Video("Top 5 Places in Peru", "Travel Mundo", 510);
        v3.AgregarComentario(new Comment("Cathy", "Peru is beautiful!"));
        v3.AgregarComentario(new Comment("Ben", "I want to visit Cusco."));
        v3.AgregarComentario(new Comment("Nina", "Great video and nice music."));

        List<Video> videos = new List<Video> { v1, v2, v3 };

        foreach (Video video in videos)
        {
            Console.WriteLine("========================================");
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment c in video.GetComments())
            {
                Console.WriteLine($" - {c.GetName()}: {c.GetText()}");
            }

            Console.WriteLine();
        }
    }
}
