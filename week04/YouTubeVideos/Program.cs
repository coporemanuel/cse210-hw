using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("C# for Beginners", "TechAcademy", 1200);
        video1.AddComment(new Comment("Alison", "Great tutorial, very clear!"));
        video1.AddComment(new Comment("Neil", "I finally understand classes, thanks!"));
        video1.AddComment(new Comment("Manuel", "More examples would be great!"));
        videos.Add(video1);

        Video video2 = new Video("Advanced OOP Concepts", "CodeMaster", 1800);
        video2.AddComment(new Comment("David", "Fantastic explanation of polymorphism!"));
        video2.AddComment(new Comment("Eva", "Encapsulation is now my favorite thing."));
        video2.AddComment(new Comment("Franco", "Could you cover abstract classes next?"));
        videos.Add(video2);

        Video video3 = new Video("C# Design Patterns", "DevInsights", 2400);
        video3.AddComment(new Comment("Graciela", "Singleton pattern always confuses me."));
        video3.AddComment(new Comment("Francisco", "Great breakdown of factory patterns!"));
        video3.AddComment(new Comment("Ines", "Very well-structured, thanks!"));
        videos.Add(video3);

        foreach (var video in videos)
        {
            video.DisplayInfo();
        }
    }
}
