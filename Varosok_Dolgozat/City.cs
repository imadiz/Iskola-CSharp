    using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Varosok_Dolgozat
{
    public partial class City : ObservableObject
    {
        [ObservableProperty]
        private int _number;

        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private string _country;

        [ObservableProperty]
        private int _population;

        public City(int number, string name, string country, int population)
        {
            _number = number;
            _name = name;
            _country = country;
            _population = population;
        }
        public City()
        {

        }
    }
}
