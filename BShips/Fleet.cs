using System.Drawing;

namespace BShips;

public class Fleet
{
    public readonly Ship[] Ships;
    public readonly List<Point> OccupiedCells;
    
    public Fleet()
    {
        var shipList = new[]
            { ShipName.Battleship, ShipName.Carrier, ShipName.Destroyer, ShipName.Submarine, ShipName.PatrolBoat };
        var fleet = new Ship[5];
        var occupiedCells = new List<Point>();

        Ships = fleet;
        OccupiedCells = occupiedCells;
        
        foreach (var ship in shipList)
        {
            fleet[(int)ship] = new Ship(shipList[(int)ship], OccupiedCells);
            for (var i = 0; i < fleet[(int)ship].Length; i++)
            {
                occupiedCells.Add(fleet[(int)ship].XyArray[i]);  
            }
        }
    }

    // Populates map with ship coordinates.
    public static void Fleet2Map(Map map, IEnumerable<Ship> ships)
    {
        foreach (var ship in ships)
        {
            for (var i = 0; i < ship.Length; i++)
            {
                map.Grid[ship.XyArray[i].X, ship.XyArray[i].Y].Occupied = true;
                map.Grid[ship.XyArray[i].X, ship.XyArray[i].Y].Symbol = ship.Symbol; 
            }
        }
    }
}
