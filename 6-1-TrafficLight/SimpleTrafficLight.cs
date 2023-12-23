using System;
using System.Threading;

class TrafficLight
{
    public event Action<string, int> OnSignalChange;

    public void SimulateTrafficLight()
    {
        while (true)
        {
            OnSignalChange?.Invoke("Красный", 20);
            OnSignalChange?.Invoke("Желтый", 5);
            OnSignalChange?.Invoke("Зеленый", 15);
            OnSignalChange?.Invoke("Желтый", 5);
        }
    }
}

class Program
{
    static void Main()
    {
        TrafficLight trafficLight = new TrafficLight();
        trafficLight.OnSignalChange += DisplaySignal;

        Thread trafficLightThread = new Thread(trafficLight.SimulateTrafficLight);
        trafficLightThread.Start();
    }

    static void DisplaySignal(string color, int duration)
    {
        Console.WriteLine($"Сигнал: {color}, Ожидание: {duration} Секунд");
        Thread.Sleep(duration * 100);
    }
}
