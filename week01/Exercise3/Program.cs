using System;

class Program
{
    static void Main(string[] args)
    {
        Random ramdoGenerator = new Random();
        int randomNumber = ramdoGenerator.Next(1, 101);

        int guess = -1;

        while (guess != randomNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (randomNumber > guess)
            {
                Console.WriteLine("Higher!");
            }
            else if (randomNumber < guess)
            {
                Console.WriteLine("Lower!");
            }
            else
            {
                Console.WriteLine("You guessed it!");
                Console.WriteLine($"The number was {randomNumber}");
            }
        }
    }
}