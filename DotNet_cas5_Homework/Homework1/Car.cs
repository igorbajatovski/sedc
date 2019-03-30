using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1
{
    class Car
    {
        public string Model { get; set; }
        public int Speed { get; set; }
        public Driver Driver { get; set; }

        public int CalculateSpeed()
        {
            if (this.Driver == null)
                return -1;
            return this.Speed * this.Driver.Skill;
        }
    }
}
