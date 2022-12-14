namespace AdventOfCode22;

using System.Linq;

public static class Day1
{
    private record ElfCarrier(int Id, int Calories);

    private static IEnumerable<ElfCarrier> ParseCarriers()
    {
        var lines = Util.GetDataLines("Day1.txt");
        int count = 0;
        int id = 0;
        var carriers = new List<ElfCarrier>();
        foreach (string line in lines)
        {
            if (String.IsNullOrEmpty(line))
            {
                carriers.Add(new ElfCarrier(id, count));
                count = 0;
                id += 1;
            }
            else
            {
                count += Int32.Parse(line);
            }
        }
        carriers.Add(new ElfCarrier(id, count)); // Add the last elf

        return carriers;
    }

    private static IEnumerable<ElfCarrier> ParseCarriersRecursive(string[] lines, int lineNumber = 0, int id = 0, int caloryValue = 0)
    {
        var list = new List<ElfCarrier>();

        // base case
        if (lineNumber == lines.Length)
        {
            list.Add(new ElfCarrier(id, caloryValue));
            return list;
        }

        if (String.IsNullOrEmpty(lines[lineNumber]))
        {
            list.Add(new ElfCarrier(id, caloryValue));
            return list.Concat(ParseCarriersRecursive(lines, lineNumber + 1, id + 1, 0));
        }
        else
        {
            return ParseCarriersRecursive(lines, lineNumber + 1, id, caloryValue + Int32.Parse(lines[lineNumber]));
        }
    }

    public static void PrintMaxCarrierCalories()
    {
        var carriers = ParseCarriersRecursive(Util.GetDataLines("Day1.txt"));
        var res = carriers.MaxBy(carrier => carrier.Calories);
        if (res == null)
        {
            throw new Exception("No carriers parsed");
        }
        Console.WriteLine($"Elf {res.Id} has the most calories: {res.Calories}.");
    }

    public static void PrintTopThreeCarriersTotal()
    {
        var carriers = ParseCarriersRecursive(Util.GetDataLines("Day1.txt"));
        var res = carriers
                  .OrderByDescending(carrier => carrier.Calories)
                  .Take(3)
                  .Sum(carrier => carrier.Calories);
        Console.WriteLine($"The top 3 elves carry {res} calories in total.");
    }
}

