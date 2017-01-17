using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
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
    class VariableManager
    {
        //Variable declaration
        public String installingMod = null;
        public String installingModWithoutPath = null;
        public String installingModExtension = null;
        public String mxDirectory = null;
        public String backupModName = null;

        //Getters and Setters
        public String getInstallingMod()
        {
            return installingMod;
        }
        public void setInstallingMod(String mod)
        {
            installingMod = mod;
        }
        public String getInstallingModWithoutPath()
        {
            return installingModWithoutPath;
        }
        public void setInstallingModWithoutPath(String modWithoutPath)
        {
            installingModWithoutPath = modWithoutPath;
        }
        public String getInstallingModExtension()
        {
            String extension = Path.GetExtension(installingMod);
            return extension;
        }
        public String getMxDirectory()
        {
            return mxDirectory;
        }
        public void setMxDirectory(String directory)
        {
            mxDirectory = directory;
        }
        public String getbackupModName()
        {
            return backupModName;
        }
        public void setBackupModName(String name)
        {
            backupModName = name;
        }
    }
}
