using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
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
                    dbManager.StartInstallProcess(vManager.getInstallingModWithoutPath(), vManager.getInstallingMod(), "track", vManager.getInstallingModExtension(), vManager.getLoadedDatabase(), mxDirTbox.Text);
                }
                else if (gearRadioButton.Checked == true)
                {
                    dbManager.StartInstallProcess(vManager.getInstallingModWithoutPath(), vManager.getInstallingMod(), "gear", vManager.getInstallingModExtension(), vManager.getLoadedDatabase(), mxDirTbox.Text);
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
    }
}
