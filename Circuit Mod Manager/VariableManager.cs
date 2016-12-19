using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Circuit_Mod_Manager
{
    class VariableManager
    {
        //Variable declaration
        public String installingMod = null;
        public String installingModWithoutPath = null;
        public String installingModExtension = null;
        public String mxDirectory = null;
        public XmlDocument loadedDatabase = null;

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
        public XmlDocument getLoadedDatabase()
        {
            loadedDatabase = new XmlDocument();
            return loadedDatabase;
        }
    }
}
