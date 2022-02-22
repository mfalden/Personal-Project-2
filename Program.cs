using System;

public class Program
{
    public static void Main(string[] args)
    {   
        // Before this will work, you need to run
        // dotnet add package dotnet-curses
        
        FancyConsole.SetColor(FancyColor.RED);
        FancyConsole.Write(5, 5, "Hello");
        FancyConsole.SetColor(FancyColor.BLUE);
        FancyConsole.Write(6, 8, "World");
        
        while (true) {
            int input = FancyConsole.GetChar();


            if (input != -1) { // If no input was detected, GetChar returns -1
                FancyConsole.SetColor(FancyColor.WHITE);
                FancyConsole.Write(0, 0, $"Key Code: {input}    "); // Display the most recent key press code
            }

            char asChar = (char)input;
            if (asChar == 'a') {
                FancyConsole.SetColor(FancyColor.MAGENTA);
                FancyConsole.Write(3, 0, "You pressed A!");
            } else {
                FancyConsole.Write(3, 0, "              ");
            }

            if (asChar == 'x') {
                break; // Exits the loop
            }

            if (asChar == 'c') {
                FancyConsole.Clear(); // Clears all text
            }

            FancyConsole.Sleep(200);
            FancyConsole.Refresh();
        }
    }
}