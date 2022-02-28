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
        // Feedback (jcollard 2022-02-28): There are a few reasonable ways to do this
        // I've created a new method for you called "GetRandomObstacle" below which I
        // think will accomplish what you want using only things you have seen so far in this class.
        // Below that, I've created a method called "FancyGetRandomObstacle" which, I believe, is a slightly
        // more robust version.
        // Study them and let me know if you have questions.
        Random generator;
        generator = new Random();
        int randomNumber = generator.Next(1, 5);
        return $"Obstacle{randomNumber}";
    }


    public static (List<string>, int, int) GetRandomObstacle()
    {
        // First, we make the return type of GetRandomObstacle match the return
        // type of your Obstacle methods. This allows us to delegate one of them
        // based on the random number generated
        Random generator;
        generator = new Random();
        // This returns one of the numbers 0, 1, 2, 3, or 4
        int randomNumber = generator.Next(0, 5);
        if (randomNumber == 0)
        {
            return Obstacle0();
        }
        else if (randomNumber == 1)
        {
            return Obstacle1();
        }
        else if (randomNumber == 2)
        {
            return Obstacle2();
        }
        else if (randomNumber == 3)
        {
            return Obstacle3();
        }
        else
        {//(randomNumber == 5) {
            return Obstacle4();
        }
        // The major down side is that you have to add several more lines if you
        // decide to make more of these
    }

    public static (List<string>, int, int) FancyGetRandomObstacle() 
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