using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            MessageBox.Show("File: " + vManager.getInstallingMod());
            MessageBox.Show("File without path: " + vManager.getInstallingModWithoutPath());
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
                    dbManager.installMod(vManager.getInstallingModWithoutPath(), "track", vManager.getInstallingModExtension(), vManager.getLoadedDatabase());
                }
                else if (gearRadioButton.Checked == true)
                {
                    dbManager.installMod(vManager.getInstallingModWithoutPath(), "gear", vManager.getInstallingModExtension(), vManager.getLoadedDatabase());
                }
            }
        }
    }
}
