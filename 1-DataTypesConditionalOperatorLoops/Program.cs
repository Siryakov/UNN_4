using System;
Console.WriteLine("\n Задание #1 ");
Console.WriteLine($"Максимальное число: " + FindMax());
Console.WriteLine("\n Задание #2 ");
FindDivider();
Console.WriteLine("\n \n Задание #6 ");
FindDividerInLine();
Console.WriteLine("\n Задание #8 ");
GameFindNumber();
Console.WriteLine("\n Задание #9 ");
HeadsOrTails();


static double FindMax()
{
    double x, y, z;

    while (true)
    {
        try
        {
            Console.Write("Введите первое число: ");
            x = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите второе число: ");
            y = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите третье число: ");
            z = Convert.ToDouble(Console.ReadLine());

            double max = Math.Max(x, Math.Max(y, z));
            return max; // Возвращаем максимальное число при успешном вводе и вычислении
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: Введите корректное число.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Ошибка: Введено слишком большое (или слишком маленькое) число.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}

static void FindDivider()
{
    Console.Write("Введите число у которого хотите узнать делитель: ");
    int x = Convert.ToInt32(Console.ReadLine());
    Console.Write("Делители: ");
    for (int i = 1; i <= 10; i++)
    {
        if (x % i == 0) Console.Write(i + " ");

    }
}
static void FindDividerInLine()
{
    Console.Write("Введите начало отрезка: ");
    int start = Convert.ToInt32(Console.ReadLine());
    Console.Write(" \n Введите конец отрезка: ");
    int end = Convert.ToInt32(Console.ReadLine());

    int Divider3 = 0;
    int Divider5 = 0;
    int Divider9 = 0;
    for (int i = start; i < end; i++)
    {
        if (i % 3 == 0)
        {
            Divider3++;
        }

        if (i % 5 == 0)
        {
            Divider5++;
        }

        if (i % 9 == 0)
        {
            Divider9++;
        }
    }
    Console.WriteLine($"Количество чисел, делящихся на 3: {Divider3}");
    Console.WriteLine($"Количество чисел, делящихся на 5: {Divider5}");
    Console.WriteLine($"Количество чисел, делящихся на 9: {Divider9}");
}

static void HeadsOrTails()
{
    int flips = 100, heads = 0, tails = 0;
    var random = new Random();

    for (int i = 0; i < flips; i++)
    {
        if (random.Next(2) == 0) heads++;
        else tails++;
    }

    Console.WriteLine($"Орлов: {heads}, Решек: {tails}");
}


static void GameFindNumber()
{
    Random random = new Random();
    int number = random.Next(51); // Генерируем число от 0 до 50 включительно
    int count = 0;

    while (true)
    {
        try
        {
            Console.Write("Введите число: ");
            int numberP = Convert.ToInt32(Console.ReadLine());

            if (numberP < 0 || numberP > 50)
            {
                Console.WriteLine("Число должно быть в диапазоне от 0 до 50.");
            }
            else
            {
                count++;

                if (number == numberP)
                {
                    Console.WriteLine("Вы угадали загаданное число.");
                    break;
                }
                else if (number > numberP)
                {
                    Console.WriteLine("Загаданное число больше: " + numberP);
                }
                else if (number < numberP)
                {
                    Console.WriteLine("Загаданное число меньше: " + numberP);
                }
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: Введите корректное число.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Ошибка: Введено слишком большое (или слишком маленькое) число.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }

    Console.WriteLine("Число попыток: " + count);
}




