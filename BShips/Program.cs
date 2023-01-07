using System.Drawing;
using BShips;

//my battle ship game
/*var playerFleet = new Fleet();
var enemyFleet = new Fleet();
var playerOcean = new Map();
var playerTracking = new Map();
var enemyOcean = new Map();
var enemyTracking = new Map();

//debug();

Fleet.Fleet2Map(playerOcean, playerFleet.TheFleet);
Fleet.Fleet2Map(enemyOcean, enemyFleet.TheFleet);
Map.DrawMap(playerTracking);
Map.DrawMap(playerOcean);
Map.DrawMap(enemyTracking);
Map.DrawMap(enemyOcean);*/

var prevEnemyGuesses = new List<Point>(){Capacity = 100};
var enemyAi = new EnemyAi();
for (var i = 0; i < 100; i++)
{
    enemyAi.RandomGuess(prevEnemyGuesses);
    Console.Clear();
    Console.Write(i);
}

Console.Clear();
foreach (var p in prevEnemyGuesses.ToList())
{
    Console.WriteLine(p.ToString());
}

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