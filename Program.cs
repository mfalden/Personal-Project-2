using System;
using System.Collections.Generic;

public class Program
{

    public static void Main(string[] args)
    {

        Maze maze = Maze.LoadMaze("maze.txt");
        Player player = new Player();
        player.Row = maze.StartRow;
        player.Col = maze.StartCol;
        int ticks = 0;

        int ViewPortRadiusWidth = 8;
        int ViewPortradiusHeight = 4;
        int ViewPortCenterRow = 7;
        int ViewPortCenterColumn = 10;


        while (true)
        {

            int input = FancyConsole.GetChar();
            char asChar = (char)input;

            FancyConsole.Clear();

            Player.HandleInput(asChar, player, maze);
            Player.DrawInfo(player);
            Program.DrawViewPort(player, maze, ViewPortCenterRow, ViewPortCenterColumn, ViewPortRadiusWidth, ViewPortradiusHeight);

            FancyConsole.Refresh();
            FancyConsole.Sleep(20);
            ticks++;
        }
    }

    public static void DrawViewPort(Player player, Maze maze, int centerRow, int centerCol, int radiusWidth, int radiusHeight)
    {
        // Calculate the viewport window size relative to the player's vision radius
        int MinRow = player.Row - radiusHeight;
        int MinCol = player.Col - radiusWidth;
        int MaxRow = player.Row + radiusHeight;
        int MaxCol = player.Col + radiusWidth;


        // Start at the first row
        int row = MinRow;
        // Loop through each row we want to draw
        while (row <= MaxRow)
        {
            // Start at the first column
            int col = MinCol;
            // Loop through each column we want to draw
            while (col <= MaxCol)
            {
                
                // Calculate the offset, this is based on where we want to draw
                // the center of the view port and then relative to the player's
                // position This centers the player at the middle of the
                // viewport
                int offsetRow = centerRow - player.Row;
                int offsetCol = centerCol - player.Col;

                // Retrieve the character to be drawn.
                (FancyColor color, char ch) = Maze.GetCharacter(maze, row, col);

                // If we are at the edge of the view port, draw a border instead
                if (row == MinRow || row == MaxRow || col == MinCol || col == MaxCol) 
                {
                    color = FancyColor.WHITE;
                    ch = GetBorderCharacter(row, col, MinRow, MinCol, MaxRow, MaxCol);
                }
                FancyConsole.SetColor(color);
                FancyConsole.Write(offsetRow + row, offsetCol + col, $"{ch}");
                // Go to the next column
                col = col + 1;
            }
            // Go to the nex trow
            row = row + 1;
        }

        // Finally, draw the player at the center of the view port.
        FancyConsole.SetColor(FancyColor.GREEN);
        FancyConsole.Write(centerRow, centerCol, "A");
    }

    private static char GetBorderCharacter(int row, int col, int minRow, int minCol, int maxRow, int maxCol)
    {
        // We are in the corner if (row is the min or max) AND (col is the min or max)
        if ((row == minRow || row == maxRow) && (col == minCol || col == maxCol))
        {
            return '+';
        }

        // If we are the top or bottom edge
        if (row == minRow || row == maxRow)
        {
            return '-';
        }

        // If we are the left or right edge
        if (col == minCol || col == maxCol)
        {
            return '|';
        }

        throw new Exception("Could not determine the border character, something went wrong.");
    }
}
