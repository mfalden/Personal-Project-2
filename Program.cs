using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        
        Player player = new Player();
        player.X = 0;
        player.IsJumping = false;
        player.EndJumpAt = -1;

        int ticks = 0;

        int length; 
        int height;
        List<string> obstacle;
        string randomObstacle = Obstacle.RandomGenerator();
        //(obstacle, length, height) = Obstacle.$"{randomObstacle}"();
        (obstacle, length, height) = Obstacle.Obstacle0();
        int x = 0;
        foreach (string line in obstacle)
        {
            FancyConsole.Write(5 + x, 10, line);
            x++;
        }

        while (true)
        {

            int input = FancyConsole.GetChar();
            char asChar = (char)input;

            HandleJump(player, asChar, ticks);
            FancyConsole.Sleep(200);
            FancyConsole.Refresh();
            ticks++;
            player.X++;
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
            player.JumpStart = true;
            player.EndJumpAt = ticks + 10;
        }

        if (asChar == 'j' && player.IsJumping == true)
        {
            player.IsDoubleJump = true;
            player.EndJumpAt = ticks + 5;
        }

        if (player.IsJumping && player.IsDoubleJump && player.EndJumpAt < ticks)
        {
            player.IsJumping = false;
            player.IsDoubleJump = false;
            player.DoubleJumpEnd = true;
        }
        if (player.IsJumping && !player.IsDoubleJump && player.EndJumpAt < ticks)
        {
            player.IsJumping = false;
            player.JumpEnd = true;
        }
// jump rules
        if (player.IsJumping && player.JumpStart && !player.IsDoubleJump)
        {
            FancyConsole.Write(6, player.X, " D");
            FancyConsole.Write(7, player.X, "_");
            player.JumpStart = false;
        }
        if (player.IsJumping && player.JumpStart && player.IsDoubleJump)
        {
            FancyConsole.Write(5, player.X, " D");
            FancyConsole.Write(7, player.X, "_");
            player.JumpStart = false;
        }
        if (player.IsJumping && !player.JumpStart && !player.IsDoubleJump)
        {
            FancyConsole.Write(6, player.X, " D");
        }
        if (player.IsJumping && !player.JumpStart && player.IsDoubleJump)
        {
            FancyConsole.Write(5, player.X, " D");
            FancyConsole.Write(6, player.X, " "); 
        }
        if (player.JumpEnd)
        {
            FancyConsole.Write(6, player.X, "  ");
            FancyConsole.Write(7, player.X, "_D"); 
            player.JumpEnd = false;
        }
        if (player.DoubleJumpEnd)
        {
            FancyConsole.Write(6, player.X, "  ");
            FancyConsole.Write(7, player.X, "_D"); 
            player.DoubleJumpEnd = false;
        }
        else
        {
            FancyConsole.Write(7, player.X, "_D"); 
        }
        // if (player.IsJumping)
        // {
        //     if (player.IsDoubleJump)
        // {
        //     FancyConsole.Write(5, player.X, " D");
        //     FancyConsole.Write(6, player.X, "  ");
        //     FancyConsole.Write(7, player.X, "_");
        // }
        //     else
        // {
        //     FancyConsole.Write(5, player.X, "  ");
        //     FancyConsole.Write(6, player.X, " D");
        //     FancyConsole.Write(7, player.X, "_");
        // }
        // }

        // else
        // {
        // FancyConsole.Write(7, player.X, "_D");
        // FancyConsole.Write(6, player.X, "  ");
        // FancyConsole.Write(5, player.X, "  ");

        // }

    }
}
