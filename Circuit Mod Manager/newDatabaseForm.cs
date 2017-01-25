using System;
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
    public partial class newDatabaseForm : Form
    {

        CustomDatabaseHandler cdbHandler = new CustomDatabaseHandler();
        public newDatabaseForm()
        {
            InitializeComponent();
        }
        

        private void createDatabaseButton_Click(object sender, EventArgs e)
        {
            try
            {
                if(!System.IO.Directory.Exists("custom_databases"))
                {
                    System.IO.Directory.CreateDirectory("custom_databases");
                }
                else
                {
                    
                }
                System.IO.File.Create("custom_databases\\" + databaseNameTextbox.Text + ".db").Close();
                cdbHandler.reloadDatabaseArray();
                MessageBox.Show("Successfully created your custom database!", databaseNameTextbox.Text + " Created!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Hide();
            }
            catch(System.IO.IOException dbCreationException)
            {
                MessageBox.Show(dbCreationException.Message);
                Hide();
            }
            
            
        }

        private void closeNewDatabaseFormButton_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
