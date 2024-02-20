using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Maraton_FutoVerseny
{
    public class Futo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _uniqueid;
        public string UniqueID
        {
            get => _uniqueid;
            set
            {
                _uniqueid = value;
                OnPropertyChanged();
            }
        }

        private string _displayname;
        public string DisplayName
        {
            get => _displayname;
            set
            {
                _displayname = value;
                OnPropertyChanged();
            }
        }

        private DateTime _birthdate;
        public DateTime BirthDate
        {
            get => _birthdate;
            set
            {
                _birthdate = value;
                OnPropertyChanged();
            }
        }

        private string _country;
        public string Country
        {
            get => _country;
            set
            {
                _country = value;
                OnPropertyChanged();
            }
        }

        private TimeSpan _timeran;
        public TimeSpan TimeRan
        {
            get => _timeran;
            set
            {
                _timeran = value;
                OnPropertyChanged();
            }
        }

        public Futo(string id, string name, DateTime birth, string country, TimeSpan time)
        {
            UniqueID = id;
            DisplayName = name;
            BirthDate = birth;
            Country = country;
            TimeRan = time;
        }
    }
}