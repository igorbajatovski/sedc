using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    partial class Customer
    {
        partial void PrintCustomerInfo()
        {
            Console.WriteLine(this.Name + " " + this.Address);
        }
    }

    static partial class StaticClass { }
}
