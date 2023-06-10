using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Assembly
{
    class PhotoModel:Product
    {

        string selected_photo_papper_name;
        Dictionary<string, int> photo_papper = new Dictionary<string, int>()
        {
            { "Sony UDP-110S", 1300 },
            { "Sony UDP-110HD", 3700 },
            { "Sony UPP-110HG", 2700},
            { "Sony UPP-210HD", 4600 }
        };



        public PhotoModel()
        {
            selected_photo_papper_name = photo_papper.Keys.ToList()[0];
            //name = $"Фотобумага {selected_photo_papper_name}";
            price_unit = photo_papper[selected_photo_papper_name];
        }    
        
        
        public override string Name
        {
            get
            {
                return $"Фотобумага {selected_photo_papper_name}";
            }
        }
            

        public string SelectedPhotoPapperName
        {
            get
            {
                return selected_photo_papper_name;
            }
            set
            {
                selected_photo_papper_name = value;
                price_unit = photo_papper[value];

                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(PriceUnit));
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        public List<string> PhotoPapperNames
        {
            get
            {
                return photo_papper.Keys.ToList();
            }
        }
    }
}
