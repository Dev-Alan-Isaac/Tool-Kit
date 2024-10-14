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
    public partial class Menu_Extract : UserControl
    {
        public Menu_Extract()
        {
            InitializeComponent();
        }

        private void Menu_Extract_Load(object sender, EventArgs e)
        {
            while (true)
            {
                if (!File.Exists("Config_Extract.json"))
                {
                    // Create the JSON object
                    var jsonContent = new JObject(
                         new JProperty("Option", new JObject(
                             new JProperty("Delete", true),
                             new JProperty("Subfolder", true),
                             new JProperty("ByName", true),
                             new JProperty("ByHash", false),
                             new JProperty("Root", false),
                             new JProperty("Split", false),
                             new JProperty("Group", false),
                             new JProperty("RootDecompress", true),
                             new JProperty("Folder", false)
                         ))
                    );

                    // Save to a file (e.g., "Extensions.json")
                    File.WriteAllText("Config_Extract.json", jsonContent.ToString());
                }

                // File already exists; get the filepath
                string filePath = Path.GetFullPath("Config_Extract.json");
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
                    bool isDelete = jsonObject["Option"]["Delete"]?.ToObject<bool>() ?? false;
                    bool isSubfolder = jsonObject["Option"]["Subfolder"]?.ToObject<bool>() ?? false;
                    bool isName = jsonObject["Option"]["ByName"]?.ToObject<bool>() ?? false;
                    bool isHash = jsonObject["Option"]["ByHash"]?.ToObject<bool>() ?? false;
                    bool isRoot = jsonObject["Option"]["Root"]?.ToObject<bool>() ?? false;
                    bool isSplit = jsonObject["Option"]["Split"]?.ToObject<bool>() ?? false;
                    bool isGroup = jsonObject["Option"]["Group"]?.ToObject<bool>() ?? false;
                    bool isRootDecompress = jsonObject["Option"]["RootDecompress"]?.ToObject<bool>() ?? false;
                    bool isFolder = jsonObject["Option"]["Folder"]?.ToObject<bool>() ?? false;

                    checkBox_Delete.Checked = isDelete;
                    checkBox_Subfolders.Checked = isSubfolder;

                    if (isName)
                    {
                        radioButton_Name.Checked = true;
                    }
                    else if (isHash)
                    {
                        radioButton_Hash.Checked = true;
                    }

                    if (isRoot)
                    {
                        radioButton_Root.Checked = true;
                    }
                    else if (isSplit)
                    {
                        radioButton_Split.Checked = true;
                    }
                    else if (isGroup)
                    {
                        radioButton_Group.Checked = true;
                    }

                    if (isRootDecompress)
                    {
                        radioButton_RootDecompress.Checked = true;
                    }
                    else if (isFolder)
                    {
                        radioButton_Folder.Checked = true;
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
                    ["Delete"] = checkBox_Delete.Checked,
                    ["Subfolder"] = checkBox_Subfolders.Checked,
                    ["ByName"] = radioButton_Name.Checked,
                    ["ByHash"] = radioButton_Hash.Checked,
                    ["Root"] = radioButton_Root.Checked,
                    ["Split"] = radioButton_Split.Checked,
                    ["Group"] = radioButton_Group.Checked,
                    ["RootDecompress"] = radioButton_RootDecompress.Checked,
                    ["Folder"] = radioButton_Folder.Checked,
                }
            };

            // Define the path to the JSON file
            string filePath = "Config_Extract.json";

            // Write the JSON object to the file
            File.WriteAllText(filePath, jsonObject.ToString());

            // Optionally, show a message to indicate that the file was saved
            MessageBox.Show("Configuration saved successfully!", "Save Config", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Name.Checked)
            {
                radioButton_Root.Enabled = false;
                radioButton_Group.Enabled = false;
                radioButton_Split.Enabled = false;
            }
            else if (radioButton_Hash.Checked)
            {
                radioButton_Root.Enabled = true;
                radioButton_Group.Enabled = true;
                radioButton_Split.Enabled = true;
            }
        }
    }
}
