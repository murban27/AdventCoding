using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;

Console.WriteLine("Pass input");

List<string> lines = new List<string>();
List<ConsoleApp1.Result> results = new List<Result>();
string line = "";
while (!string.IsNullOrEmpty(line = Console.ReadLine()))
{
    lines.Add(line);
}
createMatrix(lines);
long total = 0;
results.ForEach(x => total += CalculateTotal(x));

Console.WriteLine("Total: " + total);



void createMatrix(List<string> lines)
{
    foreach (var line in lines)
    {
        long FinalResult = long.Parse(line.Substring(0, line.IndexOf(":")));
        var numbers = line.Substring(line.IndexOf(": ") + 1).Split(" ")
                        .Where(x => long.TryParse(x, out _))
                        .Select(long.Parse)
                        .ToArray();
        Result result = new Result(FinalResult, numbers);
        results.Add(result);
    }
}

List<string> GeneratePossibilities(long[] array)
{
    char[] possible = new char[] { '*', '+' };
    List<string> results = new List<string>();

    if (array.Length == 2)
    {
        return possible.Select(op => op.ToString()).ToList();
    }
    else if (array.Length > 2)
    {
        GenerateCombinations(array.Length - 1, possible, "", results);
    }

    return results;
}

void GenerateCombinations(int length, char[] possible, string current, List<string> results)
{
    if (current.Length == length)
    {
        results.Add(current);
        return;
    }

    foreach (char op in possible)
    {
        GenerateCombinations(length, possible, current + op, results);
    }
}

long CalculateTotal(Result result)
{
    var possibilities = GeneratePossibilities(result.Numbers);

    foreach (var possibility in possibilities)
    {
        if (ApplyOperators(result.Numbers, possibility) == result.FinalResult)
        {
            return result.FinalResult; // Přičte pouze jednou a vrátí
        }
    }

    return 0; // Pokud žádná kombinace nevyhovuje, vrátí 0
}

long ApplyOperators(long[] numbers, string operators)
{
    long result = numbers[0];

    for (int i = 0; i < operators.Length; i++)
    {
        result = ApplyOperator(result, numbers[i + 1], operators[i]);
    }

    return result;
}

long ApplyOperator(long a, long b, char op)
{
    switch (op)
    {
        case '*':
            return a * b;
        case '+':
            return a + b;
        default:
            throw new ArgumentException("Invalid operator");
    }
}


