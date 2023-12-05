
using System;
using System.Drawing;
using System.Numerics;
using System.Reflection;


int[] mass1 = { 1, 7, 3, 5, 5, 6, 7, };
int[] mass2 = { 1, 2, 3, 4, 5, 6 };
PrintArray(QuickSort(mass1));
FindMinMaxAverage(mass1);
Console.WriteLine(Cinema(4, 6));
//MatrixMultiplication();

static T[] InsertArrayInArrayOnKPosition<T>(T[] originalArray, T[] newElements, int positionK) //1
{
    // Проверка на допустимость вставки
    if (positionK < 0 || positionK > originalArray.Length)
    {
        throw new ArgumentOutOfRangeException(nameof(positionK));
    }

    // Вычисляем длину нового массива, которая равна сумме длин исходного массива и новых элементов
    int newArrayLength = originalArray.Length + newElements.Length;

    T[] newArray = new T[newArrayLength];

    for (int i = 0, j = 0; i < newArrayLength; i++)
    {
        if (i < positionK)
        {
            // Если индекс i меньше позиции вставки, копируем элемент из исходного массива
            newArray[i] = originalArray[i];
        }
        else
        {
            // Если индекс i больше или равен позиции вставки, добавляем новый элемент из массива newElements
            newArray[i] = newElements[j];
            j++;

            // Если добавили все новые элементы, продолжаем копировать элементы из исходного массива
            if (j == newElements.Length)
            {
                i++;

                // Используем цикл для скопирования оставшихся элементов из исходного массива
                while (i < newArrayLength)
                {
                    // Копируем элементы из исходного массива, с учетом смещения
                    newArray[i] = originalArray[i - newElements.Length];
                    i++;
                }
            }
        }
    }

    // Возвращаем новый массив, в котором выполнена вставка новых элементов
    return newArray;
}

static int[] SwitchArray(int[] array) //2
{
    for (int i = 0; i < array.Length / 2; i++)
    {
        // Обмен элементов местами между первой и второй половиной массива
        int temp = array[i];
        array[i] = array[i + array.Length / 2];
        array[i + array.Length / 2] = temp;
    }
    return array;
}

static int GetUserArraySize()
{
    int size;
    do
    {
        Console.Write("Введите размер массива (положительное целое число): ");
    } while (!int.TryParse(Console.ReadLine(), out size) || size <= 0);

    return size;
}

static int[] InitializeRandomArray(int size) //3.1
{
    Random random = new Random();
    int[] array = new int[size];

    for (int i = 0; i < size; i++)
    {
        array[i] = random.Next(); // Генерация случайного числа
    }

    return array;
}

static T[] AdditionArray<T>(T[] firstArray, T[] secondArray) //3.2
{
    if (firstArray.Length == secondArray.Length)
    {
        int newArrayLength = firstArray.Length + secondArray.Length;
        T[] newArray = new T[newArrayLength];
        int i = 0;
        int c = 0;
        while (i != newArrayLength)
        {
            newArray[i] = firstArray[c];
            i++;
            newArray[i] = secondArray[c];
            i++;
            c++;
        }
        return newArray;
    }
    else
    {
        throw new ArgumentException("Длины массивов не совпадают");
    }

}

static T[] FindCommonValues<T>(T[] array1, T[] array2) // Функция для нахождения общих значений в двух массивах
{
    List<T> commonValues = new List<T>(); // Создаем список для хранения общих значений

    foreach (T item1 in array1) // Перебираем элементы первого массива
    {
        foreach (T item2 in array2) // Для каждого элемента первого массива перебираем элементы второго массива
        {
            if (item1.Equals(item2)) // Если элементы равны, то они общие
            {
                commonValues.Add(item1); // Добавляем общее значение в список
                break; // Прерываем внутренний цикл, так как мы уже нашли общее значение
            }
        }
    }

    return commonValues.ToArray(); // Преобразуем список в массив и возвращаем его
}

static void PrintArray<T>(T[] array) // Функция для вывода массива на консоль
{
    foreach (var i in array) // Перебираем элементы массива
    {
        Console.Write(i + " "); // Выводим каждый элемент на консоль
    }
}

static void SortArray<T>(T[] array) // Функция для сортировки массива (не завершена)
{
    int middleArray = array.Length; // Здесь должна быть реализация сортировки
}

