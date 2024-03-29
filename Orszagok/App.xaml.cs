﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Orszagok
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public ViewModel VM { get; set; } = new();
        public MainWindow FirstWin { get; set; } = new MainWindow();
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            FirstWin.Show();
        }
    }
}
