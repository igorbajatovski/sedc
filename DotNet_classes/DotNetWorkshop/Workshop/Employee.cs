using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop
{
    public abstract class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Title { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public string Email { get; set; }
        public int Salary { get; set; }

        public int WorkingExperiance()
        {
            return DateTime.Now.Year - HireDate.Year;
        }

        public override string ToString()
        {   
            return $"ID\tName\tSurname\tTitle\tBirth Date\tHire Date\tEmail\tSalary\n" +
                   $"{ID}\t{Name}\t{Surname}\t{Title}\t{BirthDate.ToShortDateString()}\t{HireDate.ToShortDateString()}\t{Email}\t{Salary}";
        }
    }
}
