using System;
using System.Collections.Generic;

namespace SiryakovHomeWork4Klasss
{
    class ArrayInt
    {
        protected int Length;
        protected List<int> a;

        public ArrayInt() { } // пустой конструктор, для дочернего класса

        public ArrayInt(int Length)
        {
            this.Length = Length;
            this.a = new List<int>();
        }

        public void InputData()
        {
            Console.WriteLine($"Введите элементы массива, длинна которого = #{Length}");
            for (int i = 0; i < Length; i++)
            {
                a.Add(Convert.ToInt32(Console.ReadLine()));
            }
        }

        public void InputDataRandom()
        {
            for (int i = 0; i < Length; i++)
            {
                Random rnd = new Random();
                a.Add(rnd.Next(100));
            }
        }

        public void Print(int start, int end)
        {
            if (start < 0 || start >= Length || end < 0 || end > Length || start >= end)
            {
                Console.WriteLine("Некорректные границы для вывода. Вывод всего массива:");
                start = 0;
                end = Length;
            }

            for (int i = start; i < end; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();
        }

        public void FindValue(int valueToSearch)
        {
            bool found = false;

            for (int i = 0; i < Length; i++)
            {
                if (a[i] == valueToSearch)
                {
                    Console.Write($"Число {valueToSearch} находится в индексах: ");
                    Console.Write($"{i} ");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine($"Число {valueToSearch} не найдено в массиве");
            }
            else
            {
                Console.WriteLine();
            }
        }

        public void DelValue(int numberToDelete)
        {
            a.RemoveAll(x => x == numberToDelete);
            Length = a.Count;
        }
    }

    internal class OneDimensionalArrayOfIntegers
    {
        static void Main(string[] args)
        {
            ArrayInt array = new ArrayInt(5);
            array.InputDataRandom();
            array.Print(0, 5);

            Console.WriteLine("Введите число для поиска:");
            int searchNumber = Convert.ToInt32(Console.ReadLine());
            array.FindValue(searchNumber);

            Console.WriteLine("Введите число для удаления:");
            int deleteNumber = Convert.ToInt32(Console.ReadLine());
            array.DelValue(deleteNumber);
            array.Print(0, 4);

            // Задержка перед завершением программы
            Console.ReadKey();
        }
    }
}
