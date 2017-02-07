namespace App.WinForm.Fields
{
    partial class ManyToOneField
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
            this.comboBoxManyToOne = new System.Windows.Forms.ComboBox();
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
            this.splitContainer.Panel2.Controls.Add(this.comboBoxManyToOne);
            // 
            // comboBoxManyToOne
            // 
            this.comboBoxManyToOne.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxManyToOne.FormattingEnabled = true;
            this.comboBoxManyToOne.Location = new System.Drawing.Point(0, 0);
            this.comboBoxManyToOne.Name = "comboBoxManyToOne";
            this.comboBoxManyToOne.Size = new System.Drawing.Size(150, 21);
            this.comboBoxManyToOne.TabIndex = 0;
            this.comboBoxManyToOne.SelectedIndexChanged += new System.EventHandler(this.comboBoxManyToOne_SelectedIndexChanged);
            // 
            // ManyToOneField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "ManyToOneField";
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxManyToOne;
    }
}
