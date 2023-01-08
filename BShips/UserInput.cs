using System.Drawing;

namespace BShips;

public class UserInput
{
    public static Point GetPlayerXy()
    {
        var cursorLeft = Console.CursorLeft;
        var cursorTop = Console.CursorTop;
        Console.Write("Target Co-Ordinates: X = ");
        var x = Console.ReadKey();
        Console.Write(", Y = ");
        var y = Console.ReadKey();
        var deleteChars = Console.CursorLeft;
        if (char.IsDigit(x.KeyChar) && char.IsDigit(y.KeyChar))
        {
            return new Point() 
            { 
                X = (int.Parse(x.KeyChar.ToString())),
                Y = (int.Parse(y.KeyChar.ToString()))
            };
        }
        
        ClearLine(cursorLeft,cursorTop);

        Console.Write("Invalid Co-Ordinate!\n");
        SpaceBarToContinue();
        return Point.Empty;
    }

    // Clear buffer for Cursor position to buffer width.
    public static void ClearLine(int left, int top)
    {
        Console.SetCursorPosition(left, top);
        for (int i = 0; i < Console.BufferWidth; i++)
        {
            Console.Write(" ");
        }
        Console.SetCursorPosition(left, top);
    }
    
    // Check received point is valid
    public static bool CheckValidPoint(Point xy)
    { 
        return xy.X is >= 0 and <= 9 && xy.Y is >=0 and <=9 && !xy.IsEmpty ;
    }

    // Pause for user interaction.
    public static void SpaceBarToContinue()
    {
        ConsoleKeyInfo anyKey = default;
        Console.Write("Any Space to continue...");
        while(anyKey.Key != ConsoleKey.Spacebar) 
            anyKey = Console.ReadKey(true);
    }
}

