using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPizzaManager
{
    public class IngreTypeViewModel : BaseViewModel
    {
        public ObservableCollection<BLL.IngredientModel> IngresInThisCate { get; set; }
        public ObservableCollection<BLL.IngredientModel> AllIngre = new ObservableCollection<BLL.IngredientModel>(db.GetAllIngres());
        public BLL.CategoryModel CateIngre { get; set; }

        public IngreTypeViewModel()
        {

        }
    }
}
