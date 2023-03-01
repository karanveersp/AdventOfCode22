namespace AdventOfCode22;

using System.Linq;

public static class Day3
{
    public static void SumOfItems()
    {
        var data = Util.GetDataLines(3);
        string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        var priorities = letters.ToLower().ToArray().Concat(letters.ToArray()).ToArray();
        int sum = data
            .Select(items =>
                    {
                        int halfway = items.Length / 2;
                        return (fst: items.Substring(0, halfway), snd: items.Substring(halfway));
                    })
            .Select(pair =>
                    {
                        return pair.fst.ToHashSet().Intersect(pair.snd.ToHashSet()).First();
                    })
            .Select(item => Array.IndexOf(priorities, item) + 1)
            .Sum();
        Console.WriteLine($"Sum of items: {sum}");
    }
}