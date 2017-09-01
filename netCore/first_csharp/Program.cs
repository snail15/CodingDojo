using System;

namespace first_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 255; i++)
            {
                Console.WriteLine(i);
            }
            for (int i = 1; i < 101; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    continue;
                }
                if (i % 3==0 || i % 5==0)
                {
                    System.Console.WriteLine(i);
                }
            }
            for (int i = 1; i < 101; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    System.Console.WriteLine("FizzBuzz");;
                }
                else if (i % 3==0)
                {
                    System.Console.WriteLine("Fizz");
                }
                else if (i % 5 ==0)
                {
                    System.Console.WriteLine("Buzz");
                }

            }

        }
    }
}
