using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
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
            DataContext = this;
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
            TextBox_Street.Text = "";
            TextBox_Street.Clear();
        }

        private void CheckBox_Phone_Click(object sender, RoutedEventArgs e)
        {
            if (Stack_NewPhone.Visibility == Visibility.Visible)
                Stack_NewPhone.Visibility = Visibility.Collapsed;
            else Stack_NewPhone.Visibility = Visibility.Visible;
        }

        private void ButtonAddPizza_Click(object sender, RoutedEventArgs e)
        {
            Grid newGrid = GridChoosePizza();

            stackForNewPizza.Children.Add(newGrid);
        }

        private Grid GridChoosePizza()
        {
            Grid grid = new Grid();
            Thickness margin = new Thickness(10, 0, 0, 0);

            ComboBox cbbChoosePizza = new ComboBox()
            {
                Text = "Choose Pizza",
                FontWeight = FontWeights.Bold,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 5, 0, 0),
                SelectedIndex = 0
            };
            ComboBox cbbChooseSize = new ComboBox()
            {
                Text = "Size",
                FontWeight = FontWeights.Bold,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 5, 0, 0),
                SelectedIndex = 0
            };
            ComboBox cbbChooseQuant = new ComboBox()
            {
                Text = "Quantity",
                FontWeight = FontWeights.Bold,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 5, 0, 0),
                SelectedIndex = 0
            };

            Button delete = new Button()
            {
                Background = null,
                BorderBrush = null,
                VerticalAlignment = VerticalAlignment.Center,
                Style = Application.Current.TryFindResource("MaterialDesignFloatingActionMiniAccentButton") as Style,
            };
            MaterialDesignThemes.Wpf.PackIcon exit = new MaterialDesignThemes.Wpf.PackIcon();
            exit.Kind = MaterialDesignThemes.Wpf.PackIconKind.Delete;
            exit.Foreground = Brushes.Red;
            delete.Content = exit;
            delete.Click += new RoutedEventHandler(DeleteSelectedPizza);

            grid.Margin = margin;
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(4, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            Grid.SetColumn(cbbChoosePizza, 0);
            Grid.SetColumn(cbbChooseSize, 1);
            Grid.SetColumn(cbbChooseQuant, 2);
            Grid.SetColumn(delete, 3);

            cbbChoosePizza.ItemsSource = new List<string>() { "Pizza 1", "Pizza 2", "Pizza 3" };
            cbbChooseSize.ItemsSource = new List<string>() { "Small", "Medium", "Large" };
            cbbChooseQuant.ItemsSource = new List<int>() { 1, 2, 3};

            grid.Children.Add(cbbChoosePizza);
            grid.Children.Add(cbbChooseSize);
            grid.Children.Add(cbbChooseQuant);
            grid.Children.Add(delete);

            return grid;
        }

        private void DeleteSelectedPizza(object sender, RoutedEventArgs e)
        {
            
        }

    }
}
