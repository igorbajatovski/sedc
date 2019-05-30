using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceDotNet_cas2_Homework
{
    class Cat : IPredator, IPray
    {
        public int AttackSpeed { get; set; }
        public string Name { get; set; }
        public int FleeSpeed { get; set; }

        public void Attack(IPray pray)
        {
            if (this.AttackSpeed > pray.FleeSpeed)
                Console.WriteLine(this.Name + " catches " + pray.Name);
            else
                Console.WriteLine(pray.Name + " escapes from " + this.Name);
        }

        public void Flee()
        {
            Console.WriteLine(this.Name + " flees away...");
        }
    }
}
