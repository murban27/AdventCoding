using System;
using System.Collections.Generic;
using System.Linq;

public static class Program
{
    private static string[] inputStrings;
    private static long[] inputStones;
    public static Dictionary<(long, int), long> Cache=new Dictionary<(long, int), long>();
     

    public static void Main(string[] args)
    {
        inputStrings = Init();
        inputStones = CreateField();
        var Sum = inputStones.Sum(x => EvalCalc(x,25));
        Console.WriteLine(Sum);
    }
     public static long EvalCalc(long stone,int blinks)
    {
  
        if(Cache.TryGetValue((stone,blinks),out long result)) 
        {
            return result;
        }
        if(blinks == 0) 
        {
            return 1;
        }
        else if(stone == 0) 
        {
            result=EvalCalc(1,blinks-1);
        }

        else if(stone.ToString().Length%2==0)
        {
            string ParseStone=stone.ToString();
            long leftnode=long.Parse(ParseStone.Substring(0,ParseStone.Length/2));
            long rightnode = long.Parse(ParseStone.Substring(ParseStone.Length / 2));
            result = EvalCalc(leftnode, blinks - 1)+EvalCalc(rightnode, blinks-1);
        }
        else 
        {
            result=EvalCalc(stone * 2024, blinks-1);
        }
        Cache[(stone,blinks)] = result;
        return result;
    }
    public static long[] CreateField()
    {
        return inputStrings.Select(long.Parse).ToArray();
    }

    public static string[] Init()
    {
        Console.WriteLine("Init stone");
        string line = Console.ReadLine();
        return line.Split(" ");
    }
}

