using System;
using System.Collections.Generic;
using System.IO;

public class ActivityLog
{
    private readonly string _filePath;
    private Dictionary<string, (int Count, int TotalSeconds)> _stats;

    public ActivityLog(string filePath)
    {
        _filePath = filePath;
        _stats = new Dictionary<string, (int, int)>();
    }

    // This loads stats from a file if it exists.
    public void Load()
    {
        if (!File.Exists(_filePath))
        {
            return;
        }

        string[] lines = File.ReadAllLines(_filePath);

        foreach (string line in lines)
        {
            // Expected format: Name|Count|TotalSeconds
            string[] parts = line.Split('|');
            if (parts.Length != 3) continue;

            string name = parts[0];

            if (int.TryParse(parts[1], out int count) &&
                int.TryParse(parts[2], out int totalSeconds))
            {
                _stats[name] = (count, totalSeconds);
            }
        }
    }

    // This saves stats to a file.
    public void Save()
    {
        List<string> lines = new List<string>();

        foreach (var kvp in _stats)
        {
            lines.Add($"{kvp.Key}|{kvp.Value.Count}|{kvp.Value.TotalSeconds}");
        }

        File.WriteAllLines(_filePath, lines);
    }

    // This records one completed activity.
    public void Record(string activityName, int seconds)
    {
        if (_stats.ContainsKey(activityName))
        {
            var current = _stats[activityName];
            _stats[activityName] = (current.Count + 1, current.TotalSeconds + seconds);
        }
        else
        {
            _stats[activityName] = (1, seconds);
        }
    }

    // This returns a friendly report for the user.
    public string GetReport()
    {
        if (_stats.Count == 0)
        {
            return "No activities recorded yet.";
        }

        string report = "";

        foreach (var kvp in _stats)
        {
            report += $"{kvp.Key}: {kvp.Value.Count} times, {kvp.Value.TotalSeconds} total seconds\n";
        }

        return report.TrimEnd();
    }
}
