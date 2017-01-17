using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SQLite;
using System.Linq;
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

        DatabaseManager dbManager = new DatabaseManager();
        StartupRoutine sr = new StartupRoutine();
        VariableManager vManager = new VariableManager();
        String gearConnection;
        String trackConnection;
        String bikeConnection;

        public Form1()
        {
            InitializeComponent();
            sr.CheckCircuitData();
            mxDirTbox.Text = sr.CheckMXdir();
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
                    dbManager.StartInstallProcess(vManager.getInstallingModWithoutPath(), vManager.getInstallingMod(), "track", vManager.getInstallingModExtension(), mxDirTbox.Text);
                }
                else if (gearRadioButton.Checked == true)
                {
                    dbManager.StartInstallProcess(vManager.getInstallingModWithoutPath(), vManager.getInstallingMod(), "gear", vManager.getInstallingModExtension(), mxDirTbox.Text);
                }
                else if (bikeRadioButton.Checked == true)
                {
                    dbManager.StartInstallProcess(vManager.getInstallingModWithoutPath(), vManager.getInstallingMod(), "bike", vManager.getInstallingModExtension(), mxDirTbox.Text);
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
            if(installerRadioButton.Checked == true)
            {
                sw.WriteLine("default_screen=installer");
            } else if (ManagerRadioButton.Checked == true)
            {
                sw.WriteLine("default_screen=manager");
            } else if (SettingsRadioButton.Checked == true)
            {
                sw.WriteLine("default_screen=settings");
            }
            sw.Close();
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

        private void installerPage_Click(object sender, EventArgs e)
        {

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
                            MessageBox.Show("Successfully connected to track data base");
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
                            MessageBox.Show("Successfully connected to gear data base at: " + Directory.GetCurrentDirectory() + "\\gear_mods.db");
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
                            MessageBox.Show("Successfully connected to bike database");
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
        }

        private void modComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)filterModComboBox.SelectedItem == "Track")
            {
                MessageBox.Show("Showing Track Mods");
                modListBox.Items.Clear();
                trackConnection = "Data Source=" + Directory.GetCurrentDirectory() + "\\track_mods.db;version=3;";
                using (SQLiteConnection trackCon = new SQLiteConnection(trackConnection))
                {
                    try
                    {
                        trackCon.Open();
                        if (trackCon.State == System.Data.ConnectionState.Open)
                        {
                            MessageBox.Show("Successfully connected");
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
                MessageBox.Show("Showing Gear Mods files for: " + modComboBox.SelectedItem.ToString());
                modListBox.Items.Clear();
                gearConnection = "Data Source=" + Directory.GetCurrentDirectory() + "\\gear_mods.db;version=3;";
                using (SQLiteConnection gearCon = new SQLiteConnection(gearConnection))
                {
                    try
                    {
                        gearCon.Open();
                        if (gearCon.State == System.Data.ConnectionState.Open)
                        {
                            MessageBox.Show("Successfully connected");
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
                MessageBox.Show("Showing Bike Mods files for: " + modComboBox.SelectedItem.ToString());
                modListBox.Items.Clear();
                bikeConnection = "Data Source=" + Directory.GetCurrentDirectory() + "\\bike_mods.db;version=3;";
                using (SQLiteConnection bikeCon = new SQLiteConnection(bikeConnection))
                {
                    try
                    {
                        bikeCon.Open();
                        if (bikeCon.State == System.Data.ConnectionState.Open)
                        {
                            MessageBox.Show("Successfully connected");
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
        }

        private void executeActionButton_Click(object sender, EventArgs e)
        {
            if((string)modComboBox.SelectedItem == null)
            {
                MessageBox.Show("No mod selected", "MXSIM:MM", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if ((string)actionComboBox.SelectedItem == "Clear Database")
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
                                    MessageBox.Show("Removed " + (string)modComboBox.SelectedItem + " from gear database");
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
                        MessageBox.Show("Cleared Track Database");
                    }
                }
                else if((string)actionComboBox.SelectedItem == "Delete Mod")
                {
                    
                    if (gearDatabaseStatusLabel.Text == "Loaded")
                    {
                        gearConnection = "Data Source=" + Directory.GetCurrentDirectory() + "\\gear_mods.db;version=3;";
                        using (SQLiteConnection gearCon = new SQLiteConnection(gearConnection))
                        {
                            try
                            {
                                gearCon.Open();
                                if (gearCon.State == System.Data.ConnectionState.Open)
                                {
                                    SQLiteCommand cmd = new SQLiteCommand("DROP TABLE " + "'" + (string)modComboBox.SelectedItem + "'", gearCon);
                                    cmd.ExecuteNonQuery();
                                    
                                    for(int counter = 0; counter < modListBox.Items.Count; counter++)
                                    {
                                        MessageBox.Show(modListBox.Items[counter].ToString());
                                        File.Delete(mxDirTbox.Text + "\\" + modListBox.Items[counter].ToString());
                                    }
                                    modListBox.Items.Clear();
                                    modComboBox.Items.Remove(modComboBox.SelectedItem);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            gearCon.Close();
                        }
                    }
                    else if(trackDatabaseStatusLabel.Text == "Loaded")
                    {
                        trackConnection = "Data Source=" + Directory.GetCurrentDirectory() + "\\track_mods.db;version=3;";
                        using (SQLiteConnection trackCon = new SQLiteConnection(trackConnection))
                        {
                            try
                            {
                                trackCon.Open();
                                if (trackCon.State == System.Data.ConnectionState.Open)
                                {
                                    SQLiteCommand cmd = new SQLiteCommand("DROP TABLE " + "'" + (string)modComboBox.SelectedItem + "'", trackCon);
                                    cmd.ExecuteNonQuery();
                                    for (int counter = 0; counter < modListBox.Items.Count; counter++)
                                    {
                                        if (File.Exists(mxDirTbox.Text + "\\" + modListBox.Items[counter].ToString()))
                                        {
                                            File.Delete(mxDirTbox.Text + "\\" + modListBox.Items[counter].ToString());
                                        }
                                        if(Directory.Exists(mxDirTbox.Text + "\\" + modListBox.Items[counter].ToString()))
                                        {
                                            Directory.Delete(mxDirTbox.Text + "\\" + modListBox.Items[counter].ToString(), true);
                                        }
                                    }
                                    modListBox.Items.Clear();
                                    modComboBox.Items.Remove(modComboBox.SelectedItem);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            trackCon.Close();
                        }
                    }
                    else if(bikeDatabaseStatusLabel.Text == "Loaded")
                    {
                        bikeConnection = "Data Source=" + Directory.GetCurrentDirectory() + "\\bike_mods.db;version=3;";
                        using (SQLiteConnection bikeCon = new SQLiteConnection(bikeConnection))
                        {
                            try
                            {
                                bikeCon.Open();
                                if (bikeCon.State == System.Data.ConnectionState.Open)
                                {
                                    SQLiteCommand cmd = new SQLiteCommand("DROP TABLE " + "'" + (string)modComboBox.SelectedItem + "'", bikeCon);
                                    cmd.ExecuteNonQuery();

                                    for (int counter = 0; counter < modListBox.Items.Count; counter++)
                                    {
                                        MessageBox.Show(modListBox.Items[counter].ToString());
                                        File.Delete(mxDirTbox.Text + "\\" + modListBox.Items[counter].ToString());
                                    }
                                    modListBox.Items.Clear();
                                    modComboBox.Items.Remove(modComboBox.SelectedItem);
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
                else if((string)actionComboBox.SelectedItem == "Delete Selected Files")
                {
                    if (gearDatabaseStatusLabel.Text == "Loaded")
                    {
                        gearConnection = "Data Source=" + Directory.GetCurrentDirectory() + "\\gear_mods.db;version=3;";
                        using (SQLiteConnection gearCon = new SQLiteConnection(gearConnection))
                        {
                            try
                            {
                                gearCon.Open();
                                if (gearCon.State == System.Data.ConnectionState.Open)
                                {
                                    for(int counter = 0; counter < modListBox.CheckedItems.Count; counter++)
                                    {
                                        SQLiteCommand cmd = new SQLiteCommand("DELETE FROM " + "'" + (string)modComboBox.SelectedItem + "'" + " WHERE modFiles = " + "'" + modListBox.CheckedItems[counter].ToString() + "';", gearCon);
                                        cmd.ExecuteNonQuery();
                                    }
                                    for (int counter = 0; counter < modListBox.CheckedItems.Count; counter++)
                                    {
                                        MessageBox.Show(modListBox.CheckedItems[counter].ToString());
                                        File.Delete(mxDirTbox.Text + "\\" + modListBox.CheckedItems[counter].ToString());
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
                            gearCon.Close();
                        }
                    }
                    else if(trackDatabaseStatusLabel.Text == "Loaded")
                    {
                        trackConnection = "Data Source=" + Directory.GetCurrentDirectory() + "\\track_mods.db;version=3;";
                        using (SQLiteConnection trackCon = new SQLiteConnection(trackConnection))
                        {
                            try
                            {
                                trackCon.Open();
                                if (trackCon.State == System.Data.ConnectionState.Open)
                                {
                                    for (int counter = 0; counter < modListBox.CheckedItems.Count; counter++)
                                    {
                                        SQLiteCommand cmd = new SQLiteCommand("DELETE FROM " + "'" + (string)modComboBox.SelectedItem + "'" + " WHERE modFiles = " + "'" + modListBox.CheckedItems[counter].ToString() + "';", trackCon);
                                        cmd.ExecuteNonQuery();
                                    }
                                    for (int counter = 0; counter < modListBox.CheckedItems.Count; counter++)
                                    {
                                        MessageBox.Show(modListBox.CheckedItems[counter].ToString());
                                        File.Delete(mxDirTbox.Text + "\\" + modListBox.CheckedItems[counter].ToString());
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
                            trackCon.Close();
                        }
                    }
                    else if(bikeDatabaseStatusLabel.Text == "Loaded")
                    {
                        bikeConnection = "Data Source=" + Directory.GetCurrentDirectory() + "\\bike_mods.db;version=3;";
                        using (SQLiteConnection bikeCon = new SQLiteConnection(bikeConnection))
                        {
                            try
                            {
                                bikeCon.Open();
                                if (bikeCon.State == System.Data.ConnectionState.Open)
                                {
                                    for (int counter = 0; counter < modListBox.CheckedItems.Count; counter++)
                                    {
                                        SQLiteCommand cmd = new SQLiteCommand("DELETE FROM " + "'" + (string)modComboBox.SelectedItem + "'" + " WHERE modFiles = " + "'" + modListBox.CheckedItems[counter].ToString() + "';", bikeCon);
                                        cmd.ExecuteNonQuery();
                                    }
                                    for (int counter = 0; counter < modListBox.CheckedItems.Count; counter++)
                                    {
                                        MessageBox.Show(modListBox.CheckedItems[counter].ToString());
                                        File.Delete(mxDirTbox.Text + "\\" + modListBox.CheckedItems[counter].ToString());
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
                            bikeCon.Close();
                        }
                    }
                }
            }
        }
    }
}
