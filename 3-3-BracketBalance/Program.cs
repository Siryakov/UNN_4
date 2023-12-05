using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



class Program
{
    static void Main(string[] args)
    {
        // Ваш код здесь

        int[] arrey = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };
        MyStack<int> stack = new MyStack<int>();
        foreach (int item in arrey)
        {
            stack.Push(item); // Добавляем элементы из массива в стек
        }
        stack.Push();
        stack.Pop();
        stack.Back();
        stack.Size();
        stack.Clear();
        stack.Exit();

    }

    public string CheckingForCorrectPlacementOfBrackets(string text) //3
    {
        Stack<int> stack = new Stack<int>();

        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == '(')
            {
                stack.Push(i);
            }
            else if (text[i] == ')')
            {
                if (stack.Count == 0)
                {
                    return "нет (";
                }
                stack.Pop();
            }
        }

        if (stack.Count == 0)
        {
            return "да";
        }
        else
        {
            return "нет " + stack.Count;
        }
    }
}