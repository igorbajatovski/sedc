using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class Program
    {
        public delegate void DelegatePointsTo(string str);
        public delegate int IntDelegate(int i);

        public delegate int AddDeleg(int a, int b);

        static void Main(string[] args)
        {
            DelegatePointsTo deleg1 = new DelegatePointsTo(Hello);
            deleg1("This is first delegate");

            DelegatePointsTo deleg2 = new DelegatePointsTo(Hello);
            deleg1("This is second delegate");

            IntDelegate deleg3 = new IntDelegate(getInt);
            int i = deleg3(456);
            Console.WriteLine(i);

            AddDeleg add = new AddDeleg(Add1);
            add += Add2;
            add += Add3;
            Console.WriteLine(add(5, 10));

            add -= Add3;
            Console.WriteLine(add(5, 10));

            add -= Add2;
            Console.WriteLine(add(5, 10));

            Console.ReadLine();
        }

        public static int Add1(int i, int j)
        {
            Console.WriteLine("Presmetav kolku se i + j = {0}", i+j+1);
            return i + j + 1;
        }

        public static int Add2(int a, int b)
        {
            Console.WriteLine("Presmetav kolku se a + b = {0}", a + b + 2);
            return a + b + 2;
        }

        public static int Add3(int n1, int n2)
        {
            Console.WriteLine("Presmetav kolku se n1 + n2 = {0}", n1 + n2 + 3);
            return n1 + n2 + 3;
        }


        public static void Hello(string strMsg)
        {
            Console.WriteLine(strMsg);
        }

        public static void Pozdrav(string strMsg)
        {
            Console.WriteLine(strMsg);
        }

        public static int getInt(int i)
        {
            return i;
        }
    }
}
