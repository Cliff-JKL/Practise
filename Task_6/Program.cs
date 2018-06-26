using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace Task_6
{
    class Program
    {
        static double a1 = 0, a2 = 0, a3 = 0;
        static double E = 0;
        static Dictionary<int, double> sum = new Dictionary<int, double>();

        static int N = 0;

        static double[] els = new double[N];
        static int[] numbers = new int[N];

        static void Main(string[] args)
        {
            #region Ввод данных
            Console.Write("Введите количество искомых элементов: ");
            N = InputInt();
            Console.Write("Введите E: ");
            E = InputDouble();
            Console.WriteLine("Введите поочередно a1, a2, a3:");
            a1 = InputDouble();
            a2 = InputDouble();
            a3 = InputDouble();
            #endregion

            double a = A(N);

            double[] vs = new double[sum.Keys.Count];
            for (int i = 0; i < vs.Length; i++)
            {
                vs[i] = sum[i + 1];
            }

            double[] els = new double[N];
            for (int i = 1; i < N; i++)
            {
                if (Math.Abs(vs[i] - vs[i - 1]) > E)
                {
                    Console.WriteLine($"{i + 1}) {vs[i]}");
                }
            }

            Console.Write("Нажмите любую клавишу, чтобы завершить программу...");
            Console.ReadKey();
        }

        static double A(int n)
        {
            double an = 0;

            switch (n)
            {
                case 1:
                    an = a1;
                    if (!sum.ContainsKey(n))
                        sum.Add(n, an);
                    return an;
                case 2:
                    an = a2;
                    if (!sum.ContainsKey(n))
                        sum.Add(n, an);
                    return an;
                case 3:
                    an = a3;
                    if (!sum.ContainsKey(n))
                        sum.Add(n, an);
                    return an;
                default:
                    break;
            }

            an = A(n - 1) + 2 * A(n - 2) * A(n - 3);
            if (!sum.ContainsKey(n))
                        sum.Add(n, an);
            return an;
        }

        static int InputInt()
        {
            bool ok;
            int input;

            do
            {
                string buf = Console.ReadLine();
                ok = int.TryParse(buf, out input);
                if (!ok || input < 3) { Console.WriteLine("Ошибка: количество элементов должно быть не меньше трех!"); }
            }
            while (!ok || input < 3);

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
