using System.Drawing;
using BShips;


var playerFleet = new Fleet();
var enemyFleet = new Fleet();
var playerMap = new Map("Player Map");
var enemyMap = new Map("Enemy Map");
var playerTracking = new Map("player Tracking");
var enemyTracking = new Map("Enemy Tracking");
var ui = new UserInput();

//debug();

Fleet.Fleet2Map(playerMap, playerFleet.TheFleet);
Fleet.Fleet2Map(enemyMap, enemyFleet.TheFleet);
Map.DrawMap(playerMap);
Map.DrawMap(playerTracking);
Map.DrawMap(enemyMap);
Map.DrawMap(enemyTracking);
var PlayerXyTarget = UserInput.GetPlayerXy();
var prevPlayerGuesses = new List<Point>() { Capacity = 100 };
var prevEnemyGuesses = new List<Point>(){ Capacity = 100 };
var enemyAi = new EnemyAi();



/*void Debug()
{
    foreach (var ship in playerFleet!.TheFleet)
    {
        Console.WriteLine($"\nClass {ship.ShipName}");
        Console.WriteLine($"Length: {ship.Length}");
        Console.WriteLine($"Orientation: {ship.Orientation}");
        Console.WriteLine("X, Y");
        for (var i = 0; i < ship.Length; i++)
        {
            Console.WriteLine("{0}, {1}", ship.XyArray[i].X, ship.XyArray[i].Y); 
        }
    }
    Console.WriteLine("\nOccupied Cells:");
    foreach (var p in playerFleet.OccupiedCells)
    {
        Console.WriteLine("{0}, {1}", p.X, p.Y);
    }
}*/