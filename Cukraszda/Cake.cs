using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cukraszda
{
    public partial class Cake(int price, string name) : ObservableObject
    {
        [ObservableProperty]
        private int _price = price;

        [ObservableProperty]
        private string _name = name;

        [ObservableProperty]
        private string _displayname = $"{name} | {price} Ft";
    }
}
