using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Assembly;

namespace WpfApp1
{
    class GlovesModel:Product
    {

        public GlovesModel()
        {

        }

        public GlovesModel(string name, int price_unit) : base(name, price_unit)
        {

        }
    }
}
