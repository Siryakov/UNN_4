using System;

namespace _5_1_PersonStudentTeacher
{
    public class StudentWithAdvisor : Student
    {
        public Teacher? Teacher { get; set; }
        

        public StudentWithAdvisor(string name, int age, int course, Teacher? teacher = null)
            : base(name, age, course)
        {
            Teacher = teacher;
            
        }

        public override void Print()
        {
            Console.WriteLine($"StudentWithAdvisor: {Name}, Age: {Age}, Course: {Course}");
            if (Teacher != null)
            {
                Console.WriteLine($"Advisor: {Teacher.Name}");
            }
        }

        public new object Clone()
        {
            return new StudentWithAdvisor(Name, Age, Course, (Teacher)Teacher?.Clone());
        }

        public override bool Equals(object obj)
        {
            if (obj is StudentWithAdvisor otherStudentWithAdvisor)
            {
                return StringComparer.OrdinalIgnoreCase.Equals(Name, otherStudentWithAdvisor.Name) &&
                       Age == otherStudentWithAdvisor.Age &&
                       Course == otherStudentWithAdvisor.Course &&
                       ((Teacher == null && otherStudentWithAdvisor.Teacher == null) ||
                        (Teacher != null && otherStudentWithAdvisor.Teacher != null &&
                         Teacher.Equals(otherStudentWithAdvisor.Teacher)));
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Age, Course, Teacher);
        }
    }
}
