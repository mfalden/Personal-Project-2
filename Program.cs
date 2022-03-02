using System;
using System.Collections.Generic;

public class Program
{
    static int baseRow = 7;
    static int maxRow = 5;
    int totalDistance = 0;
    public static void Main(string[] args)
    {

        Player player = new Player();
        player.X = 1;
        player.IsJumping = false;
        player.EndJumpAt = -1;

        

        int ticks = 0;

        List<Obstacle> obstacles = new List<Obstacle>();
        
        while (true)
        {
            
            int input = FancyConsole.GetChar();
            char asChar = (char)input;
            DrawObstacles(ticks, AddObstacle(ticks, obstacles));

            //HandleJump(player, asChar, ticks);

            //FakeJump(player, asChar, ticks);
            FancyConsole.Sleep(200);
            FancyConsole.Refresh();
            ticks++;
            player.X++;
        }
    }

    public static (int, int) DrawObstacles(int ticks)
    {
       Obstacle o = Obstacle.GetRandomObstacle();
       int columnNumber = ticks;
       int finalColumn = columnNumber + o.Length;
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
       return (columnNumber, finalColumn);
    }

    public static List<Obstacle> AddObstacle(int ticks, List<Obstacle> obstacles)
    {
        int totalWidth = 0;
        foreach(Obstacle o in obstacles)
        {
            totalWidth = totalWidth + o.Length;
        }
        if (totalWidth < ticks)
        {
            obstacles.Add(Obstacle.GetRandomObstacle());
        }
        return obstacles;
    }

    public static void DrawObstacles(int ticks, List<Obstacle> obstacles)
    {
        // need to update and store values externally to keep them updated correctly.
        int offsetX = 0;
        //    Obstacle o = Obstacle.GetRandomObstacle();
        foreach (Obstacle o in obstacles)
        {
            int columnNumber = 0;
            
            // int columnNumber = ticks;
            // int finalColumn = columnNumber + o.Length;
            int drawnHeight = 0;
            // x, height, SpaceBefore, SpaceAfter
            while (columnNumber <= o.Length)
            {
                while (columnNumber < o.X)
                {
                    FancyConsole.Write(baseRow, columnNumber + offsetX, "_");
                    columnNumber++;
                }
                if (columnNumber == o.X)
                {
                    while (drawnHeight <= o.Height)
                    {
                        FancyConsole.Write(baseRow - drawnHeight, columnNumber + offsetX, "#");
                        drawnHeight++;
                    }
                    columnNumber++;
                }
                FancyConsole.Write(baseRow, columnNumber + offsetX, "_");
                columnNumber++;
            }
            offsetX += o.Length;
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
