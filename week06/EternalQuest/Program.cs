using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static int score = 0;
    static List<Goal> goals = new List<Goal>();

    static void Main()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("Eternal Quest");
            Console.WriteLine("-------------------------");
            Console.WriteLine($"Score: {score}");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Display Score");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Quit");
            Console.Write("Select a choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;

                case "2":
                    ListGoals();
                    break;

                case "3":
                    RecordEvent();
                    break;

                case "4":
                    DisplayScore();
                    break;

                case "5":
                    SaveGoals();
                    break;

                case "6":
                    LoadGoals();
                    break;

                case "7":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    static void CreateGoal()
    {
        Console.WriteLine();
        Console.WriteLine("Create Goal");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Choose a goal type: ");

        string type = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();

        Console.Write("Enter description: ");
        string description = Console.ReadLine();

        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == "2")
        {
            goals.Add(new EternalGoal(name, description, points));
        }
        else if (type == "3")
        {
            Console.Write("How many times must this goal be completed? ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("Enter bonus points: ");
            int bonus = int.Parse(Console.ReadLine());

            goals.Add(new ChecklistGoal(
                name,
                description,
                points,
                target,
                bonus
            ));
        }
        else
        {
            Console.WriteLine("Invalid goal type.");
            return;
        }

        Console.WriteLine("Goal created successfully!");
    }

    static void ListGoals()
    {
        Console.WriteLine();
        Console.WriteLine("Your Goals:");

        if (goals.Count == 0)
        {
            Console.WriteLine("No goals have been created.");
            return;
        }

        for (int i = 0; i < goals.Count; i++)
        {
            Console.Write($"{i + 1}. ");
            Console.WriteLine(goals[i].GetDetails());
        }
    }

    static void RecordEvent()
    {
        Console.WriteLine();

        if (goals.Count == 0)
        {
            Console.WriteLine("There are no goals to record.");
            return;
        }

        ListGoals();

        Console.Write("Which goal did you accomplish? ");
        int choice = int.Parse(Console.ReadLine());

        if (choice < 1 || choice > goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        int pointsEarned = goals[choice - 1].RecordEvent();

        score += pointsEarned;

        Console.WriteLine($"You earned {pointsEarned} points!");
        Console.WriteLine($"Your total score is now {score}.");

        // Creativity feature:
        // The player levels up every 1000 points.
        int level = (score / 1000) + 1;
        Console.WriteLine($"You are currently Quest Level {level}!");
    }

    static void DisplayScore()
    {
        int level = (score / 1000) + 1;

        Console.WriteLine();
        Console.WriteLine($"Your score is: {score}");
        Console.WriteLine($"Your Quest Level is: {level}");
    }

    static void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            writer.WriteLine(score);

            foreach (Goal goal in goals)
            {
                writer.WriteLine(goal.Save());
            }
        }

        Console.WriteLine("Goals saved successfully.");
    }

    static void LoadGoals()
    {
        if (!File.Exists("goals.txt"))
        {
            Console.WriteLine("No saved file found.");
            return;
        }

        string[] lines = File.ReadAllLines("goals.txt");

        score = int.Parse(lines[0]);
        goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split("|");

            string type = parts[0];
            string name = parts[1];
            string description = parts[2];
            int points = int.Parse(parts[3]);

            if (type == "SimpleGoal")
            {
                bool completed = bool.Parse(parts[4]);

                SimpleGoal goal =
                    new SimpleGoal(name, description, points);

                goal.SetCompleted(completed);
                goals.Add(goal);
            }
            else if (type == "EternalGoal")
            {
                goals.Add(
                    new EternalGoal(name, description, points)
                );
            }
            else if (type == "ChecklistGoal")
            {
                int target = int.Parse(parts[4]);
                int bonus = int.Parse(parts[5]);
                int completed = int.Parse(parts[6]);

                ChecklistGoal goal =
                    new ChecklistGoal(
                        name,
                        description,
                        points,
                        target,
                        bonus
                    );

                goal.SetCompletedCount(completed);
                goals.Add(goal);
            }
        }

        Console.WriteLine("Goals loaded successfully.");
    }
}

// BASE CLASS

abstract class Goal
{
    private string _name;
    private string _description;
    private int _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetPoints()
    {
        return _points;
    }

    // Polymorphism:
    // Derived classes override these methods.
    public abstract int RecordEvent();

    public abstract string GetDetails();

    public abstract string Save();
}


// SIMPLE GOAL

class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(
        string name,
        string description,
        int points)
        : base(name, description, points)
    {
        _isComplete = false;
    }

    public override int RecordEvent()
    {
        if (_isComplete)
        {
            return 0;
        }

        _isComplete = true;

        return GetPoints();
    }

    public override string GetDetails()
    {
        string status = _isComplete ? "[X]" : "[ ]";

        return $"{status} {GetName()} ({GetDescription()})";
    }

    public override string Save()
    {
        return $"SimpleGoal|{GetName()}|{GetDescription()}|{GetPoints()}|{_isComplete}";
    }

    public void SetCompleted(bool completed)
    {
        _isComplete = completed;
    }
}


// ETERNAL GOAL

class EternalGoal : Goal
{
    public EternalGoal(
        string name,
        string description,
        int points)
        : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        return GetPoints();
    }

    public override string GetDetails()
    {
        return $"[ ] {GetName()} ({GetDescription()})";
    }

    public override string Save()
    {
        return $"EternalGoal|{GetName()}|{GetDescription()}|{GetPoints()}";
    }
}


// CHECKLIST GOAL

class ChecklistGoal : Goal
{
    private int _target;
    private int _bonus;
    private int _completedCount;

    public ChecklistGoal(
        string name,
        string description,
        int points,
        int target,
        int bonus)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _completedCount = 0;
    }

    public override int RecordEvent()
    {
        if (_completedCount >= _target)
        {
            return 0;
        }

        _completedCount++;

        int earnedPoints = GetPoints();

        if (_completedCount == _target)
        {
            earnedPoints += _bonus;
        }

        return earnedPoints;
    }

    public override string GetDetails()
    {
        string status = _completedCount >= _target ? "[X]" : "[ ]";

        return $"{status} {GetName()} ({GetDescription()}) " +
               $"-- Completed {_completedCount}/{_target} times";
    }

    public override string Save()
    {
        return $"ChecklistGoal|{GetName()}|{GetDescription()}|" +
               $"{GetPoints()}|{_target}|{_bonus}|{_completedCount}";
    }

    public void SetCompletedCount(int count)
    {
        _completedCount = count;
    }
}
