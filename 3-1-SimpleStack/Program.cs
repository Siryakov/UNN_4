//Домашняя работа 3 "Методы"

//Задание 1 Стек и его функции push n  pop  back size clear exit

using System;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;


//internal class ClassStack
//{
//    private static void Main(string[] args)
//    {
//        int[] arrey = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };
//        MyStack stack = new MyStack();
//        foreach (int item in arrey)
//        {
//            stack.Push(item); // Добавляем элементы из массива в стек
//        }
//        stack.Push();
//        stack.Pop();
//        stack.Back();
//        stack.Size();
//        stack.Clear();
//        stack.Exit();
//    }
//}

public class MyStack<T>
{
    private T[] arr;
    private int top;
    private int capacity = 100; // мощность (максимальное значение стека)

    public MyStack()
    {
        arr = new T[100];
        top = -1;
    }

    public void Push()
    {
        if (IsFull())
        {
            Console.WriteLine("Стек заполнен");
            return;
        }
        Console.WriteLine("Введите значение, которое вы хотите добавить в стек: ");
        T value = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
        arr[++top] = value;
        Console.WriteLine("Ok ");
    }

    public void Push(T value)
    {
        if (IsFull())
        {
            Console.WriteLine("Стек заполнен");
            return;
        }
        arr[++top] = value;
    }

    // Проверяем, не заполнен ли стек
    public bool IsFull()
    {
        return top == capacity - 1;
    }

    public T Pop()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Стек пуст");
            return default(T);
        }
        return arr[top--];
    }

    // Проверяем, пуст ли стек
    public bool IsEmpty()
    {
        return top == -1;
    }

    public void Back()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Стек пуст");
            return;
        }
        Console.WriteLine("Значение последнего элемента: " + arr[top]);
    }

    public void Size()
    {
        Console.WriteLine("Количество элементов в стеке: " + (top + 1));
    }

    public void Clear()
    {
        arr = new T[100];
        top = -1;
        Console.WriteLine("Стек очищен!");
    }

    public void Exit()
    {
        Console.WriteLine("Bye!");
        Environment.Exit(0);
    }
}