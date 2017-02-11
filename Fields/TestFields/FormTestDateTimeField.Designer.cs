namespace App.WinForm.Fields.TestFields
{
    partial class FormTestDateTimeField
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
            this.dateTimeControl1 = new App.WinFrom.Fields.Controls.DateTimeControl();
            this.dateTimeField1 = new App.WinForm.Fields.DateTimeField();
            this.SuspendLayout();
            // 
            // dateTimeControl1
            // 
            this.dateTimeControl1.AutoSize = true;
            this.dateTimeControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.dateTimeControl1.Location = new System.Drawing.Point(38, 23);
            this.dateTimeControl1.Name = "dateTimeControl1";
            this.dateTimeControl1.Size = new System.Drawing.Size(331, 20);
            this.dateTimeControl1.TabIndex = 0;
            this.dateTimeControl1.Value = new System.DateTime(2017, 2, 11, 9, 43, 0, 198);
            // 
            // dateTimeField1
            // 
            this.dateTimeField1.AutoSize = true;
            this.dateTimeField1.ConfigEntity = null;
            this.dateTimeField1.configProperty = null;
            this.dateTimeField1.HeightField = 0;
            this.dateTimeField1.Location = new System.Drawing.Point(86, 108);
            this.dateTimeField1.Name = "dateTimeField1";
            this.dateTimeField1.Size = new System.Drawing.Size(210, 55);
            this.dateTimeField1.TabIndex = 1;
            this.dateTimeField1.Value = new System.DateTime(2017, 2, 7, 16, 48, 33, 903);
            // 
            // FormTestDateTimeField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 316);
            this.Controls.Add(this.dateTimeField1);
            this.Controls.Add(this.dateTimeControl1);
            this.Name = "FormTestDateTimeField";
            this.Text = "DateTimeField Test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WinFrom.Fields.Controls.DateTimeControl dateTimeControl1;
        private DateTimeField dateTimeField1;
    }
}