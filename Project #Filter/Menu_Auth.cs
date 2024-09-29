using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project__Filter
{
    public partial class Menu_Auth : UserControl
    {
        public Menu_Auth()
        {
            InitializeComponent();
        }

        private void Menu_Auth_Load(object sender, EventArgs e)
        {
            while (true)
            {
                if (!File.Exists("Config_Permissions.json"))
                {
                    // Create the JSON object
                    var jsonContent = new JObject(
                         new JProperty("Option", new JObject(
                             new JProperty("Readable", true),
                             new JProperty("Writable", false),
                             new JProperty("Executable", false)
                         ))
                     );

                    // Save to a file (e.g., "Extensions.json")
                    File.WriteAllText("Config_Permissions.json", jsonContent.ToString());
                }

                string filePath = Path.GetFullPath("Config_Permissions.json");
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
                    bool isReadable = jsonObject["Option"]["Readable"]?.ToObject<bool>() ?? false;
                    bool isWritable = jsonObject["Option"]["Writable"]?.ToObject<bool>() ?? false;
                    bool isExecutable = jsonObject["Option"]["Executable"]?.ToObject<bool>() ?? false;

                    if (isReadable)
                    {
                        radioButton_Readable.Checked = true; // Assuming this is the radio button for "Alphabetically"
                    }
                    else if (isWritable)
                    {
                        radioButton_Writable.Checked = true; // Assuming this is the radio button for "AlphabeticallyExtension"
                    }
                    else if (isExecutable)
                    {
                        radioButton_Executable.Checked = true; // Assuming this is the radio button for "AlphabeticallyExtension"
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
                    ["Readable"] = radioButton_Readable.Checked,
                    ["Writable"] = radioButton_Writable.Checked,
                    ["Executable"] = radioButton_Executable.Checked
                }
            };

            // Define the path to the JSON file
            string filePath = "Config_Permissions.json";

            // Write the JSON object to the file
            File.WriteAllText(filePath, jsonObject.ToString());

            // Optionally, show a message to indicate that the file was saved
            MessageBox.Show("Configuration saved successfully!", "Save Config", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
