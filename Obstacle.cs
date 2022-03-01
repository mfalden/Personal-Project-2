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

    public static (List<string>, int, int) GetRandomObstacle() 
    {
        // In C#, you can actually have a list of functions (methods as long as
        // they all return the same thing). In your case, you have a set of
        // methods which return (List<string>, int, int). We can specify a
        // function that takes no arguments and returns that as
        // Func<(List<string>, int, int)>. Then, if we want a list of those we
        // can say:
        List<Func<(List<string>, int, int)>> possibleObstacles = new List<Func<(List<string>, int, int)>>();

        // Next we can add each of your methods to the list:
        possibleObstacles.Add(Obstacle0);
        possibleObstacles.Add(Obstacle1);
        possibleObstacles.Add(Obstacle2);
        possibleObstacles.Add(Obstacle3);
        possibleObstacles.Add(Obstacle4);

        // Finally, we can generate a random number based on the size of the list:
        Random generator;
        generator = new Random();
        // This returns one of the indices of the list
        int randomNumber = generator.Next(0, possibleObstacles.Count);
        // Finally, we get the method associated with that index and we Invoke it.
        return possibleObstacles[randomNumber].Invoke();

        // The main benefit here is that you only need to add new elements to
        // the list (or remove them) and you do not need to change any other
        // code.
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