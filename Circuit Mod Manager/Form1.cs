using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SQLite;
using System.Linq;
using Ionic.Zip;
using System.Collections;
using System.Text;
#region License
/*
Circuit Manager Source Code File
By Ethan87
All rights reserved.

"Author" and "Ethan87" refer to Ethan Jaramillo.
"Software" refers to all files included within repository and those created during program runtime.
"Licensee" and "you" refer to the recipient of this Software.

Except where otherwise noted, all copyrights are exclusively owned by the Author.

BY USING OR DISTRIBUTING THE SOURCE FILE (OR ANY WORK BASED ON THE SOURCE FILE ), YOU INDICATE YOUR ACCEPTANCE OF THIS LICENSE TO DO SO, AND ALL ITS TERMS AND CONDITIONS FOR USING AND DISTRIBUTING THE SOURCE FILE OR WORKS BASED ON IT. NOTHING OTHER THAN THIS LICENSE GRANTS YOU PERMISSION TO DISTRIBUTE THE SOURCE FILE OR ITS DERIVATIVE WORKS. THESE ACTIONS ARE PROHIBITED BY LAW. IF YOU DO NOT ACCEPT THESE TERMS AND CONDITIONS, DO NOT DISTRIBUTE THE SOURCE FILE.
Licenses

Licensor hereby grants you the following rights, provided that you comply with all of the restrictions set forth in this License and provided.
Permission is granted to use the file for non-commercial purposes.

Restrictions
You may not copy and distribute copies of the source file or Software as you receive it throughout the world, in any medium.
You may not create works based on/using the source file and or Software and distribute copies of such throughout the world, in any medium.
You may not remove any comment lines from the source file that may contain material such as credits, release version, or developer name/website.
You may not sell, or create a paid version of the source file.

Links & Emails

mailto:ethan872100@gmail.com

*/
#endregion
//|------DO-NOT-REMOVE------|
//
// Creator: Ethan87
// Contact: ethan872100@gmail.com
// Created: 19.Dec.2016
// Changed: 19.Dec.2016
// Version: 0.0.1
//
//|------DO-NOT-REMOVE------|
namespace Circuit_Mod_Manager
{
    public partial class Form1 : Form
    {
        String mxsimmmVersion = "0.1.7";

        DatabaseManager dbManager = new DatabaseManager();
        StartupRoutine sr = new StartupRoutine();
        VariableManager vManager = new VariableManager();
        String gearConnection;
        String trackConnection;
        String bikeConnection;
        String customConnection;
        String desktopPath;
        ArrayList paramList = new ArrayList();
        ArrayList customDatabaseList = new ArrayList();
        ArrayList customDatabaseListNoExt = new ArrayList();

        public Form1()
        {
            InitializeComponent();
            this.Icon = Circuit_Mod_Manager.Properties.Resources.mxsim_mod_manager;
            this.ShowIcon = true;
            this.ShowInTaskbar = true;
            iTalk_TabControl1.SelectedTab = iTalk_TabControl1.TabPages[Properties.Settings.Default.defaultPage];
            sr.CheckCircuitData();
            mxDirTbox.Text = sr.CheckMXdir();
            //Properties.Settings.Default.customDatabasesExist = false;
            //Properties.Settings.Default.Save();
            if (Properties.Settings.Default.usingPersonalFolder == true)
            {
                mxExeLocationTextbox.Text = Properties.Settings.Default.mxExeLocation;
            }
            else
            {
                mxExeLocationTextbox.Text = mxDirTbox.Text + "\\" + "mx.exe";
            }
            if (Properties.Settings.Default.lockFps == "")
            {
                lockFPSTextbox.Text = "";
            }
            else
            {
                lockFPSTextbox.Text = Properties.Settings.Default.lockFps;
            }
            refreshCustomDatabaseList();
        }
        private void refreshCustomDatabaseList()
        {
            String databaseName;
            foreach (String fileName in Directory.GetFiles("custom_databases"))
            {
                databaseName = Path.GetFileNameWithoutExtension(fileName);
                if(!vManager.getCustomDatabaseListNoExt().Contains(databaseName))
                {
                    vManager.getCustomDatabaseListNoExt().Add(databaseName);
                }
            }
        }

        private void modTbox_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void modTbox_DragDrop(object sender, DragEventArgs e)
        {
            //Initialize mod variables
            String[] files = (String[])e.Data.GetData(DataFormats.FileDrop, false);
            modTbox.Text = files[0];
            vManager.setInstallingMod(files[0]);
            vManager.setInstallingModWithoutPath(Path.GetFileName(files[0]));
        }

        private void installModButton_Click(object sender, EventArgs e)
        {
            //Check if a mod is loaded to install
            if(vManager.getInstallingMod() == null)
            {
                MessageBox.Show("Drag and Drop a mod into the text box above", "No mod loaded", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (trackRadioButton.Checked == true)
                {
                    if (deleteFileAfterCheckbox.Checked == true)
                    {
                        dbManager.StartInstallProcess(vManager.getInstallingModWithoutPath(), vManager.getInstallingMod(), "track", vManager.getInstallingModExtension(), mxDirTbox.Text, true, (string)customDatabaseComboBox.SelectedItem);
                    }
                    else
                    {
                        dbManager.StartInstallProcess(vManager.getInstallingModWithoutPath(), vManager.getInstallingMod(), "track", vManager.getInstallingModExtension(), mxDirTbox.Text, false, (string)customDatabaseComboBox.SelectedItem);
                    }
                }
                else if (gearRadioButton.Checked == true)
                {
                    if(deleteFileAfterCheckbox.Checked == true)
                    {
                        dbManager.StartInstallProcess(vManager.getInstallingModWithoutPath(), vManager.getInstallingMod(), "gear", vManager.getInstallingModExtension(), mxDirTbox.Text, true, (string)customDatabaseComboBox.SelectedItem);
                    }
                    else
                    {
                        dbManager.StartInstallProcess(vManager.getInstallingModWithoutPath(), vManager.getInstallingMod(), "gear", vManager.getInstallingModExtension(), mxDirTbox.Text, false, (string)customDatabaseComboBox.SelectedItem);
                    }
                    
                }
                else if (bikeRadioButton.Checked == true)
                {
                    if(deleteFileAfterCheckbox.Checked == true)
                    {
                        dbManager.StartInstallProcess(vManager.getInstallingModWithoutPath(), vManager.getInstallingMod(), "bike", vManager.getInstallingModExtension(), mxDirTbox.Text, true, (string)customDatabaseComboBox.SelectedItem);
                    }
                    else
                    {
                        dbManager.StartInstallProcess(vManager.getInstallingModWithoutPath(), vManager.getInstallingMod(), "bike", vManager.getInstallingModExtension(), mxDirTbox.Text, false, (string)customDatabaseComboBox.SelectedItem);
                    }
                }
                else if (customRadioButton.Checked == true)
                {
                    if (deleteFileAfterCheckbox.Checked == true)
                    {
                        dbManager.StartInstallProcess(vManager.getInstallingModWithoutPath(), vManager.getInstallingMod(), "custom", vManager.getInstallingModExtension(), mxDirTbox.Text, true, (string)customDatabaseComboBox.SelectedItem);
                    }
                    else
                    {
                        dbManager.StartInstallProcess(vManager.getInstallingModWithoutPath(), vManager.getInstallingMod(), "custom", vManager.getInstallingModExtension(), mxDirTbox.Text, false, (string)customDatabaseComboBox.SelectedItem);
                    }
                }
            }
        }

        private void ethan87Link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.twitter.com/Ethan8721");
        }

