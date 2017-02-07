namespace App.WinForm
{
    partial class InputCollectionControle
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
            this.groupBoxFilter = new System.Windows.Forms.GroupBox();
            this.groupBoxListChoices = new System.Windows.Forms.GroupBox();
            this.listBoxChoices = new System.Windows.Forms.ListBox();
            this.groupBoxDisplaySelected = new System.Windows.Forms.GroupBox();
            this.labelDisplaySelectedEntity = new System.Windows.Forms.Label();
            this.groupBoxListChoices.SuspendLayout();
            this.groupBoxDisplaySelected.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxFilter
            // 
            this.groupBoxFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxFilter.Location = new System.Drawing.Point(12, 3);
            this.groupBoxFilter.Name = "groupBoxFilter";
            this.groupBoxFilter.Size = new System.Drawing.Size(262, 100);
            this.groupBoxFilter.TabIndex = 0;
            this.groupBoxFilter.TabStop = false;
            this.groupBoxFilter.Text = "Filtre";
            // 
            // groupBoxListChoices
            // 
            this.groupBoxListChoices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxListChoices.Controls.Add(this.listBoxChoices);
            this.groupBoxListChoices.Location = new System.Drawing.Point(12, 109);
            this.groupBoxListChoices.Name = "groupBoxListChoices";
            this.groupBoxListChoices.Size = new System.Drawing.Size(262, 206);
            this.groupBoxListChoices.TabIndex = 1;
            this.groupBoxListChoices.TabStop = false;
            this.groupBoxListChoices.Text = "Liste de choix";
            // 
            // listBoxChoices
            // 
            this.listBoxChoices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxChoices.FormattingEnabled = true;
            this.listBoxChoices.Location = new System.Drawing.Point(3, 16);
            this.listBoxChoices.Name = "listBoxChoices";
            this.listBoxChoices.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxChoices.Size = new System.Drawing.Size(256, 187);
            this.listBoxChoices.TabIndex = 0;
            this.listBoxChoices.SelectedIndexChanged += new System.EventHandler(this.listBoxChoices_SelectedIndexChanged);
            // 
            // groupBoxDisplaySelected
            // 
            this.groupBoxDisplaySelected.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxDisplaySelected.Controls.Add(this.labelDisplaySelectedEntity);
            this.groupBoxDisplaySelected.Location = new System.Drawing.Point(12, 321);
            this.groupBoxDisplaySelected.Name = "groupBoxDisplaySelected";
            this.groupBoxDisplaySelected.Size = new System.Drawing.Size(262, 100);
            this.groupBoxDisplaySelected.TabIndex = 2;
            this.groupBoxDisplaySelected.TabStop = false;
            this.groupBoxDisplaySelected.Text = "Détaille de la valeur selectioné";
            // 
            // labelDisplaySelectedEntity
            // 
            this.labelDisplaySelectedEntity.AutoSize = true;
            this.labelDisplaySelectedEntity.Location = new System.Drawing.Point(7, 20);
            this.labelDisplaySelectedEntity.Name = "labelDisplaySelectedEntity";
            this.labelDisplaySelectedEntity.Size = new System.Drawing.Size(35, 13);
            this.labelDisplaySelectedEntity.TabIndex = 0;
            this.labelDisplaySelectedEntity.Text = "label1";
            // 
            // InputCollectionControle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxDisplaySelected);
            this.Controls.Add(this.groupBoxListChoices);
            this.Controls.Add(this.groupBoxFilter);
            this.Name = "InputCollectionControle";
            this.Size = new System.Drawing.Size(283, 449);
            this.groupBoxListChoices.ResumeLayout(false);
            this.groupBoxDisplaySelected.ResumeLayout(false);
            this.groupBoxDisplaySelected.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxFilter;
        private System.Windows.Forms.GroupBox groupBoxListChoices;
        private System.Windows.Forms.GroupBox groupBoxDisplaySelected;
        private System.Windows.Forms.ListBox listBoxChoices;
        private System.Windows.Forms.Label labelDisplaySelectedEntity;
    }
}
