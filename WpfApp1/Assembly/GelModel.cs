using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Assembly
{
    class GelModel : Product
    {

        string color;
        string density;
        double volume;

        public List<string> COLORS = new List<string>() { "Бесцветный", "Стерильный", "Цветной" };

        public GelModel()
        {

        }

        public GelModel(string name, int price_unit) : base(name, price_unit)
        {

        }
    }
}

