using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Pass your input");

        int correctnumbers = 0;
        string line = "";
        while (!string.IsNullOrEmpty(line = Console.ReadLine()))
        {
            var chars = line.Split(" ").Select(int.Parse).ToList();
            bool isCorrect = IsLineCorrect(chars);

            if (!isCorrect)
            {
                // Try removing each number one by one
                for (int i = 0; i < chars.Count; i++)
                {
                    var tempChars = chars.ToList();
                    tempChars.RemoveAt(i);
                    if (IsLineCorrect(tempChars))
                    {
                        isCorrect = true;
                        break;
                    }
                }
            }

            if (isCorrect)
            {
                correctnumbers++;
                Console.WriteLine("Correct or fixed line: " + string.Join(" ", chars));
            }
            else
            {
                Console.WriteLine("Incorrect line: " + string.Join(" ", chars));
            }
        }
        Console.WriteLine("Correct numbers are: " + correctnumbers);
        Console.ReadKey();
    }

    static bool CheckThreeNumbers(int previous, int current, int future)
    {
        if ((previous < current && current < future) || (previous > current && current > future))
        {
            if (Math.Abs(previous - current) <= 3 && Math.Abs(current - future) <= 3)
            {
                return true;
            }
        }
        return false;
    }

    static bool IsLineCorrect(System.Collections.Generic.List<int> numbers)
    {
        for (int i = 1; i < numbers.Count - 1; i++)
        {
            if (!CheckThreeNumbers(numbers[i - 1], numbers[i], numbers[i + 1]))
            {
                return false;
            }
        }
        return true;
    }
}