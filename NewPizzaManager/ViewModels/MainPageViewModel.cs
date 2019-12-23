using System;
using System.Windows;
using System.Windows.Input;

namespace NewPizzaManager
{
    public class MainPageViewModel : BaseViewModel
    {
        public ICommand SelectSection { get; set; }

        public Section CurrentSection { get; set; } = Section.Home;

        public Visibility IsOrderVisible { get; set; } = Visibility.Collapsed;
        public Visibility IsOverViewVisible { get; set; } = Visibility.Visible;

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
                    IsOrderVisible = Visibility.Collapsed;
                    IsOverViewVisible = Visibility.Visible;
                    break;

                case Section.QuickOrder:
                    IsOrderVisible = Visibility.Visible;
                    IsOverViewVisible = Visibility.Collapsed;
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