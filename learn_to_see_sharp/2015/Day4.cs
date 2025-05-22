using System.Text;

namespace learn_to_see_sharp._2015;

public static class Day4
{
    private const string Day4Input = "iwrupvqb";

    private static byte[] CreateMD5(string input)
    {
        var inputBytes = Encoding.ASCII.GetBytes(input);
        var hash = System.Security.Cryptography.MD5.HashData(inputBytes);
        return hash;
    }

    private static int GetLowestHashInput(int zeroes)
    {
        var sb = new StringBuilder(Day4Input, Day4Input.Length + 10);
        for (var i = 0;; i++)
        {
            sb.Length = Day4Input.Length;
            sb.Append(i);
            var cont = true;
            var hexHash = CreateMD5(sb.ToString());
            var zeroBytes = zeroes / 2;
            for (var j = 0; j < zeroBytes; j++)
            {
                if (hexHash[j] == 0) continue;
                cont = false;
                break;
            }

            if (!cont) continue;
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