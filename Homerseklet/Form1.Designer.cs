namespace Homerseklet
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lb_data = new System.Windows.Forms.ListBox();
            this.lbl_eveskozephom = new System.Windows.Forms.Label();
            this.lbl_legkisebbkozephom = new System.Windows.Forms.Label();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.lbl_nomatch = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_data
            // 
            this.lb_data.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lb_data.FormattingEnabled = true;
            this.lb_data.Location = new System.Drawing.Point(0, 100);
            this.lb_data.Name = "lb_data";
            this.lb_data.Size = new System.Drawing.Size(272, 147);
            this.lb_data.TabIndex = 0;
            // 
            // lbl_eveskozephom
            // 
            this.lbl_eveskozephom.AutoSize = true;
            this.lbl_eveskozephom.Location = new System.Drawing.Point(12, 9);
            this.lbl_eveskozephom.Name = "lbl_eveskozephom";
            this.lbl_eveskozephom.Size = new System.Drawing.Size(126, 13);
            this.lbl_eveskozephom.TabIndex = 1;
            this.lbl_eveskozephom.Text = "Éves átlagos középhőm.:";
            // 
            // lbl_legkisebbkozephom
            // 
            this.lbl_legkisebbkozephom.AutoSize = true;
            this.lbl_legkisebbkozephom.Location = new System.Drawing.Point(12, 22);
            this.lbl_legkisebbkozephom.Name = "lbl_legkisebbkozephom";
            this.lbl_legkisebbkozephom.Size = new System.Drawing.Size(137, 13);
            this.lbl_legkisebbkozephom.TabIndex = 2;
            this.lbl_legkisebbkozephom.Text = "Éves legkisebb középhőm.:";
            // 
            // txt_search
            // 
            this.txt_search.Location = new System.Drawing.Point(0, 74);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(149, 20);
            this.txt_search.TabIndex = 3;
            // 
            // lbl_nomatch
            // 
            this.lbl_nomatch.AutoSize = true;
            this.lbl_nomatch.Location = new System.Drawing.Point(54, 162);
            this.lbl_nomatch.Name = "lbl_nomatch";
            this.lbl_nomatch.Size = new System.Drawing.Size(157, 26);
            this.lbl_nomatch.TabIndex = 4;
            this.lbl_nomatch.Text = "Nincs ilyen hónap vagy nincs a \r\nközéphőmérséklet 10°C felett!";
            this.lbl_nomatch.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 247);
            this.Controls.Add(this.lbl_nomatch);
            this.Controls.Add(this.txt_search);
            this.Controls.Add(this.lbl_legkisebbkozephom);
            this.Controls.Add(this.lbl_eveskozephom);
            this.Controls.Add(this.lb_data);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "Hőmérséklet";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lb_data;
        private System.Windows.Forms.Label lbl_eveskozephom;
        private System.Windows.Forms.Label lbl_legkisebbkozephom;
        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.Label lbl_nomatch;
    }
}

