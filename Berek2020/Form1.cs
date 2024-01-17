using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Berek2020
{
    public partial class Form1 : Form, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string? propertyName = null)//Ez a függvény szól a UI-nak, amikor adatváltozás történik.
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        List<Worker> AllWorkers = new();
        BindingList<Worker> DisplayWorkers = new();
        public Form1()
        {
            InitializeComponent();
            btn_exit.Click += Btn_exit_Click; 
            btn_Avg.Click += Btn_Avg_Click;

            lbx_nevek.DataSource = DisplayWorkers;
            lbx_nevek.DisplayMember = "Name";

            ReadFile();

            lbl_numberofworkers.Text = $"{AllWorkers.Count} dolgozó adata van feldolgozva.";
        }

        private void Btn_Avg_Click(object? sender, EventArgs e)
        {
            lbl_Avg.Text = $"{AllWorkers.Average(x => x.Wage) / 1000:N1}e Ft";
        }

        public void ReadFile()
        {
            foreach (string item in File.ReadAllLines("berek2020.txt").Skip(1))
            {
                string[] linedata = item.Split(';');
                AllWorkers.Add(new Worker(linedata[0], linedata[1], linedata[2], Convert.ToInt32(linedata[3]), Convert.ToDouble(linedata[4])));
            }

            foreach (Worker item in AllWorkers)
                DisplayWorkers.Add(item);
        }

        private void Btn_exit_Click(object? sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}