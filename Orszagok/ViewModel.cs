using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Orszagok
{
    public class ViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Country> AllCountries { get; set; } = new();

        private string _moreorlessdisplay = "";
        public string MoreOrLessDisplay
        {
            get => _moreorlessdisplay;
            set
            {
                _moreorlessdisplay = value;
                OnPropertyChanged();
            }
        }
        public void ReadFile()
        {
            StreamReader sr = new($@"orszagok.txt");
            Country temp = new();
            do
            {
                temp.Name = sr.ReadLine().Trim();
                temp.Population = Convert.ToInt32(sr.ReadLine());
                temp.Region = sr.ReadLine().Trim();

                temp = new();

                AllCountries.Add(temp);
            } while (!sr.EndOfStream);
            AllCountries.RemoveAt(AllCountries.Count - 1);
        }

        private Country _cbiggestorlowest= new Country();
        public Country BiggestOrLowestDisplay
        {
            get => _cbiggestorlowest;
            set
            {
                _cbiggestorlowest = value;
                OnPropertyChanged();
            }
        }

        RelayCommand<bool> _calculatemoreorless;//A true több mint 10 millió
        public ICommand CalculateMoreOrLess
        {
            get
            {
                _calculatemoreorless = new RelayCommand<bool>((ismore) =>
                {
                    if (ismore)//ha több mint 10 millió
                        MoreOrLessDisplay = AllCountries.Count(x => x.Population > 1000).ToString();
                    else
                        MoreOrLessDisplay = AllCountries.Count(x => x.Population < 1000).ToString();
                });
                return _calculatemoreorless;
            }
        }

        private RelayCommand<ComboBox> _biggestorlowest;
        public ICommand BiggestOrLowest
        {
            get
            {
                _biggestorlowest = new RelayCommand<ComboBox>((cmb) =>
                {
                    switch (cmb.SelectedIndex)
                    {
                        case 1:
                            BiggestOrLowestDisplay = AllCountries.First(x => x.Population.Equals(AllCountries.Max(p => p.Population)));
                            break;
                        case 2:
                            BiggestOrLowestDisplay = AllCountries.First(x => x.Population.Equals(AllCountries.Min(p => p.Population)));
                            break;
                        default:
                            break;
                    }
                });
                return _biggestorlowest;
            }
        }
        public ViewModel()
        {
            ReadFile();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}