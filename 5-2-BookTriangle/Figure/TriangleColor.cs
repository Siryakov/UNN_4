using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_2_BookTriangle.Figure
{
    public class TriangleColor : Triangle
    {
        private string color;

        // Конструктор с 5 параметрами, вызывающий конструктор базового класса
        public TriangleColor(string name, double a, double b, double c, string color) : base(name, a, b, c)
        {
            this.color = color;
        }

        // Свойство Color, которое предназначено для доступа к внутреннему полю color
        public string Color
        {
            get { return color; }
        }

        // Свойство Area2, вызывающее одноименное свойство базового класса для вычисления площади треугольника
        public override double Area2
        {
            get { return base.Area2; }
        }

        // Метод Area(), возвращающий площадь треугольника по его сторонам
        public new double Area()
        {
            return Area2;
        }

        // Виртуальный метод Print() для вывода внутренних полей класса
        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Color: {color}");
        }
    }
}
