using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ionic.Zip;

namespace Circuit_Mod_Manager
{
    public partial class PasswordManager : Form
    {
        private int flag = 0;

        public PasswordManager(int archiveType)
        {
            InitializeComponent();
            this.flag = archiveType;
        }

        private void submitPasswordButton_Click(object sender, EventArgs e)
        {
            if(passwordTBox.Text == "")
            {
                MessageBox.Show("Please enter the password for the mod archive");
            }
            else
            {
                if(flag == 1)
                {
                    VariableManager.zipPassword = passwordTBox.Text;
                    VariableManager.rarPassword = "";
                }
                else if (flag == 2)
                {
                    VariableManager.rarPassword = passwordTBox.Text;
                    VariableManager.zipPassword = "";
                }
                Hide();
            }
        }

        private void closePasswordManagerFormButton_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
