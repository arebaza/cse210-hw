using System;

class Program
{
    static void Main(string[] args)
    {
        //  Shows creativity and exceeds core requirements
        //Eternal Goal Streak Bonus (Gamification)
        //- If you record the same Eternal Goal multiple times in a row, it earns extra bonus points.
        //- Bonus grows by streak: streak 1 = +5, streak 2 = +10, streak 3 = +15, etc.
        //- The streak resets automatically if you record a different goal type or a different Eternal Goal.
        //Delete ALL Records (Reset Feature)
        //- Added a menu option “Delete ALL records” to clear all goals and reset the score back to 0.
        //- Includes a confirmation prompt (y/n) to prevent accidental deletion.
        //- After deleting, it overwrites goals.txt so your saved file is clean.
        //Safer Load System (Robustness Improvement)
        //- LoadGoals() now validates file lines before parsing (checks the correct number of fields).
        //- Skips bad or unknown lines instead of crashing.
        //- If goals.txt is missing, it auto-creates a new save file by calling SaveGoals().

        GoalManager gestor = new GoalManager();
        gestor.Start();
    }
}
