using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDemo.Models
{
    public class User : IEntity
    {
        public int ID { get; set; }

        public string PhoneNumber { get; set; }

        public string FullName { get; set; }

        public string Address { get; set; }

        public User(int ID, string phoneNumber, string fullName, string address)
        {
            this.ID = ID;
            this.PhoneNumber = phoneNumber;
            this.FullName = fullName;
            this.Address = address;
        }

        //public override bool Equals(object obj)
        //{
        //    User user = obj as User;
        //    if (user == null)
        //        return false;
        //    if (this.ID == user.ID)
        //        return true;
        //    else
        //        return false;
        //}
    }
}
