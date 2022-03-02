using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Obstacle
{

    public int X;
    public int Height;
    public int SpaceBefore, SpaceAfter;
    public int Length => SpaceAfter + SpaceBefore + 1;

    public static Obstacle GetRandomObstacle() 
    {
        List<Func<Obstacle>> possibleObstacles = new List<Func<Obstacle>>();

        possibleObstacles.Add(Obstacle1x);
        possibleObstacles.Add(Obstacle0x);
        possibleObstacles.Add(Obstacle0x);

        Random generator;
        generator = new Random();
        int randomNumber = generator.Next(0, possibleObstacles.Count);
        return possibleObstacles[randomNumber].Invoke();
    }
    public static (List<string>, int, int) Obstacle0()
    {
        List<string> obstacle = new List<string>();
        obstacle.Insert(0, "                  ");
        obstacle.Insert(1, "                  ");
        obstacle.Insert(2, "__________________");
        int length = 19;
        int height = 3;
        return (obstacle, length, height);
    }
public static Obstacle Obstacle0x()
    {
        Obstacle o = new Obstacle();
        o.X = 1; // total coordinate - 1
        o.Height = -1; // total height - 1
        o.SpaceBefore = 0; // total length - 1
        o.SpaceAfter = 19; // total length
        return o;
    }

public static Obstacle Obstacle1x()
    {
        Obstacle o = new Obstacle();
        o.X = 3; // total coordinate - 1
        o.Height = 2; // total height - 1
        o.SpaceBefore = 2; // total length - 1
        o.SpaceAfter = 15; // total length
        return o;
    }
    public static void DrawObstacle(Obstacle o)
    {
        

    }

    public static (List<string>, int, int) Obstacle1()
    {
        List<string> obstacle = new List<string>();
        obstacle.Insert(0, "   #               ");
        obstacle.Insert(1, "   #               ");
        obstacle.Insert(2, "___#_______________");
        int length = 20;
        int height = 3;
        return (obstacle, length, height);
    }
    public static (List<string>, int, int) Obstacle2()
    {
        List<string> obstacle = new List<string>();
        obstacle.Insert(0, "                        ");
        obstacle.Insert(1, "        #               ");
        obstacle.Insert(2, "________#_______________");
        int length = 24;
        int height = 2;
        return (obstacle, length, height);
    }

    public static (List<string>, int, int) Obstacle3()
    {
        List<string> obstacle = new List<string>();
        obstacle.Insert(0, "              ");
        obstacle.Insert(1, "           #  ");
        obstacle.Insert(2, "___________#__");
        int length = 15;
        int height = 3;
        return (obstacle, length, height);
    }

    public static (List<string>, int, int) Obstacle4()
    {
        List<string> obstacle = new List<string>();
        obstacle.Insert(0, "     ");
        obstacle.Insert(1, "     ");
        obstacle.Insert(2, "__#__");
        int length = 5;
        int height = 1;
        return (obstacle, length, height);
    }
}