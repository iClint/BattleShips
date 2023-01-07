using System.Drawing;

namespace BShips;

public class EnemyAi
{
    public Point RandomGuess(List<Point> enemyGuesses)
    {
        if (enemyGuesses.Count() == enemyGuesses.Capacity) throw new OperationCanceledException("Maximum guesses reached!");
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
}

