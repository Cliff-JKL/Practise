using System;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ввод координат:");
            double x = InputDouble(" введите x: ");
            double y = InputDouble(" введите y: ");

            bool answer = CheckPoint(x, y);

            switch (answer)
            {
                case true:
                    Console.WriteLine($"Точка ({x}, {y}) принадлежит закрашенной области");
                    break;
                case false:
                    Console.WriteLine($"Точка ({x}, {y}) не принадлежит закрашенной области");
                    break;
            }

            Console.Write("Нажмите любую клавишу, чтобы завершить программу...");
            Console.ReadKey();
        }

        static bool CheckPoint(double x, double y)
        {
            return (y >= Math.Pow(x, 2)) && (y <= Math.Exp(x)) && (y <= Math.Exp(-x));
        }

        static double InputDouble(string inputString)
        {
            Console.Write(inputString);
            bool ok;
            double input;

            do
            {
                string buf = Console.ReadLine();
                ok = double.TryParse(buf, out input);
                if (!ok) { Console.WriteLine("Ошибка: неверный ввод!"); }
            }
            while (!ok);

            return input;
        }
    }
}
