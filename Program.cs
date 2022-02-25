using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        // List<Obstacle> obstacles = new List<Obstacle>();
        // obstacles.Add(new Obstacle(7, 4));


        Player player = new Player();
        player.X = 0;
        player.IsJumping = false;
        player.EndJumpAt = -1;

        int ticks = 0;



        // Before this will work, you need to run
        // dotnet add package dotnet-curses
        int length; 
        int height;
        List<string> obstacle;
        (obstacle, length, height) = Obstacle.Obstacle1();
        int x = 0;
        foreach (string line in obstacle)
        {
            FancyConsole.Write(8 + x, 34, line);
            x++;
        }
        FancyConsole.SetColor(FancyColor.RED);
        FancyConsole.Write(5, 5, "Hello");
        FancyConsole.SetColor(FancyColor.BLUE);
        FancyConsole.Write(6, 8, "World");

        while (true)
        {
            int input = FancyConsole.GetChar();


            if (input != -1)
            { // If no input was detected, GetChar returns -1
                FancyConsole.SetColor(FancyColor.WHITE);
                FancyConsole.Write(0, 0, $"Key Code: {input}    "); // Display the most recent key press code
            }

            char asChar = (char)input;
            HandleJump(player, asChar, ticks);


            if (asChar == 'a')
            {
                FancyConsole.SetColor(FancyColor.MAGENTA);
                FancyConsole.Write(3, 0, "You pressed A!");
            }
            else
            {
                FancyConsole.Write(3, 0, "              ");
            }

            if (asChar == 'x')
            {
                break; // Exits the loop
            }

            if (asChar == 'c')
            {
                FancyConsole.Clear(); // Clears all text
            }

            FancyConsole.Sleep(17);
            FancyConsole.Refresh();
            ticks++;
        }
    }

    public static void DrawObstacles(List<Obstacle> obstacles)
    {

    }

    public static void HandleJump(Player player, char asChar, int ticks)
    {
        if (asChar == 'j' && player.IsJumping == false)
        {
            player.IsJumping = true;
            player.EndJumpAt = ticks + 120;
        }

        if (player.IsJumping && player.EndJumpAt < ticks)
        {
            player.IsJumping = false;
        }



        if (ticks % 60 == 0)
        {
            FancyConsole.Write(7, player.X, " ");
            FancyConsole.Write(10, player.X, " ");
            player.X++;
        }

        if (player.IsJumping)
        {
            FancyConsole.Write(7, player.X, "D");
            FancyConsole.Write(10, player.X, " ");
        }
        else
        {
            FancyConsole.Write(10, player.X, "D");
            FancyConsole.Write(7, player.X, " ");
        }
    }
}