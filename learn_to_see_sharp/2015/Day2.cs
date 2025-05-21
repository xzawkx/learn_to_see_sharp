using System.ComponentModel;

namespace learn_to_see_sharp._2015;

public static class Day2
{
    private const string Puzzle1FilePath = @"2015\2015_2_1.txt";

    private static List<List<int>> _presents = [];

    public static Task Puzzle1()
    {
        var sFileFullPath = Path.Combine(Program.CurrentDirectory, Puzzle1FilePath);
        var reader = new StreamReader(sFileFullPath);
        var nResult = 0;

        for (var line = reader.ReadLine(); line != null; line = reader.ReadLine())
        {
            var n = line.Split('x').Select(int.Parse).ToList();

            _presents.Add(n);

            nResult += 2 * n[0] * n[1] + 2 * n[1] * n[2] + 2 * n[0] * n[2];
            if (n[0] < n[1])
            {
                nResult += n[0] * Math.Min(n[1], n[2]);
                continue;
            }

            nResult += n[1] * Math.Min(n[0], n[2]);
        }

        Console.WriteLine($"Day 2 Puzzle 1 of 2015\nResult: {nResult} square feet of wrapping paper");
        return Task.CompletedTask;
    }

    public static Task Puzzle2()
    {
        
        var nResult = 0;
        
        foreach (var present in _presents)
        {
            
            if (present[0] < present[1])
            {
                nResult += 2 * present[0] + 2 * Math.Min(present[1], present[2]);
            }
            else
            {
                nResult += 2 * present[1] + 2 * Math.Min(present[0], present[2]);
            }
            
            nResult += present[0] * present[1] * present[2];
        }
        
        Console.WriteLine($"Day 2 Puzzle 2 of 2015\nResult: {nResult} square feet of ribbon");
        return Task.CompletedTask;
    }
}