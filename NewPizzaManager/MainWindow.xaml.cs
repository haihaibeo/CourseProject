using BLL;
using BLL.Utilitites;
using Ninject;
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

namespace NewPizzaManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var kernel = new StandardKernel(new ContainerConfig(), new ServiceModule("OrderPizzaEntity"));
            IDBDataOperation dbo = kernel.Get<IDBDataOperation>();

            this.DataContext = new WindowViewModel(dbo);
        }
    }
}
