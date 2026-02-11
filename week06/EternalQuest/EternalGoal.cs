using System;

public class EternalGoal : Goal
{
    private int _streakCount;

    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _streakCount = 0;
    }

    public EternalGoal(string name, string description, int points, int streakCount)
        : base(name, description, points)
    {
        _streakCount = streakCount;
    }

    public void ResetStreak()
    {
        _streakCount = 0;
    }

    public void IncrementStreak()
    {
        _streakCount++;
    }

    public int GetStreakCount()
    {
        return _streakCount;
    }

    public override int RecordEvent()
    {
        return GetPoints();
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal|{GetShortName()}|{GetDescription()}|{GetPoints()}|{_streakCount}";
    }
}
