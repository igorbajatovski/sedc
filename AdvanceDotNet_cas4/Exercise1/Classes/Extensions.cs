using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1.Classes
{
 
    public static class Extensions
    {
        public static string PriceWithCurrency(this double value, string currency)
        {
            // TODO: Implement the extension method PriceWithCurrency()
            /*
                * The method formats amounts. e.g. 100.00 will be formated as 100.00 EUR or 100.00 USD
                */
            return string.Format("{0:F2} eur", value);
        }
    }
}
