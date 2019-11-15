using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PizzaManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int GridCursor_index { get; set; } = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// exit application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExitApp(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Set the cursor grid to move toward the current selected menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMainButtonsClick(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);

            Binding binding = new Binding();

            switch (index)
            {
                case 0:
                    GridCursor_index = 0;
                    GridHome.Visibility = Visibility.Visible;
                    GridOrder.Visibility = Visibility.Collapsed;
                    GridCreate.Visibility = Visibility.Collapsed;
                    GridDiscount.Visibility = Visibility.Collapsed;
                    break;
                case 1:
                    GridCursor_index = 1;
                    GridHome.Visibility = Visibility.Collapsed;
                    GridOrder.Visibility = Visibility.Visible;
                    GridCreate.Visibility = Visibility.Collapsed;
                    GridDiscount.Visibility = Visibility.Collapsed;
                    break;
                case 2:
                    GridCursor_index = 2;
                    GridHome.Visibility = Visibility.Collapsed;
                    GridOrder.Visibility = Visibility.Hidden;
                    GridCreate.Visibility = Visibility.Collapsed;
                    GridDiscount.Visibility = Visibility.Collapsed;
                    break;
                case 3:
                    GridCursor_index = 3;
                    GridHome.Visibility = Visibility.Collapsed;
                    GridOrder.Visibility = Visibility.Collapsed;
                    GridCreate.Visibility = Visibility.Collapsed;
                    GridDiscount.Visibility = Visibility.Visible;
                    break;
                default:
                    break;
            }

            binding.Source = GridCursor_index;
            grid.SetBinding(Grid.ColumnProperty, binding);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_CurrAddr_Click(object sender, RoutedEventArgs e)
        {
            if (Stack_NewAddress.Visibility == Visibility.Visible)
                Stack_NewAddress.Visibility = Visibility.Collapsed;
            else Stack_NewAddress.Visibility = Visibility.Visible;
        }

        private void TextBox_Street_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Binding binding = new Binding();
            binding.Source = String.Empty;
            TextBox_Street.SetBinding(TextBox.TextProperty, binding);
        }
    }
}
