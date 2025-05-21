namespace learn_to_see_sharp._2015;


public class Day4
{
    private const string Day4Input = "iwrupvqb";

    private static string CreateMD5(string input)
    {
        var inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
        var hash = System.Security.Cryptography.MD5.HashData(inputBytes);

        return Convert.ToHexString(hash);
    }

    private static int GetLowestHashInput(int zeroes)
    {
        var zs = "";
        for (var i = 0; i < zeroes; i++) zs += "0";
        
        for (var i = 0;; i++)
        {
            var hexHash = CreateMD5($"{Day4Input}{i}");
            if (!hexHash.StartsWith(zs)) continue;
            return i;
        }
    }

    public static Task Puzzle1()
    {
        Console.WriteLine($"Day 4 Puzzle 1 of 2015\nResult: The lowest number is {GetLowestHashInput(5)}");
        return Task.CompletedTask;
    }
    
        public static Task Puzzle2()
    {
        Console.WriteLine($"Day 4 Puzzle 2 of 2015\nResult: The lowest number is {GetLowestHashInput(6)}");
        return Task.CompletedTask;
    }
}