using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    static class GallonsToLiterConverter
    {  
        public static double GallonsToLiter(double gallons)
        {
            return gallons * 3.78541;
        }

        public static double LiterToGallons(double liter)
        {
            return liter / 3.78541;
        }
    }
}
