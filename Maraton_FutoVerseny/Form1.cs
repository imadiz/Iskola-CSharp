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

namespace Maraton_FutoVerseny
{
    public partial class form_main : Form
    {
        string FilePath = "";
        BindingList<Futo> AllRunners = new BindingList<Futo>();
        public form_main()
        {
            InitializeComponent();
            lbox_resztvevok.DataSource = AllRunners;
            lbox_resztvevok.DisplayMember = "DisplayName";
        }

        private void menuitem_OpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Environment.CurrentDirectory;

            if (ofd.ShowDialog() == DialogResult.OK)
                FilePath = ofd.FileName;

            foreach (string row in File.ReadAllLines(FilePath))
            {
                string[] data = row.Split(';');
                AllRunners.Add(new Futo(data[0], data[1], Convert.ToDateTime(data[2]), data[3], TimeSpan.Parse(data[4])));
            }
        }
    }
}