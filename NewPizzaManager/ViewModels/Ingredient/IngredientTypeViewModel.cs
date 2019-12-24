using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPizzaManager
{
    public class IngredientTypeViewModel : BaseViewModel
    {
        public ObservableCollection<BLL.IngredientModel> AllIngres { get; set; } = new ObservableCollection<BLL.IngredientModel>(db.GetAllIngres());
        public ObservableCollection<BLL.IngredientModel> IngresInThisType { get; set; }

        public BLL.CategoryModel ThisType { get; set; }

        public IngredientTypeViewModel(BLL.CategoryModel type)
        {
            this.ThisType = type;
            IngresInThisType = new ObservableCollection<BLL.IngredientModel>(db.GetIngresInThisType(type));
        }
    }
}
