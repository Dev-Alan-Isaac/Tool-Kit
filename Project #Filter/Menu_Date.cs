using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
                if (!File.Exists("Config_Date.json"))
                {
                    // Create the JSON object
                    var jsonContent = new JObject(
                         new JProperty("Option", new JObject(
                             new JProperty("Accessed", true),
                             new JProperty("Creation", false),
                             new JProperty("Modified", false)
                         ))
                     );

                    // Save to a file (e.g., "Extensions.json")
                    File.WriteAllText("Config_Date.json", jsonContent.ToString());
                }

                string filePath = Path.GetFullPath("Config_Date.json");
                Populate_Inputs(filePath);
                break;
            }
        }

        private void Populate_Inputs(string FilePath)
        {
            if (File.Exists(FilePath))
            {
                // Read the JSON content from the file
                string jsonContent = File.ReadAllText(FilePath);

                // Deserialize the JSON content into a JObject
                var jsonObject = JObject.Parse(jsonContent);

                // Check if the "Option" property exists
                if (jsonObject["Option"] != null)
                {
                    // Check the state of "Alphabetically" and "AlphabeticallyExtension" and set radio buttons accordingly
                    bool isAccessed = jsonObject["Option"]["Accessed"]?.ToObject<bool>() ?? false;
                    bool isCreation = jsonObject["Option"]["Creation"]?.ToObject<bool>() ?? false;
                    bool isModified = jsonObject["Option"]["Modified"]?.ToObject<bool>() ?? false;

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
