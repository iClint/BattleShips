namespace BShips;

public class Map
{
    public readonly Cell[,] Grid;
    public Map()
    {
        var grid = new Cell[10, 10];
        Grid = grid;

        for (var i = 0; i < 10; i++)
        {
            for (var j = 0; j < 10; j++)
            {
                grid[i, j] = new Cell();
            }
        }
    }

    public class Cell
    {
        public bool Occupied = false;
        public bool Targeted = false;
        public string? Symbol;
    }

    public static void DrawMap(Map map)
    {
        Console.WriteLine("  0 1 2 3 4 5 6 7 8 9 x");
        for (var i = 0; i < 10; i++)
        {
            Console.Write($"{i} ");
            for (var j = 0; j < 10; j++)
            {
                var s = (map.Grid[i,j].Occupied == false ? "." : map.Grid[i,j].Symbol);
                Console.Write($"{s} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("y");
    }
}

