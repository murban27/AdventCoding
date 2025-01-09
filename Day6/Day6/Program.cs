// See https://aka.ms/new-console-template for more information
using System.Drawing;

public class Program
{
    public static char[,] Map;

    public static int lineDimension { get; private set; }

    private static List<string> lines = new List<string>();
    private static int startHeight;
    private static int startWeight;
    private static int runner;
    private static HashSet<Point> visitedPoints;

    public static Point StartingPoint { get; private set; }

    public static void Main(string[] args)
    {
        CreateMap(args);
    }

    private static void CreateMap(string[] args)
    {
        Console.WriteLine("pass your input");
        string? data;
        while ((data = Console.ReadLine()) != null && data != string.Empty)
        {
            lines.Add(data);
        }
        Map = new char[lines.Count, lines.FirstOrDefault().ToCharArray().Length];
        lineDimension = lines.FirstOrDefault().ToCharArray().Length;
        TrimList();
        CalculateThrowTheMap();
        Console.WriteLine($"Visited: {visitedPoints.Count}");
    }

    private static void TrimList()
    {
         runner = 0;
        foreach (string line in lines)
        {
            var k = line.ToCharArray();
            for (int i = 0; i < k.Length; i++)
            {
                if (k[i] == '^')
                {
                  StartingPoint=new Point(runner, i);
                }
                Map[runner, i] = k[i];

            }
            runner++;
        }
    }
    public static void CalculateThrowTheMap()
    {
             visitedPoints = new HashSet<Point>();
        int visited = 0;
        Point direction=new Point(-1, 0 );
        Point currentPoint = StartingPoint;
        while (true)
        {
           var NextPoint=new Point(currentPoint.X + direction.X, currentPoint.Y + direction.Y);
            if (!visitedPoints.Contains(currentPoint))
            {
                visitedPoints.Add(currentPoint);
            }
            if (OutOfMap(NextPoint))
            {
                break;
            }
            //NextPoint
            if (Map[currentPoint.X+direction.X, currentPoint.Y+direction.Y] == '#')
            {
                //Otočit doprava
                //-1,0 NAHORU
                //0,1  DOPRAVA
                //1,0  DOLU
                //0,-1 DOLEVA

                direction = new Point(direction.Y, direction.X * -1);
                NextPoint = new Point(currentPoint.X + direction.X, currentPoint.Y + direction.Y);
            }

            currentPoint = NextPoint;



        }
    }

    private static bool OutOfMap(Point nextPoint)
    {
       if(nextPoint.X < 0 || nextPoint.X >= lineDimension || nextPoint.Y < 0 || nextPoint.Y >= runner)
        {
            return true;
        }
        return false;
    }
}
