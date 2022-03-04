using System;
using System.Collections.Generic;

public class Program
{
    static int baseRow = 7;
    static int columnNumber = 0;
    static int drawnHeight = 0;
    static int offsetColumn = 0;
    static int obstacleProgress = 0;
    public static void Main(string[] args)
    {
        MainBrainstorm();
    }
    public static void MainBrainstorm()
    {
        Player player = new Player();
        player.X = 1;
        List<Obstacle> obstacles = new List<Obstacle>();

        bool hasgamestarted = false;
        while (!hasgamestarted)
        {
           InitializeScreen(obstacles);
           if (offsetColumn == 50)
           {
           hasgamestarted = true;
           }
        }
        while (hasgamestarted)
        {
            PlayBrainStorm();
        }
    }
    public static List<Obstacle> AddObstacle(List<Obstacle> obstacles)
    {
        if (offsetColumn + columnNumber > obstacleProgress)
        {
            obstacles.Add(Obstacle.GetRandomObstacle());
        }
        return obstacles;
    }
    public static void InitializeScreen(List<Obstacle> obstacles)
    {

        DrawAllObstacles(AddObstacle(obstacles));
    }
    public static void DrawAllObstacles(List<Obstacle> obstacles)
    {   foreach (Obstacle o in obstacles)
        {
            obstacleProgress += o.Length;
        while (columnNumber <= o.Length)
        {
            while (columnNumber < o.X || columnNumber > o.X)
            {
                FancyConsole.Write(baseRow, columnNumber + offsetColumn, "_");
                columnNumber++;
            }
            if (columnNumber == o.X)
            {
                while (drawnHeight < o.Height)
                {
                    FancyConsole.Write(baseRow - drawnHeight, columnNumber + offsetColumn, "#");
                    drawnHeight++;
                }
                columnNumber++;
            }
        }
        }
    }
    public static void PlayBrainStorm()
    {

    }
    public static void AllDrawObstacles()
    {

    }
}