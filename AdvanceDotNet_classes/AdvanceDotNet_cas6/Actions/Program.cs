using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actions
{
    class Program
    {

        class Student
        {
            public string FullName { get; set; }
            public int Age { get; set; }

            public Student(string name, int age)
            {
                this.FullName = name;
                this.Age = age;
            }

            public Student()
            {
            }
        }


        static void Main(string[] args)
        {
            Action<string> showMessage = delegate (string str) { Console.WriteLine(str); };
            showMessage("Hello World!!!");

            Action line = () => Console.WriteLine();
            Action line2 = delegate { Console.WriteLine(); };
            Action line3 = delegate() { Console.WriteLine(); };
            line();
            line2();
            line3();

            Student student = new Student() { FullName = "Igor Bajatovski", Age = 35 };
            Action<Student> printStudentInfo = delegate (Student s)
            {
                Console.WriteLine($"Name: {s.FullName}, Age: {s.Age}");
            };
            printStudentInfo(student);

            Action<Student> printStudentInfo2 = s => Console.WriteLine($"Name: {s.FullName}, Age: {s.Age}");
            printStudentInfo2(student);

            Console.ReadLine();
        }
    }
}
