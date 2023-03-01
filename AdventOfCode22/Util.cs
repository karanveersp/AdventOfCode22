namespace AdventOfCode22;

public static class Util
{
    public static string[] GetDataLines(int day)
    {
        var dataFilePath = GetDataFilePath(day);
        return File.ReadAllLines(dataFilePath);
    }

    private static string GetDataFilePath(int day)
    {
        var currentDir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
        var projectDir = currentDir.Parent!.Parent!.Parent!.FullName;
        var dataFilePath = Path.Join(projectDir, "data", $"Day{day}.txt");
        return dataFilePath;
    }
}