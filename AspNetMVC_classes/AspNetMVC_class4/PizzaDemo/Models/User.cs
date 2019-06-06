using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDemo.Models
{
    public class User
    {
        public string PhoneNumber { get; set; }

        public string FullName { get; set; }

        public string Address { get; set; }

        public User(string phoneNumber, string fullName, string address)
        {
            this.PhoneNumber = phoneNumber;
            this.FullName = fullName;
            this.Address = address;
        }
    }
}
