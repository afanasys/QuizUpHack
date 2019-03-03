using System;
using System.Threading;
using QuizUpHack.Helpers;

namespace QuizUpHack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("email:");
            var email = Console.ReadLine();
            Console.WriteLine("password:");
            var password = CommonHelpers.GetPassword();

            var gamer = new Gamer(email, password);
            
            Console.WriteLine();
            for (var index = 0; index < gamer.mySlugs.Count; index++)
            {
                var slugItem = gamer.mySlugs[index];
                Console.WriteLine($"{index}.{slugItem}");
            }

            var slug = "super-bowl";

            do
            {
                Console.WriteLine("Pick a slug(write number of your choice and press enter)");
                try
                {
                    slug = gamer.mySlugs[Convert.ToInt32(Console.ReadLine())];
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("you did wrong. Believe yourself and try again.");
                }
                break;
            } while (true);

            do
            {
                Console.WriteLine("1-Play tournament");
                Console.WriteLine("2-Play with random opponent");
                Console.WriteLine("3-Single player");
                var choice = Console.ReadKey();
                Console.WriteLine("");
                int correctQuestion;
                switch (choice.KeyChar)
                {
                    case '1':
                        Console.WriteLine("How many question do you want to solve correctly");
                        correctQuestion = Convert.ToInt32(Console.ReadLine());
                        gamer.PlayTournament("6a8777ce-e43f-482c-a5b7-e36bc8d6251b", slug, correctQuestion);
                        break;
                    case '2':
                        gamer.PlayWithRandomOpponent(slug);
                        break;
                    case '3':
                        Console.WriteLine("How many question do you want to solve correctly");
                        correctQuestion = Convert.ToInt32(Console.ReadLine());
                        gamer.PlaySinglePlayer(slug, correctQuestion);
                        break;
                    default:
                        Console.WriteLine("pfff, just price 1,2 or 3!");
                        Thread.Sleep(2000);
                        break;
                }
            } while (true);

        }
    }
}
