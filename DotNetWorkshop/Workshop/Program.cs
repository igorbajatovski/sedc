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
            Logger.ArchiveLog();
            Logger.DeleteLog();

            Employee ts = new TechnicalStuff()
            {
                ID = 1,
                Name = "Igor",
                Surname = "Bajatovski",
                Title = "Manager",
                BirthDate = DateTime.Parse("12/27/1983"),
                HireDate = DateTime.Parse("06/27/2009"),
                Email = "igorbajatovski@gmail.com",
                Salary = 12000
            };
            Console.WriteLine(ts);
            ((TechnicalStuff)ts).MaintainSystems();
            ((TechnicalStuff)ts).Eat();
            ((TechnicalStuff)ts).Work();
            Console.WriteLine("Technitianд has " + ((TechnicalStuff)ts).WorkingExperiance() + " years of working experiance");
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++");

            Accountant accountant = new Accountant()
            {
                ID = 2,
                Name = "Blagoj",
                Surname = "Ristovski",
                Title = "Police accountant",
                BirthDate = DateTime.Parse("07/06/1978"),
                HireDate = DateTime.Parse("12/05/2006"),
                Email = "blaspeh@gmail.com",
                Salary = 32000
            };
            Console.WriteLine(accountant);
            accountant.MaintainAccounts();
            accountant.Eat();
            accountant.Manage();
            Console.WriteLine("Accountant has " + accountant.WorkingExperiance() + " years of working experiance");
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++");

            Robot robot = new Robot()
            {
                ID = 3,
                Name = "R2D2",
                Surname = "Mitchibusi",
                Title = "Robot",
                BirthDate = DateTime.Parse("07/09/2012"),
                HireDate = DateTime.Parse("08/02/2018"),
                Email = "bostondynamics@gmail.com",
                Salary = 120000
            };
            Console.WriteLine(robot);
            robot.MaintaingDatawareHouse();
            robot.Work();
            Console.WriteLine("Robot has " + robot.WorkingExperiance() + " years of working experiance");
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++");

            Manager manager = new Manager()
            {
                ID = 4,
                Name = "Steve",
                Surname = "Jobs",
                Title = "Apple general manager",
                BirthDate = DateTime.Parse("01/09/1956"),
                HireDate = DateTime.Parse("08/02/1971"),
                Email = "apple@gmail.com",
                Salary = 600000
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
                ID = 5,
                Name = "Orce",
                Surname = "Kamcev",
                Title = "Orka holding director",
                BirthDate = DateTime.Parse("10/11/1968"),
                HireDate = DateTime.Parse("10/23/1990"),
                Email = "orka@gmail.com",
                Salary = 120000
            };
            Console.WriteLine(director);
            director.DoEmployeeApprisal(manager);
            director.PromoteEmployee(robot);
            director.SendCommunication();
            director.Manage();
            Console.WriteLine("Director has " + director.WorkingExperiance() + " years of working experiance");
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++");

            // +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            Accountant accountant1 = new Accountant()
            {
                ID = 6,
                Name = "Riste",
                Surname = "Tolov",
                Title = "",
                BirthDate = DateTime.Parse("07/06/1978"),
                HireDate = DateTime.Parse("12/05/2006"),
                Email = "ristetolov@gmail.com",
                Salary = 32000
            };

            Accountant accountant2 = new Accountant()
            {
                ID = 7,
                Name = "Pero",
                Surname = "Perov",
                Title = "",
                BirthDate = DateTime.Parse("07/06/1978"),
                HireDate = DateTime.Parse("12/05/2006"),
                Email = "peroperov@gmail.com",
                Salary = 32000
            };

            Employee ts1 = new TechnicalStuff()
            {
                ID = 8,
                Name = "Boban",
                Surname = "Madjovski",
                Title = "Server maintenance",
                BirthDate = DateTime.Parse("12/27/1983"),
                HireDate = DateTime.Parse("06/27/2009"),
                Email = "bobanmadjovski@gmail.com",
                Salary = 12000
            };

            Employee ts2 = new TechnicalStuff()
            {
                ID = 9,
                Name = "Igor",
                Surname = "Micov",
                Title = "Printer maintenance",
                BirthDate = DateTime.Parse("12/27/1983"),
                HireDate = DateTime.Parse("06/27/2009"),
                Email = "igormicov@gmail.com",
                Salary = 12000
            };

            manager.AddSubEmployee(ts);
            manager.AddSubEmployee(accountant);
            manager.AddSubEmployee(accountant1);

            director.AddSubEmployee(ts1);
            director.AddSubEmployee(accountant2);
            director.AddSubEmployee(ts2);

            Console.WriteLine(manager);
            Console.WriteLine();
            Console.WriteLine(director);
            Console.WriteLine();

            Console.WriteLine(manager + "\nEmployees:\n" + string.Join("\n", manager.GetEmployees()));
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine(director + "\nEmployees:\n" + string.Join("\n", director.GetEmployees()));
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++");
            // +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            manager.PromoteSubEmployees(10000);
            Console.WriteLine(manager + "\nEmployees:\n" + string.Join("\n", manager.GetEmployees()));
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++");

            director.PromoteSubEmployees(13500);
            Console.WriteLine(director + "\nEmployees:\n" + string.Join("\n", director.GetEmployees()));
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++");

            Director director1 = new Director()
            {
                ID = 10,
                Name = "Saso",
                Surname = "Mijalkov",
                Title = "Meriot hotel manager",
                BirthDate = DateTime.Parse("10/11/1968"),
                HireDate = DateTime.Parse("10/23/1990"),
                Email = "meriot@gmail.com",
                Salary = 120000
            };

            director1.PromoteSubEmployees(10000);

            Console.ReadLine();
        }
    }
}
