using System;

class Program
{
    static void Main(string[] args)
    {
        // Exceeding requirements:
        // This program includes a "streak bonus" for Eternal Goals.
        // If the user records the SAME Eternal Goal multiple times in a row,
        // the goal awards increasing bonus points (e.g., +5, +10, +15...) on top
        // of the base points. The streak resets when a different goal is recorded.

        GoalManager gestor = new GoalManager();
        gestor.Start();
    }
}
