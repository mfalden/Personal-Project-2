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

    /// <summary>
    /// the first obstacle
    /// </summary>
    /// <param name="Obstacle1("></param>
    /// <returns></returns>
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

}