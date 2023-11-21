using ConsoleApp9;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {
                TestPech.ShowTest();
                Console.SetCursorPosition(0, 8);
                Console.Clear();
                Leaderboard.Display();
                Console.WriteLine("Хотите попробовать снова? Если да нажмите f1. Если нет ESC");
                ConsoleKeyInfo key = Console.ReadKey();
                while(key.Key != ConsoleKey.Escape || key.Key != ConsoleKey.F1)
                {
                    key = Console.ReadKey(true);
                }
                if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }

            } while (true);

        }
    }
}