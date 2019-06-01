using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceDotNet_cas2_Homework
{
    class Gazella : IPray
    {
        public int FleeSpeed { get; set; }
        public string Name { get; set; }

        public void Flee()
        {
            Console.WriteLine(this.Name + " flees away...");
        }
    }
}
