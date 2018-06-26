using System;
using System.Collections.Generic;
using System.IO;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(new FileStream(@"INPUT.txt", FileMode.Open, FileAccess.Read));
            StreamWriter sw = new StreamWriter(new FileStream(@"OUTPUT.txt", FileMode.OpenOrCreate, FileAccess.Write));
            string data = sr.ReadLine();            // считываемые числа
            string[] splitter = data.Split(' ');
            int n = Convert.ToInt32(splitter[0]);   // количество букв (первое число)
            int k = Convert.ToInt32(splitter[1]);   // максимальный шаг (второе число)
            List<char> letters = new List<char>();  // список пройденных букв
            List<int> price = new List<int>();      // список стоимостей
            int bestCost = 0;                       // цена лучшего хода
            int currentCost = 0;                    // текущий ход
            char curLet = '0';                      // текущая буква

            if (!(n >= 2) || !(n <= Math.Pow(10, 5)))
            {
                throw new Exception();
            }
            if (!(k >= 1) || !(k <= n))
            {
                throw new Exception();
            }

            letters.Add((char)sr.Read());
            price.Add(0);

            if (n <= k)
            {
                char first = (char)sr.Read();
                for (int i = 0; i < n - 2; i++) { sr.Read(); }
                char last = (char)sr.Read();

                bool check = first == last;
                switch (check)
                {
                    case true:
                        sw.Write("0");
                        break;
                    case false:
                        sw.Write("1");
                        break;
                }
                sw.Close();
                return;
            }
            else
            {
                int i = 1, j = 0;
                for (; i < k; i++)
                {
                    letters.Add((char)sr.Read());
                    bestCost = k;
                    for (; j < i - 1; j++)
                    {
                        if (letters[j] == letters[i]) { currentCost = price[j]; }
                        else { currentCost = price[j] + 1; }
                        if (currentCost < bestCost) { bestCost = currentCost; }
                    }
                    price.Add(bestCost);
                }
                for (i = 0; i < n - k; i++)
                {
                    curLet = (char)sr.Read();
                    bestCost = n;
                    for (j = 0; j < k; j++)
                    {
                        if (letters[j] == curLet) { currentCost = price[j]; }
                        else { currentCost = price[j] + 1; }
                        if (currentCost < bestCost) { bestCost = currentCost; }
                    }
                    letters[i % k] = curLet;
                    price[i % k] = bestCost;
                }
                i--;
                sw.Write(price[i % k]);
                sw.Close();
                return;
            }
        }
    }
}

