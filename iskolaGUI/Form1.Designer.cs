namespace iskolaGUI
{
    partial class form_main
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
            this.lbx_tanulok = new System.Windows.Forms.ListBox();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbx_tanulok
            // 
            this.lbx_tanulok.FormattingEnabled = true;
            this.lbx_tanulok.ItemHeight = 20;
            this.lbx_tanulok.Location = new System.Drawing.Point(12, 12);
            this.lbx_tanulok.Name = "lbx_tanulok";
            this.lbx_tanulok.Size = new System.Drawing.Size(456, 664);
            this.lbx_tanulok.TabIndex = 0;
            // 
            // btn_delete
            // 
            this.btn_delete.AutoSize = true;
            this.btn_delete.Location = new System.Drawing.Point(12, 715);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(149, 30);
            this.btn_delete.TabIndex = 1;
            this.btn_delete.Text = "Törlés";
            this.btn_delete.UseVisualStyleBackColor = true;
            // 
            // btn_save
            // 
            this.btn_save.AutoSize = true;
            this.btn_save.Location = new System.Drawing.Point(319, 715);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(149, 30);
            this.btn_save.TabIndex = 2;
            this.btn_save.Text = "Állomány mentése";
            this.btn_save.UseVisualStyleBackColor = true;
            // 
            // form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 772);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.lbx_tanulok);
            this.Name = "form_main";
            this.Text = "Iskola GUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbx_tanulok;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_save;
    }
}

