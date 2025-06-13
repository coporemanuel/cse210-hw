using System;

class Program
{
    static void Main()
    {
        GoalManager manager = new();
        int choice;

        do
        {
            Console.WriteLine("\nEternal Quest Menu:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Show Score");
            Console.WriteLine("5. Save Goals to File");
            Console.WriteLine("6. Load Goals from File");
            Console.WriteLine("0. Exit");
            Console.Write("Select an option: ");
            
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Please enter a valid number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine("\nSelect the type of goal:");
                    Console.WriteLine("1. Simple Goal");
                    Console.WriteLine("2. Eternal Goal");
                    Console.WriteLine("3. Checklist Goal");
                    Console.Write("Enter choice: ");
                    int goalType = int.Parse(Console.ReadLine());

                    Console.Write("Enter goal name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter goal description: ");
                    string description = Console.ReadLine();

                    Console.Write("Enter point value: ");
                    int points = int.Parse(Console.ReadLine());

                    switch (goalType)
                    {
                        case 1:
                            manager.AddGoal(new SimpleGoal(name, description, points));
                            Console.WriteLine("Simple Goal created!");
                            break;

                        case 2:
                            manager.AddGoal(new EternalGoal(name, description, points));
                            Console.WriteLine("Eternal Goal created!");
                            break;

                        case 3:
                            Console.Write("Enter number of times to complete for bonus: ");
                            int targetCount = int.Parse(Console.ReadLine());

                            Console.Write("Enter bonus points: ");
                            int bonusPoints = int.Parse(Console.ReadLine());

                            manager.AddGoal(new ChecklistGoal(name, description, points, targetCount, bonusPoints));
                            Console.WriteLine("Checklist Goal created!");
                            break;

                        default:
                            Console.WriteLine("Invalid goal type.");
                            break;
                    }
                    break;

                case 2:
                    Console.WriteLine("\nYour Goals:");
                    manager.ShowGoals();
                    break;

                case 3:
                    Console.WriteLine("\nWhich goal did you complete?");
                    manager.ShowGoals();
                    Console.Write("Enter the goal number: ");
                    int index = int.Parse(Console.ReadLine()) - 1;
                    manager.RecordGoalEvent(index);
                    Console.WriteLine("Event recorded!");
                    break;

                case 4:
                    manager.ShowScore();
                    break;

                case 5:
                    Console.Write("Enter filename to save goals: ");
                    string saveFile = Console.ReadLine();
                    manager.SaveToFile(saveFile);
                    Console.WriteLine("Goals saved!");
                    break;

                case 6:
                    Console.Write("Enter filename to load goals: ");
                    string loadFile = Console.ReadLine();
                    manager.LoadFromFile(loadFile);
                    Console.WriteLine("Goals loaded!");
                    break;

                case 0:
                    Console.WriteLine("Thanks for using Eternal Quest. Keep leveling up!");
                    break;

                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
        while (choice != 0);
    }
}
