using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GUI_projektek
{
    public class Model : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ObservableCollection<string> GUIs { get; set; } = new ObservableCollection<string>();

        public ObservableCollection<string> ReadGUIList()
        {
            List<string> temp = File.ReadAllLines("GUI_List.txt").ToList();
            ObservableCollection<string> output = new ObservableCollection<string>();
            foreach (string item in temp)
            {
                output.Add(item);
            }
            return output;
        }
        public Model()
        {
            GUIs = ReadGUIList();
        }
    }
}
