using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Assembly
{
    class BasketModel:Product
    {
        public BasketModel()
        {

        }

        public BasketModel(string name, int price_unit) : base(name, price_unit)
        {

        }

    }
}
