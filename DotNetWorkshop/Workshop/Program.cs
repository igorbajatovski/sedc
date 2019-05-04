using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee ts = new TechnicalStuff()
            {
                ID = 1,
                Name = "Igor",
                Surname = "Bajatovski",
                Title = "Manager",
                BirthDate = DateTime.Parse("12/27/1983"),
                HireDate = DateTime.Parse("06/27/2009")
            };
            Console.WriteLine(ts);
            ((TechnicalStuff)ts).MaintainSystems();
            ((TechnicalStuff)ts).Eat();
            ((TechnicalStuff)ts).Work();
            Console.WriteLine("Technitian has " + ((TechnicalStuff)ts).WorkingExperiance() + " years of working experiance");
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++");

            Accountant accountant = new Accountant()
            {
                ID = 1,
                Name = "Blagoj",
                Surname = "Ristovski",
                Title = "Police accountant",
                BirthDate = DateTime.Parse("07/06/1978"),
                HireDate = DateTime.Parse("12/05/2006")
            };
            Console.WriteLine(accountant);
            accountant.MaintainAccounts();
            accountant.Eat();
            accountant.Manage();
            Console.WriteLine("Accountant has " + accountant.WorkingExperiance() + " years of working experiance");
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++");

            Robot robot = new Robot()
            {
                ID = 1,
                Name = "R2D2",
                Surname = "Mitchibusi",
                Title = "Robot",
                BirthDate = DateTime.Parse("07/09/2012"),
                HireDate = DateTime.Parse("08/02/2018")
            };
            Console.WriteLine(robot);
            robot.MaintaingDatawareHouse();
            robot.Work();
            Console.WriteLine("Robot has " + robot.WorkingExperiance() + " years of working experiance");
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++");

            Manager manager = new Manager()
            {
                ID = 1,
                Name = "Steve",
                Surname = "Jobs",
                Title = "Apple general manager",
                BirthDate = DateTime.Parse("01/09/1956"),
                HireDate = DateTime.Parse("08/02/1971")
            };
            Console.WriteLine(manager);
            manager.DoEmployeeApprisal(ts);
            manager.PromoteEmployee(accountant);
            manager.SendCommunication();
            manager.Manage();
            Console.WriteLine("Manager has " + manager.WorkingExperiance() + " years of working experiance");
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++");

            Director director = new Director()
            {
                ID = 1,
                Name = "Orce",
                Surname = "Kamcev",
                Title = "Orka holding director",
                BirthDate = DateTime.Parse("10/11/1968"),
                HireDate = DateTime.Parse("10/23/1990")
            };
            Console.WriteLine(director);
            director.DoEmployeeApprisal(manager);
            director.PromoteEmployee(robot);
            director.SendCommunication();
            director.Manage();
            Console.WriteLine("Director has " + director.WorkingExperiance() + " years of working experiance");
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++");

            Console.ReadLine();
        }
    }
}
