namespace learn_to_see_sharp._2015;

public static class Day5
{
    private const string Path = @"2015\2015_5_1.txt";
    private static int _niceStrings1;
    private static int _niceStrings2;

    private delegate void Puzzle(string line);

    private static void IsNice(Puzzle f)
    {
        var fullPath = System.IO.Path.Combine(Program.CurrentDirectory, Path);
        var reader = new StreamReader(fullPath);
        for (var line = reader.ReadLine(); line != null; line = reader.ReadLine())
        {
            f(line);
        }
    }

    private static void Puzzle1Check(string line)
    {
        var prev = ' ';
        var vowels = 0;
        var skip = false;
        var dubs = false;
        foreach (var c in line)
        {
            if ($"{prev}{c}" is "ab" or "cd" or "pq" or "xy")
            {
                skip = true;
                break;
            }

            if (c is 'a' or 'e' or 'i' or 'o' or 'u') vowels++;
            if (c == prev) dubs = true;
            prev = c;
        }

        if (!skip && vowels >= 3 && dubs) _niceStrings1++;
    }

    public static Task Puzzle1()
    {
        IsNice(Puzzle1Check);
        Console.WriteLine($"Day 5 Puzzle 1 of 2015\nResult: {_niceStrings1} nice strings");
        return Task.CompletedTask;
    }

    private static void Puzzle2Check(string line)
    {
        var hasDouble = false;
        var hasTriplet = false;
        
        // Check for pairs first
        for (var i = 0; i < line.Length - 1 && !hasDouble; i++)
        {
            var pair = line.Substring(i, 2);
            // Look for this pair in the rest of the string (non-overlapping)
            for (var j = i + 2; j < line.Length - 1; j++)
            {
                if (line.Substring(j, 2) != pair) continue;
                hasDouble = true;
                break;
            }
        }
        
        // Check for a triplet pattern (your original logic was correct for this)
        var currentPair = new Queue<char>();
        foreach (var c in line.TakeWhile(_ => !hasTriplet))
        {
            if (currentPair.Count == 2)
            {
                var pair = string.Join(null, currentPair);
                if (pair[0] == c) hasTriplet = true;
                currentPair.Dequeue();
            }
            currentPair.Enqueue(c);
        }

        if (hasDouble && hasTriplet) _niceStrings2++;
    }

    public static Task Puzzle2()
    {
        IsNice(Puzzle2Check);
        Console.WriteLine($"Day 5 Puzzle 2 of 2015\nResult: {_niceStrings2} nice strings");
        return Task.CompletedTask;
    }
}