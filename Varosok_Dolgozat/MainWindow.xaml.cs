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

namespace Varosok_Dolgozat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void rbtn_orderasc_Checked(object sender, RoutedEventArgs e)
        {
            lbox_allcities.Items.SortDescriptions.Clear();
            lbox_allcities.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("Population", System.ComponentModel.ListSortDirection.Ascending));
        }

        private void rbtn_orderdesc_Checked(object sender, RoutedEventArgs e)
        {
            lbox_allcities.Items.SortDescriptions.Clear();
            lbox_allcities.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("Population", System.ComponentModel.ListSortDirection.Descending));
        }
    }
}
