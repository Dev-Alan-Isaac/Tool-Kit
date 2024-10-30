using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Project__Filter
{
    public partial class Menu_Date : UserControl
    {
        public Menu_Date()
        {
            InitializeComponent();
        }
        private void Menu_Date_Load(object sender, EventArgs e)
        {
            while (true)
            {
                if (File.Exists("Config_Sort.json"))
                {
                    // File already exists; get the filepath
                    string filePath = Path.GetFullPath("Config_Sort.json");
                    Populate_Inputs(filePath);
                    break;
                }
            }
        }

        private void Populate_Inputs(string FilePath)
        {
            if (File.Exists(FilePath))
            {
                // Read the JSON content once
                string jsonContent = File.ReadAllText(FilePath);
                var jsonObject = JsonConvert.DeserializeObject<JObject>(jsonContent);           

                // Check the state of "Alphabetically" and "AlphabeticallyExtension" and set radio buttons accordingly
                bool isAccessed = jsonObject["Date"]["Accessed"]?.ToObject<bool>() ?? false;
                bool isCreation = jsonObject["Date"]["Creation"]?.ToObject<bool>() ?? false;
                bool isModified = jsonObject["Date"]["Modified"]?.ToObject<bool>() ?? false;

                if (isAccessed)
                {
                    radioButton_Accessed.Checked = true; // Assuming this is the radio button for "Alphabetically"
                }
                else if (isCreation)
                {
                    radioButton_Creation.Checked = true; // Assuming this is the radio button for "AlphabeticallyExtension"
                }
                else if (isModified)
                {
                    radioButton_Modified.Checked = true; // Assuming this is the radio button for "AlphabeticallyExtension"
                }
            }
        }

        private void button_Saved_Click(object sender, EventArgs e)
        {
            var jsonObject = new JObject
            {
                ["Option"] = new JObject
                {
                    ["Accessed"] = radioButton_Accessed.Checked,
                    ["Creation"] = radioButton_Creation.Checked,
                    ["Modified"] = radioButton_Modified.Checked
                }
            };

            // Define the path to the JSON file
            string filePath = "Config_Date.json";

            // Write the JSON object to the file
            File.WriteAllText(filePath, jsonObject.ToString());

            // Optionally, show a message to indicate that the file was saved
            MessageBox.Show("Configuration saved successfully!", "Save Config", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button_Saved_Click_1(object sender, EventArgs e)
        {

        }
    }
}
