using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circuit_Mod_Manager
{
    class CustomDatabaseHandler
    {

        public ArrayList customDatabaseArray = new ArrayList();

        public Boolean doCustomDatabasesExist()
        {
            if (Directory.GetFiles("custom_databases", "*.db").Length == 0)
            {
                //NO DATABASE FILES IN CUSTOM DATABASES FOLDER
                return false;
            }
            else
            {
                //DATABASE FILES EXIST IN CUSTOM DATABASES FOLDER
                return true;
            }
        }

        public void reloadDatabaseArray()
        {
            String newDatabaseName = null;
            foreach (String databaseName in Directory.GetFiles("custom_databases", "*.db"))
            {
                if(!File.Exists(databaseName))
                {
                    System.Windows.Forms.MessageBox.Show("File: " + databaseName + " doesn't exist!!!!!!");
                }
                else
                {
                    newDatabaseName = Path.GetFileNameWithoutExtension(databaseName);
                    if (customDatabaseArray.Contains(newDatabaseName))
                    {
                        //Do Nothing
                    }
                    else
                    {
                        customDatabaseArray.Add(newDatabaseName);
                    }
                }
            }
        }

        public ArrayList getCustomDatabases()
        {
            return customDatabaseArray;
        }

        public void addDatabaseToArray(String databaseNameToAdd)
        {
            if(customDatabaseArray.Contains(databaseNameToAdd))
            {
                System.Windows.Forms.MessageBox.Show("Database: " + databaseNameToAdd + " already exists in array");
            }
            else
            {
                customDatabaseArray.Add(databaseNameToAdd);
            }
        }

        public void removeDatabaseFromArray(String databaseNameToRemove)
        {
            if(!customDatabaseArray.Contains(databaseNameToRemove))
            {
                System.Windows.Forms.MessageBox.Show("Database: " + databaseNameToRemove + " doesn't exist, can't remove");
            }
            else
            {
                customDatabaseArray.Remove(databaseNameToRemove);
            }
        }
    }
}
