using Newtonsoft.Json.Linq;

namespace Project__Filter
{
    public partial class Menu_Merge : UserControl
    {
        public Menu_Merge()
        {
            InitializeComponent();
        }

        private void Menu_Merge_Load(object sender, EventArgs e)
        {
            while (true)
            {
                if (!File.Exists("Config_Merge.json"))
                {
                    // Create the JSON object
                    var jsonContent = new JObject(
                        new JProperty("Option", new JObject(
                            new JProperty("Delete", true),
                            new JProperty("Subfolder", true),
                            new JProperty("Keep", true)
                        ))
                    );

                    // Save to a file (e.g., "Extensions.json")
                    File.WriteAllText("Config_Merge.json", jsonContent.ToString());
                }

                // File already exists; get the filepath
                string filePath = Path.GetFullPath("Config_Merge.json");
                PopulateInputs(filePath);
                break;
            }
        }

        private void PopulateInputs(string filePath)
        {
            if (File.Exists(filePath))
            {
                // Read the JSON content from the file
                string jsonContent = File.ReadAllText(filePath);

                // Deserialize the JSON content into a JObject
                var jsonObject = JObject.Parse(jsonContent);

                // Populate checkboxes
                bool isDelete = jsonObject["Option"]["Delete"]?.ToObject<bool>() ?? false;
                bool isSubfolder = jsonObject["Option"]["Subfolder"]?.ToObject<bool>() ?? false;
                bool isKeep = jsonObject["Option"]["Keep"]?.ToObject<bool>() ?? false;
                checkBox_Delete.Checked = isDelete;
                checkBox_Subfolders.Checked = isSubfolder;
                checkBox_Keep.Checked = isKeep;
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
                    ["Keep"] = checkBox_Keep.Checked
                }
            };

            // Save JSON back to file
            string filePath = "Config_Merge.json";
            File.WriteAllText(filePath, jsonObject.ToString());

            MessageBox.Show("Configuration saved successfully!", "Save Config", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
