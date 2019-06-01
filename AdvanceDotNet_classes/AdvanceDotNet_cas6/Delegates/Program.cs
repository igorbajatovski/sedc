using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
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
            Func<int> f = new Func<int>(getNumber);
            Console.WriteLine(f());
            Func<double> ddv = delegate { return 18.0; };
            Console.WriteLine(ddv());

            Func<int, int, int, long> volume = delegate(int i, int j, int k)
            {
                return i * j * k;
            };

            Console.WriteLine(volume(2,3,5));

            Console.WriteLine("----------------------------------------------");

            Func<int, int, bool> isEqual = delegate (int i, int j) { return i == j; };
            Console.WriteLine(isEqual(3, 4));
            Console.WriteLine(isEqual(4, 4));

            Func<int, string, bool> isLongerThen = delegate (int length, string str)
            {
                return str.Length > length;
            };
            Console.WriteLine(isLongerThen(10, "sdfsdfs"));

            Console.WriteLine("----------------------------------------------");

            Student student = new Student() { FullName = "Igor Bajatovski", Age = 35 };
            Student student2 = new Student("Blagoj Ristovski", 42);
            Student student3 = new Student("Igor Micov", 15);

            Func<Student, bool> isTeenager = delegate (Student stud)
            {
                return stud.Age > 12 && stud.Age < 20;
            };

            Func<Student, bool> isTeenager2 = (s) => (s.Age > 12 && s.Age < 20);
            Func<Student, bool> isTeenager3 = s => s.Age > 12 && s.Age < 20;
            
            Console.WriteLine(isTeenager(student));
            Console.WriteLine(isTeenager2(student2));
            Console.WriteLine(isTeenager3(student3));

            Console.WriteLine("----------------------------------------------");

            int[] ints = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var parsni = from e in ints.AsEnumerable() where e % 2 == 0 select e;
            Console.WriteLine(string.Join(" ", parsni));

            Console.ReadLine();
        }

        public static int getNumber()
        {
            return 5;
        }
    }
}
