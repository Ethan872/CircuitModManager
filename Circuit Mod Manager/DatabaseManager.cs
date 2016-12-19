using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using NUnrar;

namespace Circuit_Mod_Manager
{
    class DatabaseManager
    {

        VariableManager vManager = new VariableManager();

        public void installMod(String modToInstall, String modType, String modExtension, XmlDocument database)
        {
            // 1) Check if database has any mods, if not create it
            // 2) Check if installing mod is in a database
            // 3) Check installing mod extension

            if (modType == "track")
            {
                //Load Track DB
                database.Load("CircuitDatabases\\trackDB.xml");
                XmlNode rootNodeTrack = database.SelectSingleNode("trackDB");

                // 1) Check if database has any mods, if not create one for the installing mod

                if (!rootNodeTrack.HasChildNodes) //No mods in database (Empty)
                { 
                    XmlElement mod = database.CreateElement("mod");
                    XmlAttribute modAttribute = database.CreateAttribute("name");
                    modAttribute.Value = modToInstall;
                    rootNodeTrack.AppendChild(mod);
                    mod.Attributes.Append(modAttribute);
                    mod.InnerText = "test";
                    database.Save("CircuitDatabases\\trackDB.xml");
                }
                else //Has mods in database
                {
                    // 2) Check if installing mod is in a database
                    XmlNodeList modList = rootNodeTrack.SelectNodes("/trackDB/mod[@name]");
                    MessageBox.Show(modList[0].Attributes[0].Value);
                    foreach (XmlNode mod in modList)
                    {
                        if(mod.Attributes[0].Value == modToInstall) //Mod exist in database
                        {
                            MessageBox.Show("Mod exists in db");
                        }
                        else //Mod doesn't exist in database, add here
                        {
                            MessageBox.Show("Mod doesn't exist, add here");   
                        }
                    }
                    database.Save("CircuitDatabases\\trackDB.xml");
                }
            }
            else if (modType == "gear")
            {
                //Load Gear DB
                // 1
                database.Load("CircuitDatabases\\gearDB.xml");
                database.Save("CircuitDatabases\\gearDB.xml");
            }
            else
            {
                MessageBox.Show("Unknown Error!", "Error 115");
            }
        }
    }
}
