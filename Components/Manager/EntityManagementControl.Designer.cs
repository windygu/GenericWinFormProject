namespace App.WinForm
{
    partial class EntityManagementControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntityManagementControl));
            this.panelDataGrid = new System.Windows.Forms.Panel();
            this.tabControlManagers = new System.Windows.Forms.TabControl();
            this.main = new System.Windows.Forms.TabPage();
            this.tabControl_MainManager = new System.Windows.Forms.TabControl();
            this.TabGrid = new System.Windows.Forms.TabPage();
            this.tabPageAdd = new System.Windows.Forms.TabPage();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel_Filtre = new System.Windows.Forms.Panel();
            this.panelDataGrid.SuspendLayout();
            this.tabControlManagers.SuspendLayout();
            this.tabControl_MainManager.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDataGrid
            // 
            this.panelDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDataGrid.Controls.Add(this.tabControlManagers);
            this.panelDataGrid.Controls.Add(this.tabControl_MainManager);
            this.panelDataGrid.Location = new System.Drawing.Point(12, 14);
            this.panelDataGrid.Name = "panelDataGrid";
            this.panelDataGrid.Size = new System.Drawing.Size(1065, 370);
            this.panelDataGrid.TabIndex = 17;
            this.panelDataGrid.Tag = "";
            // 
            // tabControlManagers
            // 
            this.tabControlManagers.Controls.Add(this.main);
            this.tabControlManagers.HotTrack = true;
            this.tabControlManagers.ItemSize = new System.Drawing.Size(100, 30);
            this.tabControlManagers.Location = new System.Drawing.Point(31, 41);
            this.tabControlManagers.Multiline = true;
            this.tabControlManagers.Name = "tabControlManagers";
            this.tabControlManagers.SelectedIndex = 0;
            this.tabControlManagers.Size = new System.Drawing.Size(393, 215);
            this.tabControlManagers.TabIndex = 16;
            // 
            // main
            // 
            this.main.AutoScroll = true;
            this.main.Location = new System.Drawing.Point(4, 34);
            this.main.Name = "main";
            this.main.Padding = new System.Windows.Forms.Padding(3);
            this.main.Size = new System.Drawing.Size(385, 177);
            this.main.TabIndex = 0;
            this.main.Text = "Gestion";
            this.main.UseVisualStyleBackColor = true;
            // 
            // tabControl_MainManager
            // 
            this.tabControl_MainManager.CausesValidation = false;
            this.tabControl_MainManager.Controls.Add(this.TabGrid);
            this.tabControl_MainManager.Controls.Add(this.tabPageAdd);
            this.tabControl_MainManager.HotTrack = true;
            this.tabControl_MainManager.ImageList = this.imageList;
            this.tabControl_MainManager.ItemSize = new System.Drawing.Size(20, 28);
            this.tabControl_MainManager.Location = new System.Drawing.Point(564, 41);
            this.tabControl_MainManager.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl_MainManager.Name = "tabControl_MainManager";
            this.tabControl_MainManager.Padding = new System.Drawing.Point(5, 2);
            this.tabControl_MainManager.SelectedIndex = 0;
            this.tabControl_MainManager.ShowToolTips = true;
            this.tabControl_MainManager.Size = new System.Drawing.Size(439, 219);
            this.tabControl_MainManager.TabIndex = 15;
            this.tabControl_MainManager.TabStop = false;
            this.tabControl_MainManager.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl_MainManager_Selecting);
            // 
            // TabGrid
            // 
            this.TabGrid.CausesValidation = false;
            this.TabGrid.Location = new System.Drawing.Point(4, 32);
            this.TabGrid.Name = "TabGrid";
            this.TabGrid.Padding = new System.Windows.Forms.Padding(3);
            this.TabGrid.Size = new System.Drawing.Size(431, 183);
            this.TabGrid.TabIndex = 0;
            this.TabGrid.Text = "Informations";
            this.TabGrid.UseVisualStyleBackColor = true;
            // 
            // tabPageAdd
            // 
            this.tabPageAdd.ImageKey = "add.png";
            this.tabPageAdd.Location = new System.Drawing.Point(4, 32);
            this.tabPageAdd.Name = "tabPageAdd";
            this.tabPageAdd.Size = new System.Drawing.Size(431, 183);
            this.tabPageAdd.TabIndex = 1;
            this.tabPageAdd.ToolTipText = "Ajouter";
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "add.png");
            // 
            // splitContainer1
            // 
            this.splitContainer1.CausesValidation = false;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.MinimumSize = new System.Drawing.Size(800, 500);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel_Filtre);
            this.splitContainer1.Panel1MinSize = 100;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.CausesValidation = false;
            this.splitContainer1.Panel2.Controls.Add(this.panelDataGrid);
            this.splitContainer1.Size = new System.Drawing.Size(1089, 500);
            this.splitContainer1.SplitterDistance = 100;
            this.splitContainer1.TabIndex = 15;
            // 
            // panel_Filtre
            // 
            this.panel_Filtre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Filtre.AutoSize = true;
            this.panel_Filtre.Location = new System.Drawing.Point(12, 3);
            this.panel_Filtre.Name = "panel_Filtre";
            this.panel_Filtre.Size = new System.Drawing.Size(1065, 94);
            this.panel_Filtre.TabIndex = 16;
            this.panel_Filtre.Tag = "";
            // 
            // EntityManagementControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "EntityManagementControl";
            this.Size = new System.Drawing.Size(1089, 439);
            this.Load += new System.EventHandler(this.EntityManagementForm_Load);
            this.panelDataGrid.ResumeLayout(false);
            this.tabControlManagers.ResumeLayout(false);
            this.tabControl_MainManager.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDataGrid;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel_Filtre;
        private System.Windows.Forms.TabControl tabControl_MainManager;
        private System.Windows.Forms.TabPage TabGrid;
        private System.Windows.Forms.TabControl tabControlManagers;
        private System.Windows.Forms.TabPage main;
        private System.Windows.Forms.TabPage tabPageAdd;
        private System.Windows.Forms.ImageList imageList;
    }
}
