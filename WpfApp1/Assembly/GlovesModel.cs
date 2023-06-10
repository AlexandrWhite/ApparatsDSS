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

        int selected_material_index = 0;

        Dictionary<string, int> materials = new Dictionary<string, int>()
        {
            { "Латексные",800 },
            { "Нитриловые",200 },
            { "Виниловые",1120 },
            { "Хирургические",150 },
        };

        public GlovesModel()
        {
            string selected_key = materials.Keys.ToList()[selected_material_index];
            price_unit = materials[selected_key];
        }

        public override string Name
        {
            get { return "Перчатки " + materials.Keys.ToList()[selected_material_index].ToLower(); }
        }

        public int SelectedMaterialIndex
        {
            get
            {
                return selected_material_index;
            }
            set
            {
                selected_material_index = value;
                string selected_key = materials.Keys.ToList()[selected_material_index];
                price_unit = materials[selected_key];
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(PriceUnit));
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        public List<string> Materials
        {
            get { return materials.Keys.ToList(); }
        }





    }
}
