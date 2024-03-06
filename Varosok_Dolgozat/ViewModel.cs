using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Varosok_Dolgozat
{
    [ObservableObject]
    public partial class ViewModel
    {
        [ObservableProperty]
        private ObservableCollection<City> _allCities = new();

        [ObservableProperty]
        private ObservableCollection<string> _allCountries = new();

        [ObservableProperty]
        private City _popSelection;

        [ObservableProperty]
        private City _biggestOrLowest = new();

        private RelayCommand _openfile;
        public ICommand OpenFile
        {
            get
            {
                _openfile = new RelayCommand(() =>
                {
                    OpenFileDialog ofd = new OpenFileDialog
                    {
                        InitialDirectory = Environment.CurrentDirectory
                    };

                    if (ofd.ShowDialog().Equals(true))
                        ReadFile(ofd.FileName);

                });
                return _openfile;
            }
        }

        private RelayCommand<string> _biggestOrLowestPop;
        public ICommand BiggestOrLowestPop
        {
            get
            {
                _biggestOrLowestPop = new RelayCommand<string>((rbtn_name) =>
                {
                    if (rbtn_name.Equals("rbtn_biggest"))
                        BiggestOrLowest = AllCities.OrderBy(x => x.Population).First();
                    else
                        BiggestOrLowest = AllCities.OrderByDescending(x => x.Population).First();
                });
                return _biggestOrLowestPop;
            }
        }

        private RelayCommand _exit;
        public ICommand Exit
        {
            get
            {
                _exit = new RelayCommand(() =>
                {
                    App.Current.Shutdown();
                });
                return _exit;
            }
        }

        private RelayCommand _openfilterwin;
        public ICommand OpenFilterWin
        {
            get
            {
                _openfilterwin = new RelayCommand(() =>
                {
                    FilterWindow filter = new();
                    filter.Show();
                });
                return _openfilterwin;
            }
        }

        public void ReadFile(string PathToFile)
        {
            StreamReader sr = new(PathToFile, Encoding.Default);

            sr.ReadLine();

            while (!sr.EndOfStream)
            {
                string[] rowdata = sr.ReadLine().Split(';');

                AllCities.Add(new City(Convert.ToInt32(rowdata[0]), rowdata[1], rowdata[2], Convert.ToInt32(rowdata[3])));
            }

            AllCountries = new ObservableCollection<string>(AllCities.DistinctBy(x=>x.Country).Select(x=>x.Country));//Összes város
        }

        private RelayCommand _saveFiltered;
        public ICommand SaveFiltered
        {
            get
            {
                _saveFiltered = new RelayCommand(() =>
                {
                    string PathToSave;

                    SaveFileDialog ofd = new SaveFileDialog
                    {
                        InitialDirectory = Environment.CurrentDirectory
                    };


                });
                return _saveFiltered;
            }
        }
    }
}