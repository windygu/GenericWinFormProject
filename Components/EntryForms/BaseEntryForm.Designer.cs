namespace App.WinForm
{
    partial class BaseEntryForm
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btEnregistrer = new System.Windows.Forms.Button();
            this.btAnnuler = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanelForm = new System.Windows.Forms.FlowLayoutPanel();
            this.tabControlForm = new System.Windows.Forms.TabControl();
            this.tabPageForm = new System.Windows.Forms.TabPage();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControlForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.CausesValidation = false;
            this.panel1.Controls.Add(this.btEnregistrer);
            this.panel1.Controls.Add(this.btAnnuler);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(647, 48);
            this.panel1.TabIndex = 2;
            // 
            // btEnregistrer
            // 
            this.btEnregistrer.AccessibleDescription = "Enregistrement des informations";
            this.btEnregistrer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btEnregistrer.Image = global::App.WinForm.Properties.Resources.save;
            this.btEnregistrer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btEnregistrer.Location = new System.Drawing.Point(3, 9);
            this.btEnregistrer.Name = "btEnregistrer";
            this.btEnregistrer.Size = new System.Drawing.Size(83, 31);
            this.btEnregistrer.TabIndex = 5;
            this.btEnregistrer.Text = "Enregistrer";
            this.btEnregistrer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btEnregistrer.UseVisualStyleBackColor = true;
            this.btEnregistrer.Click += new System.EventHandler(this.btEnregistrer_Click);
            // 
            // btAnnuler
            // 
            this.btAnnuler.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btAnnuler.CausesValidation = false;
            this.btAnnuler.Image = global::App.WinForm.Properties.Resources.fermer_noir;
            this.btAnnuler.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAnnuler.Location = new System.Drawing.Point(574, 9);
            this.btAnnuler.Name = "btAnnuler";
            this.btAnnuler.Size = new System.Drawing.Size(70, 31);
            this.btAnnuler.TabIndex = 1;
            this.btAnnuler.Text = "Annuler";
            this.btAnnuler.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btAnnuler.UseVisualStyleBackColor = true;
            this.btAnnuler.Click += new System.EventHandler(this.btAnnuler_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.CausesValidation = false;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.CausesValidation = false;
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanelForm);
            this.splitContainer1.Panel1.Controls.Add(this.tabControlForm);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.CausesValidation = false;
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(647, 296);
            this.splitContainer1.SplitterDistance = 244;
            this.splitContainer1.TabIndex = 3;
            this.splitContainer1.TabStop = false;
            // 
            // flowLayoutPanelForm
            // 
            this.flowLayoutPanelForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelForm.AutoScroll = true;
            this.flowLayoutPanelForm.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.flowLayoutPanelForm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelForm.Location = new System.Drawing.Point(311, 29);
            this.flowLayoutPanelForm.Name = "flowLayoutPanelForm";
            this.flowLayoutPanelForm.Padding = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanelForm.Size = new System.Drawing.Size(295, 175);
            this.flowLayoutPanelForm.TabIndex = 1;
            // 
            // tabControlForm
            // 
            this.tabControlForm.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControlForm.Controls.Add(this.tabPageForm);
            this.tabControlForm.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControlForm.ItemSize = new System.Drawing.Size(30, 70);
            this.tabControlForm.Location = new System.Drawing.Point(17, 25);
            this.tabControlForm.Multiline = true;
            this.tabControlForm.Name = "tabControlForm";
            this.tabControlForm.SelectedIndex = 0;
            this.tabControlForm.Size = new System.Drawing.Size(261, 156);
            this.tabControlForm.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlForm.TabIndex = 2;
            this.tabControlForm.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            // 
            // tabPageForm
            // 
            this.tabPageForm.Location = new System.Drawing.Point(74, 4);
            this.tabPageForm.Name = "tabPageForm";
            this.tabPageForm.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageForm.Size = new System.Drawing.Size(183, 148);
            this.tabPageForm.TabIndex = 0;
            this.tabPageForm.Text = "tabPage1";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // BaseEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "BaseEntryForm";
            this.Size = new System.Drawing.Size(647, 296);
            this.Load += new System.EventHandler(this.BaseEntryForm_Load);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControlForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btAnnuler;
        private System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.ErrorProvider errorProvider;
        public System.Windows.Forms.Button btEnregistrer;
        public System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabPage tabPageForm;
        protected System.Windows.Forms.TabControl tabControlForm;
        protected System.Windows.Forms.FlowLayoutPanel flowLayoutPanelForm;
    }
}
