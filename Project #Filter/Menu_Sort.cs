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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Project__Filter
{
    public partial class Menu_Sort : UserControl
    {
        public Menu_Sort()
        {
            InitializeComponent();
        }

        private void Menu_Sort_Load(object sender, EventArgs e)
        {
            while (true)
            {
                if (!File.Exists("Config_Sort.json"))
                {
                    // Create the JSON object
                    var jsonContent = new JObject(
                         new JProperty("Option", new JObject(
                             new JProperty("Delete", true),
                             new JProperty("Subfolder", false)
                         ))
                    );

                    // Save to a file (e.g., "Extensions.json")
                    File.WriteAllText("Config_Sort.json", jsonContent.ToString());
                }

                // File already exists; get the filepath
                string filePath = Path.GetFullPath("Config_Sort.json");
                PopulateInputs(filePath);
                break;
            }
        }

        private void PopulateInputs(string FilePath)
        {
            if (File.Exists(FilePath))
            {
                // Read the JSON content from the file
                string jsonContent = File.ReadAllText(FilePath);

                // Deserialize the JSON content into a JObject
                var jsonObject = JsonConvert.DeserializeObject<JObject>(jsonContent);

                // Access the "Allow" object inside the JSON
                var extensionsObject = jsonObject["Option"] as JObject;

                if (extensionsObject != null)
                {
                    // Update checkboxes based on JSON values
                    checkBox_Delete.Checked = extensionsObject["Delete"]?.Value<bool>() ?? false;
                    checkBox_Subfolders.Checked = extensionsObject["Subfolder"]?.Value<bool>() ?? false;
                }
            }
        }


        private void button_Saved_Click(object sender, EventArgs e)
        {
            var jsonObject = new JObject
            {
                ["Option"] = new JObject
                {
                    ["Delete"] = checkBox_Delete.Checked,
                    ["Subfolder"] = checkBox_Subfolders.Checked,
                }
            };

            // Define the path to the JSON file
            string filePath = "Config_Sort.json";

            // Write the JSON object to the file
            File.WriteAllText(filePath, jsonObject.ToString());

            // Optionally, show a message to indicate that the file was saved
            MessageBox.Show("Configuration saved successfully!", "Save Config", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
