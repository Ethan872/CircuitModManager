using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Circuit_Mod_Manager
{
    class StartupRoutine
    {

        VariableManager vManager = new VariableManager();

        public void CheckCircuitData()
        {
            //Check if mx dir settings exist
            if(!File.Exists("mxdir.txt"))
            {
                MessageBox.Show("MX Simulator game folder not found, please select one", "Circuit Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //Check if mxdir.txt contains anything
                String line = null;
                try
                {
                    using (StreamReader streamReader = new StreamReader("mxdir.txt"))
                    {
                        line = streamReader.ReadLine();
                        streamReader.Close();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error reading settings!", "Error 0100", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show(e.Message);
                }
                if(line == null)
                {
                    MessageBox.Show("MX Simulator game folder not found, please select one", "Circuit Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            if(!Directory.Exists("CircuitDatabases") || !File.Exists("CircuitDatabases\\trackDB.xml") || !File.Exists("CircuitDatabases\\gearDB.xml"))
            {
                Directory.CreateDirectory("CircuitDatabases");
                File.Create("CircuitDatabases\\trackDB.xml").Close();
                File.Create("CircuitDatabases\\gearDB.xml").Close();
                //Create base xml nodes for track database
                XmlDocument trackDB = vManager.getLoadedDatabase();
                XmlElement rootElementTrack = trackDB.CreateElement("trackDB");
                trackDB.AppendChild(rootElementTrack);
                trackDB.Save("CircuitDatabases\\trackDB.xml");
                //Create base xml nodes for gear database
                XmlDocument gearDB = vManager.getLoadedDatabase();
                XmlElement rootElementGear = gearDB.CreateElement("gearDB");
                gearDB.AppendChild(rootElementGear);
                gearDB.Save("CircuitDatabases\\gearDB.xml");
            }
            else
            {
                //Do nothing
            }
        }
    }
}
