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
    /// Interaction logic for CreatePizza.xaml
    /// </summary>
    public partial class OrderView : Page
    {
        public OrderView()
        {
            InitializeComponent();
            this.DataContext = new OrderViewModel();
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
            cbbChooseQuant.ItemsSource = new List<int>() { 1, 2, 3 };

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
