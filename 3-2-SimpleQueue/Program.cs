using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Домашняя работа 3 "Методы"

//Задание 1 Стек и его функции push n  pop  back size clear exit

using System;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;


//internal class ClassQueue
//{

//}

public class MyQueue
{
    private int[] arr;
    private int first;
    private int last;
    private int capacity = 100;

    public MyQueue()
    {
        arr = new int[capacity];
        first = 0;
        last = -1;
    }

    public void Push(int n)
    {
        if (IsFull())
        {
            Console.WriteLine("Очередь полна");
            return;
        }
        arr[++last] = n;
    }

    public int Pop()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Очередь пуста");
            Console.WriteLine("error");
            return 0;
        }
        int dequeuedItem = arr[first++];
        return dequeuedItem;
    }

    public int Front()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Очередь пуста");
            Console.WriteLine("error");
            return 0;
        }
        return arr[first];
    }

    public int Size()
    {
        return last - first + 1;
    }

    public bool IsEmpty()
    {
        return first > last;
    }

    public bool IsFull()
    {
        return last == capacity - 1;
    }

    public void Clear()
    {
        first = 0;
        last = -1;
    }

    public void Exit()
    {
        Console.WriteLine("bye");
        Environment.Exit(0);
    }
}