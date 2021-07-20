using System;

namespace ConsoleApp1
{
    class Program
    {
        public static void Main()
        {
            double a, b = 0, avg;
            int postive = 0;
            for (int i = 0; i < 6; i++)
            {
                a = double.Parse(Console.ReadLine());

                if (a > 0)
                {
                    postive++;
                    b += a;
                }
            }
            avg = Math.Round((b / postive), 1);
            Console.WriteLine($"{postive} valores positivos");
            Console.WriteLine($"{avg}");

            Console.ReadKey();
        }
    }
}
//6451888