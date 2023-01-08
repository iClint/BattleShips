namespace BShips;

public class Map
{
    public readonly Cell[,] Grid;
    public readonly string Name;
    public Map(string name)
    {
        var grid = new Cell[10, 10];
        Grid = grid;
        Name = name;

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
        public bool Occupied;
        public bool Targeted;
        public string? Symbol;
    }

    public static void DrawMap(Map map)
    {
        Console.WriteLine("{0}", map.Name);
        Console.WriteLine("  0 1 2 3 4 5 6 7 8 9 y");
        for (var i = 0; i < 10; i++)
        {
            Console.Write($"{i} ");
            for (var j = 0; j < 10; j++)
            {

                var s = map.Grid[i, j].Occupied == false ? "." : map.Grid[i, j].Symbol;
                if (map.Grid[i, j].Targeted) s = "*";
                if (map.Grid[i, j].Targeted && map.Grid[i, j].Occupied) s = "#";
                Console.Write($"{s} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("x");
    }

    public static ShotFiredResult CheckTargetedXy(Point xy, Map map,Map tracking, Fleet fleet)
    {
        var x = xy.X;
        var y = xy.Y;
        var alreadyTargeted = tracking.Grid[x, y].Targeted;
        if (alreadyTargeted) return new ShotFiredResult(false, null, true);
        var hit = (map.Grid[x, y].Occupied);
        if (hit) tracking.Grid[x, y].Occupied = true;
        ShipName? ship = map.Grid[x, y].Symbol switch
        {
            "B" => ShipName.Battleship,
            "C" => ShipName.Carrier,
            "D" => ShipName.Destroyer,
            "S" => ShipName.Submarine,
            "P" => ShipName.PatrolBoat,
            _ => null
        };
        if (ship == null) return new ShotFiredResult(hit, ship, false);
        if (hit) fleet.Ships[(int)ship!].HitCount++;
        if (fleet.Ships[(int)ship!].HitCount == fleet.Ships[(int)ship!].Length)
            fleet.Ships[(int)ship!].IsSunk = true;

        return new ShotFiredResult(hit, ship, false);
    }

    public class ShotFiredResult
    {
        public readonly bool Hit;
        public ShipName? Ship;
        public readonly bool IsAlreadyTargeted;

        public ShotFiredResult(bool hit, ShipName? ship, bool isAlreadyTargeted)
        {
            Hit = hit;
            Ship = ship;
            IsAlreadyTargeted = isAlreadyTargeted;
        }
    }
}

