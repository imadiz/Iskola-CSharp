namespace Berek2020
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_exit = new Button();
            ms_mainstrip = new MenuStrip();
            fájlToolStripMenuItem = new ToolStripMenuItem();
            megnyitásToolStripMenuItem = new ToolStripMenuItem();
            lbl_numberofworkers = new Label();
            btn_Avg = new Button();
            lbl_Avg = new Label();
            lbx_nevek = new ListBox();
            ms_mainstrip.SuspendLayout();
            SuspendLayout();
            // 
            // btn_exit
            // 
            btn_exit.Location = new Point(12, 404);
            btn_exit.Name = "btn_exit";
            btn_exit.Size = new Size(112, 34);
            btn_exit.TabIndex = 0;
            btn_exit.Text = "Kilépés";
            btn_exit.UseVisualStyleBackColor = true;
            // 
            // ms_mainstrip
            // 
            ms_mainstrip.ImageScalingSize = new Size(24, 24);
            ms_mainstrip.Items.AddRange(new ToolStripItem[] { fájlToolStripMenuItem });
            ms_mainstrip.Location = new Point(0, 0);
            ms_mainstrip.Name = "ms_mainstrip";
            ms_mainstrip.Size = new Size(800, 33);
            ms_mainstrip.TabIndex = 1;
            ms_mainstrip.Text = "menuStrip1";
            // 
            // fájlToolStripMenuItem
            // 
            fájlToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { megnyitásToolStripMenuItem });
            fájlToolStripMenuItem.Name = "fájlToolStripMenuItem";
            fájlToolStripMenuItem.Size = new Size(53, 29);
            fájlToolStripMenuItem.Text = "Fájl";
            // 
            // megnyitásToolStripMenuItem
            // 
            megnyitásToolStripMenuItem.Name = "megnyitásToolStripMenuItem";
            megnyitásToolStripMenuItem.Size = new Size(196, 34);
            megnyitásToolStripMenuItem.Text = "Megnyitás";
            // 
            // lbl_numberofworkers
            // 
            lbl_numberofworkers.AutoSize = true;
            lbl_numberofworkers.Location = new Point(130, 409);
            lbl_numberofworkers.Name = "lbl_numberofworkers";
            lbl_numberofworkers.Size = new Size(263, 25);
            lbl_numberofworkers.TabIndex = 2;
            lbl_numberofworkers.Text = "Dolgozói adatok feldolgozása...";
            // 
            // btn_Avg
            // 
            btn_Avg.AutoSize = true;
            btn_Avg.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_Avg.Location = new Point(12, 36);
            btn_Avg.Name = "btn_Avg";
            btn_Avg.Size = new Size(90, 35);
            btn_Avg.TabIndex = 3;
            btn_Avg.Text = "Átlagbér";
            btn_Avg.UseVisualStyleBackColor = true;
            // 
            // lbl_Avg
            // 
            lbl_Avg.AutoSize = true;
            lbl_Avg.Location = new Point(108, 41);
            lbl_Avg.Name = "lbl_Avg";
            lbl_Avg.Size = new Size(42, 25);
            lbl_Avg.TabIndex = 4;
            lbl_Avg.Text = "0 Ft";
            // 
            // lbx_nevek
            // 
            lbx_nevek.Dock = DockStyle.Right;
            lbx_nevek.FormattingEnabled = true;
            lbx_nevek.ItemHeight = 25;
            lbx_nevek.Location = new Point(479, 33);
            lbx_nevek.Name = "lbx_nevek";
            lbx_nevek.Size = new Size(321, 417);
            lbx_nevek.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(lbx_nevek);
            Controls.Add(lbl_Avg);
            Controls.Add(btn_Avg);
            Controls.Add(lbl_numberofworkers);
            Controls.Add(btn_exit);
            Controls.Add(ms_mainstrip);
            MainMenuStrip = ms_mainstrip;
            Name = "Form1";
            Text = "Bérek";
            ms_mainstrip.ResumeLayout(false);
            ms_mainstrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_exit;
        private MenuStrip ms_mainstrip;
        private ToolStripMenuItem fájlToolStripMenuItem;
        private ToolStripMenuItem megnyitásToolStripMenuItem;
        private Label lbl_numberofworkers;
        private Button btn_Avg;
        private Label lbl_Avg;
        private ListBox lbx_nevek;
    }
}
