using System;

namespace ThirtyOne_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Random random = new Random();

            var n = 5;
            var h = random.Next(5);
            Console.WriteLine(h);
            Console.ReadKey();

        }
    }
}
