using System;
using System.Collections.Generic;

public class Program
{
    static int baseRow = 7;
    static int maxRow = 5;
    int totalDistance;
    public static void Main(string[] args)
    {

        Player player = new Player();
        player.X = 1;
        player.IsJumping = false;
        player.EndJumpAt = -1;
        

        int ticks = 0;

        // int length; 
        // int height;
        // List<string> obstacle;
        // (obstacle, length, height) = Obstacle.GetRandomObstacle();
        // int x = 0;
        // foreach (string line in obstacle)
        // {
        //     FancyConsole.Write(5 + x, 10, line);
        //     x++;
        // }
        DrawObstacles();

        while (true)
        {

            int input = FancyConsole.GetChar();
            char asChar = (char)input;

            //HandleJump(player, asChar, ticks);
            
            //FakeJump(player, asChar, ticks);
            FancyConsole.Sleep(200);
            FancyConsole.Refresh();
            ticks++;
            player.X++;
        }
    }

    public static void DrawObstacles()
    {
       Obstacle o = Obstacle.Obstacle1x();
       int columnNumber = 0; // + totaldistance
       int drawnHeight = 0;
       // x, height, SpaceBefore, SpaceAfter
       while (columnNumber <= o.Length)
       {
           while (columnNumber < o.X)
           {
               FancyConsole.Write(baseRow, columnNumber, "_");
               columnNumber++;
           }
           if (columnNumber == o.X)
           {
               while (drawnHeight <= o.Height)
               {
               FancyConsole.Write(baseRow - drawnHeight, columnNumber, "#");
               drawnHeight++;
               }
               columnNumber++;
           }
           FancyConsole.Write(baseRow, columnNumber, "_");
           columnNumber++;
       }
    }

public static void FakeJump(Player player, char asChar, int ticks)
{

    FancyConsole.Write(7, player.X, "D");
    FancyConsole.Write(7, player.X - 1, "_");
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
