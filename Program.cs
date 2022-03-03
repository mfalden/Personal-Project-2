using System;
using System.Collections.Generic;

public class Program
{

    public static void Main(string[] args)
    {

        Player player = new Player();
        player.Row = 5;
        player.Col = 5;
        player.Health = 10;


        int ticks = 0;

        List<Enemy> enemies = new List<Enemy>();

        while (true)
        {

            int input = FancyConsole.GetChar();
            char asChar = (char)input;

            if (player.Health > 0)
            {
                PlayGame(player, enemies, asChar, ticks);
            } 
            else 
            {
                GameOverScreen(player, enemies, asChar, ticks);
            }


            ticks++;
        }
    }

    /// <summary>
    /// Runs the Game
    /// </summary>
    /// <param name="player"></param>
    /// <param name="enemies"></param>
    /// <param name="input"></param>
    /// <param name="ticks"></param>
    public static void PlayGame(Player player, List<Enemy> enemies, char input, int ticks)
    {
        FancyConsole.Clear();
        Player.DrawPlayer(player);
        Player.HandleInput(input, player);
        Player.DrawHealth(player);

        // Add a new enemy every 10 ticks
        if (ticks % 50 == 0)
        {
            enemies.Add(Enemy.CreateRandomEnemy(10, 10, 10));
        }

        Enemy.MoveEnemies(player, enemies, ticks);
        Enemy.DestroyEnemies(enemies);
        Enemy.DrawEnemies(enemies);

        FancyConsole.Sleep(20);
        FancyConsole.Refresh();
    }

    /// <summary>
    /// Displays a "fancy" game over screen and waits for the user to press space to restart.
    /// </summary>
    /// <param name="player"></param>
    /// <param name="enemies"></param>
    /// <param name="input"></param>
    /// <param name="ticks"></param>
    public static void GameOverScreen(Player player, List<Enemy> enemies, char input, int ticks)
    {
        
        List<FancyColor> colors = new List<FancyColor>();
        colors.Add(FancyColor.RED);
        colors.Add(FancyColor.BLUE);
        colors.Add(FancyColor.CYAN);
        colors.Add(FancyColor.GREEN);
        colors.Add(FancyColor.MAGENTA);
        colors.Add(FancyColor.WHITE);
        colors.Add(FancyColor.YELLOW);
        string message = "GAME OVER! Press Space To Restart!";
        int color = ticks;
        int column = 5;
        FancyConsole.Clear();
        foreach(char ch in message)
        {
            FancyConsole.SetColor(colors[color % colors.Count]);
            FancyConsole.Write(5, column, $"{ch}");
            color++;
            column++;
        }
        FancyConsole.Sleep(100);
        FancyConsole.Refresh();

        // If the player presses space, reset the game
        if (input == ' ')
        {
            player.Row = 5;
            player.Col = 5;
            player.Health = 10;
            player.IsHurt = false;
            enemies.Clear();
        }
    }
}
