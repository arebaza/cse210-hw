using System;

class Program
{
    static void Main(string[] args)
    {
        // Exceeding requirements:
        // This project includes a simple leveling system. As the player earns points,
        // they level up and receive a new title. This adds a gamification element
        // beyond the core requirements.

        GoalManager gestor = new GoalManager();
        gestor.Start();
    }
}
