public class ListingActivity : MindfulnessActivity
{
    private static readonly string[] Prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing Exercise",
        "This activity helps you reflect on positive aspects of life.") { }

    protected override void RunActivity()
    {
        Console.WriteLine($"Prompt: {Prompts[new Random().Next(Prompts.Length)]}");
        ShowAnimation();
        Console.WriteLine("Start listing items...");

        int itemCount = 0;
        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("Enter an item: ");
            Console.ReadLine();
            itemCount++;
        }

        Console.WriteLine($"You listed {itemCount} items!");
    }
}