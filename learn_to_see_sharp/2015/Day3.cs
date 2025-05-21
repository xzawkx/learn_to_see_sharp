namespace learn_to_see_sharp._2015;

public static class Day3
{
    private static Dictionary<string, bool> _visited1 = new();
    private static Dictionary<string, bool> _visited2 = new();
    private const string Puzzle1FilePath = @"2015\2015_3_1.txt";
    
    private static string ToString(int x, int y){
        return $"{x}-{y}";
    }
    
    public static void Puzzle1()
    {
        Console.WriteLine("Day 3 Puzzle 1 of 2015");
        var x= 0;
        var y = 0;
        _visited1[ToString(x,y)] = true;
        var fullPath = Path.Combine(Program.CurrentDirectory, Puzzle1FilePath);
        var reader = new StreamReader(fullPath);

        for (var c = reader.Read();c != -1;c = reader.Read())
        {
            var direction = (char) c;
            switch (direction)
            {
                case '^': y++; break;
                case 'v': y--; break;
                case '<': x--; break;
                case '>': x++; break;
            }

            if (_visited1.ContainsKey(ToString(x, y))) continue;
            _visited1[ToString(x,y)] = true;
        }
        
        Console.WriteLine($"Result: {_visited1.Count} houses were visited");
    }
    
    public static void Puzzle2()
    {
        Console.WriteLine("Day 3 Puzzle 2 of 2015");
        var x1= 0;
        var y1 = 0;
        var x2= 0;
        var y2 = 0;
        var count = 0;
        _visited2[ToString(x1,y1)] = true;
        var fullPath = Path.Combine(Program.CurrentDirectory, Puzzle1FilePath);
        var reader = new StreamReader(fullPath);

        for (var c = reader.Read();c != -1;c = reader.Read())
        {
            count++;
            var direction = (char) c;
            switch (count % 2)
            {
                case 0:
                    switch (direction)
                    {
                        case '^': y1++; break;
                        case 'v': y1--; break;
                        case '<': x1--; break;
                        case '>': x1++; break;
                    }
                    if (_visited2.ContainsKey(ToString(x1, y1))) continue;
                    _visited2[ToString(x1,y1)] = true;
                    break;
                case 1:
                    switch (direction)
                    {
                        case '^': y2++; break;
                        case 'v': y2--; break;
                        case '<': x2--; break;
                        case '>': x2++; break;
                    }
                    if (_visited2.ContainsKey(ToString(x2, y2))) continue;
                    _visited2[ToString(x2,y2)] = true;
                    break;
            }

        }
        
        Console.WriteLine($"Result: {_visited2.Count} houses were visited");
    }
}