// See https://aka.ms/new-console-template for more information

namespace learn_to_see_sharp;

public static class Program
{
    public static readonly string CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
    
    public static void Main(string[] args)
    {
        Console.WriteLine(args);
        _2015.Day1.Puzzle1();
        _2015.Day1.Puzzle2();
        _2015.Day2.Puzzle1();
        _2015.Day2.Puzzle2();
        _2015.Day3.Puzzle1();
        _2015.Day3.Puzzle2();
    }
}