using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iskolaGUI
{
    public partial class form_main : Form
    {
        public form_main()
        {
            InitializeComponent();
            btn_delete.Click += Btn_delete_Click;
            btn_save.Click += Btn_save_Click;
            ReadFile();
        }

        private void Btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter sw = new StreamWriter(new FileStream("nevekNEW.txt", FileMode.CreateNew));
                foreach (string item in lbx_tanulok.Items)
                {
                    sw.WriteLine(item);
                }
                MessageBox.Show("Sikeres mentés!", "IskolaGUI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt a fájl mentésekor: {ex.Message}", "IskolaGUI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_delete_Click(object sender, EventArgs e)
        {
            if (lbx_tanulok.SelectedIndex != -1)
                lbx_tanulok.Items.RemoveAt(lbx_tanulok.SelectedIndex);
            else
                MessageBox.Show("Nem jelölt ki tanulót!", "IskolaGUI", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        public void ReadFile()
        {
            foreach (string row in File.ReadAllLines("nevekGUI.txt"))
                lbx_tanulok.Items.Add(row);
        }
    }
}