// See https://aka.ms/new-console-template for more information
using Day4;
using System.Runtime.InteropServices;

Console.WriteLine("Zadej input");


List<char[]> lines = new List<char[]>();
string line;
while (!string.IsNullOrEmpty(line = Console.ReadLine()))
{
    lines.Add(line.ToCharArray());
}

int rowCount = lines.Count;
int colCount = lines[0].Length;
char[,] c = new char[rowCount, colCount];

for (int i = 0; i < rowCount; i++)
{
  for(int j=0; j < colCount; j++)
    {
        c[i, j] = lines[i][j];

    }
}
int totalcnt = 0;
Direction direction = new Direction(c);
for(int i = 0; i < rowCount; ++i)
{
    for (int j = 0; j < colCount; ++j)
    {
        direction.SetPossibilities(i, j);
        Console.WriteLine($"i: {i}, j: {j}");
        Console.WriteLine($"_possibilities: {direction._possibilities.Count}");

        foreach (var item in direction._possibilities)
        {
            if(direction.Search(item, i, j))
            {
                totalcnt++;
            }
        }

    }
}

Console.WriteLine(totalcnt);
Console.ReadKey();