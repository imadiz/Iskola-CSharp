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
using System.Windows.Shapes;

namespace GUI_projektek.GUISelector
{
    /// <summary>
    /// Interaction logic for SelectorView.xaml
    /// </summary>
    public partial class SelectorView : Window
    {
        public SelectorVM VM;
        public SelectorView()
        {
            InitializeComponent();
            VM = this.DataContext as SelectorVM;
        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {
            VM.StartProject.Execute((sender as ListViewItem).Content);
        }
    }
}
