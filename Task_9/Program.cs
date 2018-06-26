using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество элементов списка: ");
            int size = InputInt();
            Point point = null;

            point = Point.MakeList(size);
            Count(point);

            Console.Write("Нажмите любую клавишу, чтобы завершить программу...");
            Console.ReadKey();
        }

        static void Count(Point point)
        {
            int count = 0;

            Console.Write("\nКоличество элементов в списке: ");

            if (point == null)
            {
                Console.WriteLine("список пуст!");
                return;
            }

            Point p = point;
            while (p != null)
            {
                count++;
                p = p.next;
            }

            Console.WriteLine(count);
        }

        static int InputInt()
        {
            bool ok;
            int input;

            do
            {
                string buf = Console.ReadLine();
                ok = int.TryParse(buf, out input);
                if (!ok || input < 1) { Console.WriteLine("Ошибка: количество элементов должно быть не меньше единицы!"); }
            }
            while (!ok || input < 1);

            return input;
        }
    }

    public class Point
    {
        public int data;
        public Point next;

        public Point()
        {
            data = 0;
            next = null;
        }

        public Point(int d)
        {
            data = d;
            next = null;
        }

        static Point MakePoint(int d)
        {
            Point p = new Point(d);
            return p;
        }

        public static Point MakeList(int size)
        {
            Random rnd = new Random();
            int info = rnd.Next(0, 101);
            Point beg = MakePoint(info);
            Point r = beg;

            for (int i = 1; i < size; i++)
            {
                info = rnd.Next(0, 101);
                Point p = MakePoint(info);
                r.next = p;
                r = p;
            }
            return beg;
        }
    }
}
