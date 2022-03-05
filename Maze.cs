using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Maze
{
    public List<string> Rows;
    public int StartRow;
    public int StartCol;

    public int ExitRow;
    public int ExitCol;

    public static Maze LoadMaze(string filename)
    {
        Maze maze = new Maze();
        // Load the Maze file
        maze.Rows = File.ReadAllLines(filename).ToList();
        int currentRow = 0;
        // Scan the maze file looking for the start position and the exit positions
        foreach(string row in maze.Rows)
        {
            int currentCol = 0;
            foreach(char ch in row)
            {
                if (ch == 'S')
                {
                    maze.StartCol = currentCol;
                    maze.StartRow = currentRow;
                }

                if (ch == 'X')
                {
                    maze.ExitRow = currentRow;
                    maze.ExitCol = currentCol;
                }
                currentCol = currentCol + 1;
            }
            currentRow = currentRow + 1;
        }
        return maze;
    }

    public static bool IsWall(Maze m, int row, int col)
    {
        // If we are out of bounds, return true.
        if (row < 0 || row >= m.Rows.Count)
        {
            return true;
        }

        // If we are out of bounds, return true.
        if (col < 0 || col >= m.Rows[row].Length)
        {
            return true;
        }

        return m.Rows[row][col] == '#';
    }

    public static (FancyColor, char) GetCharacter(Maze m, int row, int col)
    {
        // If we are out of bounds, return a white wall.
        if (row < 0 || row >= m.Rows.Count)
        {
            return (FancyColor.WHITE, '#');
        }

        // If we are out of bounds, return a white wall.
        if (col < 0 || col >= m.Rows[row].Length)
        {
            return (FancyColor.WHITE, '#');
        }
        char value = m.Rows[row][col];
        FancyColor color = Maze.GetCharacterColor(value);
        return (color, value);
    }
    
    public static FancyColor GetCharacterColor(char ch)
    {
        if (ch == ' ') return FancyColor.WHITE;
        if (ch == '#') return FancyColor.BLUE;
        if (ch == 'S') return FancyColor.MAGENTA;
        if (ch == 'X') return FancyColor.CYAN;
        return FancyColor.WHITE;
    }

    
}