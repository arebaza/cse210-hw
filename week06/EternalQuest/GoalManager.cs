using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private const string ArchivoMetas = "goals.txt"; // Spanish constant name, comment in English

    private List<Goal> _goals;
    private int _score;

    private int nivelActual;       // Spanish variable name
    private string tituloActual;   // Spanish variable name

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        nivelActual = 1;
        tituloActual = "Beginner";
    }

    public void Start()
    {
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine();
            DisplayPlayerInfo();
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");

            int opcion = PedirEntero("Select a choice from the menu: ", 1, 6);

            switch (opcion)
            {
                case 1:
                    CreateGoal();
                    break;
                case 2:
                    ListGoalDetails();
                    break;
                case 3:
                    SaveGoals();
                    break;
                case 4:
                    LoadGoals();
                    break;
                case 5:
                    RecordEvent();
                    break;
                case 6:
                    salir = true;
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        UpdateLevelSystem();
        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine($"Level: {nivelActual}  Title: {tituloActual}");
        Console.WriteLine($"Save file: {ArchivoMetas}");
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals created yet.");
            return;
        }

        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine();
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");

        int tipo = PedirEntero("Which type of goal would you like to create? ", 1, 3);

        string name = PedirTexto("What is the name of your goal? ");
        string description = PedirTexto("What is a short description of it? ");
        int points = PedirEntero("What is the amount of points associated with this goal? ", 1, 1_000_000);

        if (tipo == 1)
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (tipo == 2)
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else
        {
            int target = PedirEntero("How many times does this goal need to be accomplished for a bonus? ", 1, 1_000_000);
            int bonus = PedirEntero("What is the bonus for accomplishing it that many times? ", 0, 1_000_000);
            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }

        Console.WriteLine("Goal created.");
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available to record. Create a goal first.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }

        int index = PedirEntero("Which goal did you accomplish? ", 1, _goals.Count) - 1;

        int puntosGanados = _goals[index].RecordEvent();
        _score += puntosGanados;

        if (puntosGanados > 0)
        {
            Console.WriteLine($"Congratulations! You have earned {puntosGanados} points!");
        }
        else
        {
            Console.WriteLine("This goal is already completed (or no points were awarded).");
        }

        UpdateLevelSystem();
        Console.WriteLine($"You now have {_score} points.");
    }

    public void SaveGoals()
    {
        using (StreamWriter outputFile = new StreamWriter(ArchivoMetas))
        {
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine($"Goals saved to {ArchivoMetas}.");
    }

    public void LoadGoals()
    {
        if (!File.Exists(ArchivoMetas))
        {
            Console.WriteLine($"File not found: {ArchivoMetas}");
            return;
        }

        string[] lines = File.ReadAllLines(ArchivoMetas);

        if (lines.Length == 0)
        {
            Console.WriteLine("File is empty.");
            return;
        }

        _goals.Clear();

        if (!int.TryParse(lines[0], out _score))
        {
            Console.WriteLine("Invalid score in file.");
            _score = 0;
        }

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] parts = line.Split('|');

            if (parts.Length == 0) continue;

            string type = parts[0];

            try
            {
                if (type == "SimpleGoal")
                {
                    string name = parts[1];
                    string desc = parts[2];
                    int points = int.Parse(parts[3]);
                    bool isComplete = bool.Parse(parts[4]);

                    _goals.Add(new SimpleGoal(name, desc, points, isComplete));
                }
                else if (type == "EternalGoal")
                {
                    string name = parts[1];
                    string desc = parts[2];
                    int points = int.Parse(parts[3]);

                    _goals.Add(new EternalGoal(name, desc, points));
                }
                else if (type == "ChecklistGoal")
                {
                    string name = parts[1];
                    string desc = parts[2];
                    int points = int.Parse(parts[3]);
                    int target = int.Parse(parts[4]);
                    int bonus = int.Parse(parts[5]);
                    int amountCompleted = int.Parse(parts[6]);

                    _goals.Add(new ChecklistGoal(name, desc, points, target, bonus, amountCompleted));
                }
            }
            catch
            {
                Console.WriteLine($"Skipped an invalid line in the file: {line}");
            }
        }

        UpdateLevelSystem();
        Console.WriteLine($"Goals loaded from {ArchivoMetas}.");
    }

    private void UpdateLevelSystem()
    {
        int newLevel = (_score / 1000) + 1;

        if (newLevel != nivelActual)
        {
            nivelActual = newLevel;
            tituloActual = GetTitleForLevel(nivelActual);
            Console.WriteLine($"Level up! You are now Level {nivelActual} ({tituloActual}).");
        }
    }

    private string GetTitleForLevel(int level)
    {
        if (level >= 10) return "Legend";
        if (level >= 7) return "Master";
        if (level >= 5) return "Expert";
        if (level >= 3) return "Apprentice";
        return "Beginner";
    }

    private int PedirEntero(string prompt, int min, int max)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (int.TryParse(input, out int value) && value >= min && value <= max)
            {
                return value;
            }

            Console.WriteLine($"Please enter a number between {min} and {max}.");
        }
    }

    private string PedirTexto(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
            {
                return input.Trim();
            }

            Console.WriteLine("Please enter a value.");
        }
    }
}