        private void nunrarlink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/adamhathcock/sharpcompress");
        }

        private void hazelDevLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://twitter.com/hazeldev");
        }

        private void saveMXdirButton_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("mxdir.txt");
            sw.WriteLine(mxDirTbox.Text);
            if (installerRadioButton.Checked == true)
            {
                Properties.Settings.Default.defaultPage = "installerPage";
                Properties.Settings.Default.Save();
            }
            else if (ManagerRadioButton.Checked == true)
            {
                Properties.Settings.Default.defaultPage = "modPage";
                Properties.Settings.Default.Save();
            }
            else if (SettingsRadioButton.Checked == true)
            {
                Properties.Settings.Default.defaultPage = "settingsPage";
                Properties.Settings.Default.Save();
            }
            else if (DatabasesRadioButton.Checked == true)
            {
                Properties.Settings.Default.defaultPage = "databasesPage";
                Properties.Settings.Default.Save();
            }
            else if (LaunchRadioButton.Checked == true)
            {
                Properties.Settings.Default.defaultPage = "launchPage";
                Properties.Settings.Default.Save();
            }
            sw.Close();
            if(personalFolderCB.Checked == true)
            {
                Properties.Settings.Default.usingPersonalFolder = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.usingPersonalFolder = false;
                Properties.Settings.Default.Save();
            }
            vManager.setMxDirectory(mxDirTbox.Text);
            notifyIconSettings.ShowBalloonTip(2000);
        }

        private void browseMXdirButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Select your MX Simulator root directory";
            fbd.ShowDialog();
            mxDirTbox.Text = fbd.SelectedPath;
        }

        private void filterModComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)filterModComboBox.SelectedItem == "Track")
            {
                trackDatabaseStatusLabel.ForeColor = System.Drawing.Color.DarkGreen;
                trackDatabaseStatusLabel.Text = "Loaded";
                gearDatabaseStatusLabel.ForeColor = System.Drawing.Color.FromArgb(142, 142, 142);
                gearDatabaseStatusLabel.Text = "Idle";
                bikeDatabaseStatusLabel.ForeColor = System.Drawing.Color.FromArgb(142, 142, 142);
                bikeDatabaseStatusLabel.Text = "Idle";
                trackConnection = "Data Source=" + Directory.GetCurrentDirectory() + "\\track_mods.db;version=3;";
                using (SQLiteConnection trackCon = new SQLiteConnection(trackConnection))
                {
                    try
                    {
                        trackCon.Open();
                        if (trackCon.State == System.Data.ConnectionState.Open)
                        {
                            //MessageBox.Show("Successfully connected to track data base");
                            modComboBox.Items.Clear();
                            modListBox.Items.Clear();
                            SQLiteCommand cmd = new SQLiteCommand("SELECT name FROM sqlite_master WHERE type = 'table'", trackCon);
                            using (SQLiteDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    modComboBox.Items.Add(reader["name"]);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    trackCon.Close();
                }
            }
            else if ((string)filterModComboBox.SelectedItem == "Gear")
            {
                trackDatabaseStatusLabel.ForeColor = System.Drawing.Color.FromArgb(142, 142, 142);
                trackDatabaseStatusLabel.Text = "Idle";
                gearDatabaseStatusLabel.ForeColor = System.Drawing.Color.DarkGreen;
                gearDatabaseStatusLabel.Text = "Loaded";
                bikeDatabaseStatusLabel.ForeColor = System.Drawing.Color.FromArgb(142, 142, 142);
                bikeDatabaseStatusLabel.Text = "Idle";
                String gearConnection = "Data Source=" + Directory.GetCurrentDirectory() + "\\gear_mods.db;version=3;";
                using (SQLiteConnection gearCon = new SQLiteConnection(gearConnection))
                {
                    try
                    {
                        gearCon.Open();
                        if (gearCon.State == System.Data.ConnectionState.Open)
                        {
                            //MessageBox.Show("Successfully connected to gear data base at: " + Directory.GetCurrentDirectory() + "\\gear_mods.db");
                            modComboBox.Items.Clear();
                            modListBox.Items.Clear();
                            SQLiteCommand cmd = new SQLiteCommand("SELECT name FROM sqlite_master WHERE type = 'table'", gearCon);
                            using (SQLiteDataReader reader = cmd.ExecuteReader())
                            {
                                while(reader.Read())
                                {
                                    modComboBox.Items.Add(reader["name"]);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    gearCon.Close();
                }
            }
            else if ((string)filterModComboBox.SelectedItem == "Bike")
            {
                trackDatabaseStatusLabel.ForeColor = System.Drawing.Color.FromArgb(142, 142, 142);
                trackDatabaseStatusLabel.Text = "Idle";
                gearDatabaseStatusLabel.ForeColor = System.Drawing.Color.FromArgb(142, 142, 142);
                gearDatabaseStatusLabel.Text = "Idle";
                bikeDatabaseStatusLabel.ForeColor = System.Drawing.Color.DarkGreen;
                bikeDatabaseStatusLabel.Text = "Loaded";
                String bikeConnection = "Data Source=" + Directory.GetCurrentDirectory() + "\\bike_mods.db;version=3;";
                using (SQLiteConnection bikeCon = new SQLiteConnection(bikeConnection))
                {
                    try
                    {
                        bikeCon.Open();
                        if (bikeCon.State == System.Data.ConnectionState.Open)
                        {
                            //MessageBox.Show("Successfully connected to bike database");
                            modComboBox.Items.Clear();
                            modListBox.Items.Clear();
                            SQLiteCommand cmd = new SQLiteCommand("SELECT name FROM sqlite_master WHERE type = 'table'", bikeCon);
                            using (SQLiteDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    modComboBox.Items.Add(reader["name"]);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    bikeCon.Close();
                }
            }
            else
            {
                foreach (String databaseName in vManager.getCustomDatabaseListNoExt())
                {
                    if ((string)filterModComboBox.SelectedItem == databaseName)
                    {
                        trackDatabaseStatusLabel.ForeColor = System.Drawing.Color.FromArgb(142, 142, 142);
                        trackDatabaseStatusLabel.Text = "Idle";
                        gearDatabaseStatusLabel.ForeColor = System.Drawing.Color.FromArgb(142, 142, 142);
                        gearDatabaseStatusLabel.Text = "Idle";
                        bikeDatabaseStatusLabel.ForeColor = System.Drawing.Color.FromArgb(142, 142, 142);
                        bikeDatabaseStatusLabel.Text = "Idle";
                        customDatabaseStatusLabel.Text = "Loaded";
                        customDatabaseStatusLabel.ForeColor = System.Drawing.Color.DarkGreen;
                        loadModsFromCustomDatabase(false, databaseName);
                        break;
                    }
                }
            }
            
        }

        private void loadModsFromCustomDatabase(Boolean databaseView, String databaseName)
        {
            customConnection = "Data Source=" + Directory.GetCurrentDirectory() + "\\custom_databases\\" + databaseName + ".db;version=3;";
            using (SQLiteConnection customCon = new SQLiteConnection(customConnection))
            {
                try
                {
                    customCon.Open();
                    if (customCon.State == System.Data.ConnectionState.Open)
                    {
                        if(databaseView == false)
                        {
                            modComboBox.Items.Clear();
                            modListBox.Items.Clear();
                            SQLiteCommand cmd = new SQLiteCommand("SELECT name FROM sqlite_master WHERE type = 'table'", customCon);
                            using (SQLiteDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    modComboBox.Items.Add(reader["name"]);
                                }
                            }
                        }
                        else
                        {
                            databaseModListBox.Items.Clear();
                            SQLiteCommand cmd = new SQLiteCommand("SELECT name FROM sqlite_master WHERE type = 'table'", customCon);
                            using (SQLiteDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    databaseModListBox.Items.Add(reader["name"]);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                customCon.Close();
            }
        }

        private void modComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)filterModComboBox.SelectedItem == "Track")
            {
                //MessageBox.Show("Showing Track Mods");
                modListBox.Items.Clear();
                trackConnection = "Data Source=" + Directory.GetCurrentDirectory() + "\\track_mods.db;version=3;";
                using (SQLiteConnection trackCon = new SQLiteConnection(trackConnection))
                {
                    try
                    {
                        trackCon.Open();
                        if (trackCon.State == System.Data.ConnectionState.Open)
                        {
                            //MessageBox.Show("Successfully connected");
                            SQLiteCommand cmd = new SQLiteCommand("SELECT modFiles FROM " + "'" + (string)modComboBox.SelectedItem + "';", trackCon);
                            using (SQLiteDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    modListBox.Items.Add(reader["modFiles"]);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    trackCon.Close();
                }
            }
            else if ((string)filterModComboBox.SelectedItem == "Gear")
            {
                //MessageBox.Show("Showing Gear Mods files for: " + modComboBox.SelectedItem.ToString());
                modListBox.Items.Clear();
                gearConnection = "Data Source=" + Directory.GetCurrentDirectory() + "\\gear_mods.db;version=3;";
                using (SQLiteConnection gearCon = new SQLiteConnection(gearConnection))
                {
                    try
                    {
                        gearCon.Open();
                        if (gearCon.State == System.Data.ConnectionState.Open)
                        {
                            //MessageBox.Show("Successfully connected");
                            SQLiteCommand cmd = new SQLiteCommand("SELECT modFiles FROM " + "'" + (string)modComboBox.SelectedItem + "';", gearCon);
                            using (SQLiteDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    modListBox.Items.Add(reader["modFiles"]);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    gearCon.Close();
                }
            }
            else if ((string)filterModComboBox.SelectedItem == "Bike")
            {
                //MessageBox.Show("Showing Bike Mods files for: " + modComboBox.SelectedItem.ToString());
                modListBox.Items.Clear();
                bikeConnection = "Data Source=" + Directory.GetCurrentDirectory() + "\\bike_mods.db;version=3;";
                using (SQLiteConnection bikeCon = new SQLiteConnection(bikeConnection))
                {
                    try
                    {
                        bikeCon.Open();
                        if (bikeCon.State == System.Data.ConnectionState.Open)
                        {
                            //MessageBox.Show("Successfully connected");
                            SQLiteCommand cmd = new SQLiteCommand("SELECT modFiles FROM " + "'" + (string)modComboBox.SelectedItem + "';", bikeCon);
                            using (SQLiteDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    modListBox.Items.Add(reader["modFiles"]);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    bikeCon.Close();
                }
            }
            else
            {
                foreach(String databaseEntry in vManager.getCustomDatabaseListNoExt())
                {
                    if((string)filterModComboBox.SelectedItem == databaseEntry)
                    {
                        modListBox.Items.Clear();
                        customConnection = "Data Source=" + Directory.GetCurrentDirectory() + "\\custom_databases\\" + databaseEntry + ".db;version=3;";
                        using (SQLiteConnection customCon = new SQLiteConnection(customConnection))
                        {
                            try
                            {
                                customCon.Open();
                                if (customCon.State == System.Data.ConnectionState.Open)
                                {
                                    //MessageBox.Show("Successfully connected");
                                    SQLiteCommand cmd = new SQLiteCommand("SELECT modFiles FROM " + "'" + (string)modComboBox.SelectedItem + "';", customCon);
                                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                                    {
                                        while (reader.Read())
                                        {
                                            modListBox.Items.Add(reader["modFiles"]);
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            customCon.Close();
                        }
                    }
                }
            }
        }

        private void executeActionButton_Click(object sender, EventArgs e)
        {
            if((string)modComboBox.SelectedItem == null)
            {
                if((string)actionComboBox.SelectedItem != "Backup Entire MXS Install")
                {
                    MessageBox.Show("No mod selected", "MXSIM:MM", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    backupMXSInstall();
                }
            }
            else
            {
                if ((string)actionComboBox.SelectedItem == "Remove From Database")
                {
                    if ((string)filterModComboBox.SelectedItem == "Gear")
                    {
                        using (SQLiteConnection gearCon = new SQLiteConnection(gearConnection))
                        {
                            try
                            {
                                gearCon.Open();
                                if (gearCon.State == System.Data.ConnectionState.Open)
                                {
                                    SQLiteCommand cmd = new SQLiteCommand("DROP TABLE " + "'" + (string)modComboBox.SelectedItem + "'", gearCon);
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("Removed " + (string)modComboBox.SelectedItem + " from gear database", "Removed mod from Database", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    modComboBox.Items.Remove(modComboBox.SelectedItem);
                                    modListBox.Items.Clear();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            gearCon.Close();
                        }
                    }
                    else if ((string)filterModComboBox.SelectedItem == "Track")
                    {
                        using (SQLiteConnection trackCon = new SQLiteConnection(trackConnection))
                        {
                            try
                            {
                                trackCon.Open();
                                if (trackCon.State == System.Data.ConnectionState.Open)
                                {
                                    SQLiteCommand cmd = new SQLiteCommand("DROP TABLE " + "'" + (string)modComboBox.SelectedItem + "'", trackCon);
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("Removed " + (string)modComboBox.SelectedItem + " from track database", "Removed mod from Database", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    modComboBox.Items.Remove(modComboBox.SelectedItem);
                                    modListBox.Items.Clear();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            trackCon.Close();
                        }
                    }
                    else if ((string)filterModComboBox.SelectedItem == "Bike")
                    {
                        using (SQLiteConnection bikeCon = new SQLiteConnection(bikeConnection))
                        {
                            try
                            {
                                bikeCon.Open();
                                if (bikeCon.State == System.Data.ConnectionState.Open)
                                {
                                    SQLiteCommand cmd = new SQLiteCommand("DROP TABLE " + "'" + (string)modComboBox.SelectedItem + "'", bikeCon);
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("Removed " + (string)modComboBox.SelectedItem + " from bike database", "Removed mod from Database", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    modComboBox.Items.Remove(modComboBox.SelectedItem);
                                    modListBox.Items.Clear();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            bikeCon.Close();
                        }
                    }
                }
                else if((string)actionComboBox.SelectedItem == "Delete Mod")
                {
                    if (gearDatabaseStatusLabel.Text == "Loaded")
                    {
                        SQLiteConnection gearCon = null;
                        deleteMod(false, false, "gear_mods", gearCon, "gearConnection");
                    }
                    else if(trackDatabaseStatusLabel.Text == "Loaded")
                    {
                        SQLiteConnection trackCon = null;
                        deleteMod(false, false, "track_mods", trackCon, "trackConnection");
                    }
                    else if(bikeDatabaseStatusLabel.Text == "Loaded")
                    {
                        SQLiteConnection bikeCon = null;
                        deleteMod(false, false, "bike_mods", bikeCon, "bikeConnection");
                    }
                    else if(customDatabaseStatusLabel.Text == "Loaded")
                    {
                        SQLiteConnection customCon = null;
                        deleteMod(false, true, (string)filterModComboBox.SelectedItem, customCon, "customConnection");
                    }
                }
                else if((string)actionComboBox.SelectedItem == "Delete Selected Files")
                {
                    if (gearDatabaseStatusLabel.Text == "Loaded")
                    {
                        SQLiteConnection gearCon = null;
                        deleteSelectedFiles(false, "gear_mods", gearCon, "gearConnection");
                    }
                    else if(trackDatabaseStatusLabel.Text == "Loaded")
                    {
                        SQLiteConnection trackCon = null;
                        deleteSelectedFiles(false, "track_mods", trackCon, "trackConnection");
                    }
                    else if(bikeDatabaseStatusLabel.Text == "Loaded")
                    {
                        SQLiteConnection bikeCon = null;
                        deleteSelectedFiles(false, "bike_mods", bikeCon, "bikeConnection");
                    }
                    else if(customDatabaseStatusLabel.Text == "Loaded")
                    {
                        SQLiteConnection customCon = null;
                        deleteSelectedFiles(true, (string)filterModComboBox.SelectedItem, customCon, "customConnection");
                    }
                }
                else if((string)actionComboBox.SelectedItem == "Backup Mod")
                {
                    
                    if (gearDatabaseStatusLabel.Text == "Loaded")
                    {
                        SQLiteConnection gearCon = null;
                        backupMod(false, false, "gear_mods", gearCon, "gearConnection");
                    }
                    else if (trackDatabaseStatusLabel.Text == "Loaded")
                    {
                        SQLiteConnection trackCon = null;
                        backupMod(false, false, "track_mods", trackCon, "trackConnection");
                    }
                    else if (bikeDatabaseStatusLabel.Text == "Loaded")
                    {
                        SQLiteConnection bikeCon = null;
                        backupMod(false, false, "bike_mods", bikeCon, "bikeConnection");
                    }
                    else if (customDatabaseStatusLabel.Text == "Loaded")
                    {
                        SQLiteConnection customCon = null;
                        backupMod(true, false, (string)filterModComboBox.SelectedItem, customCon, "customConnection");
                    }
                }
                else if((string)actionComboBox.SelectedItem == "Backup Selected Files")
                {
                    if (gearDatabaseStatusLabel.Text == "Loaded")
                    {
                        SQLiteConnection gearCon = null;
                        backupMod(false, true, "gear_mods", gearCon, "gearConnection");
                        //gearConnection = "Data Source=" + Directory.GetCurrentDirectory() + "\\gear_mods.db;version=3;";
                        //using (SQLiteConnection gearCon = new SQLiteConnection(gearConnection))
                        //{
                        //    try
                        //    {
                        //        gearCon.Open();
                        //        if (gearCon.State == System.Data.ConnectionState.Open)
                        //        {
                        //            desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                        //            using (ZipFile zip = new ZipFile(desktopPath + "\\" + backupNameTextbox.Text + ".zip"))
                        //            {
                        //                foreach (var item in modListBox.CheckedItems.OfType<string>().ToList())
                        //                {
                        //                    FileAttributes attr = File.GetAttributes(mxDirTbox.Text + "\\" + item);
                        //                    if (attr.HasFlag(FileAttributes.Directory))
                        //                    {

                        //                    }
                        //                    else
                        //                    {
                        //                        zip.AddFile(mxDirTbox.Text + "\\" + item);
                        //                    }
                        //                }
                        //                zip.Comment = "Gear Backup by MXSIM:MM, Date: " + System.DateTime.Now.ToString("G");
                        //                zip.Save();
                        //            }
                        //        }
                        //    }
                        //    catch (Exception ex)
                        //    {
                        //        MessageBox.Show(ex.Message);
                        //    }
                        //    gearCon.Close();
                        //}
                    }
                    else if (trackDatabaseStatusLabel.Text == "Loaded")
                    {
                        SQLiteConnection trackCon = null;
                        backupMod(false, true, "track_mods", trackCon, "trackConnection");
                        //trackConnection = "Data Source=" + Directory.GetCurrentDirectory() + "\\track_mods.db;version=3;";
                        //using (SQLiteConnection trackCon = new SQLiteConnection(trackConnection))
                        //{
                        //    try
                        //    {
                        //        trackCon.Open();
                        //        if (trackCon.State == System.Data.ConnectionState.Open)
                        //        {
                        //            desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                        //            using (ZipFile zip = new ZipFile(desktopPath + "\\" + backupNameTextbox.Text + ".zip"))
                        //            {
                        //                foreach (var item in modListBox.CheckedItems.OfType<string>().ToList())
                        //                {
                        //                    FileAttributes attr = File.GetAttributes(mxDirTbox.Text + "\\" + item);
                        //                    if (attr.HasFlag(FileAttributes.Directory))
                        //                    {

                        //                    }
                        //                    else
                        //                    {
                        //                        zip.AddFile(mxDirTbox.Text + "\\" + item);
                        //                    }
                        //                }
                        //                zip.Comment = "Gear Backup by MXSIM:MM, Date: " + System.DateTime.Now.ToString("G");
                        //                zip.Save();
                        //            }
                        //        }
                        //    }
                        //    catch (Exception ex)
                        //    {
                        //        MessageBox.Show(ex.Message);
                        //    }
                        //    trackCon.Close();
                        //}
                    }
                    else if (bikeDatabaseStatusLabel.Text == "Loaded")
                    {
                        SQLiteConnection bikeCon = null;
                        backupMod(false, true, "bike_mods", bikeCon, "bikeConnection");
                        //bikeConnection = "Data Source=" + Directory.GetCurrentDirectory() + "\\bike_mods.db;version=3;";
                        //using (SQLiteConnection bikeCon = new SQLiteConnection(bikeConnection))
                        //{
                        //    try
                        //    {
                        //        bikeCon.Open();
                        //        if (bikeCon.State == System.Data.ConnectionState.Open)
                        //        {
                        //            desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                        //            using (ZipFile zip = new ZipFile(desktopPath + "\\" + backupNameTextbox.Text + ".zip"))
                        //            {
                        //                foreach (var item in modListBox.CheckedItems.OfType<string>().ToList())
                        //                {
                        //                    FileAttributes attr = File.GetAttributes(mxDirTbox.Text + "\\" + item);
                        //                    if (attr.HasFlag(FileAttributes.Directory))
                        //                    {

                        //                    }
                        //                    else
                        //                    {
                        //                        zip.AddFile(mxDirTbox.Text + "\\" + item);
                        //                    }
                        //                }
                        //                zip.Comment = "Bike Backup by MXSIM:MM, Date: " + System.DateTime.Now.ToString("G");
                        //                zip.Save();
                        //            }
                        //        }
                        //    }
                        //    catch (Exception ex)
                        //    {
                        //        MessageBox.Show(ex.Message);
                        //    }
                        //    bikeCon.Close();
                        //}
                    }
                    else if (customDatabaseStatusLabel.Text == "Loaded")
                    {
                        SQLiteConnection customCon = null;
                        backupMod(true, true, (string)filterModComboBox.SelectedItem, customCon, "customConnection");
                    }
                }
                else if((string)actionComboBox.SelectedItem == "Backup Entire MXS Install")
                {
                    backupMXSInstall();
                }
            }
        }

        private void backupMod(Boolean isCustom, Boolean selectedFiles, String databaseName, SQLiteConnection sqliteCon, String sqliteConnectionString)
        {
            if(isCustom == true)
            {
                sqliteConnectionString = "Data Source=" + Directory.GetCurrentDirectory() + "\\custom_databases\\" + databaseName + ".db;version=3;";
            }
            else
            {
                sqliteConnectionString = "Data Source=" + Directory.GetCurrentDirectory() + "\\" + databaseName + "db;version=3;";
            }
            
            using (sqliteCon = new SQLiteConnection(sqliteConnectionString))
            {
                try
                {
                    sqliteCon.Open();
                    if (sqliteCon.State == System.Data.ConnectionState.Open)
                    {
                        desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                        using (ZipFile zip = new ZipFile(desktopPath + "\\" + backupNameTextbox.Text + ".zip"))
                        {
                            if(selectedFiles == true)
                            {
                                foreach (var item in modListBox.CheckedItems.OfType<string>().ToList())
                                {
                                    FileAttributes attr = File.GetAttributes(mxDirTbox.Text + "\\" + item);
                                    if (attr.HasFlag(FileAttributes.Directory))
                                    {

                                    }
                                    else
                                    {
                                        zip.AddFile(mxDirTbox.Text + "\\" + item);
                                    }

                                }
                                zip.Comment = " Backup by MXSIM:MM " + mxsimmmVersion + ", Date: " + System.DateTime.Now.ToString("G");
                                zip.Save();
                            }
                            else
                            {
                                foreach (var item in modListBox.Items.OfType<string>().ToList())
                                {
                                    FileAttributes attr = File.GetAttributes(mxDirTbox.Text + "\\" + item);
                                    if (attr.HasFlag(FileAttributes.Directory))
                                    {

                                    }
                                    else
                                    {
                                        zip.AddFile(mxDirTbox.Text + "\\" + item);
                                    }

                                }
                                zip.Comment = " Backup by MXSIM:MM " + mxsimmmVersion + ", Date: " + System.DateTime.Now.ToString("G");
                                zip.Save();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
                sqliteCon.Close();
            }
        }

        private void deleteSelectedFiles(Boolean isCustom, String databaseName, SQLiteConnection sqliteCon, String sqliteConnectionString)
        {
            if(isCustom == true)
            {
                sqliteConnectionString = "Data Source=" + Directory.GetCurrentDirectory() + "\\custom_databases\\" + databaseName + ".db;version=3;";
            }
            else
            {
                sqliteConnectionString = "Data Source=" + Directory.GetCurrentDirectory() + "\\" + databaseName + ".db;version=3;";
            }
            using (sqliteCon = new SQLiteConnection(sqliteConnectionString))
            {
                try
                {
                    sqliteCon.Open();
                    if (sqliteCon.State == System.Data.ConnectionState.Open)
                    {
                        deleteSelectedModFiles();
                        for (int counter = 0; counter < modListBox.CheckedItems.Count; counter++)
                        {
                            SQLiteCommand cmd = new SQLiteCommand("DELETE FROM " + "'" + (string)modComboBox.SelectedItem + "'" + " WHERE modFiles = " + "'" + modListBox.CheckedItems[counter].ToString() + "';", sqliteCon);
                            cmd.ExecuteNonQuery();
                        }
                        foreach (var item in modListBox.CheckedItems.OfType<string>().ToList())
                        {
                            modListBox.Items.Remove(item);
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                sqliteCon.Close();
            }
        }

        private void deleteMod(Boolean databaseView, Boolean isCustom, String databaseName, SQLiteConnection sqliteCon, String sqliteConnectionString)
        {
            if(isCustom == true)
            {
                sqliteConnectionString = "Data Source=" + Directory.GetCurrentDirectory() + "\\custom_databases\\" + databaseName + ".db;version=3;";
            }
            else
            {
                sqliteConnectionString = "Data Source=" + Directory.GetCurrentDirectory() + "\\" + databaseName + ".db;version=3;";
            }
            using (sqliteCon = new SQLiteConnection(sqliteConnectionString))
            {
                try
                {
                    sqliteCon.Open();
                    if (sqliteCon.State == System.Data.ConnectionState.Open)
                    {
                        if(databaseView == false)
                        {
                            deleteModFiles(false);
                            SQLiteCommand cmd = new SQLiteCommand("DROP TABLE " + "'" + (string)modComboBox.SelectedItem + "'", sqliteCon);
                            cmd.ExecuteNonQuery();
                            modListBox.Items.Clear();
                            modComboBox.Items.Remove(modComboBox.SelectedItem);
                        }
                        else
                        {
                            foreach(String modInDatabase in databaseModListBox.Items)
                            {
                                deleteModFiles(modInDatabase);
                                SQLiteCommand cmd = new SQLiteCommand("DROP TABLE " + "'" + modInDatabase + "'", sqliteCon);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                sqliteCon.Close();
            }
        }

        private void actionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)actionComboBox.SelectedItem == "Backup Mod" || (string)actionComboBox.SelectedItem == "Backup Selected Files" || (string)actionComboBox.SelectedItem == "Backup Entire MXS Install")
            {
                backupNameLabel.Visible = true;
                backupNameTextbox.Visible = true;
            }
            else
            {
                backupNameLabel.Visible = false;
                backupNameTextbox.Visible = false;
            }
        }

        private void backupMXSInstall()
        {
            MessageBox.Show("Note: If your MX Simulator directory is large, MXSIM:MM will seem frozen, it's not, please let it work", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //Zip mod
            using (ZipFile zip = new ZipFile())
            {
                zip.AddDirectory(mxDirTbox.Text);
                zip.Save(desktopPath + "\\" + backupNameTextbox.Text + ".zip");
            }
        }

        private void deleteModFiles(Boolean databaseView)
        {
            if(databaseView == false)
            {
                for (int counter = 0; counter < modListBox.Items.Count; counter++)
                {
                    try
                    {
                        FileAttributes attr = File.GetAttributes(mxDirTbox.Text + "\\" + modListBox.Items[counter].ToString());
                        if (attr.HasFlag(FileAttributes.Directory))
                        {
                            if (modListBox.Items[counter].ToString().Contains("/"))
                            {
                                modListBox.Items[counter].ToString().Replace("/", "\\");
                                Directory.Delete(mxDirTbox.Text + "\\" + modListBox.Items[counter].ToString(), true);
                            }
                            else
                            {
                                Directory.Delete(mxDirTbox.Text + "\\" + modListBox.Items[counter].ToString(), true);
                            }
                        }
                        else
                        {
                            File.Delete(mxDirTbox.Text + "\\" + modListBox.Items[counter].ToString());
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            else
            {
                for (int counter = 0; counter < databaseModListBox.Items.Count; counter++)
                {
                    try
                    {
                        FileAttributes attr = File.GetAttributes(mxDirTbox.Text + "\\" + databaseModListBox.Items[counter].ToString());
                        if (attr.HasFlag(FileAttributes.Directory))
                        {
                            if (databaseModListBox.Items[counter].ToString().Contains("/"))
                            {
                                databaseModListBox.Items[counter].ToString().Replace("/", "\\");
                                Directory.Delete(mxDirTbox.Text + "\\" + databaseModListBox.Items[counter].ToString(), true);
                            }
                            else
                            {
                                Directory.Delete(mxDirTbox.Text + "\\" + databaseModListBox.Items[counter].ToString(), true);
                            }
                        }
                        else
                        {
                            File.Delete(mxDirTbox.Text + "\\" + databaseModListBox.Items[counter].ToString());
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }

        private void deleteModFiles(String modName)
        {
            customConnection = "Data Source=" + Directory.GetCurrentDirectory() + "\\custom_databases\\" + (string)databaseComboBox.SelectedItem + ".db;version=3;";
            using (SQLiteConnection customCon = new SQLiteConnection(customConnection))
            {
                try
                {
                    customCon.Open();
                    if (customCon.State == System.Data.ConnectionState.Open)
                    {
                        ArrayList fileList = new ArrayList();
                        SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM '" + modName + "';", customCon);
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                fileList.Add(reader[1]);
                            }
                        }
                        foreach (String fileName in fileList)
                        {
                            for (int counter = 0; counter < fileList.Count; counter++)
                            {
                                try
                                {
                                    FileAttributes attr = File.GetAttributes(mxDirTbox.Text + "\\" + fileName);
                                    if (attr.HasFlag(FileAttributes.Directory))
                                    {
                                        if (fileName.Contains("/"))
                                        {
                                            fileName.Replace("/", "\\");
                                            Directory.Delete(mxDirTbox.Text + "\\" + fileName, true);
                                        }
                                        else
                                        {
                                            Directory.Delete(mxDirTbox.Text + "\\" + fileName, true);
                                        }
                                    }
                                    else
                                    {
                                        File.Delete(mxDirTbox.Text + "\\" + fileName);
                                    }
                                }
                                catch (Exception)
                                {

                                }
                            }
                        }
                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                customCon.Close();
            }
        }

        private void deleteSelectedModFiles()
        {
            for (int counter = 0; counter < modListBox.CheckedItems.Count; counter++)
            {
                try
                {
                    FileAttributes attr = File.GetAttributes(mxDirTbox.Text + "\\" + modListBox.CheckedItems[counter].ToString());
                    if (attr.HasFlag(FileAttributes.Directory))
                    {
                        if (modListBox.CheckedItems[counter].ToString().Contains("/"))
                        {
                            modListBox.CheckedItems[counter].ToString().Replace("/", "\\");
                            Directory.Delete(mxDirTbox.Text + "\\" + modListBox.CheckedItems[counter].ToString(), true);
                        }
                        else
                        {
                            Directory.Delete(mxDirTbox.Text + "\\" + modListBox.CheckedItems[counter].ToString(), true);
                        }
                    }
                    else
                    {
                        File.Delete(mxDirTbox.Text + "\\" + modListBox.CheckedItems[counter].ToString());
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        private void donateButton_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=6ZHWULCKM5BGY&lc=US&item_name=MXSIM%20Mod%20Manager&currency_code=USD&bn=PP%2dDonationsBF%3abtn_donate_LG%2egif%3aNonHosted");
        }

        private void selectAllRadioButton_CheckedChanged(object sender)
        {
            if(selectAllRadioButton.Checked == true)
            {
                for (int i = 0; i < modListBox.Items.Count; i++)
                {
                    modListBox.SetItemCheckState(i, CheckState.Checked);
                }
            }
        }

        private void selectNoneRadioButton_CheckedChanged(object sender)
        {
            if (selectNoneRadioButton.Checked == true)
            {
                for (int i = 0; i < modListBox.Items.Count; i++)
                {
                    modListBox.SetItemCheckState(i, CheckState.Unchecked);
                }
            }
        }

        private void googleLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://twitter.com/google");
        }

        private void dotNetZipLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://dotnetzip.codeplex.com/");
        }

        private void rotateLineupTrackbar_ValueChanged()
        {
            rotateLineupValue.Text = rotateLineupTrackbar.Value.ToString();
        }

        private void lodBiasTrackbar_ValueChanged()
        {
            lodBiasValue.Text = lodBiasTrackbar.Value.ToString();
        }

        private void roostFreqTrackbar_ValueChanged()
        {
            roostFreqValue.Text = roostFreqTrackbar.Value.ToString();
        }

        private void detailTrackbar_ValueChanged()
        {
            detailValue.Text = detailTrackbar.Value.ToString();
        }

        private void customRadioButton_CheckedChanged(object sender)
        {
            if(customRadioButton.Checked == true)
            {
                customDatabaseComboBox.Visible = true;
                if (Properties.Settings.Default.customDatabasesExist == true)
                {
                    customDatabaseComboBox.Items.Clear();
                    String databaseName;
                    foreach (String fileName in Directory.GetFiles("custom_databases"))
                    {
                        if(fileName == "")
                        {
                            MessageBox.Show("Null database name: " + fileName, "Error: Null database name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            databaseName = Path.GetFileNameWithoutExtension(fileName);
                            customDatabaseComboBox.Items.Add(databaseName);
                            vManager.getCustomDatabaseListNoExt().Add(databaseName);
                        }
                    }
                }
            }
            else
            {
                customDatabaseComboBox.Visible = false;
            }
        }

        private void iTalk_TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(iTalk_TabControl1.SelectedTab == iTalk_TabControl1.TabPages["databasesPage"])
            {
                if(Properties.Settings.Default.customDatabasesExist == true)
                {
                    createNewDatabaseButton.Visible = false;
                    noCustomDatabaseLabel.Visible = false;
                    createNewDatabase2Button.Visible = true;
                    databaseActionLabel.Visible = true;
                    databaseActionComboBox.Visible = true;
                    databaseBackupNameLabel.Visible = false;
                    databaseBackupNameTextbox.Visible = false;
                    databaseComboBox.Visible = true;
                    databaseExecuteButton.Visible = true;
                    databaseLabel.Visible = true;
                    databaseModListBox.Visible = true;
                    databaseComboBox.Items.Clear();
                    refreshCustomDatabaseList();
                    foreach (String databaseEntry in vManager.getCustomDatabaseListNoExt())
                    {
                        if (!databaseComboBox.Items.Contains(databaseEntry))
                        {
                            databaseComboBox.Items.Add(databaseEntry);
                        }
                    }
                }
                else
                {
                    createNewDatabaseButton.Visible = true;
                    noCustomDatabaseLabel.Visible = true;
                    createNewDatabase2Button.Visible = false;
                    databaseActionLabel.Visible = false;
                    databaseActionComboBox.Visible = false;
                    databaseBackupNameLabel.Visible = false;
                    databaseBackupNameTextbox.Visible = false;
                    databaseComboBox.Visible = false;
                    databaseExecuteButton.Visible = false;
                    databaseLabel.Visible = false;
                    databaseModListBox.Visible = false;
                }

            }
            else if(iTalk_TabControl1.SelectedTab == iTalk_TabControl1.TabPages["launchPage"])
            {
                if(Properties.Settings.Default.usingPersonalFolder == true)
                {
                    mxExeLocationTextbox.Text = Properties.Settings.Default.mxExeLocation;
                }
                else
                {
                    mxExeLocationTextbox.Text = mxDirTbox.Text + "\\" + "mx.exe";
                }
            }
            else if(iTalk_TabControl1.SelectedTab == iTalk_TabControl1.TabPages["settingsPage"])
            {
                if(Properties.Settings.Default.usingPersonalFolder == true)
                {
                    personalFolderCB.Checked = true;
                }
                else
                {
                    personalFolderCB.Checked = false;
                }
            }
            else if(iTalk_TabControl1.SelectedTab == iTalk_TabControl1.TabPages["installerPage"])
            {
                if(Properties.Settings.Default.alwaysDeleteFileAfterInstall == true)
                {
                    alwaysDeleteFileAfterInstallCB.Checked = true;
                    deleteFileAfterCheckbox.Checked = true;
                }
                else
                {
                    alwaysDeleteFileAfterInstallCB.Checked = false;
                    deleteFileAfterCheckbox.Checked = false;
                }
                if (Properties.Settings.Default.customDatabasesExist == true)
                {
                    customDatabaseComboBox.Items.Clear();
                    refreshCustomDatabaseList();
                    foreach (String databaseEntry in vManager.getCustomDatabaseListNoExt())
                    {
                        if (!customDatabaseComboBox.Items.Contains(databaseEntry))
                        {
                            customDatabaseComboBox.Items.Add(databaseEntry);
                        }
                    }
                }
            }
            else if(iTalk_TabControl1.SelectedTab == iTalk_TabControl1.TabPages["modPage"])
            {
                if (Properties.Settings.Default.customDatabasesExist == true)
                {
                    filterModComboBox.Items.Clear();
                    refreshCustomDatabaseList();
                    filterModComboBox.Items.Add("Gear");
                    filterModComboBox.Items.Add("Track");
                    filterModComboBox.Items.Add("Bike");
                    foreach (String databaseEntry in vManager.getCustomDatabaseListNoExt())
                    {
                        if(!filterModComboBox.Items.Contains(databaseEntry))
                        {
                            filterModComboBox.Items.Add(databaseEntry);
                        }
                    }
                }
            }
        }

        private void createNewDatabaseButton_Click(object sender, EventArgs e)
        {
            newDatabaseForm newDBform = new newDatabaseForm();
            newDBform.Show();
            Properties.Settings.Default.customDatabasesExist = true;
            Properties.Settings.Default.Save();
        }

        private void launchMXS_Click(object sender, EventArgs e)
        {
            if (mxExeLocationTextbox.Text == "")
            {
                MessageBox.Show("MX.exe location was not specified", "MX.exe not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                String rotateLineupValue = 0.ToString();
                if(rotateLineupCB.Checked == true)
                {
                    updateParamlist(true, "--rotate-lineup " + rotateLineupTrackbar.Value + " ");
                }
                else
                {
                    updateParamlist(false, "--rotate-lineup " + rotateLineupTrackbar.Value + " ");
                }
                if(lodBiasCB.Checked == true)
                {
                    updateParamlist(true, "--lod-bias " + lodBiasTrackbar.Value + " ");
                }
                else
                {
                    updateParamlist(false, "--lod-bias " + lodBiasTrackbar.Value + " ");
                }
                if(roostFreqCB.Checked == true)
                {
                    updateParamlist(true, "--roostfrequency " + roostFreqTrackbar.Value + " ");
                }
                else
                {
                    updateParamlist(false, "--roostfrequency " + roostFreqTrackbar.Value + " ");
                }
                if(detailCB.Checked == true)
                {
                    updateParamlist(true, "--detail " + detailTrackbar.Value + " ");
                }
                else
                {
                    updateParamlist(false, "--detail " + detailTrackbar.Value + " ");
                }
                if(lockFPSCB.Checked == true)
                {
                    updateParamlist(true, "--lock-fps " + lockFPSTextbox.Text + " ");
                    Properties.Settings.Default.lockFps = lockFPSTextbox.Text;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    updateParamlist(false, "--lock-fps " + lockFPSTextbox.Text + " ");
                }
                if (fakelagCB.Checked == true)
                {
                    updateParamlist(true, "--fake-lag ");
                }
                else
                {
                    updateParamlist(false, "--fake-lag ");
                }
                if (noVertexArraysCB.Checked == true)
                {
                    updateParamlist(true, "--novertexarrays ");
                }
                else
                {
                    updateParamlist(false, "--novertexarrays ");
                }
                if (debugCB.Checked == true)
                {
                    updateParamlist(true, "--debug ");
                }
                else
                {
                    updateParamlist(false, "--debug ");
                }
                if (superDebugCB.Checked == true)
                {
                    updateParamlist(true, "--super-debug ");
                }
                else
                {
                    updateParamlist(false, "--super-debug ");
                }
                if (accurateSkipCB.Checked == true)
                {
                    updateParamlist(true, "--accurate-skip 1 ");
                }
                else
                {
                    updateParamlist(false, "--accurate-skip 1 ");
                }
                if (erodeCB.Checked == true)
                {
                    updateParamlist(true, "--erode 1 ");
                }
                else
                {
                    updateParamlist(false, "--erode 1 ");
                }
                if (glFinishCB.Checked == true)
                {
                    updateParamlist(true, "--glfinish 1 ");
                }
                else
                {
                    updateParamlist(false, "--glfinish 1 ");
                }
                if (aiLearnCB.Checked == true)
                {
                    updateParamlist(true, "--learn ");
                }
                else
                {
                    updateParamlist(false, "--learn ");
                }
                if (noAiLearnCB.Checked == true)
                {
                    updateParamlist(true, "--nolearn ");
                }
                else
                {
                    updateParamlist(false, "--nolearn ");
                }
                if (aiWarpCB.Checked == true)
                {
                    updateParamlist(true, "--warp ");
                }
                else
                {
                    updateParamlist(false, "--warp ");
                }
                if (noMMXCB.Checked == true)
                {
                    updateParamlist(true, "--nommx ");
                }
                else
                {
                    updateParamlist(false, "--nommx ");
                }
                if (hidePauseCB.Checked == true)
                {
                    updateParamlist(true, "--hidden-pause 1 ");
                }
                else
                {
                    updateParamlist(false, "--hidden-pause 1 ");
                }
                if (hideHudCB.Checked == true)
                {
                    updateParamlist(true, "--hidden-hud 1 ");
                }
                else
                {
                    updateParamlist(false, "--hidden-hud 1 ");
                }
                if (fuglyCB.Checked == true)
                {
                    updateParamlist(true, "--fugly 1 ");
                }
                else
                {
                    updateParamlist(false, "--fugly 1 ");
                }
                if (drawFPSCB.Checked == true)
                {
                    updateParamlist(true, "--draw-fps 1 ");
                }
                else
                {
                    updateParamlist(false, "--draw-fps 1 ");
                }
                if (drawTimeCB.Checked == true)
                {
                    updateParamlist(true, "--draw-time 1 ");
                }
                else
                {
                    updateParamlist(false, "--draw-time 1 ");
                }
                if (drawPingCB.Checked == true)
                {
                    updateParamlist(true, "--draw-ping 1 ");
                }
                else
                {
                    updateParamlist(false, "--draw-ping 1 ");
                }
                if (drawRenderStatsCB.Checked == true)
                {
                    updateParamlist(true, "--draw-render-stats 1 ");
                }
                else
                {
                    updateParamlist(false, "--draw-render-stats 1 ");
                }
                if (recordVideoCB.Checked == true)
                {
                    updateParamlist(true, "--record-video ");
                }
                else
                {
                    updateParamlist(false, "--record-video ");
                }
                if (noSoundCB.Checked == true)
                {
                    updateParamlist(true, "--nosound ");
                }
                else
                {
                    updateParamlist(false, "--nosound ");
                }
                if (editorCB.Checked == true)
                {
                    updateParamlist(true, "--editor 1 ");
                }
                else
                {
                    updateParamlist(false, "--editor 1 ");
                }
                if (practiceCB.Checked == true)
                {
                    updateParamlist(true, "--practice ");
                }
                else
                {
                    updateParamlist(false, "--practice ");
                }
                StringBuilder sb = new StringBuilder();
                foreach (String parameter in paramList)
                {
                    sb.Append(parameter);   
                }
                try
                {
                    Process.Start(mxExeLocationTextbox.Text, sb.ToString());
                    paramList.Clear();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error loading MX Simulator, verify path", "Error loading MX.exe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            
        }

        private void rotateLineupCB_CheckedChanged(object sender)
        {
            if(rotateLineupCB.Checked == true)
            {
                rotateLineupTrackbar.Enabled = true;
            }
            else
            {
                rotateLineupTrackbar.Enabled = false;
                rotateLineupTrackbar.Value = 0;
                rotateLineupValue.Text = 0.ToString();
            }
        }

        private void lodBiasCB_CheckedChanged(object sender)
        {
            if(lodBiasCB.Checked == true)
            {
                lodBiasTrackbar.Enabled = true;
            }
            else
            {
                lodBiasTrackbar.Enabled = false;
                lodBiasTrackbar.Value = 0;
                lodBiasValue.Text = 0.ToString();
            }
        }

        private void roostFreqCB_CheckedChanged(object sender)
        {
            if(roostFreqCB.Checked == true)
            {
                roostFreqTrackbar.Enabled = true;
            }
            else
            {
                roostFreqTrackbar.Enabled = false;
                roostFreqTrackbar.Value = 0;
                roostFreqValue.Text = 0.ToString();
            }
        }

        private void detailCB_CheckedChanged(object sender)
        {
            if(detailCB.Checked == true)
            {
                detailTrackbar.Enabled = true;
            }
            else
            {
                detailTrackbar.Enabled = false;
                detailTrackbar.Value = 0;
                detailValue.Text = 0.ToString();
            }
        }

        private void updateParamlist(Boolean add, String parameter)
        {
            if(add == true)
            {
                //add to paramlist
                paramList.Add(parameter);
            }
            else
            {
                paramList.Remove(parameter);
                //remove from paramlist
            }
        }

        private void alwaysDeleteFileAfterInstallCB_CheckedChanged(object sender)
        {
            if(alwaysDeleteFileAfterInstallCB.Checked == true)
            {
                Properties.Settings.Default.alwaysDeleteFileAfterInstall = true;
                Properties.Settings.Default.Save();
                deleteFileAfterCheckbox.Checked = true;
            }
            else
            {
                Properties.Settings.Default.alwaysDeleteFileAfterInstall = false;
                Properties.Settings.Default.Save();
                deleteFileAfterCheckbox.Checked = false;
            }
        }

        private void browseMxExeLocationButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select your MX Simulator executable location";
            ofd.ShowDialog();
            mxExeLocationTextbox.Text = ofd.FileName;
            Properties.Settings.Default.mxExeLocation = ofd.FileName;
            Properties.Settings.Default.Save();
        }

        private void createNewDatabase2Button_Click(object sender, EventArgs e)
        {
            newDatabaseForm newDBform = new newDatabaseForm();
            newDBform.Show();
            Properties.Settings.Default.customDatabasesExist = true;
            Properties.Settings.Default.Save();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            databaseComboBox.Items.Clear();
            refreshCustomDatabaseList();
            foreach (String databaseEntry in vManager.getCustomDatabaseListNoExt())
            {
                if (!databaseComboBox.Items.Contains(databaseEntry))
                {
                    databaseComboBox.Items.Add(databaseEntry);
                }
            }
        }

        private void refreshButton_MouseDown(object sender, MouseEventArgs e)
        {
            refreshButton.Image = Properties.Resources.refresh_clicked;
        }

        private void refreshButton_MouseEnter(object sender, EventArgs e)
        {
            refreshButton.Image = Properties.Resources.refresh_hover;
        }

        private void refreshButton_MouseLeave(object sender, EventArgs e)
        {
            refreshButton.Image = Properties.Resources.refresh;
        }

        private void refreshButton_MouseUp(object sender, MouseEventArgs e)
        {
            refreshButton.Image = Properties.Resources.refresh_hover;
        }

        private void databaseComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (String databaseName in vManager.getCustomDatabaseListNoExt())
            {
                if ((string)databaseComboBox.SelectedItem == databaseName)
                {
                    loadModsFromCustomDatabase(true, databaseName);
                    break;
                }
            }
        }

        private void databaseExecuteButton_Click(object sender, EventArgs e)
        {
            if((string)databaseComboBox.SelectedItem == null)
            {
                MessageBox.Show("No Database Selected!", "MXSIM Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if ((string)databaseActionComboBox.SelectedItem == "Delete Database")
                {

                    databaseActionStatusLabel.Visible = true;
                    DialogResult result = MessageBox.Show("This action will delete the mod files associated with this database, do you want to continue?", "Database deletion confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.Yes)
                    {
                        SQLiteConnection customCon = null;
                        deleteMod(true, true, (string)databaseComboBox.SelectedItem, customCon, "customConnection");
                        vManager.getCustomDatabaseListNoExt().Remove((string)databaseComboBox.SelectedItem);
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        File.Delete(Directory.GetCurrentDirectory() + "\\custom_databases\\" + (string)databaseComboBox.SelectedItem + ".db");
                        databaseComboBox.Items.Remove(databaseComboBox.SelectedItem);
                        databaseModListBox.Items.Clear();
                    }
                    else
                    {

                    }
                    databaseActionStatusLabel.Visible = false;
                }
            }
        }

        private void openMxDir_Click(object sender, EventArgs e)
        {
            if(mxDirTbox.Text == "")
            {
                MessageBox.Show("Please set your MXS Directory in settings", "Couldn't open directory", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Process.Start(mxDirTbox.Text);
            }
        }
    }
}
