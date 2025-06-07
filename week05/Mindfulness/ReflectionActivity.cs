using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;

public class ReflectionActivity : MindfulnessActivity
{
    private static readonly string[] Prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private static readonly string[] Questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity() : base("Reflection Exercise", 
        "This activity helps you reflect on times in your life when you have shown strength and resilience.\n" +
        "This will help you recognize the power you have and how you can use it in other aspects of your life.") { }

    protected override void RunActivity()
    {
    // Random question selection
        Console.WriteLine($"\nPrompt: {Prompts[new Random().Next(Prompts.Length)]}");
        ShowAnimation();

        int cycles = Duration / 4;
        for (int i = 0; i < cycles; i++)
        {
            Console.WriteLine(Questions[new Random().Next(Questions.Length)]);
            ShowCountdown(4);
        }
    }

    private void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\r{i}...");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}
