// See https://aka.ms/new-console-template for more information

namespace learn_to_see_sharp;

public static class Program
{
    public static readonly string CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;

    private static void RunPuzzles()
    {
        var puzzles = new List<Func<Task>>
        {
            _2015.Day1.Puzzle1,
            _2015.Day1.Puzzle2,
            _2015.Day2.Puzzle1,
            _2015.Day2.Puzzle2,
            _2015.Day3.Puzzle1,
            _2015.Day3.Puzzle2,
            _2015.Day4.Puzzle1,
            _2015.Day4.Puzzle2,
            _2015.Day5.Puzzle1,
            _2015.Day5.Puzzle2,
        };
    
        Parallel.ForEach(puzzles, puzzle => puzzle().Wait());
    }

    public static void Main(string[] args)
    {
        RunPuzzles();
    }
}