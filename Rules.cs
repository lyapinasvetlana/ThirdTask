using System;

namespace Game
{
    public class Rules
    {

        public static void GetGameResult(string[] gameCondition, string computerMove, string userMove)
         {
            Console.WriteLine($"Your move: {gameCondition[Int16.Parse(userMove) - 1]}");
            Console.WriteLine($"Computer move: {computerMove}");

            int movesNumber = gameCondition.Length;
            int computerIndex = Array.IndexOf(gameCondition, computerMove) + 1;
            int userIndex = Int16.Parse(userMove);

            if (Math.Abs(userIndex - computerIndex) == movesNumber / 2)
            {
                string x = userIndex - computerIndex > 0 ? "You lose!" : "You won!";
                Console.WriteLine(x);
            }

            else if (Math.Abs(userIndex - computerIndex) > movesNumber / 2 && userIndex < computerIndex)
            {
                Console.WriteLine("You lose!");
            }

            else if (userIndex == computerIndex)
            {
                Console.WriteLine("It's a draw!");
            }

            else
            {
                Console.WriteLine("You win!");
            }

        }

    }
}
