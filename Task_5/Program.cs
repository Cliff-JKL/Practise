using System;

namespace Task_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите размерность квадратной матрицы: ");
            int n = InputN();

            double[,] matr = new double[n, n];

            Console.WriteLine("Введите поочередно значения элементов матрицы: ");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                { matr[i, j] = InputDouble(); }
            }

            double max = GetMax(matr, n);
            Console.WriteLine($"Максимальное из значений элементов матрицы: {max}");

            Console.Write("Нажмите любую клавишу, чтобы завершить программу...");
            Console.ReadKey();
        }

        static double GetMax(double[,] matr, int n)
        {
            int m = n;  // Вспомогательная переменная
            double max = matr[0, 0];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (max < matr[i, j]) { max = matr[i, j]; }
                }
                m -= 1;
            }

            return max;
        }

        static int InputN()
        {
            bool ok;
            int input;

            do
            {
                string buf = Console.ReadLine();
                ok = int.TryParse(buf, out input);
                if (!ok || input < 1) { Console.WriteLine("Ошибка: размерность должна быть больше нуля!"); }
            }
            while (!ok || input < 1);

            return input;
        }

        static double InputDouble()
        {
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
