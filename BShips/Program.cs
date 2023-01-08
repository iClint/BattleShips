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

Fleet.Fleet2Map(playerMap, playerFleet.Ships);
Fleet.Fleet2Map(enemyMap, enemyFleet.Ships);
// Map.DrawMap(playerMap);
// Map.DrawMap(playerTracking);
// Map.DrawMap(enemyMap);
// Map.DrawMap(enemyTracking);
while (true)
{
    Console.Clear();
    Map.DrawMap(playerTracking);
    Map.DrawMap(playerMap);
    //UserInput.GetPlayerXy();
    var cursorLeft = Console.CursorLeft;
    var cursorTop = Console.CursorTop;
    var xy = UserInput.GetPlayerXy();
    var result = Map.CheckTargetedXy(xy, playerMap, playerTracking, playerFleet);
    playerTracking.Grid[xy.X, xy.Y].Targeted = true;
    if (result.Hit)
    {
        Console.Clear();
        Map.DrawMap(playerTracking);
        Map.DrawMap(playerMap);
        Console.WriteLine(
            playerFleet.Ships[(int)result.Ship!].IsSunk ? "\n         {0} Sunk !!!" : "\n         {0} Hit !!!",
            result.Ship.ToString());
        Console.WriteLine(playerTracking.Grid[xy.X, xy.Y].Targeted);
        Console.WriteLine(playerTracking.Grid[xy.X, xy.Y].Occupied);
        Console.WriteLine(playerFleet.Ships[(int)result.Ship!].IsSunk);
        Console.WriteLine(playerFleet.Ships[(int)result.Ship!].HitCount);
    }
    if(!result.Hit && !result.IsAlreadyTargeted)
    {
        Console.Clear();
        Map.DrawMap(playerTracking);
        Map.DrawMap(playerMap);
        Console.WriteLine("\n             Miss");       
        Console.WriteLine(playerTracking.Grid[xy.X, xy.Y].Targeted);
        Console.WriteLine(playerTracking.Grid[xy.X, xy.Y].Occupied);
    }
    if(result.IsAlreadyTargeted)
    {
        UserInput.ClearLine(cursorLeft,cursorTop);
        Console.Write("Invalid Co-Ordinate!\n");
    }
    UserInput.SpaceBarToContinue();
}
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