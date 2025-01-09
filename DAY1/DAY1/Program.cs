using System.Collections;
List<int> First = new List<int>();
List<int> Second = new List<int>();

Console.WriteLine("Put the numbers");
string line = "   ";
while (!string.IsNullOrEmpty(line = Console.ReadLine()))
{
    var numbers = line.Split(" ");
    First.Add(int.Parse(numbers[0].Trim()));
    Second.Add(int.Parse(numbers[1].Trim()));
}
//CompareOrderedLists();
Part2();

void CompareOrderedLists()
{
   First= First.OrderBy(x => x).ToList(); 
    Second=Second.OrderBy(x=>x).ToList();
    int totalresult = 0;
    for(int i=0; i < First.Count; i++)
    {
        totalresult += Math.Abs(First[i] - Second[i]);
    }
    Console.WriteLine(totalresult);
    Console.ReadKey();
}
void Part2()
{

    var c = Second.GroupBy(x => x).Select(x => new { Number =x.Distinct().First(), Count = x.Count() }).ToList();     
    int totalresult = 0;

    for (int i = 0; i < First.Count; i++)
    {
        totalresult += First[i] * (c.Where(x => x.Number == First[i]).Select(x=>x.Count).FirstOrDefault(0));
    }
    Console.WriteLine(totalresult);
    Console.ReadKey();
}