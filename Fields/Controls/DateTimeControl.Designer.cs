namespace App.WinFrom.Fields.Controls
{
    partial class DateTimeControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.radioButtonCultureInfo1 = new System.Windows.Forms.RadioButton();
            this.radioButtonCultureInfo2 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dateTimePicker.Location = new System.Drawing.Point(0, 44);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(230, 20);
            this.dateTimePicker.TabIndex = 0;
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // radioButtonCultureInfo1
            // 
            this.radioButtonCultureInfo1.AutoSize = true;
            this.radioButtonCultureInfo1.Location = new System.Drawing.Point(3, 3);
            this.radioButtonCultureInfo1.Name = "radioButtonCultureInfo1";
            this.radioButtonCultureInfo1.Size = new System.Drawing.Size(85, 17);
            this.radioButtonCultureInfo1.TabIndex = 1;
            this.radioButtonCultureInfo1.TabStop = true;
            this.radioButtonCultureInfo1.Text = "radioButton1";
            this.radioButtonCultureInfo1.UseVisualStyleBackColor = true;
            // 
            // radioButtonCultureInfo2
            // 
            this.radioButtonCultureInfo2.AutoSize = true;
            this.radioButtonCultureInfo2.Location = new System.Drawing.Point(109, 3);
            this.radioButtonCultureInfo2.Name = "radioButtonCultureInfo2";
            this.radioButtonCultureInfo2.Size = new System.Drawing.Size(85, 17);
            this.radioButtonCultureInfo2.TabIndex = 2;
            this.radioButtonCultureInfo2.TabStop = true;
            this.radioButtonCultureInfo2.Text = "radioButton2";
            this.radioButtonCultureInfo2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButtonCultureInfo1);
            this.panel1.Controls.Add(this.radioButtonCultureInfo2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 27);
            this.panel1.TabIndex = 3;
            // 
            // DateTimeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dateTimePicker);
            this.Name = "DateTimeControl";
            this.Size = new System.Drawing.Size(230, 64);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.RadioButton radioButtonCultureInfo1;
        private System.Windows.Forms.RadioButton radioButtonCultureInfo2;
        private System.Windows.Forms.Panel panel1;
    }
}
