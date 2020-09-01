using System;

namespace HelloApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            /*
             * Вывод на экран
             * Учимся писать комментарии, как интересно (нет)
             */

            var str = new string('=', 20);
            Console.WriteLine(str);

            //========================================
            //Ввод и вывод данных
            Console.Write("\nEnter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine($"Your name is = {name}");
            Console.WriteLine(str);

            //========================================
            //Деление чисел

            Console.Write("\nEnter first numbers: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.Write("\nEnter second numbers: ");
            double b = Convert.ToDouble(Console.ReadLine());


            if(a == 0 || b == 0)
            {
                Console.WriteLine("Divising by zero...");
            }
            else
            {
                double result = a / b;
                Console.Write($"{a} / {b} = {result}");

            }


            //========================================
            Console.WriteLine("\nPress any key ... ");
            Console.ReadKey();
        }
    }
}
