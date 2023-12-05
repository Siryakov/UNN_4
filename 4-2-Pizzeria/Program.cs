using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ConsoleTables;

namespace SiryakovHomeWork4Klasss
{
    public class Baker
    {
        public string Name { get; set; }
        public int Experience { get; set; }

        public void BakePizza(Order order, Warehouse warehouse)
        {
            order.Baked = true;
            order.Status = "baked";
            warehouse.StorePizza(order);

            if (order.Baked)
            {
                Console.WriteLine($"Пицца для заказа {order.OrderNumber} готова и сохранена на складе.");
                order.Status = "Хранится";
            }
            else
            {
                Console.WriteLine($"Пицца для заказа {order.OrderNumber} не удалось испечь.");
                order.Status = "ошибка_при_печи";
            }
        }
    }

    public class Deliveryman
    {
        public string Name { get; set; }
        public int BagCapacity { get; set; }
        public List<Order> DeliveringOrders { get; } = new List<Order>();
        public Order CurrentOrder { get; private set; }

        public void DeliverPizza(Order order)
        {
            if (DeliveringOrders.Contains(order))
            {
                order.Delivered = true;
                order.Status = "delivered";
                DeliveringOrders.Remove(order);

                Console.WriteLine($"Курьер {Name} доставил пиццу для заказа {order.OrderNumber}.");
            }
            else
            {
                Console.WriteLine($"Курьер {Name} не может доставить несуществующий заказ.");
            }

            CurrentOrder = null;
        }

        public void StartDelivery(Order order)
        {
            if (CurrentOrder == null)
            {
                CurrentOrder = order;
                DeliveringOrders.Add(order);
                Console.WriteLine($"Курьер {Name} начал доставку для заказа {order.OrderNumber}.");
            }
            else
            {
                Console.WriteLine($"Курьер {Name} уже находится в процессе доставки заказа.");
            }
        }
    }

    public class Warehouse
    {
        public int Capacity { get; }
        public List<Order> Pizzas { get; } = new List<Order>();

        public Warehouse(int capacity)
        {
            Capacity = capacity;
        }

        public void StorePizza(Order order)
        {
            if (Pizzas.Count < Capacity)
            {
                Pizzas.Add(order);
            }
            else
            {
                Console.WriteLine("Склад полон. Ожидание свободного места.");
            }
        }
    }

    //public class PizzaName
    //{
    //    public string Name = "123";
    //}

    public class Order
    {
        private static int lastOrderNumber = 0;

        public int OrderNumber { get; }
        public DateTime Timestamp { get; }
        public string Status { get; set; }
        public bool Baked { get; set; }
        public Baker Baker { get; set; }
        public bool Delivered { get; set; }

        public Order()
        {
            lastOrderNumber++;
            OrderNumber = lastOrderNumber;
            Timestamp = DateTime.Now;
            Status = "queued";
            Baked = false;
            Delivered = false;
        }

        public bool IsLate()
        {
            TimeSpan timeElapsed = DateTime.Now - Timestamp;
            return timeElapsed.TotalMinutes > 30;
        }
    }

    public class Employees
    {
        public List<Baker> baker { get; set; }
        public List<Deliveryman> deliveryman { get; set; }
    }




    internal class Pizza
    {
        private static readonly object bakerLock = new object();
        private static readonly object deliverymanLock = new object();

        private static SemaphoreSlim bakerSemaphore = new SemaphoreSlim(1);
        private static SemaphoreSlim deliverymanSemaphore = new SemaphoreSlim(1);

        static Queue<Baker> bakerQueue = new Queue<Baker>();
        static Queue<Deliveryman> deliverymanQueue = new Queue<Deliveryman>();
        static Queue<Order> orderQueue = new Queue<Order>();

        private static List<(int, string, string, string, int)> completedOrders = new List<(int, string, string, string, int)>();

        static async Task Main(string[] args)
        {
            // Получаем текущий рабочий каталог
            string currentDirectory = Directory.GetCurrentDirectory();

            // Строим относительный путь к файлу
            string relativePath = "employees.json";
            string filePath = Path.Combine(currentDirectory, relativePath);

            // Чтение данных из файла
            string json = File.ReadAllText(filePath);

            // Преобразование JSON в объекты
            var employees = JsonConvert.DeserializeObject<Employees>(json);

            if (employees.baker != null)
            {
                foreach (var bakerData in employees.baker)
                {
                    Baker baker = new Baker
                    {
                        Name = bakerData.Name,
                        Experience = bakerData.Experience
                    };
                    bakerQueue.Enqueue(baker);
                }
            }
            else
            {
                Console.WriteLine("Отсутствуют данные о булочниках в файле.");
            }

            if (employees.deliveryman != null)
            {
                foreach (var deliverymanData in employees.deliveryman)
                {
                    Deliveryman deliveryman = new Deliveryman
                    {
                        Name = deliverymanData.Name,
                        BagCapacity = deliverymanData.BagCapacity
                    };
                    deliverymanQueue.Enqueue(deliveryman);
                }
            }
            else
            {
                Console.WriteLine("Отсутствуют данные о курьерах в файле.");
            }

            Console.WriteLine("Создаем объекты Order и передаем их на испечение в несколько потоков");
            List<Task> tasks = new List<Task>();
            for (int i = 0; i < 20; i++)
            {
                Order order = new Order();
                orderQueue.Enqueue(order);
                tasks.Add(Task.Run(() => ProcessOrder()));
            }

            await Task.WhenAll(tasks);

            // После завершения всех заказов выполняем анализ и предоставляем рекомендации
            AnalyzeAndRecommend();

            // Запись данных в файл
            WriteToFile();
        }

