using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    public class User
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public double CharactersPerMinute { get; set; }
        [DataMember]
        public double CharactersPerSecond { get; set; }
        
    }

    public static class Leaderboard
    {
        public static List<User> users = new List<User>();
        public static void Load()

        {
            try
            {
                using (FileStream fs = new FileStream("C:\\Users\\user\\Desktop\\leaderboard1.json", FileMode.Open))
                {
                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<User>));
                    users = (List<User>)serializer.ReadObject(fs);
                }
            }
            catch
            {
                Console.WriteLine("Failed to load leaderboard");
            }
        }

        public static void Save()
        {
            try
            {
                using (FileStream fs = new FileStream("C:\\Users\\user\\Desktop\\leaderboard1.json", FileMode.Create))
                {
                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<User>));
                    serializer.WriteObject(fs, users);
                }
            }
            catch
            {
                Console.WriteLine("Failed to save leaderboard");
            }
        }

        public static void AddUser(User user)
        {
            Load();
            users.Add(user);
            Save();
        }

        public static void Display()
        {
            Load();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Leaderboard:");
            foreach (User user in users)
            {
                Console.WriteLine($" Имя - {user.Name}: {user.CharactersPerMinute} слов в минуту, {user.CharactersPerSecond} слов в секунду");
                Console.WriteLine();
            }
            Console.WriteLine("Нажмите ENTER чтобы начать");

        }
    }
    public class TestPech
    {
        public static string txt = "Дядя Семён ехал из города домой. С ним была собака Жучка. Вдруг из леса выскочили волки. Жучка испугалась и прыгнула в сани. У дяди Семёна была хорошая лошадь. Она тоже испугалась и быстро помчалась по дороге. Деревня была близко. Показались огни в окнах. Волки отстали.";
        private static int top = 0;
        private static int j = 0;
        private static bool stop = true;
        private static int rezult = 0;
        static void Start(string name)
        {
            stop = true;
            SizeConsole(120, 30);
            char[] b = txt.ToCharArray();
            int dlina = 120;
            ConsoleKeyInfo key;
            int shet = b.Length;
            int finaly = shet;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(txt);
            bool q = true;
            
            for (int i = 0; i < shet;)
            {
                if (stop == false)
                {
                    break;
                }
                key = Console.ReadKey(true);
                char simvol = key.KeyChar;

                if (i >= dlina)
                {
                    if (j >= dlina)
                    {
                        top++;
                        j = 0;
                    }
                    Console.SetCursorPosition(j, top);
                }
                else
                {
                    Console.SetCursorPosition(i, top);
                }
                if (simvol == b[i])
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(b[i]);
                    i++;
                    j++;
                    finaly--;
                }
            }
            rezult = shet - finaly;
            AddRez(rezult, name);
        }
        private static void SizeConsole(int width, int height)
        {
            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);
        }
        private static void Timer()
        {
            int seconds = 60;
            while (seconds > 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(0, 10);
                Console.WriteLine($"Осталось {seconds} секунд");
                Thread.Sleep(1000);
                seconds--;
            }
            stop = false;
            Console.SetCursorPosition(0, 10);
            Console.WriteLine("СТОП МАШИНА! TIME IS OUT!!!");
        }
        private static void AddRez(int sym, string name)
        {
            int symSek = (int)Convert.ToDouble(sym / 60.0);
            int symMin = sym;
            User user = new User
            {
                Name = name,
                CharactersPerMinute = symMin,
                CharactersPerSecond = symSek
            };
            Leaderboard.AddUser(user);
            Console.Clear();
            Leaderboard.Display();


        }
        public static void ShowTest()
        {
            bool q = true;
            Console.Clear();
            Console.WriteLine("Введите своё имя:");
            string name = Console.ReadLine();
            Console.WriteLine();
            Leaderboard.Display();
            ConsoleKeyInfo key = Console.ReadKey();
            while (key.Key != ConsoleKey.Enter)
            {
                key = Console.ReadKey(true);
            }
            if (key.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                Console.WriteLine(txt);
                Console.WriteLine("\nЕсли готовы, нажмите ENTER чтобы начать");
                while (q != false)
                {
                    key = Console.ReadKey(true);
                    if(key.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    Thread potok = new Thread(new ThreadStart(Timer));
                    potok.Start();
                    Thread.Sleep(1000);
                    Start(name);
                }
            }

        }
    }
}