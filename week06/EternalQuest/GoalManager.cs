using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class GoalManager
{
    private List<Goal> _goals = new();
    private int _score = 0;

    public void AddGoal(Goal goal) => _goals.Add(goal);

    public void RecordGoalEvent(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            _score += _goals[goalIndex].RecordEvent();
        }
    }

    public void ShowGoals()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()}");
        }
    }

    public void ShowScore() => Console.WriteLine($"Total Score: {_score}");

    public void SaveToFile(string filename)
    {
        using StreamWriter outputFile = new(filename);
        outputFile.WriteLine(_score);
        foreach (Goal goal in _goals)
        {
            outputFile.WriteLine(goal.GetStringRepresentation());
        }
    }

    public void LoadFromFile(string filename)
    {
        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);
        _goals.Clear();

        foreach (string line in lines.Skip(1))
        {
            string[] parts = line.Split('|');
            string type = parts[0];

            switch (type)
            {
                case "SimpleGoal":
                    _goals.Add(new SimpleGoal(
                        parts[1],
                        parts[2], 
                        int.Parse(parts[3]),
                        bool.Parse(parts[4]) 
                    ));
                    break;

                case "EternalGoal":
                    _goals.Add(new EternalGoal(
                        parts[1],
                        parts[2],
                        int.Parse(parts[3])
                    ));
                    break;

                case "ChecklistGoal":
                    var checklist = new ChecklistGoal(
                        parts[1], 
                        parts[2], 
                        int.Parse(parts[3]), 
                        int.Parse(parts[4]), 
                        int.Parse(parts[5])  
                    );

                    int completed = int.Parse(parts[6]);
                    for (int i = 0; i < completed; i++)
                    {
                        checklist.RecordEvent();
                    }

                    _goals.Add(checklist);
                    break;
            }
        }
    }

    public List<Goal> GetGoals() => _goals;
}
