using System;
using static Game.KeyGenerator;
using static Game.HMACGenerator;
using System.Collections.Generic;
using System.Linq;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length < 3) throw new Exception("You have entered less than 3 arguments!");
                if (Array.Exists(args, element => element == "?" || element == "0")) throw new Exception("You have used banned arguments: '?' or '0'!");
                if (args.Length % 2 == 0) throw new Exception("You have entered an even number of arguments!");
                if (args.Distinct().Count() != args.Length) throw new Exception("You have two or more the same arguments!");

                var keyHMAC = GenerateHMAC(GenerateKey(), args);
                Console.WriteLine($"HMAC:\n{keyHMAC.Item1}");
                TableHelp.ShowMenu(args);

                string userInput = Console.ReadLine();
                while (!(Int32.TryParse(userInput, out int input) && input <= args.Length && input > 0))
                {
                    if (userInput == "?") TableHelp.ShowHelp(new List<string>(args));
                    if (userInput == "0")
                    {
                        Console.WriteLine("You left the game!");
                        Environment.Exit(0);
                    }

                    TableHelp.ShowMenu(args);
                    userInput = Console.ReadLine();
                }

                Rules.GetGameResult(args, keyHMAC.Item3, userInput);
                Console.WriteLine($"HMAC key: {keyHMAC.Item2}");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("You should enter more than 2 arguments - all different (the odd number) \nWithout using the '?' and '0'.\nInput example: rock paper scissors\nInput example: 1 5 6 7 8");
            }
          
        }
    }


}
