namespace AdventOfCode22;

public static class Util
{
    public static string[] GetDataLines(string name)
    {
        var currentDir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
        var projectDir = currentDir.Parent!.Parent!.Parent!.FullName;
        var dataFilePath = Path.Join(projectDir, "data", name);
        return File.ReadAllLines(dataFilePath);
    }
}