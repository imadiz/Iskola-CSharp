using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.ObjectModel;
using System.IO;

namespace Cukraszda.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private string _greeting = "Welcome to Avalonia!";

    [ObservableProperty]
    private ObservableCollection<Cake> _allcakes = new();

    public void ReadFile()
    {
        if (OperatingSystem.IsBrowser())
        {
            Allcakes.Clear();
            string source = "Somlói galuska;300\r\nRákóczi túrós;280\r\nCsoki torta;350\r\nMarcipán alagút;400\r\nEszterházy szelet;400";

            StringReader sr = new(source);
            string? row = sr.ReadLine();
            while (row != null)
            {
                string[] rowdata = row.Split(";");
                Allcakes.Add(new Cake(Convert.ToInt32(rowdata[1]), rowdata[0]));
            }
        }
        else
        {
            foreach (string row in File.ReadAllLines("sutemenyek.txt"))
            {
                string[] rowdata = row.Split(";");
                Allcakes.Add(new Cake(Convert.ToInt32(rowdata[1]), rowdata[0]));
            }
        }
    }
    public MainViewModel()
    {
        ReadFile();
    }
}
