using System;
using System.Windows.Forms;
using System.Xml;
using SharpCompress.Archive.Rar;
using SharpCompress.Reader.Rar;
using System.IO;
using SharpCompress.Archive;
using SharpCompress.Common;
#region License
/*
Circuit Manager Source Code File
By Ethan87
All rights reserved.

"Author" and "Ethan87" refer to Ethan Jaramillo.
"Software" refers to all files included within this repository and those created during program runtime.
"Licensee" and "you" refer to the recipient of this Software.

Except where otherwise noted, all copyrights are exclusively owned by the Author.

BY USING AND OR EDITING THIS SOURCE FILE (OR ANY WORK BASED ON THE SOURCE FILE), YOU INDICATE YOUR ACCEPTANCE OF THIS LICENSE TO DO SO, AND ALL ITS TERMS AND CONDITIONS FOR USING THE SOURCE FILE AND OR WORKS BASED ON IT. NOTHING OTHER THAN THIS LICENSE GRANTS YOU PERMISSION TO EDIT OR USE THIS SOURCE FILE OR ITS DERIVATIVE WORKS. THESE ACTIONS ARE PROHIBITED BY LAW. IF YOU DO NOT ACCEPT THESE TERMS AND CONDITIONS, DO NOT USE THE SOURCE FILE.
Licenses

Licensor hereby grants you the following rights, provided that you comply with all of the restrictions set forth in this License and provided.

Permission is granted to use the file for non-commercial purposes.

Restrictions
You may not copy and distribute copies of the source file or Software as you receive it throughout the world, in any medium.
You may not create works based on/using the source file and or Software and distribute copies of such throughout the world, in any medium.
You may not remove any comment lines from the source file that may contain material such as credits, release version, or developer name/website.
You may not sell, create and or distribute a paid version of the source file or any file within this repository

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
    class DatabaseManager
    {

        VariableManager vManager = new VariableManager();

        private bool CheckDatabases(String whichDatabase, XmlDocument database, String modToInstall)
        {
            if (whichDatabase == "track")
            {
                XmlNodeList xnList = database.SelectNodes("/trackDB/mod");
                foreach (XmlNode xn in xnList)
                {
                    if (xn.InnerText != modToInstall)
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
        private void AddModToDB(String whichDatabase, XmlDocument database, String modToInstall)
        {
            if (whichDatabase == "track")
            {
                XmlNode rootNode = database.DocumentElement;
                XmlElement mod = database.CreateElement("mod");
                //XmlAttribute modAttribute = database.CreateAttribute("name");
                //modAttribute.Value = modToInstall;
                rootNode.AppendChild(mod);
                //mod.Attributes.Append(modAttribute);
                mod.InnerText = modToInstall;
                database.Save("PinnedDatabases\\trackDB.xml");
            }
        }
        private void installMod(String modExtension, String whichDatabase, XmlDocument database, String modToInstallWithPath, String mxDirectory)
        {
            if (whichDatabase == "track")
            {
                if (modExtension == ".zip")
                {

                }
                else if (modExtension == ".rar")
                {
                    var archive = ArchiveFactory.Open(modToInstallWithPath);
                    foreach (var entry in archive.Entries)
                    {
                        if (!entry.IsDirectory)
                        {
                            try
                            {
                                MessageBox.Show("entry: " + entry.FilePath);
                                entry.WriteToDirectory(mxDirectory, ExtractOptions.ExtractFullPath | ExtractOptions.Overwrite);
                            }
                            catch (ArgumentException e)
                            {
                                MessageBox.Show("An error occurred, make sure your MX Simulator directory is set!", "Error RAR install", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            
                        }
                    }
                }
            }
        }
        public void StartInstallProcess(String modToInstall, String modToInstallWithPath, String modType, String modExtension, XmlDocument database, String mxDir)
        {
            // 1) Check if database has any mods, if not create it
            // 2) Check if installing mod is in a database
            // 3) Check installing mod extension
            if (modType == "track")
            {
                //Load Track DB
                if (!File.Exists("PinnedDatabases\\trackDB.xml"))
                {
                    MessageBox.Show("Track Database doesn't exist, will create one now", "No track database on disk", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    File.Create("PinnedDatabases\\trackDB.xml").Close();
                }
                else
                {
                    database.Load("PinnedDatabases\\trackDB.xml");
                }
                
                XmlNode rootNodeTrack = database.DocumentElement;

                // 1) Check if database has any mods, if not create one for the installing mod

                if (rootNodeTrack.HasChildNodes) //No mods in database (Empty)
                {
                    if (CheckDatabases("track", database, modToInstall)) //Mod doesn't exist
                    {
                        AddModToDB("track", database, modToInstall);
                        MessageBox.Show("Don't exist");
                        if(modExtension == ".rar")
                        {
                            MessageBox.Show("IsRar");
                            installMod(".rar", "track", database, modToInstallWithPath, mxDir);
                        }
                        else if(modExtension == ".zip")
                        {
                            MessageBox.Show("isZip");
                        }
                    }
                    else
                    {
                        MessageBox.Show("That mod already exists within the track database", "Mod Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    database.Save("PinnedDatabases\\trackDB.xml");
                    
                }
                else //Has mods in database
                {
                    AddModToDB("track", database, modToInstall);
                }
            }
            else
            {
                MessageBox.Show("Unknown Error!", "Error 115");
            }
        }
    }
}