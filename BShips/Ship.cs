using System.Drawing;

namespace BShips;

public class Ship
{
    public readonly ShipName ShipName;
    public readonly int Length;
    public readonly Orientation Orientation;
    public readonly Point [] XyArray;
    public  bool IsSunk = false;
    public int HitCount;
    public readonly string Symbol;

    public Ship(ShipName shipName, List<Point> occupiedCells)
    {
        var shipLengths = new[] { 5, 4, 3, 3, 2 };
        var length = shipLengths[(int)shipName];
        var xyArray = new Point[length];
        var hitCount = 0;
        var isSunk = false;
        ShipName = shipName;
        Length = length;
        HitCount = hitCount;
        IsSunk = isSunk;
        Orientation = GetOrientation();
        XyArray = xyArray;
        Symbol = shipName.ToString()[..1];
        PlaceShip(xyArray, occupiedCells);
    }

    // Returns an Orientation at random of either Horizontal or vertical
    private static Orientation GetOrientation()
    {
        var rnd = new Random(Guid.NewGuid().GetHashCode());
        var orientation = rnd.Next(0, 2);
        return (Orientation)orientation;
    }

    //Returns a random X,Y Point.
    private static Point GetRandomCoordinate()
    {
        var rnd = new Random(Guid.NewGuid().GetHashCode());
        var xy = new Point
        {
            X = rnd.Next(0, 10),
            Y = rnd.Next(0, 10)
        };
        return xy;
    }

    
    private void PlaceShip(Point[] xyArray, List<Point> occupiedCells)
    {
        do
        {
            var canBePlaced = false;
            
            switch (Orientation)
            {
                case Orientation.Horizontal:
                {
                    while (!canBePlaced)
                    {
                        xyArray[0] = GetRandomCoordinate();
                        if (xyArray[0].X + Length < 10) canBePlaced = true;
                    }
                    for (var i = 1; i < Length; i++)
                    {
                        xyArray[i].X = xyArray[0].X;
                        xyArray[i].X += i;
                        xyArray[i].Y = xyArray[0].Y;
                    }
                    break;
                }
                case Orientation.Vertical:
                {
                    while (!canBePlaced)
                    {
                        xyArray[0] = GetRandomCoordinate();
                        if (xyArray[0].Y + Length < 10) canBePlaced = true;
                    }
                    for (var i = 1; i < Length; i++)
                    {
                        xyArray[i].X = xyArray[0].X;
                        xyArray[i].Y = xyArray[0].Y;
                        xyArray[i].Y += i;
                    }
                    break;
                }
            }
        } while (!IsOverLapping(xyArray, occupiedCells));
    }

    // determines whether the ship placement will overlap any already placed ships
    private static bool IsOverLapping(IEnumerable<Point> checkXyArray, List<Point> checkOccupiedCells)
    {
        var isAlreadyOccupied = checkOccupiedCells.ToArray().Intersect(checkXyArray);
        var alreadyOccupied = isAlreadyOccupied as Point[] ?? isAlreadyOccupied.ToArray();
        return alreadyOccupied.ToArray().Length == 0;
    }
}

public enum ShipName
{
    Battleship,
    Carrier,
    Destroyer,
    Submarine,
    PatrolBoat
}

public enum Orientation
{
    Horizontal,
    Vertical
}


