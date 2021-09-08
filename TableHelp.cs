using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleTables;

namespace Game
{
    public class TableHelp
    {
        public static void ShowHelp(List<string> gameAction)
        {
            var firstRow = new List<string>(gameAction);
            firstRow.Insert(0, "USER \\ PC");
            var table = new ConsoleTable(firstRow.ToArray());
            
            for (int i = 1; i < gameAction.Count() + 1; i++)
            {
                int movesNumber = gameAction.Count();
                var row = new string[(movesNumber + 1)];
                row[0] = gameAction[i-1];
                row[i]= "DRAW";

                for (int j = 1; j < gameAction.Count()/2 + 1; j++)
                {
                    var place = gameAction.Count() + j - i;
                    if (j + i > gameAction.Count()) row[Math.Abs(gameAction.Count() - j - i)] = "WIN";
                    else row[j + i] = "WIN";

                    if (i - j - 1 < 0) row[gameAction.Count() + i - j] = "LOSE";
                    else row[i - j] = "LOSE";
                }

                table.AddRow(row);   
            }
            table.Write(Format.Alternative);
        }

        public static void ShowMenu(string[] inputMoves)
        {
            Console.WriteLine("Available moves:");
            for (int i = 1; i < inputMoves.Length + 1; i++)
            {
                Console.WriteLine($"{i} - {inputMoves[i - 1]} ");
            }

            Console.WriteLine("0 - exit");
            Console.WriteLine("? - help");
            Console.Write("Enter your move: ");
        }
    }
}
