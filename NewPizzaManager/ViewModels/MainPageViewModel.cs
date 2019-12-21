using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NewPizzaManager
{
    public class MainPageViewModel : BaseViewModel
    {
        public ICommand SelectSection { get; set; }

        public Section CurrentSection { get; set; } = Section.QuickOrder;
            
        public MainPageViewModel()
        {
            SelectSection = new RelayParameterizedCommand(Uid => _selectSection(Uid));
        }

        private void _selectSection(object Uid)
        {
            int uid = Convert.ToInt32(Uid);
            CurrentSection = (Section)uid;

            switch (CurrentSection)
            {
                case Section.Home:
                    break;
                case Section.QuickOrder:
                    break;
                case Section.CreatePizza:
                    break;
                case Section.Discount:
                    break;
                default:
                    break;
            }
        }
    }
}
