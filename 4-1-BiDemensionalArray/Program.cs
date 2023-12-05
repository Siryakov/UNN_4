using System.Data;
using System.Text.RegularExpressions;

Console.WriteLine("Введите количество строк массива: ");
int rows = InputValidationForInt();

Console.WriteLine("Введите количество столбцов массива: ");
int cols = InputValidationForInt();


int[,] array = new int[rows, cols];

Console.WriteLine("Введите значения массива через пробел:");

for (int i = 0; i < rows; i++)
{
    string[] values = Regex.Split(Console.ReadLine(), @"\s+"); // Разделяем строку на значения

    for (int j = 0; j < cols; j++)
    {
        if (values.Length > j)
        {
            if (int.TryParse(values[j], out int value))
            {
                array[i, j] = value;
            }
            else
            {
                array[i, j] = 0;
            }
        }
        else
        {
            Console.WriteLine("Недостаточно значений для строки " + (i + 1));
            break;
        }
    }
}


// Вывод массива
Console.WriteLine("Ваш двумерный массив:");
for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < cols; j++)
    {
        Console.Write(array[i, j] + " ");
    }
    Console.WriteLine();
}
int min = 0;
int max = 0;
double sum = 0;
FindMaxInArray(array, rows, cols, out max);
FindMinInArray(array, rows, cols, out min);
FindSumInArray(array, rows, cols, ref sum);
Console.WriteLine($"min: {min}");
Console.WriteLine($"max: {max}");
Console.WriteLine($"sum: {sum}");


static int InputValidationForInt() //Проверка на корректность ввода int-овых значений
{
    int input;
    bool isValid = false;

    do
    {
        isValid = int.TryParse(Console.ReadLine(), out input) && input > 0;
        if (!isValid)
        {
            Console.WriteLine("Некорректный ввод. Пожалуйста, введите положительное целое число.");
        }
    } while (!isValid);

    return input;
}

static void FindMinInArray(in int[,] array, in int rows, in int cols, out int min)
{
    min = int.MaxValue;

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            int value = array[i, j];
            if (value < min)
            {
                min = value;
            }
        }
    }
}

static void FindMaxInArray(in int[,] array, in int rows, in int cols, out int max)
{
    max = int.MinValue;

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            int value = array[i, j];
            if (value > max)
            {
                max = value;
            }
        }
    }
}

static void FindSumInArray(in int[,] array, in int rows, in int cols, ref double sum)
{
    sum = 0;

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            sum += array[i, j];
        }
    }
}