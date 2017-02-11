namespace App.WinForm.Fields
{
    partial class DateTimeField
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.dateTimeControl = new App.WinFrom.Fields.Controls.DateTimeControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.dateTimeControl);
            this.splitContainer.Size = new System.Drawing.Size(328, 123);
            this.splitContainer.SplitterDistance = 55;
            // 
            // dateTimeControl
            // 
            this.dateTimeControl.AutoSize = true;
            this.dateTimeControl.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dateTimeControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimeControl.Location = new System.Drawing.Point(0, 0);
            this.dateTimeControl.Name = "dateTimeControl";
            this.dateTimeControl.Size = new System.Drawing.Size(328, 20);
            this.dateTimeControl.TabIndex = 0;
            this.dateTimeControl.Value = new System.DateTime(2017, 2, 7, 16, 48, 33, 903);
            this.dateTimeControl.ValueChanged += new System.EventHandler(this.dateTimeControl_ValueChanged);
            // 
            // DateTimeField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoSize = true;
            this.Name = "DateTimeField";
            this.Size = new System.Drawing.Size(328, 123);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private WinFrom.Fields.Controls.DateTimeControl dateTimeControl;
    }
}
