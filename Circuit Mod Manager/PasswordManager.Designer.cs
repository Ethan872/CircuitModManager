namespace Circuit_Mod_Manager
{
    partial class PasswordManager
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
            this.iTalk_Label1 = new iTalk.iTalk_Label();
            this.passwordTBox = new iTalk.iTalk_TextBox_Small();
            this.submitPasswordButton = new iTalk.iTalk_Button_1();
            this.closePasswordManagerFormButton = new iTalk.iTalk_Button_1();
            this.iTalk_ThemeContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // iTalk_ThemeContainer1
            // 
            this.iTalk_ThemeContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.iTalk_ThemeContainer1.Controls.Add(this.closePasswordManagerFormButton);
            this.iTalk_ThemeContainer1.Controls.Add(this.submitPasswordButton);
            this.iTalk_ThemeContainer1.Controls.Add(this.passwordTBox);
            this.iTalk_ThemeContainer1.Controls.Add(this.iTalk_Label1);
            this.iTalk_ThemeContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iTalk_ThemeContainer1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.iTalk_ThemeContainer1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.iTalk_ThemeContainer1.Location = new System.Drawing.Point(0, 0);
            this.iTalk_ThemeContainer1.Name = "iTalk_ThemeContainer1";
            this.iTalk_ThemeContainer1.Padding = new System.Windows.Forms.Padding(3, 28, 3, 28);
            this.iTalk_ThemeContainer1.Sizable = true;
            this.iTalk_ThemeContainer1.Size = new System.Drawing.Size(567, 230);
            this.iTalk_ThemeContainer1.SmartBounds = false;
            this.iTalk_ThemeContainer1.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
            this.iTalk_ThemeContainer1.TabIndex = 0;
            this.iTalk_ThemeContainer1.Text = "MXSIM Mod Manager";
            // 
            // iTalk_Label1
            // 
            this.iTalk_Label1.AutoSize = true;
            this.iTalk_Label1.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_Label1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.iTalk_Label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.iTalk_Label1.Location = new System.Drawing.Point(117, 71);
            this.iTalk_Label1.Name = "iTalk_Label1";
            this.iTalk_Label1.Size = new System.Drawing.Size(332, 26);
            this.iTalk_Label1.TabIndex = 0;
            this.iTalk_Label1.Text = "The mod you\'re currently trying to install is password protected\r\n          Pleas" +
    "e enter the password for the mod to continue";
            // 
            // passwordTBox
            // 
            this.passwordTBox.BackColor = System.Drawing.Color.Transparent;
            this.passwordTBox.Font = new System.Drawing.Font("Tahoma", 11F);
            this.passwordTBox.ForeColor = System.Drawing.Color.DimGray;
            this.passwordTBox.Location = new System.Drawing.Point(66, 115);
            this.passwordTBox.MaxLength = 32767;
            this.passwordTBox.Multiline = false;
            this.passwordTBox.Name = "passwordTBox";
            this.passwordTBox.ReadOnly = false;
            this.passwordTBox.Size = new System.Drawing.Size(434, 28);
            this.passwordTBox.TabIndex = 1;
            this.passwordTBox.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.passwordTBox.UseSystemPasswordChar = false;
            // 
            // submitPasswordButton
            // 
            this.submitPasswordButton.BackColor = System.Drawing.Color.Transparent;
            this.submitPasswordButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.submitPasswordButton.Image = null;
            this.submitPasswordButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.submitPasswordButton.Location = new System.Drawing.Point(200, 153);
            this.submitPasswordButton.Name = "submitPasswordButton";
            this.submitPasswordButton.Size = new System.Drawing.Size(166, 40);
            this.submitPasswordButton.TabIndex = 2;
            this.submitPasswordButton.Text = "OK";
            this.submitPasswordButton.TextAlignment = System.Drawing.StringAlignment.Center;
            this.submitPasswordButton.Click += new System.EventHandler(this.submitPasswordButton_Click);
            // 
            // closePasswordManagerFormButton
            // 
            this.closePasswordManagerFormButton.BackColor = System.Drawing.Color.Transparent;
            this.closePasswordManagerFormButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.closePasswordManagerFormButton.Image = null;
            this.closePasswordManagerFormButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.closePasswordManagerFormButton.Location = new System.Drawing.Point(536, 3);
            this.closePasswordManagerFormButton.Name = "closePasswordManagerFormButton";
            this.closePasswordManagerFormButton.Size = new System.Drawing.Size(18, 17);
            this.closePasswordManagerFormButton.TabIndex = 3;
            this.closePasswordManagerFormButton.Text = "X";
            this.closePasswordManagerFormButton.TextAlignment = System.Drawing.StringAlignment.Center;
            this.closePasswordManagerFormButton.Click += new System.EventHandler(this.closePasswordManagerFormButton_Click);
            // 
            // PasswordManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 230);
            this.Controls.Add(this.iTalk_ThemeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(126, 39);
            this.Name = "PasswordManager";
            this.Text = "MXSIM Mod Manager";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.iTalk_ThemeContainer1.ResumeLayout(false);
            this.iTalk_ThemeContainer1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private iTalk.iTalk_ThemeContainer iTalk_ThemeContainer1;
        private iTalk.iTalk_Label iTalk_Label1;
        private iTalk.iTalk_Button_1 submitPasswordButton;
        private iTalk.iTalk_TextBox_Small passwordTBox;
        private iTalk.iTalk_Button_1 closePasswordManagerFormButton;
    }
}