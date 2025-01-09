using System.Text.RegularExpressions;

Console.WriteLine("Reading from txt file");

var input = File.ReadAllText("D:\\Michal\\Programovani\\AdventCoding\\Day3\\Day3\\AllFile.txt");
int totalNumbers = 0;

Part1();
Part2();
return;

void Part1()
{
    const string regex = @"mul\([0-9]{1,3},[0-9]{1,3}\)";
    var matches = Regex.Matches(input, regex);

    var total = 0;

    foreach (Match match in matches)
    {
        var numbers = GetNumbers(match);
        total += numbers[0] * numbers[1];
    }

    Console.WriteLine("Total: " + total);
}

void Part2()
{
    const string regex = @"do\(\)|don't\(\)|mul\([0-9]{1,3},[0-9]{1,3}\)";
    var matches = Regex.Matches(input, regex);

    // At the start, mul instructions are enabled
    var isEnabled = true;
    var total = 0;

    // loop over the matches (e.g do(), dont() or mul(x, y)
    foreach (Match match in matches)
    {
        switch (match.Value)
        {
            case "do()":
                isEnabled = true;
                break;
            case "don't()":
                isEnabled = false;
                break;
            default:
                {
                    if (match.Value.StartsWith("mul") && isEnabled)
                    {
                        var numbers = GetNumbers(match);
                        total += numbers[0] * numbers[1];
                    }

                    break;
                }
        }
    }

    Console.WriteLine("Total: " + total);
}

int[] GetNumbers(Match match)
{
    var numbers = Regex.Matches(match.Value, "\\d{1,3}");
    var a = int.Parse(numbers[0].Value);
    var b = int.Parse(numbers[1].Value);

    return [a, b];
}