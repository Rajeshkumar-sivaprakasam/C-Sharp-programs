using System;

namespace pattern_program
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Number of Line: ");
            var number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Start printing!");
            for(int i = 1 ; i <= number; i++)
            {
                for(int j = 1; j <= i; j++)
                {
                    Console.Write(j+" ");
                }

                Console.WriteLine();
            }
        }
    }
}
