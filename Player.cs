public class Player {
    public int Row, Col;
    public int TotalSteps = 0;

    /// <summary>
    /// Given an input, a player, and a maze, handles the players input. WASD control the players movement.
    /// A player cannot move into a position that is a wall within the maze.
    /// </summary>
    public static void HandleInput(char input, Player p, Maze m)
    {
        int candidateRow = p.Row;
        int candidateCol = p.Col;
        if (input == 'w')
        {
            candidateRow = p.Row - 1;
            p.TotalSteps = p.TotalSteps + 1;
        }
        if (input == 's')
        {
            candidateRow = p.Row + 1;
            p.TotalSteps = p.TotalSteps + 1;
        }
        if (input == 'a')
        {
            candidateCol = p.Col - 1;
            p.TotalSteps = p.TotalSteps + 1;
        }
        if (input == 'd')
        {
            candidateCol = p.Col + 1;
            p.TotalSteps = p.TotalSteps + 1;
        }

        // If the new potential position is not intersecting with a wall, update the players position
        if (Maze.IsWall(m, candidateRow, candidateCol) == false)
        {
            p.Col = candidateCol;
            p.Row = candidateRow;
        }
    }

    /// <summary>
    /// Displays the players current position and total number of moves in the top left of the screen.
    /// </summary>
    public static void DrawInfo(Player player)
    {
        FancyConsole.SetColor(FancyColor.WHITE);
        FancyConsole.Write(0, 0, $"Position: ({player.Row}, {player.Col}) | Steps: {player.TotalSteps}");
        
    }
}