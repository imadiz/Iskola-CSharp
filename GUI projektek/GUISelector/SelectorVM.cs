using CommunityToolkit.Mvvm.Input;
using GUI_projektek.Jegyek;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GUI_projektek.GUISelector
{
    public class SelectorVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Model _model = new Model();//Háttérlogika
        public Model Model
        {
            get => _model;
            set
            {
                _model = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand<string> _startproject;
        public ICommand StartProject
        {
            get
            {
                _startproject = new RelayCommand<string>((GUI_name) =>
                {
                    Window Selected;
                    switch (GUI_name)
                    {
                        case "Jegyek":
                            Selected = new JegyekView();
                            break;
                        default:
                            MessageBox.Show("A kiválasztott feladat nem található, válassz egy másikat.", "GUIs Projektek", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                    }
                    foreach (Window item in App.Current.Windows)
                    {
                        if (item.Name.Equals("Selector"))
                        {
                            item.Close();
                            Selected.Show();
                            break;
                        }
                    }
                });
                return _startproject;
            }
        }
    }
}
