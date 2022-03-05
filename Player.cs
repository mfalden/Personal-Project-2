public class Player {
    public int Row;
    public int Col;
    public int TotalSteps = 0;

    /// <summary>
    /// Handles the players input. WASD control the players movement.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="p"></param>
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

    

    public static void DrawInfo(Player player)
    {
        FancyConsole.SetColor(FancyColor.WHITE);
        FancyConsole.Write(0, 0, $"Position: ({player.Row}, {player.Col}) | Steps: {player.TotalSteps}");
        
    }
}