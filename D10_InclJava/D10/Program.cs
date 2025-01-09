using System;
using System.Collections.Generic;
using System.Drawing;

Point pointright = new Point(0, 1);
Point pointleft = new Point(0, -1);
Point pointUp = new Point(-1, 0);
Point pointDown = new Point(1, 0);
int[,] arrayintegeres = null;
List<Point> points = new List<Point> { pointright, pointleft, pointUp, pointDown };
var counter = 0;

Console.WriteLine("Hello, World!");
Console.WriteLine("pass inputs");

string line;
List<string> lines = new List<string>();
while (!string.IsNullOrEmpty(line = Console.ReadLine()))
{
    lines.Add(line);
}
arrayintegeres = MakeIntArrayFromList(lines);

for (int i = 0; i < arrayintegeres.GetLength(0); i++)
{
    for (int j = 0; j < arrayintegeres.GetLength(1); j++)
    {
        if (arrayintegeres[i, j] == 0)
        {
    //        bool[,] visited = new bool[arrayintegeres.GetLength(0), arrayintegeres.GetLength(1)];
            Walk(i, j, null);
        }
    }
}
Console.WriteLine(counter);

void Walk(int x, int y, bool[,] visited)
{
  //  if (visited[x, y]) return;
  //  visited[x, y] = true;

    int value = arrayintegeres[x, y];
    if (value == 9)
    {
        counter++;
    }
    else
    {
        foreach (var point in points)
        {
            int newx = x + point.X;
            int newy = y + point.Y;
            if (newx >= 0 && newx < arrayintegeres.GetLength(0) && newy >= 0 && newy < arrayintegeres.GetLength(1) && arrayintegeres[newx, newy] == value + 1)
            {
                Walk(newx, newy, visited);
            }
        }
    }
}

static int[,] MakeIntArrayFromList(List<string> lines)
{
    int[,] array = new int[lines.Count, lines[0].Length];
    for (int i = 0; i < lines.Count; i++)
    {
        for (int j = 0; j < lines[i].Length; j++)
        {
            array[i, j] = int.Parse(lines[i][j].ToString());
        }
    }
    return array;
}