        static async Task ProcessOrder()
        {
            Warehouse warehouse = new Warehouse(10);
            while (orderQueue.Count > 0)
            {
                Baker baker;
                await bakerSemaphore.WaitAsync();
                try
                {
                    baker = bakerQueue.Count > 0 ? bakerQueue.Dequeue() : null;
                    Console.WriteLine($"Попытка взять булочника {baker?.Name} из очереди.");
                }
                finally
                {
                    bakerSemaphore.Release();
                }

                if (baker != null)
                {
                    Console.WriteLine($"Взят булочник {baker.Name} из очереди.");

                    Order order;
                    lock (orderQueue)
                    {
                        order = orderQueue.Count > 0 ? orderQueue.Dequeue() : null;
                        Console.WriteLine($"Попытка взять заказ {order?.OrderNumber} из очереди.");
                    }

                    if (order != null)
                    {
                        Console.WriteLine($"Получен заказ {order.OrderNumber} для булочника {baker.Name}.");

                        // Добавляем информацию о булочнике в заказ
                        order.Baker = baker;

                        baker.BakePizza(order, warehouse);

                        Random random = new Random();
                        int bakeTime = random.Next(1000, 5000);
                        Console.WriteLine($"Имитация времени приготовления пиццы: {bakeTime} мс.");
                        await DeliverPizzaAsync(order);

                        await bakerSemaphore.WaitAsync();
                        try
                        {
                            bakerQueue.Enqueue(baker);
                        }
                        finally
                        {
                            bakerSemaphore.Release();
                        }
                        Console.WriteLine($"Булочник {baker.Name} возвращен в очередь.");
                    }
                    else
                    {
                        Console.WriteLine("Нет доступных заказов. Пожалуйста, подождите...");
                        await Task.Delay(1000);
                    }
                }
                else
                {
                    Console.WriteLine("Нет доступных булочников. Пожалуйста, подождите...");
                    await Task.Delay(1000);
                }
            }
        }
        static void AnalyzeAndRecommend()
        {
            Console.WriteLine("Анализ выполненных заказов и предоставление рекомендаций владельцу:");

            // Проводим анализ выполненных заказов
            int totalDeliveredOrders = completedOrders.Count;
            int lateOrders = completedOrders.Count(o => o.Item4 == "delivered" && IsOrderLate(o.Item1));

            Console.WriteLine($"Всего выполненных заказов: {totalDeliveredOrders}");
            Console.WriteLine($"Из них просроченных: {lateOrders}");

            // Предоставляем рекомендации владельцу
            if (lateOrders > totalDeliveredOrders / 2)
            {
                Console.WriteLine("Рекомендация: Увеличьте количество заказов, чтобы справиться с повышенным спросом.");
            }
            else if (lateOrders == 0)
            {
                Console.WriteLine("Рекомендация: Ваша команда эффективно выполняет заказы. Рассмотрите возможность расширения склада.");
            }
            else
            {
                Console.WriteLine("Рекомендация: Рассмотрите возможность найма дополнительных пекарей и курьеров для улучшения производительности.");
            }
        }

        static bool IsOrderLate(int deliveryTime)
        {
            // Задержка более 30 секунд считается просроченной
            return deliveryTime > 30000;
        }

        static void WriteToFile()
        {
            // Формируем текст для записи в файл
            var table = new ConsoleTable("Order", "Baker", "Deliveryman", "Status", "Delivery Time (ms)");

            // Заполняем таблицу данными о выполненных заказах
            foreach (var orderData in completedOrders)
            {
                table.AddRow(orderData.Item1, orderData.Item2, orderData.Item3, orderData.Item4, orderData.Item5);
            }

            Console.WriteLine(table);

            // Получаем текущий рабочий каталог
            string currentDirectory = Directory.GetCurrentDirectory();

            // Строим относительный путь к файлу
            string relativePath = "completed_orders.txt";
            string filePath = Path.Combine(currentDirectory, relativePath);

            // Записываем текст в файл
            File.WriteAllText(filePath, table.ToMarkDownString());

            Console.WriteLine($"Данные о выполненных заказах записаны в файл: {filePath}");
        }

        static async Task DeliverPizzaAsync(Order order)
        {
            while (true)
            {
                if (deliverymanQueue.Count > 0)
                {
                    Deliveryman deliveryman = null;
                    lock (deliverymanQueue)
                    {
                        if (deliverymanQueue.Count > 0)
                        {
                            deliveryman = deliverymanQueue.Dequeue();
                        }
                    }

                    if (deliveryman != null)
                    {
                        deliveryman.StartDelivery(order);

                        // Рандомная задержка для имитации времени доставки
                        Random random = new Random();
                        int deliveryTime = random.Next(2000, 8000); // Задержка от 2 до 8 секунд

                        await Task.Delay(deliveryTime); // Асинхронно ждем, пока доставка завершится

                        // Курьер возвращается в очередь
                        lock (deliverymanQueue)
                        {
                            deliverymanQueue.Enqueue(deliveryman);
                        }

                        order.Status = "delivered"; // Обновляем статус заказа

                        // Выводим информацию о доставке на экран
                        Console.WriteLine($"Курьер {deliveryman.Name} доставил пиццу для заказа {order.OrderNumber} за {deliveryTime} мс.");

                        completedOrders.Add((order.OrderNumber, order.Baker.Name, deliveryman.Name, order.Status, deliveryTime));
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Ошибка при извлечении курьера из очереди. Пожалуйста, подождите...");
                        await Task.Delay(1000);
                    }
                }
                else
                {
                    Console.WriteLine($"Нет доступных курьеров. Заказ {order.OrderNumber} ожидает доставки.");
                    await Task.Delay(1000); // Пауза перед повторной попыткой
                }
            }
        }

    }
}
