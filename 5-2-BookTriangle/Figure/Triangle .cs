using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_2_BookTriangle.Figure
{
    public class Triangle : Figure
    {
        private double a, b, c;

        
        public Triangle(string name, double a, double b, double c) : base(name)
        {
            SetABC(a, b, c);
        }

        // Методы доступа к полям класса SetABC(), GetABC()
        public void SetABC(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public (double, double, double) GetABC()
        {
            return (a, b, c);
        }

        // Свойство Area2, которое определяет площадь треугольника на основании его сторон a, b, c
        public override double Area2
        {
            get
            {
                double p = (a + b + c) / 2;
                return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            }
        }

        // Метод Area(), возвращающий площадь треугольника по его сторонам
        public override double Area()
        {
            return Area2;
        }

        // Виртуальный метод Print() для вывода внутренних полей класса
        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Sides: a={a}, b={b}, c={c}");
        }
    }
}
