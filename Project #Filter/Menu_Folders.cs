using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Project__Filter
{
    public partial class Menu_Folders : UserControl
    {
        // Make myDict a field so it's accessible in both methods
        private Dictionary<string, List<string>> myDict;

        public Menu_Folders()
        {
            InitializeComponent();
        }

        private void Config_Load(object sender, EventArgs e)
        {
            if (File.Exists("Folders.json"))
            {
                // Read the JSON file
                string json = File.ReadAllText("Folders.json");

                // Deserialize the JSON into a dictionary
                myDict = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(json);

                // Populate the folder list with the keys from the dictionary
                foreach (var key in myDict.Keys)
                {
                    // Add the key to the folder list
                    listBox_Folders.Items.Add(key);
                }
            }
        }

        private void listBox_Folders_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear the extension list
            listBox_Extension.Items.Clear();

            // Check if an item is selected in the listBox_Folders
            if (listBox_Folders.SelectedItem != null)
            {
                // Get the selected key
                string selectedKey = listBox_Folders.SelectedItem.ToString();

                // Check if the selected key exists in the dictionary
                if (myDict.ContainsKey(selectedKey))
                {
                    // Get the list of extensions for the selected key
                    List<string> extensions = myDict[selectedKey];

                    // Populate the extension list with the extensions
                    foreach (var extension in extensions)
                    {
                        listBox_Extension.Items.Add(extension);
                    }
                }
            }
        }

        private void button_Add_Click_1(object sender, EventArgs e)
        {
            // Get the new item from the text box
            string newItem = Interaction.InputBox("Please enter the new item:", "New Item", "", -1, -1).ToLower().Trim();

            if (radioButton_Folder.Checked)
            {
                // The new item is a folder, so add it as a new key to the dictionary
                if (!myDict.ContainsKey(newItem))
                {
                    myDict[newItem] = new List<string>();
                    listBox_Folders.Items.Add(newItem);
                }
            }
            else if (radioButton_Extension.Checked)
            {
                // The new item is an extension, so add it to the list for the selected folder
                string selectedFolder = listBox_Folders.SelectedItem.ToString();
                if (!myDict[selectedFolder].Contains(newItem))
                {
                    myDict[selectedFolder].Add(newItem);
                    listBox_Extension.Items.Clear();
                    foreach (var extension in myDict[selectedFolder])
                    {
                        listBox_Extension.Items.Add(extension);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select one of the options.", "Option Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Serialize the dictionary back into JSON
            string json = JsonConvert.SerializeObject(myDict, Formatting.Indented);

            // Write the JSON back to the file
            File.WriteAllText("Folders.json", json);
        }

        private void button_Remove_Click_1(object sender, EventArgs e)
        {
            if (radioButton_Folder.Checked)
            {
                // The item to remove is a folder, so remove it from the dictionary
                string selectedFolder = listBox_Folders.SelectedItem.ToString();
                if (myDict.ContainsKey(selectedFolder))
                {
                    myDict.Remove(selectedFolder);
                    listBox_Folders.Items.Remove(selectedFolder);
                    listBox_Extension.Items.Clear();
                }
            }
            else if (radioButton_Extension.Checked)
            {
                // The item to remove is an extension, so remove it from the list for the selected folder
                string selectedFolder = listBox_Folders.SelectedItem.ToString();
                string selectedExtension = listBox_Extension.SelectedItem.ToString();
                if (myDict[selectedFolder].Contains(selectedExtension))
                {
                    myDict[selectedFolder].Remove(selectedExtension);
                    listBox_Extension.Items.Remove(selectedExtension);
                }
            }

            // Serialize the dictionary back into JSON
            string json = JsonConvert.SerializeObject(myDict, Formatting.Indented);

            // Write the JSON back to the file
            File.WriteAllText("Folders.json", json);
        }
    }
}
