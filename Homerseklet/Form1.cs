using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homerseklet
{
    public partial class Form1 : Form, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)//Ez a függvény szól a UI-nak, amikor adatváltozás történik.
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        class Meres
        {
            public string Honap { get; set; }//Hónap neve
            public double KozepHom { get; set; }//Középhőmérséklet
            public double MaxHom { get; set; }//Maximum hőmérséklet
            public string Display
            {
                get => $"{Honap} | Középhőm.: {KozepHom} | (Min. Hőm.: ~{KozepHom - (MaxHom - KozepHom)})";//A megjelenő szöveg a listában.
            }//Megjelenítéshez használt formátum
            public Meres(string honap, double kozepHom, double maxHom)
            {
                Honap = honap;
                KozepHom = kozepHom;
                MaxHom = maxHom;
            }
        }
        private string _eveskozephom;
        public string EvesKozepHom
        {
            get => _eveskozephom;
            set
            {
                _eveskozephom = value;
                OnPropertyChanged();
            }
        }

        private string _legkisebbkozephom;
        public string LegkisebbKozepHom
        {
            get => _legkisebbkozephom;
            set
            {
                _legkisebbkozephom = value;
                OnPropertyChanged();
            }
        }

        //Minden binding a futásidőben módosult adatok megjelenítésére szolgál, így nem kell mindig kiírogatni újra mindent.

        public Form1()
        {
            InitializeComponent();

            txt_search.TextChanged += Txt_search_TextChanged;

            lb_data.DataSource = OsszesMeres;
            lb_data.DisplayMember = "Display";
            lb_data.DrawMode = DrawMode.OwnerDrawFixed;
            lb_data.DrawItem += Lb_data_DrawItem;

            ReadData("honapok.txt");//Adatok beolvasása

            lbl_eveskozephom.DataBindings.Add(new Binding("Text", this, "EvesKozepHom"));//Háttéradatok hozzákötése a UI-hoz
            lbl_legkisebbkozephom.DataBindings.Add(new Binding("Text", this, "LegkisebbKozepHom"));

            EvesKozepHom = $"Éves átlagos középhőm.: {OsszesMeres.Average(x=>x.KozepHom):00.00}";//Átlag
            LegkisebbKozepHom = $"Éves legkisebb középhőm.: {OsszesMeres.Min(x=>x.KozepHom):00.00}";//Legkisebb középhőmérséklet
        }

        #region Középre igazítás
        private void Lb_data_DrawItem(object sender, DrawItemEventArgs e)
        {
            ListBox list = (ListBox)sender;
            if (e.Index > -1)
            {
                string item = (list.Items[e.Index] as Meres).Display;
                e.DrawBackground();
                e.DrawFocusRectangle();
                Brush brush = new SolidBrush(e.ForeColor);
                SizeF size = e.Graphics.MeasureString(item.ToString(), e.Font);
                e.Graphics.DrawString(item.ToString(), e.Font, brush, e.Bounds.Left + (e.Bounds.Width / 2 - size.Width / 2), e.Bounds.Top + (e.Bounds.Height / 2 - size.Height / 2));
            }
        }
        #endregion

        private void Txt_search_TextChanged(object sender, EventArgs e)
        {
            TextBox searchbar = sender as TextBox;//Kereső

            if (string.IsNullOrEmpty(searchbar.Text))//Ha nincs semmi beírva
            {
                lbl_nomatch.Visible = false;//Nincs találat jelzés NEM látható

                foreach (Meres item in HatterMeres)//Megjelenítési lista feltöltése (legyen minden látható)
                    OsszesMeres.Add(item);
            }

            if (!string.IsNullOrWhiteSpace(searchbar.Text))//Ha NEM üres és CSAK látható karaktereket tartalmaz
            {
                OsszesMeres.Clear();//Lista üres

                try
                {
                    HatterMeres.First(x => (x.Honap.ToLower().Equals(searchbar.Text.ToLower()) ||
                                                             x.Honap.ToLower().Contains(searchbar.Text.ToLower())) &&
                                                             x.KozepHom > 10);//Ha nincs találat, hibát dob a Lambda expression

                    lbl_nomatch.Visible = false;//Van találat, NE legyen látható a Nincs találat jelzés

                    foreach (Meres item in HatterMeres.Where(x => (x.Honap.ToLower().Equals(searchbar.Text.ToLower())/*Ha egyezik a név*/ || 
                                                             x.Honap.ToLower().Contains(searchbar.Text.ToLower())) && /*Ha csak egy részlet egyezik*/
                                                             x.KozepHom > 10))/*Ha több mint 10°C a középhőm.*/
                        OsszesMeres.Add(item);//Egyező elemek megjelenítése
                }
                catch (Exception)
                {
                    lbl_nomatch.Visible = true;//Nincs találat jelzés látható
                }
            }
        }

        BindingList<Meres> _osszesmeres = new BindingList<Meres>();
        BindingList<Meres> OsszesMeres
        {
            get => _osszesmeres;
            set
            {
                _osszesmeres = value;
                OnPropertyChanged();
            }
        }//Megjelenítendő lista (Csak a UI-on megjelenő adatokat tartalmazza)

        List<Meres> HatterMeres = new List<Meres>();//Mindig benne van minden adat

        public void ReadData(string FileName)
        {
            foreach (string sor in File.ReadAllLines(FileName))//Fájl beolvasása soronként
            {
                string[] temp = sor.Split(';');//Adatok szétválasztása
                HatterMeres.Add(new Meres(temp[0], Convert.ToDouble(temp[1]), Convert.ToDouble(temp[2])));//Átalakítás és eltárolás
            }

            foreach (Meres item in HatterMeres)//Megjelenítési lista feltöltése
                OsszesMeres.Add(item);
        }
    }
}