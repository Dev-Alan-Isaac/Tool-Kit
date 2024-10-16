using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
                             new JProperty("Subfolder", true)
                         )),
                         new JProperty("Decompress", new JObject(
                             new JProperty("RootDecompress", true),
                             new JProperty("Folder", false)
                         )));

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
                    bool isRootDecompress = jsonObject["Decompress"]["RootDecompress"]?.ToObject<bool>() ?? false;
                    bool isFolder = jsonObject["Decompress"]["Folder"]?.ToObject<bool>() ?? false;

                    checkBox_Delete.Checked = isDelete;
                    checkBox_Subfolders.Checked = isSubfolder;

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
                    ["Subfolder"] = checkBox_Subfolders.Checked
                },
                ["Decompress"] = new JObject
                {
                    ["RootDecompress"] = radioButton_RootDecompress.Checked,
                    ["Folder"] = radioButton_Folder.Checked
                }
            };

            // Define the path to the JSON file
            string filePath = "Config_Extract.json";

            // Write the JSON object to the file
            File.WriteAllText(filePath, jsonObject.ToString(Newtonsoft.Json.Formatting.Indented));

            // Optionally, show a message to indicate that the file was saved
            MessageBox.Show("Configuration saved successfully!", "Save Config", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
