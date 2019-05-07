using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Interfaces;

namespace Workshop
{
    public abstract class ManagementStuff : Employee, IManagable
    {
        private List<Employee> _employees = new List<Employee>();

        public abstract void DoEmployeeApprisal(Employee e);
        
        public string EmailList
        {
            get
            {
                return string.Join(";", _employees.Select(e => e.Email).ToList());
            }
        }

        public void Manage()
        {
            //Console.WriteLine($"Management employee {this.Name}, {this.Surname} manages the company");
            Logger.Log($"Management employee {this.Name}, {this.Surname} manages the company");
        }

        public void AddSubEmployee(Employee e)
        {
            _employees.Add(e);
        }

        public List<Employee> GetEmployees()
        {
            return _employees;
        }

        public void PromoteSubEmployees(int totalPromotionAmount)
        {
            if (_employees.Count > 0)
            {
                int devidedSum = totalPromotionAmount / _employees.Count;
                Array.ForEach(_employees.ToArray(), e => e.Salary += devidedSum);
            }
            else
            {
                Logger.Log($"No employees under the Management stuff", LogType.Error);
            }
        }

        public override string ToString()
        {
            return base.ToString() + "\nEmployees emails: " + this.EmailList;
        }

        public abstract void PromoteEmployee(Employee e);
        public abstract void SendCommunication();
    }
}
