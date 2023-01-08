using System.Drawing;

namespace BShips;

public class EnemyAi
{
    public static Point RandomGuess(List<Point> enemyGuesses)
    {
        if (enemyGuesses.Count == enemyGuesses.Capacity) throw new OperationCanceledException("Maximum guesses reached!");
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            var guess = new Point();
            var isValid = false;
            while (!isValid)
            {
                guess = new Point()
                {
                    X = rnd.Next(0, 10),
                    Y = rnd.Next(0, 10)
                };
                var duplicate = enemyGuesses.Count(p => p == guess);
                if (duplicate != 0) continue;
                isValid = true;
                enemyGuesses.Add(guess);
            }
            return guess;
    }

    public static Point SearchAndDestroy(Point hit)
    {
        var possibleCoordinates = new Point[]
        {
            new Point {X = hit.X-1, Y = hit.Y},
            new Point {X = hit.X+1, Y = hit.Y},
            new Point {X = hit.X, Y = hit.Y-1},
            new Point {X = hit.X, Y = hit.Y+1}
        };

        for (var i = 0; i < 4; i++)
        {
            if (possibleCoordinates[i].X is < 0 or > 9 || 
                possibleCoordinates[i].Y is < 0 or > 9) possibleCoordinates[i] = Point.Empty;
        }

        var rnd = new Random(Guid.NewGuid().GetHashCode());

        var nextguess = possibleCoordinates[rnd.Next(0, 5)];
        return Point.Empty;
    }
}

