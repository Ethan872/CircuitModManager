namespace Circuit_Mod_Manager
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.iTalk_ThemeContainer1 = new iTalk.iTalk_ThemeContainer();
            this.iTalk_ControlBox1 = new iTalk.iTalk_ControlBox();
            this.iTalk_TabControl1 = new iTalk.iTalk_TabControl();
            this.installerPage = new System.Windows.Forms.TabPage();
            this.progressSpinner = new iTalk.iTalk_ProgressIndicator();
            this.iTalk_HeaderLabel1 = new iTalk.iTalk_HeaderLabel();
            this.modTbox = new iTalk.iTalk_TextBox_Big();
            this.gearRadioButton = new iTalk.iTalk_RadioButton();
            this.iTalk_Label1 = new iTalk.iTalk_Label();
            this.trackRadioButton = new iTalk.iTalk_RadioButton();
            this.installModButton = new iTalk.iTalk_Button_1();
            this.managerPage = new System.Windows.Forms.TabPage();
            this.filterModComboBox = new iTalk.iTalk_ComboBox();
            this.iTalk_Label3 = new iTalk.iTalk_Label();
            this.executeActionButton = new iTalk.iTalk_Button_2();
            this.actionComboBox = new iTalk.iTalk_ComboBox();
            this.iTalk_Label2 = new iTalk.iTalk_Label();
            this.modListBox = new System.Windows.Forms.CheckedListBox();
            this.modLabel = new iTalk.iTalk_Label();
            this.modComboBox = new iTalk.iTalk_ComboBox();
            this.settingsPage = new System.Windows.Forms.TabPage();
            this.iTalk_Label4 = new iTalk.iTalk_Label();
            this.iTalk_RadioButton3 = new iTalk.iTalk_RadioButton();
            this.iTalk_RadioButton2 = new iTalk.iTalk_RadioButton();
            this.iTalk_RadioButton1 = new iTalk.iTalk_RadioButton();
            this.iTalk_Button_13 = new iTalk.iTalk_Button_1();
            this.iTalk_Button_12 = new iTalk.iTalk_Button_1();
            this.iTalk_HeaderLabel2 = new iTalk.iTalk_HeaderLabel();
            this.mxDirTbox = new iTalk.iTalk_TextBox_Big();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.iTalk_ThemeContainer1.SuspendLayout();
            this.iTalk_TabControl1.SuspendLayout();
            this.installerPage.SuspendLayout();
            this.managerPage.SuspendLayout();
            this.settingsPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "Successfully installed mod!";
            this.notifyIcon.BalloonTipTitle = "Circuit Mod Manager";
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "notifyIcon1";
            this.notifyIcon.Visible = true;
            // 
            // iTalk_ThemeContainer1
            // 
            this.iTalk_ThemeContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.iTalk_ThemeContainer1.Controls.Add(this.iTalk_ControlBox1);
            this.iTalk_ThemeContainer1.Controls.Add(this.iTalk_TabControl1);
            this.iTalk_ThemeContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iTalk_ThemeContainer1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.iTalk_ThemeContainer1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.iTalk_ThemeContainer1.Location = new System.Drawing.Point(0, 0);
            this.iTalk_ThemeContainer1.Name = "iTalk_ThemeContainer1";
            this.iTalk_ThemeContainer1.Padding = new System.Windows.Forms.Padding(3, 28, 3, 28);
            this.iTalk_ThemeContainer1.Sizable = false;
            this.iTalk_ThemeContainer1.Size = new System.Drawing.Size(863, 511);
            this.iTalk_ThemeContainer1.SmartBounds = false;
            this.iTalk_ThemeContainer1.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.iTalk_ThemeContainer1.TabIndex = 0;
            this.iTalk_ThemeContainer1.Text = "Circuit Mod Manager";
            // 
            // iTalk_ControlBox1
            // 
            this.iTalk_ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iTalk_ControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_ControlBox1.Location = new System.Drawing.Point(782, -1);
            this.iTalk_ControlBox1.Name = "iTalk_ControlBox1";
            this.iTalk_ControlBox1.Size = new System.Drawing.Size(77, 19);
            this.iTalk_ControlBox1.TabIndex = 2;
            this.iTalk_ControlBox1.Text = "iTalk_ControlBox1";
            // 
            // iTalk_TabControl1
            // 
            this.iTalk_TabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.iTalk_TabControl1.Controls.Add(this.installerPage);
            this.iTalk_TabControl1.Controls.Add(this.managerPage);
            this.iTalk_TabControl1.Controls.Add(this.settingsPage);
            this.iTalk_TabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.iTalk_TabControl1.ImageList = this.imageList1;
            this.iTalk_TabControl1.ItemSize = new System.Drawing.Size(44, 135);
            this.iTalk_TabControl1.Location = new System.Drawing.Point(3, 24);
            this.iTalk_TabControl1.Multiline = true;
            this.iTalk_TabControl1.Name = "iTalk_TabControl1";
            this.iTalk_TabControl1.SelectedIndex = 0;
            this.iTalk_TabControl1.Size = new System.Drawing.Size(860, 465);
            this.iTalk_TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.iTalk_TabControl1.TabIndex = 0;
            // 
            // installerPage
            // 
            this.installerPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.installerPage.Controls.Add(this.progressSpinner);
            this.installerPage.Controls.Add(this.iTalk_HeaderLabel1);
            this.installerPage.Controls.Add(this.modTbox);
            this.installerPage.Controls.Add(this.gearRadioButton);
            this.installerPage.Controls.Add(this.iTalk_Label1);
            this.installerPage.Controls.Add(this.trackRadioButton);
            this.installerPage.Controls.Add(this.installModButton);
            this.installerPage.ImageIndex = 0;
            this.installerPage.Location = new System.Drawing.Point(139, 4);
            this.installerPage.Name = "installerPage";
            this.installerPage.Padding = new System.Windows.Forms.Padding(3);
            this.installerPage.Size = new System.Drawing.Size(717, 457);
            this.installerPage.TabIndex = 0;
            this.installerPage.Text = "Installer";
            // 
            // progressSpinner
            // 
            this.progressSpinner.Location = new System.Drawing.Point(318, 221);
            this.progressSpinner.MinimumSize = new System.Drawing.Size(80, 80);
            this.progressSpinner.Name = "progressSpinner";
            this.progressSpinner.P_AnimationColor = System.Drawing.Color.LightGray;
            this.progressSpinner.P_AnimationSpeed = 150;
            this.progressSpinner.P_BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.progressSpinner.Size = new System.Drawing.Size(80, 80);
            this.progressSpinner.TabIndex = 9;
            this.progressSpinner.Text = "iTalk_ProgressIndicator1";
            this.progressSpinner.Visible = false;
            // 
            // iTalk_HeaderLabel1
            // 
            this.iTalk_HeaderLabel1.AutoSize = true;
            this.iTalk_HeaderLabel1.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_HeaderLabel1.Font = new System.Drawing.Font("Segoe UI", 25F);
            this.iTalk_HeaderLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.iTalk_HeaderLabel1.Location = new System.Drawing.Point(312, 19);
            this.iTalk_HeaderLabel1.Name = "iTalk_HeaderLabel1";
            this.iTalk_HeaderLabel1.Size = new System.Drawing.Size(91, 46);
            this.iTalk_HeaderLabel1.TabIndex = 8;
            this.iTalk_HeaderLabel1.Text = "Mod";
            // 
            // modTbox
            // 
            this.modTbox.AllowDrop = true;
            this.modTbox.BackColor = System.Drawing.Color.Transparent;
            this.modTbox.Font = new System.Drawing.Font("Tahoma", 11F);
            this.modTbox.ForeColor = System.Drawing.Color.DimGray;
            this.modTbox.Image = null;
            this.modTbox.Location = new System.Drawing.Point(93, 86);
            this.modTbox.MaxLength = 32767;
            this.modTbox.Multiline = false;
            this.modTbox.Name = "modTbox";
            this.modTbox.ReadOnly = false;
            this.modTbox.Size = new System.Drawing.Size(528, 41);
            this.modTbox.TabIndex = 7;
            this.modTbox.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.modTbox.UseSystemPasswordChar = false;
            this.modTbox.DragDrop += new System.Windows.Forms.DragEventHandler(this.modTbox_DragDrop);
            this.modTbox.DragEnter += new System.Windows.Forms.DragEventHandler(this.modTbox_DragEnter);
            // 
            // gearRadioButton
            // 
            this.gearRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.gearRadioButton.Checked = false;
            this.gearRadioButton.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gearRadioButton.Location = new System.Drawing.Point(394, 152);
            this.gearRadioButton.Name = "gearRadioButton";
            this.gearRadioButton.Size = new System.Drawing.Size(60, 15);
            this.gearRadioButton.TabIndex = 4;
            this.gearRadioButton.Text = "Gear";
            // 
            // iTalk_Label1
            // 
            this.iTalk_Label1.AutoSize = true;
            this.iTalk_Label1.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_Label1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.iTalk_Label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.iTalk_Label1.Location = new System.Drawing.Point(263, 152);
            this.iTalk_Label1.Name = "iTalk_Label1";
            this.iTalk_Label1.Size = new System.Drawing.Size(59, 13);
            this.iTalk_Label1.TabIndex = 5;
            this.iTalk_Label1.Text = "Mod Type:";
            // 
            // trackRadioButton
            // 
            this.trackRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.trackRadioButton.Checked = false;
            this.trackRadioButton.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.trackRadioButton.Location = new System.Drawing.Point(328, 152);
            this.trackRadioButton.Name = "trackRadioButton";
            this.trackRadioButton.Size = new System.Drawing.Size(60, 15);
            this.trackRadioButton.TabIndex = 3;
            this.trackRadioButton.Text = "Track";
            // 
            // installModButton
            // 
            this.installModButton.BackColor = System.Drawing.Color.Transparent;
            this.installModButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.installModButton.Image = ((System.Drawing.Image)(resources.GetObject("installModButton.Image")));
            this.installModButton.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.installModButton.Location = new System.Drawing.Point(528, 389);
            this.installModButton.Name = "installModButton";
            this.installModButton.Size = new System.Drawing.Size(166, 40);
            this.installModButton.TabIndex = 2;
            this.installModButton.TextAlignment = System.Drawing.StringAlignment.Center;
            this.installModButton.Click += new System.EventHandler(this.installModButton_Click);
            // 
            // managerPage
            // 
            this.managerPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.managerPage.Controls.Add(this.filterModComboBox);
            this.managerPage.Controls.Add(this.iTalk_Label3);
            this.managerPage.Controls.Add(this.executeActionButton);
            this.managerPage.Controls.Add(this.actionComboBox);
            this.managerPage.Controls.Add(this.iTalk_Label2);
            this.managerPage.Controls.Add(this.modListBox);
            this.managerPage.Controls.Add(this.modLabel);
            this.managerPage.Controls.Add(this.modComboBox);
            this.managerPage.ImageIndex = 3;
            this.managerPage.Location = new System.Drawing.Point(139, 4);
            this.managerPage.Name = "managerPage";
            this.managerPage.Padding = new System.Windows.Forms.Padding(3);
            this.managerPage.Size = new System.Drawing.Size(717, 457);
            this.managerPage.TabIndex = 1;
            this.managerPage.Text = "Manager";
            // 
            // filterModComboBox
            // 
            this.filterModComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.filterModComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.filterModComboBox.DropDownHeight = 100;
            this.filterModComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterModComboBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.filterModComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.filterModComboBox.FormattingEnabled = true;
            this.filterModComboBox.HoverSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.filterModComboBox.IntegralHeight = false;
            this.filterModComboBox.ItemHeight = 20;
            this.filterModComboBox.Items.AddRange(new object[] {
            "Track",
            "Gear"});
            this.filterModComboBox.Location = new System.Drawing.Point(515, 22);
            this.filterModComboBox.Name = "filterModComboBox";
            this.filterModComboBox.Size = new System.Drawing.Size(178, 26);
            this.filterModComboBox.StartIndex = 0;
            this.filterModComboBox.TabIndex = 7;
            // 
            // iTalk_Label3
            // 
            this.iTalk_Label3.AutoSize = true;
            this.iTalk_Label3.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_Label3.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.iTalk_Label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.iTalk_Label3.Location = new System.Drawing.Point(476, 28);
            this.iTalk_Label3.Name = "iTalk_Label3";
            this.iTalk_Label3.Size = new System.Drawing.Size(33, 13);
            this.iTalk_Label3.TabIndex = 6;
            this.iTalk_Label3.Text = "Filter";
            // 
            // executeActionButton
            // 
            this.executeActionButton.BackColor = System.Drawing.Color.Transparent;
            this.executeActionButton.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.executeActionButton.ForeColor = System.Drawing.Color.White;
            this.executeActionButton.Image = null;
            this.executeActionButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.executeActionButton.Location = new System.Drawing.Point(527, 389);
            this.executeActionButton.Name = "executeActionButton";
            this.executeActionButton.Size = new System.Drawing.Size(166, 40);
            this.executeActionButton.TabIndex = 5;
            this.executeActionButton.Text = "Execute";
            this.executeActionButton.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // actionComboBox
            // 
            this.actionComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.actionComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.actionComboBox.DropDownHeight = 100;
            this.actionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.actionComboBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.actionComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.actionComboBox.FormattingEnabled = true;
            this.actionComboBox.HoverSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.actionComboBox.IntegralHeight = false;
            this.actionComboBox.ItemHeight = 20;
            this.actionComboBox.Items.AddRange(new object[] {
            "Delete Mod",
            "Delete Selected Mods",
            "Backup Mod",
            "Backup Selected Mods",
            "Backup Entire MXS Install"});
            this.actionComboBox.Location = new System.Drawing.Point(292, 22);
            this.actionComboBox.Name = "actionComboBox";
            this.actionComboBox.Size = new System.Drawing.Size(178, 26);
            this.actionComboBox.StartIndex = 0;
            this.actionComboBox.TabIndex = 4;
            // 
            // iTalk_Label2
            // 
            this.iTalk_Label2.AutoSize = true;
            this.iTalk_Label2.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_Label2.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.iTalk_Label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.iTalk_Label2.Location = new System.Drawing.Point(246, 28);
            this.iTalk_Label2.Name = "iTalk_Label2";
            this.iTalk_Label2.Size = new System.Drawing.Size(40, 13);
            this.iTalk_Label2.TabIndex = 3;
            this.iTalk_Label2.Text = "Action";
            // 
            // modListBox
            // 
            this.modListBox.FormattingEnabled = true;
            this.modListBox.Location = new System.Drawing.Point(26, 63);
            this.modListBox.Name = "modListBox";
            this.modListBox.Size = new System.Drawing.Size(667, 310);
            this.modListBox.TabIndex = 2;
            // 
            // modLabel
            // 
            this.modLabel.AutoSize = true;
            this.modLabel.BackColor = System.Drawing.Color.Transparent;
            this.modLabel.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.modLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.modLabel.Location = new System.Drawing.Point(25, 28);
            this.modLabel.Name = "modLabel";
            this.modLabel.Size = new System.Drawing.Size(31, 13);
            this.modLabel.TabIndex = 1;
            this.modLabel.Text = "Mod";
            // 
            // modComboBox
            // 
            this.modComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.modComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.modComboBox.DropDownHeight = 100;
            this.modComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modComboBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.modComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.modComboBox.FormattingEnabled = true;
            this.modComboBox.HoverSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.modComboBox.IntegralHeight = false;
            this.modComboBox.ItemHeight = 20;
            this.modComboBox.Location = new System.Drawing.Point(62, 22);
            this.modComboBox.Name = "modComboBox";
            this.modComboBox.Size = new System.Drawing.Size(178, 26);
            this.modComboBox.StartIndex = 0;
            this.modComboBox.TabIndex = 0;
            // 
            // settingsPage
            // 
            this.settingsPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.settingsPage.Controls.Add(this.iTalk_Label4);
            this.settingsPage.Controls.Add(this.iTalk_RadioButton3);
            this.settingsPage.Controls.Add(this.iTalk_RadioButton2);
            this.settingsPage.Controls.Add(this.iTalk_RadioButton1);
            this.settingsPage.Controls.Add(this.iTalk_Button_13);
            this.settingsPage.Controls.Add(this.iTalk_Button_12);
            this.settingsPage.Controls.Add(this.iTalk_HeaderLabel2);
            this.settingsPage.Controls.Add(this.mxDirTbox);
            this.settingsPage.ImageIndex = 2;
            this.settingsPage.Location = new System.Drawing.Point(139, 4);
            this.settingsPage.Name = "settingsPage";
            this.settingsPage.Size = new System.Drawing.Size(717, 457);
            this.settingsPage.TabIndex = 2;
            this.settingsPage.Text = "Settings";
            // 
            // iTalk_Label4
            // 
            this.iTalk_Label4.AutoSize = true;
            this.iTalk_Label4.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_Label4.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.iTalk_Label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.iTalk_Label4.Location = new System.Drawing.Point(90, 157);
            this.iTalk_Label4.Name = "iTalk_Label4";
            this.iTalk_Label4.Size = new System.Drawing.Size(82, 13);
            this.iTalk_Label4.TabIndex = 7;
            this.iTalk_Label4.Text = "Default Screen";
            // 
            // iTalk_RadioButton3
            // 
            this.iTalk_RadioButton3.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_RadioButton3.Checked = false;
            this.iTalk_RadioButton3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iTalk_RadioButton3.Location = new System.Drawing.Point(94, 260);
            this.iTalk_RadioButton3.Name = "iTalk_RadioButton3";
            this.iTalk_RadioButton3.Size = new System.Drawing.Size(74, 15);
            this.iTalk_RadioButton3.TabIndex = 6;
            this.iTalk_RadioButton3.Text = "Settings";
            // 
            // iTalk_RadioButton2
            // 
            this.iTalk_RadioButton2.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_RadioButton2.Checked = false;
            this.iTalk_RadioButton2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iTalk_RadioButton2.Location = new System.Drawing.Point(94, 230);
            this.iTalk_RadioButton2.Name = "iTalk_RadioButton2";
            this.iTalk_RadioButton2.Size = new System.Drawing.Size(74, 15);
            this.iTalk_RadioButton2.TabIndex = 5;
            this.iTalk_RadioButton2.Text = "Manager";
            // 
            // iTalk_RadioButton1
            // 
            this.iTalk_RadioButton1.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_RadioButton1.Checked = false;
            this.iTalk_RadioButton1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iTalk_RadioButton1.Location = new System.Drawing.Point(94, 200);
            this.iTalk_RadioButton1.Name = "iTalk_RadioButton1";
            this.iTalk_RadioButton1.Size = new System.Drawing.Size(74, 15);
            this.iTalk_RadioButton1.TabIndex = 4;
            this.iTalk_RadioButton1.Text = "Installer";
            // 
            // iTalk_Button_13
            // 
            this.iTalk_Button_13.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_Button_13.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.iTalk_Button_13.Image = null;
            this.iTalk_Button_13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iTalk_Button_13.Location = new System.Drawing.Point(572, 87);
            this.iTalk_Button_13.Name = "iTalk_Button_13";
            this.iTalk_Button_13.Size = new System.Drawing.Size(49, 40);
            this.iTalk_Button_13.TabIndex = 3;
            this.iTalk_Button_13.Text = "•••";
            this.iTalk_Button_13.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // iTalk_Button_12
            // 
            this.iTalk_Button_12.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_Button_12.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.iTalk_Button_12.Image = global::Circuit_Mod_Manager.Properties.Resources.saveIcon;
            this.iTalk_Button_12.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.iTalk_Button_12.Location = new System.Drawing.Point(528, 389);
            this.iTalk_Button_12.Name = "iTalk_Button_12";
            this.iTalk_Button_12.Size = new System.Drawing.Size(166, 40);
            this.iTalk_Button_12.TabIndex = 2;
            this.iTalk_Button_12.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // iTalk_HeaderLabel2
            // 
            this.iTalk_HeaderLabel2.AutoSize = true;
            this.iTalk_HeaderLabel2.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_HeaderLabel2.Font = new System.Drawing.Font("Segoe UI", 25F);
            this.iTalk_HeaderLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.iTalk_HeaderLabel2.Location = new System.Drawing.Point(172, 19);
            this.iTalk_HeaderLabel2.Name = "iTalk_HeaderLabel2";
            this.iTalk_HeaderLabel2.Size = new System.Drawing.Size(370, 46);
            this.iTalk_HeaderLabel2.TabIndex = 1;
            this.iTalk_HeaderLabel2.Text = "MX Simulator Directory";
            // 
            // mxDirTbox
            // 
            this.mxDirTbox.BackColor = System.Drawing.Color.Transparent;
            this.mxDirTbox.Font = new System.Drawing.Font("Tahoma", 11F);
            this.mxDirTbox.ForeColor = System.Drawing.Color.DimGray;
            this.mxDirTbox.Image = null;
            this.mxDirTbox.Location = new System.Drawing.Point(93, 86);
            this.mxDirTbox.MaxLength = 32767;
            this.mxDirTbox.Multiline = false;
            this.mxDirTbox.Name = "mxDirTbox";
            this.mxDirTbox.ReadOnly = false;
            this.mxDirTbox.Size = new System.Drawing.Size(461, 41);
            this.mxDirTbox.TabIndex = 0;
            this.mxDirTbox.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.mxDirTbox.UseSystemPasswordChar = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "installIcon.png");
            this.imageList1.Images.SetKeyName(1, "managerIcon.png");
            this.imageList1.Images.SetKeyName(2, "settingsIcon.png");
            this.imageList1.Images.SetKeyName(3, "bikeIcon.png");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 511);
            this.Controls.Add(this.iTalk_ThemeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(126, 39);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Circuit Mod Manager";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.iTalk_ThemeContainer1.ResumeLayout(false);
            this.iTalk_TabControl1.ResumeLayout(false);
            this.installerPage.ResumeLayout(false);
            this.installerPage.PerformLayout();
            this.managerPage.ResumeLayout(false);
            this.managerPage.PerformLayout();
            this.settingsPage.ResumeLayout(false);
            this.settingsPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private iTalk.iTalk_ThemeContainer iTalk_ThemeContainer1;
        private iTalk.iTalk_TabControl iTalk_TabControl1;
        private System.Windows.Forms.TabPage installerPage;
        private System.Windows.Forms.TabPage managerPage;
        private System.Windows.Forms.TabPage settingsPage;
        private iTalk.iTalk_ControlBox iTalk_ControlBox1;
        private iTalk.iTalk_Button_1 installModButton;
        private iTalk.iTalk_Label iTalk_Label1;
        private iTalk.iTalk_RadioButton trackRadioButton;
        private iTalk.iTalk_RadioButton gearRadioButton;
        private iTalk.iTalk_Button_1 iTalk_Button_12;
        private iTalk.iTalk_HeaderLabel iTalk_HeaderLabel2;
        private iTalk.iTalk_TextBox_Big mxDirTbox;
        private iTalk.iTalk_Button_1 iTalk_Button_13;
        private iTalk.iTalk_Label modLabel;
        private iTalk.iTalk_ComboBox modComboBox;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private iTalk.iTalk_HeaderLabel iTalk_HeaderLabel1;
        private iTalk.iTalk_TextBox_Big modTbox;
        private System.Windows.Forms.ImageList imageList1;
        private iTalk.iTalk_ProgressIndicator progressSpinner;
        private System.Windows.Forms.CheckedListBox modListBox;
        private iTalk.iTalk_Button_2 executeActionButton;
        private iTalk.iTalk_ComboBox actionComboBox;
        private iTalk.iTalk_Label iTalk_Label2;
        private iTalk.iTalk_ComboBox filterModComboBox;
        private iTalk.iTalk_Label iTalk_Label3;
        private iTalk.iTalk_Label iTalk_Label4;
        private iTalk.iTalk_RadioButton iTalk_RadioButton3;
        private iTalk.iTalk_RadioButton iTalk_RadioButton2;
        private iTalk.iTalk_RadioButton iTalk_RadioButton1;
    }
}

