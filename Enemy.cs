using System;
using System.Collections.Generic;

public class Enemy
{
    public int Row;
    public int Col;
    public int Speed;
    public FancyColor Color;
    public bool IsDestroyed;

    /// <summary>
    /// Given the maximum row, col, and speed of an enemy to be created,
    /// creates a random enemy.
    /// </summary>
    /// <param name="maxRow">The maximum row </param>
    /// <param name="maxCol">The maximum column</param>
    /// <param name="maxSpeed">The maximum speed</param>
    /// <returns></returns>
    public static Enemy CreateRandomEnemy(int maxRow, int maxCol, int maxSpeed)
    {
        Random gen = new Random();
        Enemy e = new Enemy();
        e.Row = gen.Next(1, maxRow);
        e.Col = gen.Next(1, maxCol);
        e.Speed = gen.Next(1, maxSpeed);
        List<FancyColor> allColors = new List<FancyColor>();
        allColors.Add(FancyColor.RED);
        allColors.Add(FancyColor.BLUE);
        allColors.Add(FancyColor.MAGENTA);
        allColors.Add(FancyColor.YELLOW);
        e.Color = allColors[gen.Next(0, allColors.Count)];
        return e;
    }


    /// <summary>
    /// Given a player, an enemy, and the current number of ticks, check to see if the
    /// enemy should move and if so, move the enemy toward the player
    /// </summary>
    /// <param name="player"></param>
    /// <param name="enemy"></param>
    /// <param name="ticks"></param>
    public static void MoveEnemyTowardPlayer(Player player, Enemy enemy, int ticks)
    {
        // The faster the enemy speed, the more frequently it moves
        // If enemy.Speed is 1, it moves every 100 ticks
        // If enemy.Speed is 2, it moves every 50 ticks, ets
        int moveTick = 100 / enemy.Speed;

        // Check to see if the enemy should move on the current tick.
        // If they shouldn't move, we just return (do nothing)
        if (ticks % moveTick != 0) return;

        // Otherwise, we move the enemy toward the player
        if (enemy.Row > player.Row)
        {
            enemy.Row = enemy.Row - 1;
        }

        if (enemy.Row < player.Row)
        {
            enemy.Row = enemy.Row + 1;
        }

        if (enemy.Col > player.Col)
        {
            enemy.Col = enemy.Col - 1;
        }

        if (enemy.Col < player.Col)
        {
            enemy.Col = enemy.Col + 1;
        }

        // If the enemy is in the same space as the player,
        // set the player's IsHurt flag to true and reduce the player's
        // health by 1 then mark the enemy to be destroyed
        if (enemy.Row == player.Row && enemy.Col == player.Col)
        {
            player.IsHurt = true;
            player.Health = player.Health - 1;
            enemy.IsDestroyed = true;
        }
    }

    /// <summary>
    /// Removes all enemies that have been marked to be destroyed from the
    /// list
    /// </summary>
    /// <param name="enemies"></param>
    public static void DestroyEnemies(List<Enemy> enemies)
    {
        enemies.RemoveAll((e) => e.IsDestroyed);
    }

    /// <summary>
    /// Given a player, a list of enemies, and the number of ticks, attempts to move
    /// each enemy toward the player
    /// </summary>
    /// <param name="player"></param>
    /// <param name="enemies"></param>
    /// <param name="ticks"></param>
    public static void MoveEnemies(Player player, List<Enemy> enemies, int ticks)
    {
        foreach (Enemy e in enemies)
        {
            MoveEnemyTowardPlayer(player, e, ticks);
        }
    }

    /// <summary>
    /// Given a list of enemies, draw each enemy to the console
    /// </summary>
    /// <param name="enemies"></param>
    public static void DrawEnemies(List<Enemy> enemies)
    {
        foreach(Enemy e in enemies)
        {
            FancyConsole.SetColor(e.Color);
            FancyConsole.Write(e.Row, e.Col, "^");
        }
    }
}