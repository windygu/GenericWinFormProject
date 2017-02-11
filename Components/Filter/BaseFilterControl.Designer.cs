namespace App.WinForm.EntityManagement
{
    partial class EntityFilterControl
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
            this.groupBoxFiltrage = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBoxFiltrage.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxFiltrage
            // 
            this.groupBoxFiltrage.AutoSize = true;
            this.groupBoxFiltrage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxFiltrage.Controls.Add(this.flowLayoutPanel1);
            this.groupBoxFiltrage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxFiltrage.Location = new System.Drawing.Point(0, 0);
            this.groupBoxFiltrage.Name = "groupBoxFiltrage";
            this.groupBoxFiltrage.Size = new System.Drawing.Size(512, 194);
            this.groupBoxFiltrage.TabIndex = 14;
            this.groupBoxFiltrage.TabStop = false;
            this.groupBoxFiltrage.Enter += new System.EventHandler(this.groupBoxFiltrage_Enter);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(506, 175);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // EntityFilterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.groupBoxFiltrage);
            this.Name = "EntityFilterControl";
            this.Size = new System.Drawing.Size(512, 194);
            this.groupBoxFiltrage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.GroupBox groupBoxFiltrage;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
