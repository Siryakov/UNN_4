using System;
using System.Collections.Generic;

namespace _5_1_PersonStudentTeacher
{
    public class Person : ICloneable
    {
        public string Name { get; set; }
        public int Age { get; set; } // Добавлено поле Age

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public virtual void Print()
        {
            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            return $"Person: {Name}, Age: {Age}";
        }

        // Реализация глубокого клонирования для класса Person
        public object Clone()
        {
            return new Person(Name, Age);
        }

        // Статический метод для глубокого клонирования списка людей
        public static List<Person> CloneList(List<Person> originalList)
        {
            if (originalList == null)
            {
                return null;
            }

            List<Person> clonedList = new List<Person>();

            foreach (Person person in originalList)
            {
                clonedList.Add((Person)person.Clone());
            }

            return clonedList;
        }

        public override bool Equals(object obj)
        {
            if (obj is Person otherPerson)
            {
                return StringComparer.OrdinalIgnoreCase.Equals(Name, otherPerson.Name) &&
                       Age == otherPerson.Age;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Age);
        }
    }
}
