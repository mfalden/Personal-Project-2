public class Player {
    public int Row;
    public int Col;
    public int Health;
    public bool IsHurt;
    public int HurtTicks;

    /// <summary>
    /// Given a player, draws it on the screen. If the player is hurt
    /// draws a red * for 20 ticks otherwise a green A.
    /// </summary>
    /// <param name="p"></param>
    public static void DrawPlayer(Player p)
    {
        if (p.IsHurt == false)
        {
            FancyConsole.SetColor(FancyColor.GREEN);
            FancyConsole.Write(p.Row, p.Col, "A");
            p.HurtTicks = 0;
        }
        else 
        {
            FancyConsole.SetColor(FancyColor.RED);
            FancyConsole.Write(p.Row, p.Col, "*");
            p.HurtTicks = p.HurtTicks + 1;
            if (p.HurtTicks == 20)
            {
                p.IsHurt = false;
            }
        }
    }

    /// <summary>
    /// Draw the players health bar at the top left of the screen
    /// </summary>
    /// <param name="p"></param>
    public static void DrawHealth(Player p)
    {
        string prefix = "Health: ";
        FancyConsole.SetColor(FancyColor.WHITE);
        FancyConsole.Write(0, 0, prefix);
        int remaining = p.Health;
        int column = prefix.Length;
        while (remaining > 0)
        {
            FancyConsole.SetColor(FancyColor.GREEN);
            FancyConsole.Write(0, column, "*");
            remaining--;
            column++;
        }
    }

    /// <summary>
    /// Handles the players input. WASD control the players movement.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="p"></param>
    public static void HandleInput(char input, Player p)
    {
        if (input == 'w')
        {
            p.Row = p.Row - 1;
        }
        if (input == 's')
        {
            p.Row = p.Row + 1;
        }
        if (input == 'a')
        {
            p.Col = p.Col - 1;
        }
        if (input == 'd')
        {
            p.Col = p.Col + 1;
        }
    }
}