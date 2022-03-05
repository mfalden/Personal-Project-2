using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Maze
{
    /// <summary>
    /// A list of rows in this maze
    /// </summary>
    public List<string> Rows;

    /// <summary>
    /// The starting position in this maze.
    /// </summary>
    public int StartRow, StartCol;

    /// <summary>
    /// The exit position of this maze.
    /// </summary>
    public int ExitRow, ExitCol;

    /// <summary>
    /// Given the path to a text file, load it as a maze
    /// Scans for an 'S' character and sets that to be the starting position.
    /// Scans for an 'X' character and sets that to be the ending position.
    /// </summary>
    /// <param name="filename"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Given a maze, a row, and a column, determines if the specified position
    /// is a wall. Any space outside the bounds of a maze is considered a wall.
    /// </summary>
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

    /// <summary>
    /// Given a maze, a row, and a column, determines the color and character to 
    /// draw at that position. Any position outside of the maze is considered a wall.
    /// </summary>
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
    
    /// <summary>
    /// A helper method to determine the color of a character
    /// </summary>
    public static FancyColor GetCharacterColor(char ch)
    {
        if (ch == ' ') return FancyColor.WHITE;
        if (ch == '#') return FancyColor.BLUE;
        if (ch == 'S') return FancyColor.MAGENTA;
        if (ch == 'X') return FancyColor.CYAN;
        return FancyColor.WHITE;
    }

    
}