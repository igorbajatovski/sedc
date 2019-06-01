using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceDotNet_cas2_Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            IPredator shark = new Fish() { AttackSpeed = 30, Name = "Shark" };
            IPray pinguin = new Fish() { FleeSpeed = 25, Name = "Pinguin" };
            IPray herring = new Fish() { FleeSpeed = 35, Name = "Herring" };
            shark.Attack(pinguin);
            shark.Attack(herring);

            IPredator gepard = new Cat() { AttackSpeed = 60, Name = "Gepard" };
            IPray gazella = new Gazella() { FleeSpeed = 55, Name = "Gazella" };
            gepard.Attack(gazella);
            IPredator lion = new Cat { AttackSpeed = 35, Name = "Lion" };
            lion.Attack(gazella);


            Console.ReadLine();
        }
    }
}
