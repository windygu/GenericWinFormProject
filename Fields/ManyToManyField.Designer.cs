namespace App.WinForm.Fields
{
    partial class ManyToManyField
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
            this.listBoxChoices = new System.Windows.Forms.ListBox();
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
            this.splitContainer.Panel2.Controls.Add(this.listBoxChoices);
            this.splitContainer.Size = new System.Drawing.Size(374, 534);
            this.splitContainer.SplitterDistance = 28;
            // 
            // listBoxChoices
            // 
            this.listBoxChoices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxChoices.FormattingEnabled = true;
            this.listBoxChoices.Location = new System.Drawing.Point(0, 0);
            this.listBoxChoices.Name = "listBoxChoices";
            this.listBoxChoices.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxChoices.Size = new System.Drawing.Size(374, 502);
            this.listBoxChoices.TabIndex = 1;
            // 
            // ManyToManyField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "ManyToManyField";
            this.Size = new System.Drawing.Size(374, 534);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxChoices;
    }
}
