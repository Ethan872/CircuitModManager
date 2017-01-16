using System;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Data.SQLite;
using NUnrar;
using SharpCompress.Archive;
using SharpCompress.Common;
using SharpCompress.Reader;
using SharpCompress.Writer;
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
        String gearConnection;
        String trackConnection;
        private void installMod(String modType, String modExtension, String modToInstallWithPath, String modToInstallWithoutPath, String mxDirectory)
        {
            if (modType == "gear")
            {
                if (modExtension == ".zip")
                {

                }
                else if (modExtension == ".rar")
                {
                    MessageBox.Show("isRar");
                    using (SQLiteConnection gearCon = new SQLiteConnection(gearConnection))
                    {
                        try
                        {
                            gearCon.Open();
                            if (gearCon.State == System.Data.ConnectionState.Open)
                            {
                                MessageBox.Show("Successfully connected to gear data base at: " + Directory.GetCurrentDirectory() + "\\gear_mods.db");
                                using (Stream stream = File.OpenRead(modToInstallWithPath))
                                {
                                    var archive = ArchiveFactory.Open(stream);
                                    foreach (var entry in archive.Entries)
                                    {
                                        if (!entry.IsDirectory)
                                        {
                                            //MessageBox.Show(entry.FilePath + " is not a dir");
                                        }
                                        else
                                        {
                                            //MessageBox.Show(entry.FilePath + " is a dir");
                                            SQLiteCommand cmd = new SQLiteCommand("INSERT INTO " + "'" + modToInstallWithoutPath + "'" + "(modFiles) VALUES (" + "'" + entry.FilePath + "'" + ");", gearCon);
                                            cmd.ExecuteNonQuery();
                                            Directory.CreateDirectory(mxDirectory + "\\" + entry.FilePath);
                                        }
                                    }
                                    stream.Close();
                                }
                                RarArchive rar = RarArchive.Open(modToInstallWithPath);
                                foreach (RarArchiveEntry e in rar.Entries)
                                {
                                    SQLiteCommand cmd = new SQLiteCommand("INSERT INTO " + "'" + modToInstallWithoutPath + "'" + "(modFiles) VALUES (" + "'" + e.FilePath + "'" + ");", gearCon);
                                    cmd.ExecuteNonQuery();
                                    e.ExtractToFile(mxDirectory + "\\" + e.FilePath);
                                }
                            }
                            gearCon.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                else if (modExtension == ".saf")
                {
                    MessageBox.Show("isSAf");
                    //Add to database
                    using (SQLiteConnection gearCon = new SQLiteConnection(gearConnection))
                    {
                        try
                        {
                            gearCon.Open();
                            if (gearCon.State == System.Data.ConnectionState.Open)
                            {
                                MessageBox.Show("Successfully connected to gear data base at: " + Directory.GetCurrentDirectory() + "\\gear_mods.db");
                                SQLiteCommand cmd = new SQLiteCommand("INSERT INTO " + "'" + modToInstallWithoutPath + "'" + "(modFiles) VALUES (" + "'" + modToInstallWithoutPath + "'" + ");", gearCon);
                                cmd.ExecuteNonQuery();
                                File.Move(modToInstallWithPath, mxDirectory + "\\" + modToInstallWithoutPath);
                            }
                            gearCon.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            else if(modType == "track")
            {
                if (modExtension == ".zip")
                {

                }
                else if (modExtension == ".rar")
                {
                    MessageBox.Show("isRar");
                    using (SQLiteConnection trackCon = new SQLiteConnection(trackConnection))
                    {
                        try
                        {
                            trackCon.Open();
                            if (trackCon.State == System.Data.ConnectionState.Open)
                            {
                                MessageBox.Show("Successfully connected to track database");
                                using (Stream stream = File.OpenRead(modToInstallWithPath))
                                {
                                    var archive = ArchiveFactory.Open(stream);
                                    foreach (var entry in archive.Entries)
                                    {
                                        if (!entry.IsDirectory)
                                        {
                                            //MessageBox.Show(entry.FilePath + " is not a dir");
                                        }
                                        else
                                        {
                                            //MessageBox.Show(entry.FilePath + " is a dir");
                                            SQLiteCommand cmd = new SQLiteCommand("INSERT INTO " + "'" + modToInstallWithoutPath + "'" + "(modFiles) VALUES (" + "'" + entry.FilePath + "'" + ");", trackCon);
                                            cmd.ExecuteNonQuery();
                                            Directory.CreateDirectory(mxDirectory + "\\" + entry.FilePath);
                                        }
                                    }
                                    stream.Close();
                                }
                                RarArchive rar = RarArchive.Open(modToInstallWithPath);
                                foreach (RarArchiveEntry e in rar.Entries)
                                {
                                    SQLiteCommand cmd = new SQLiteCommand("INSERT INTO " + "'" + modToInstallWithoutPath + "'" + "(modFiles) VALUES (" + "'" + e.FilePath + "'" + ");", trackCon);
                                    cmd.ExecuteNonQuery();
                                    e.ExtractToFile(mxDirectory + "\\" + e.FilePath);
                                }
                            }
                            trackCon.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                else if (modExtension == ".saf")
                {
                    MessageBox.Show("isSAf");
                    //Add to database
                    using (SQLiteConnection trackCon = new SQLiteConnection(trackConnection))
                    {
                        try
                        {
                            trackCon.Open();
                            if (trackCon.State == System.Data.ConnectionState.Open)
                            {
                                MessageBox.Show("Successfully connected to track database");
                                //Check if mod exists in database
                                SQLiteCommand cmd = new SQLiteCommand("INSERT INTO " + "'" + modToInstallWithoutPath + "'" + "(modFiles) VALUES (" + "'"  + modToInstallWithoutPath + "'" + ");", trackCon);
                                cmd.ExecuteNonQuery();
                                File.Move(modToInstallWithPath, mxDirectory + "\\" + modToInstallWithoutPath);
                            }
                            trackCon.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            else
            {

            }

        }
        public void StartInstallProcess(String modToInstall, String modToInstallWithPath, String modType, String modExtension, String mxDir)
        {
            if (modType == "gear")
            {
                gearConnection = "Data Source=" + Directory.GetCurrentDirectory() + "\\gear_mods.db;version=3;";
                using (SQLiteConnection gearCon = new SQLiteConnection(gearConnection))
                {
                    try
                    {
                        gearCon.Open();
                        if (gearCon.State == System.Data.ConnectionState.Open)
                        {
                            MessageBox.Show("Successfully connected to gear data base at: " + Directory.GetCurrentDirectory() + "\\gear_mods.db");
                            //Check if mod exists in database
                            SQLiteCommand cmd = new SQLiteCommand("CREATE TABLE IF NOT EXISTS " + "'" + modToInstall + "'" + "(modName TEXT, modFiles TEXT);", gearCon);
                            cmd.ExecuteNonQuery();
                            installMod(modType, modExtension, modToInstallWithPath, modToInstall, mxDir);
                        }
                        gearCon.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else if(modType == "track")
            {
                trackConnection = "Data Source=" + Directory.GetCurrentDirectory() + "\\track_mods.db;version=3;";
                using (SQLiteConnection trackCon = new SQLiteConnection(trackConnection))
                {
                    try
                    {
                        trackCon.Open();
                        if (trackCon.State == System.Data.ConnectionState.Open)
                        {
                            MessageBox.Show("Successfully connected to track database");
                            //Check if mod exists in database
                            SQLiteCommand cmd = new SQLiteCommand("CREATE TABLE IF NOT EXISTS " + "'" + modToInstall + "'" + "(modName TEXT, modFiles TEXT);", trackCon);
                            cmd.ExecuteNonQuery();
                            installMod(modType, modExtension, modToInstallWithPath, modToInstall, mxDir);
                        }
                        trackCon.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Unknown Error!", "Error 115");
            }
        }
    }
}