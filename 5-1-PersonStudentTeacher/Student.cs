using System;

namespace _5_1_PersonStudentTeacher
{
    public class Student : Person , IEquatable<Student?>
    {
        public int Course { get; set; }

        // Обновлен базовый конструктор
        public Student(string name, int age, int course) : base(name, age)
        {
            Course = course;
        }

        // Остальной код остается без изменений
        public override void Print()
        {
            Console.WriteLine($"Student: {Name}, Age: {Age}, Course: {Course}");
        }

        public new object Clone()
        {
            return new Student(Name, Age, Course);
        }

        public override bool Equals(object obj)
        {
            if (obj is Student otherStudent)
            {
                return StringComparer.OrdinalIgnoreCase.Equals(Name, otherStudent.Name) &&
                       Age == otherStudent.Age &&
                       Course == otherStudent.Course;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Age, Course);
        }

        public bool Equals(Student? other)
        {
            throw new NotImplementedException();
        }
    }
}
