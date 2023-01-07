using System.Drawing;

namespace BShips;

public class UserInput
{

    public static Point GetPlayerXy()
    {
        Console.Write("Target Co-Ordinates: X = ");
        var x = Console.ReadKey();
        Console.Write(", Y = ");
        var y = Console.ReadKey();
        if (char.IsDigit(x.KeyChar) && char.IsDigit(x.KeyChar))
        {
            return new Point() 
            { 
                X = (int.Parse(x.KeyChar.ToString())),
                Y = (int.Parse(y.KeyChar.ToString()))
            };
        }

        Console.WriteLine("\nInvalid Co-Ordinate!\n" + 
                          "Any key to try again...");
        var anyKey = Console.Read();
        return Point.Empty;
    }

    public static bool CheckValidPoint(Point xy)
    { 
        return (xy.X is >= 0 and <= 9 && xy.Y is >=0 and <=9 ? true : false) ;
    }
}