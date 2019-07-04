using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyApp_Dappper.Models
{
    public class Account
    {
        public int ID { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string AccountNumber { get; set; }

        public float Balance { get; set; }

        public string PIN { get; set; }

        public Account()
        {

        }
    }
}
