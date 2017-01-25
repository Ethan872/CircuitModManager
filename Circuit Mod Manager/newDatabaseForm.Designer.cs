namespace Circuit_Mod_Manager
{
    partial class newDatabaseForm
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
            this.iTalk_ThemeContainer1 = new iTalk.iTalk_ThemeContainer();
            this.databaseNameTextbox = new iTalk.iTalk_TextBox_Big();
            this.createDatabaseButton = new iTalk.iTalk_Button_1();
            this.closeNewDatabaseFormButton = new iTalk.iTalk_Button_1();
            this.iTalk_ThemeContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // iTalk_ThemeContainer1
            // 
            this.iTalk_ThemeContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.iTalk_ThemeContainer1.Controls.Add(this.closeNewDatabaseFormButton);
            this.iTalk_ThemeContainer1.Controls.Add(this.databaseNameTextbox);
            this.iTalk_ThemeContainer1.Controls.Add(this.createDatabaseButton);
            this.iTalk_ThemeContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iTalk_ThemeContainer1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.iTalk_ThemeContainer1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.iTalk_ThemeContainer1.Location = new System.Drawing.Point(0, 0);
            this.iTalk_ThemeContainer1.Name = "iTalk_ThemeContainer1";
            this.iTalk_ThemeContainer1.Padding = new System.Windows.Forms.Padding(3, 28, 3, 28);
            this.iTalk_ThemeContainer1.Sizable = true;
            this.iTalk_ThemeContainer1.Size = new System.Drawing.Size(390, 180);
            this.iTalk_ThemeContainer1.SmartBounds = false;
            this.iTalk_ThemeContainer1.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.iTalk_ThemeContainer1.TabIndex = 0;
            this.iTalk_ThemeContainer1.Text = "Create a new Database";
            // 
            // databaseNameTextbox
            // 
            this.databaseNameTextbox.BackColor = System.Drawing.Color.Transparent;
            this.databaseNameTextbox.Font = new System.Drawing.Font("Tahoma", 11F);
            this.databaseNameTextbox.ForeColor = System.Drawing.Color.DimGray;
            this.databaseNameTextbox.Image = null;
            this.databaseNameTextbox.Location = new System.Drawing.Point(12, 47);
            this.databaseNameTextbox.MaxLength = 32767;
            this.databaseNameTextbox.Multiline = false;
            this.databaseNameTextbox.Name = "databaseNameTextbox";
            this.databaseNameTextbox.ReadOnly = false;
            this.databaseNameTextbox.Size = new System.Drawing.Size(366, 41);
            this.databaseNameTextbox.TabIndex = 1;
            this.databaseNameTextbox.Text = "Custom Database Name";
            this.databaseNameTextbox.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.databaseNameTextbox.UseSystemPasswordChar = false;
            // 
            // createDatabaseButton
            // 
            this.createDatabaseButton.BackColor = System.Drawing.Color.Transparent;
            this.createDatabaseButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.createDatabaseButton.Image = null;
            this.createDatabaseButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.createDatabaseButton.Location = new System.Drawing.Point(112, 99);
            this.createDatabaseButton.Name = "createDatabaseButton";
            this.createDatabaseButton.Size = new System.Drawing.Size(166, 40);
            this.createDatabaseButton.TabIndex = 0;
            this.createDatabaseButton.Text = "Create";
            this.createDatabaseButton.TextAlignment = System.Drawing.StringAlignment.Center;
            this.createDatabaseButton.Click += new System.EventHandler(this.createDatabaseButton_Click);
            // 
            // closeNewDatabaseFormButton
            // 
            this.closeNewDatabaseFormButton.BackColor = System.Drawing.Color.Transparent;
            this.closeNewDatabaseFormButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.closeNewDatabaseFormButton.Image = null;
            this.closeNewDatabaseFormButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.closeNewDatabaseFormButton.Location = new System.Drawing.Point(360, 2);
            this.closeNewDatabaseFormButton.Name = "closeNewDatabaseFormButton";
            this.closeNewDatabaseFormButton.Size = new System.Drawing.Size(18, 17);
            this.closeNewDatabaseFormButton.TabIndex = 2;
            this.closeNewDatabaseFormButton.Text = "X";
            this.closeNewDatabaseFormButton.TextAlignment = System.Drawing.StringAlignment.Center;
            this.closeNewDatabaseFormButton.Click += new System.EventHandler(this.closeNewDatabaseFormButton_Click);
            // 
            // newDatabaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 180);
            this.Controls.Add(this.iTalk_ThemeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(126, 39);
            this.Name = "newDatabaseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create a new Database";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.iTalk_ThemeContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private iTalk.iTalk_ThemeContainer iTalk_ThemeContainer1;
        private iTalk.iTalk_TextBox_Big databaseNameTextbox;
        private iTalk.iTalk_Button_1 createDatabaseButton;
        private iTalk.iTalk_Button_1 closeNewDatabaseFormButton;
    }
}