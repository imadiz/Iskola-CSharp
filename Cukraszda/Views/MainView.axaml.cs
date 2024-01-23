using Avalonia.Controls;
using Cukraszda.ViewModels;

namespace Cukraszda.Views;

public partial class MainView : UserControl
{
    public MainViewModel VM;
    public MainView()
    {
        InitializeComponent();
        VM = this.DataContext as MainViewModel;
    }
}