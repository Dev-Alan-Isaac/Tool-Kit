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
                bool isReadable = jsonObject["Auth"]["Readable"]?.ToObject<bool>() ?? false;
                bool isWritable = jsonObject["Auth"]["Writable"]?.ToObject<bool>() ?? false;
                bool isExecutable = jsonObject["Auth"]["Executable"]?.ToObject<bool>() ?? false;

                if (isReadable)
                {
                    radioButton_Readable.Checked = isReadable; 
                }
                else if (isWritable)
                {
                    radioButton_Writable.Checked = isWritable; 
                }
                else if (isExecutable)
                {
                    radioButton_Executable.Checked = isExecutable;
                }
            }
        }

        private void button_Saved_Click(object sender, EventArgs e)
        {
            // Define the path to the JSON file
            string filePath = "Config_Sort.json";

            // Load the JSON file
            JObject jsonObject;
            if (File.Exists(filePath))
            {
                jsonObject = JObject.Parse(File.ReadAllText(filePath));
            }
            else
            {
                MessageBox.Show("Configuration file not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            jsonObject["Auth"]["Accessed"] = radioButton_Readable.Checked;
            jsonObject["Auth"]["Creation"] = radioButton_Writable.Checked;
            jsonObject["Auth"]["Modified"] = radioButton_Executable.Checked;

            // Write the modified JSON object back to the file
            File.WriteAllText(filePath, jsonObject.ToString(Formatting.Indented));

            // Show a message to indicate that the file was saved
            MessageBox.Show("Configuration saved successfully!", "Save Config", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
