using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orszagok
{
    public class ViewModel
    {
        public ObservableCollection<Country> AllCountries { get; set; } = new();
        public void ReadFile()
        {
            StreamReader sr = new($@"orszagok.txt");
            Country temp = new();
            while (!sr.EndOfStream)
            {
                temp.Name = sr.ReadLine().Trim();
                temp.Population = Convert.ToInt32(sr.ReadLine());
                temp.Region = sr.ReadLine().Trim();

                temp = new();

                AllCountries.Add(temp);
            }
        }
        public ViewModel()
        {
            ReadFile();
            var teszt = 0;
        }
    }
}