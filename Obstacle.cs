using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Obstacle
{
    // public int x;
    // public int height;

    // public Obstacle(int x, int height) {
    //     this.x = x;
    //     this.height = height;
    // }
    public static string RandomGenerator()
    {
    Random generator;
    generator = new Random();
    int randomNumber = generator.Next(1, 5);
    return $"Obstacle{randomNumber}";
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
        obstacle.Insert(0, "           #  ");
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