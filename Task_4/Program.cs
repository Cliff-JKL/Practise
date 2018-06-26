using System;

namespace Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите точность: ");
            double e = InputE();

            double se = Sum(e);

            Console.WriteLine($"Ответ: {se}");

            Console.Write("Нажмите любую клавишу, чтобы завершить программу...");
            Console.ReadKey();
        }

        static double Sum(double e)
        {
            int i = 1;                      // Подсчет слагаемых
            double element = 1.0 / 6.0;     // Текущее слагаемое
            double se = 0;                  // Сумма

            do
            {
                se += element;
                i++;
                element = Math.Pow(-1, i + 1) / ((double)i * ((double)i + 1) * ((double)i + 2));
            }
            while (Math.Abs(element) >= e);

            return se;
        }

        static double InputE()
        {
            bool ok;
            double input;

            do
            {
                string buf = Console.ReadLine();
                ok = double.TryParse(buf, out input);
                if (!ok || input <= 0) { Console.WriteLine("Ошибка: e должно быть > 0!"); }
            }
            while (!ok || input <= 0);

            return input;
        }
    }
}
