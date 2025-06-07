public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity() : base("Breathing Exercise", 
        "This activity helps you relax by guiding you through deep breathing.") { }

    protected override void RunActivity()
    {
        int cycles = Duration / 6; // Each cycle lasts about 6 seconds
        for (int i = 0; i < cycles; i++)
        {
            Console.WriteLine("Breathe in...");
            ShowCountdown(3);
            Console.WriteLine("Breathe out...");
            ShowCountdown(3);
        }
    }

    private void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\r{i}...");
            System.Threading.Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}
