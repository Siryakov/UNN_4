using _5_1_PersonStudentTeacher;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {       
        // Создаем учителей
        var teacher1 = new Teacher("Teacher 1", 35);
        var teacher2 = new Teacher("Teacher 2", 40);

        // Создаем студентов с указанием учителей
        var student1 = new StudentWithAdvisor("Student 1", 20, 3, teacher1);
        var student2 = new StudentWithAdvisor("Student 2", 22, 4, teacher1);
        var student3 = new StudentWithAdvisor("Student 3", 21, 3, teacher2);
        var student4 = new StudentWithAdvisor("Student 4", 23, 4, teacher2);

        // Добавляем студентов к учителям
        teacher1.Students = new List<Student> { student1, student2 };
        teacher2.Students = new List<Student> { student3, student4 };

        // Выводим информацию о студентах
        Console.WriteLine("Information about students:");
        student1.Print();
        student2.Print();
        student3.Print();
        student4.Print();

        // Выводим информацию о учителях и их студентах
        Console.WriteLine("\nInformation about teachers and their students:");
        teacher1.Print();
        teacher2.Print();
    }

}
