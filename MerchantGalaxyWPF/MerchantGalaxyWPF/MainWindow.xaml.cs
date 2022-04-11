using MerchantGalaxyWPF.ViewModel;
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

namespace MerchantGalaxyWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GalaxyViewModel ViewModel;
        public MainWindow()
        {
            InitializeComponent();

            ViewModel = new GalaxyViewModel();
            
            this.DataContext = ViewModel;
        }

        private void RadWatermarkTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ViewModel.InputString = ((Telerik.Windows.Controls.RadWatermarkTextBox)sender).CurrentText;
                ViewModel.Calculation();
            }

        }
    }
}
