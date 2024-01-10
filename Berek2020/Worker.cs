using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Berek2020
{
    internal class Worker : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)//Ez a függvény szól a UI-nak, amikor adatváltozás történik.
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _name = "";
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private string _gender = "";
        public string Gender
        {
            get => _gender;
            set
            {
                _gender = value;
                OnPropertyChanged();
            }
        }

        private string _department = "";
        public string Department
        {
            get => _department;
            set
            {
                _department = value;
                OnPropertyChanged();
            }
        }

        private int _entrydate = 0;
        public int EntryDate
        {
            get => _entrydate;
            set
            {
                _entrydate = value;
                OnPropertyChanged();
            }
        }
        private double _wage = 0;
        public double Wage
        {
            get => _wage;
            set
            {
                _wage = value;
                OnPropertyChanged();
            }
        }
        public Worker(string name, string gender, string department, int entrydate, double wage)
        {
            Name = name;
            Gender = gender;
            Department = department;
            EntryDate = entrydate;
            Wage = wage;
        }
    }
}
