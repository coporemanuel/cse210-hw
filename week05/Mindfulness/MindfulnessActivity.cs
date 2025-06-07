public abstract class MindfulnessActivity
{
    protected string Name;
    protected string Description;
    protected int Duration;

    public MindfulnessActivity(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void StartActivity()
    {
        Console.WriteLine($"Starting {Name}...\n{Description}");
        Console.Write("Enter duration in seconds: ");
        Duration = int.Parse(Console.ReadLine());

        Console.WriteLine("Prepare to begin...");
        ShowAnimation();

        RunActivity();
        EndActivity();
    }

    protected abstract void RunActivity();

    protected void ShowAnimation()
    {
        for (int i = 3; i > 0; i--)
        {
            Console.Write($"\rStarting in {i}...");
            System.Threading.Thread.Sleep(1000);
        }
        Console.WriteLine("\nBegin!");
    }

    protected void EndActivity()
    {
        Console.WriteLine($"Great job! You completed {Name} for {Duration} seconds.");
        ShowAnimation();
    }
}
