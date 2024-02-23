﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Shortest_Path
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<Point> AllPoints { get; set; } = new ObservableCollection<Point>();
        public List<List<Point>> PossiblePaths { get; set; } = new List<List<Point>>();
        public ObservableCollection<double> PossibleDistances { get; set; } = new ObservableCollection<double>();
        public ObservableCollection<string> AllLogs { get; set; } = new ObservableCollection<string>();
        public Random rnd { get; set; } = new Random();
    }
}