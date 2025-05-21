namespace learn_to_see_sharp._2015;

public static class Day1
{
    private const string Puzzle1FilePath = @"2015\2015_1_1.txt";
    private static int _puzzle2BasementCharacterIndex;
    
    public static Task Puzzle1()
    {
        var sFileFullPath = Path.Combine(Program.CurrentDirectory, Puzzle1FilePath);

        using var reader = new StreamReader(sFileFullPath);
        var count = 0;
        var stack = new Stack<char>();

        for (var j = reader.Read(); j != -1; j = reader.Read())
        {
            var c = (char) j;
            count++;
            if (stack.Count == 0 || stack.Peek() == c)
            {
                stack.Push(c);
                if (_puzzle2BasementCharacterIndex == 0 && c == ')') _puzzle2BasementCharacterIndex = count+1;
                continue;
            }

            stack.Pop();
        }
        
        var nResult = stack.Count;
        var direction = stack.Peek() == '(' ? "up" : "down";
        Console.WriteLine($"Day 1 Puzzle 1 of 2015\nResult: {nResult} floors {direction}");
        return Task.CompletedTask;
    }
    
    public static Task Puzzle2()
    {
        Console.WriteLine($"Day 1 Puzzle 2 of 2015\nResult: Santa Enters Basement at {_puzzle2BasementCharacterIndex}");
        return Task.CompletedTask;
    }
}