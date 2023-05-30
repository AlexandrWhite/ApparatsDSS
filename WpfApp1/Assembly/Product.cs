using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Assembly
{
    class Product
    {
        string name;
        int conunt;
        int price_unit;
        int total_price;

        public string Name
        {
            get { return name; }
        }

        public int Count
        {
            get { return conunt; }
        }

        public int PriceUnit
        {
            get { return price_unit; }
        }

        public int TotalPrice
        {
            get { return total_price; }
        }
    }
}
