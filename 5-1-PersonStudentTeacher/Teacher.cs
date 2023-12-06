using System;
using System.Collections.Generic;

namespace _5_1_PersonStudentTeacher
{
    public class Teacher : Person, IEquatable<Teacher?>
    {
        public List<Student>? Students { get; set; }

        public Teacher(string name, int age, List<Student>? students = null) : base(name, age)
        {
            Students = students;
        }

        public override void Print()
        {
            Console.WriteLine($"Teacher: {Name}, Age: {Age}");
            if (Students != null)
            {
                Console.WriteLine("Students:");
                foreach (var student in Students)
                {
                    Console.WriteLine($"\t{student}");
                }
            }
        }

        public new object Clone()
        {
            var clonedTeacher = new Teacher(Name, Age);
            if (Students != null)
            {
                clonedTeacher.Students = new List<Student>(Students.Count);
                foreach (var student in Students)
                {
                    clonedTeacher.Students.Add((Student)student.Clone());
                }
            }
            return clonedTeacher;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Teacher);
        }

        public bool Equals(Teacher? other)
        {
            return other is not null &&
                   base.Equals(other) &&
                   Name == other.Name;
        }

        public override int GetHashCode()
        {
            return StringComparer.OrdinalIgnoreCase.GetHashCode(Name);
        }

        public static bool operator ==(Teacher? left, Teacher? right)
        {
            return EqualityComparer<Teacher>.Default.Equals(left, right);
        }

        public static bool operator !=(Teacher? left, Teacher? right)
        {
            return !(left == right);
        }
    }
}
