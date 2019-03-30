using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstracPolymorphisam
{
    public abstract class Animal
    {
        public abstract bool Feathers { get; set; }

        public virtual string Describe()
        {
            return "This is info for Animal: ";
        }

        public abstract string Features();
        public abstract bool HasFeathers();
    }

    class Dog : Animal
    {
        public override bool Feathers { get; set; }
        

        public override string Features()
        {
            return "Can bark.";
        }

        public override bool HasFeathers()
        {
            return false;
        }

        public override string Describe()
        {
            return base.Describe() + " This is dog.";
        }
    }

    class Bird : Animal
    {
        public override bool Feathers { get; set; }

        public override string Features()
        {
            return "Can fly.";
        }

        public override bool HasFeathers()
        {
            return true;
        }

        public override string Describe()
        {
            return base.Describe() + " This is bird.";
        }
    }
}