static T[] QuickSort<T>(T[] data) where T : IComparable<T> // Функция для сортировки массива методом быстрой сортировки c опорными точками
{
    if (data.Length <= 1)
    {
        return data; // Если массив содержит 1 элемент или менее, он считается отсортированным
    }
    else
    {
        T pivot = data[0]; // Выбираем опорный элемент (первый элемент массива)
        T[] less = new T[data.Length]; // Массив для элементов меньше опорного
        T[] pivotList = new T[data.Length]; // Массив для элементов равных опорному
        T[] more = new T[data.Length]; // Массив для элементов больше опорного
        int lessCount = 0, pivotCount = 0, moreCount = 0;

        foreach (T item in data) // Перебираем элементы входного массива
        {
            int comparisonResult = item.CompareTo(pivot); // Сравниваем текущий элемент с опорным

            if (comparisonResult < 0) // Если элемент меньше опорного
            {
                less[lessCount++] = item; // Добавляем его в массив less и увеличиваем счетчик
            }
            else if (comparisonResult > 0) // Если элемент больше опорного
            {
                more[moreCount++] = item; // Добавляем его в массив more и увеличиваем счетчик
            }
            else // Если элемент равен опорному
            {
                pivotList[pivotCount++] = item; // Добавляем его в массив pivotList и увеличиваем счетчик
            }
        }

        Array.Resize(ref less, lessCount); // Уменьшаем размер массивов до фактической длины
        Array.Resize(ref pivotList, pivotCount);
        Array.Resize(ref more, moreCount);

        less = QuickSort(less); // Рекурсивно сортируем меньшие и большие элементы
        more = QuickSort(more);

        T[] sortedData = new T[data.Length]; // Создаем массив для хранения отсортированных данных
        Array.Copy(less, sortedData, less.Length); // Копируем данные из массивов less, pivotList и more в один массив
        Array.Copy(pivotList, 0, sortedData, less.Length, pivotList.Length);
        Array.Copy(more, 0, sortedData, less.Length + pivotList.Length, more.Length);

        return sortedData; // Возвращаем отсортированный массив
    }
}

static void FindMinMaxAverage<T>(T[] array) where T : IComparable<T>
{
    if (array == null || array.Length == 0)
    {
        Console.WriteLine("Массив пуст.");
        return;
    }

    T min = array[0];
    T max = array[0];
    double sum = Convert.ToDouble(array[0]);

    foreach (T item in array.Skip(1))
    {
        if (item.CompareTo(min) < 0)
        {
            min = item;
        }
        else if (item.CompareTo(max) > 0)
        {
            max = item;
        }

        sum += Convert.ToDouble(item);
    }

    double average = sum / array.Length;

    Console.WriteLine("\nМинимум: " + min);
    Console.WriteLine("Максимум: " + max);
    Console.WriteLine("Среднее: " + average);
}

static int Cinema(int n, int m) // 4
{
    Random random = new Random();

    int[,] Chairs = new int[n, m];


    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            int randomValue = random.Next(2);
            Chairs[i, j] = randomValue;
            Console.Write(Chairs[i, j] + " "); // Выводим элемент и добавляем пробел для разделения
        }
        Console.WriteLine();
    }

    Console.WriteLine("Введите нужное количество мест: ");
    int k = Convert.ToInt32(Console.ReadLine()); // Количество подряд идущих мест

    for (int i = 0; i < n; i++)
    {
        int consecutiveFreeSeats = 0; // Счетчик подряд идущих свободных мест в текущем ряду

        for (int j = 0; j < m; j++)
        {
            if (Chairs[i, j] == 0)
            {
                consecutiveFreeSeats++;
                if (consecutiveFreeSeats == k)
                {
                    Console.WriteLine("Свободные места есть в ряду:" + i + 1);
                    return i + 1; // Возвращаем номер ряда (индекс + 1)
                }
            }
            else
            {
                consecutiveFreeSeats = 0; // Сбрасываем счетчик, если встречаем занятое место
            }
        }
    }

    return 0;
}


static int[,] MatrixMultiplication1() // 5
{


    int n = 1000; // Размерность матриц
    int[,] x = new int[n, n];
    int[,] y = new int[n, n];
    int[,] result = new int[n, n];
    int rows1 = x.GetLength(0);
    int cols1 = x.GetLength(1);
    int rows2 = y.GetLength(0);
    int cols2 = y.GetLength(1);


    Random random = new Random();
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            int randomValue = random.Next(15);
            x[i, j] = randomValue;
            y[i, j] = randomValue;
        }
    }

    for (int i = 0; i < rows1; i++)
    {
        for (int j = 0; j < cols2; j++)
        {
            int sum = 0;
            for (int k = 0; k < cols1; k++)
            {
                sum += x[i, k] * y[k, j];
            }
            result[i, j] = sum;
        }
    }
    return result;
}
