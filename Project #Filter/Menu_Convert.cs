using Newtonsoft.Json.Linq;

namespace Project__Filter
{
    public partial class Menu_Convert : UserControl
    {
        public Menu_Convert()
        {
            InitializeComponent();
        }

        private void Menu_Transform_Load(object sender, EventArgs e)
        {
            while (true)
            {
                if (!File.Exists("Config_Convert.json"))
                {
                    // Create the JSON object
                    var jsonContent = new JObject(
                        new JProperty("Option", new JObject(
                            new JProperty("Delete", true),
                            new JProperty("Subfolder", true),
                            new JProperty("Keep", true)
                        )),
                        new JProperty("Video", new JObject(
                            new JProperty("Selected", "MP4")
                        )),
                        new JProperty("Audio", new JObject(
                            new JProperty("Selected", "MP3")
                        )),
                        new JProperty("Image", new JObject(
                            new JProperty("Selected", "BMP")
                        )),
                        new JProperty("Document", new JObject(
                            new JProperty("Selected", "DOC")
                        ))
                    );

                    // Save to a file (e.g., "Extensions.json")
                    File.WriteAllText("Config_Convert.json", jsonContent.ToString());
                }

                // File already exists; get the filepath
                string filePath = Path.GetFullPath("Config_Convert.json");
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

                // Populate ComboBoxes
                comboBox_Video.SelectedIndex = GetSelectedIndex(comboBox_Video, jsonObject["Video"]["Selected"]?.ToString());
                comboBox_Audio.SelectedIndex = GetSelectedIndex(comboBox_Audio, jsonObject["Audio"]["Selected"]?.ToString());
                comboBox_Image.SelectedIndex = GetSelectedIndex(comboBox_Image, jsonObject["Image"]["Selected"]?.ToString());
                comboBox_Document.SelectedIndex = GetSelectedIndex(comboBox_Document, jsonObject["Document"]["Selected"]?.ToString());
            }
        }

        private int GetSelectedIndex(ComboBox comboBox, string selectedValue)
        {
            for (int i = 0; i < comboBox.Items.Count; i++)
            {
                if (comboBox.Items[i].ToString().Equals(selectedValue, StringComparison.OrdinalIgnoreCase))
                {
                    return i;
                }
            }
            return -1; // or any default value you want to set if not found
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
                },
                ["Video"] = new JObject
                {
                    ["Selected"] = comboBox_Video.SelectedItem?.ToString()
                },
                ["Audio"] = new JObject
                {
                    ["Selected"] = comboBox_Audio.SelectedItem?.ToString()
                },
                ["Image"] = new JObject
                {
                    ["Selected"] = comboBox_Image.SelectedItem?.ToString()
                },
                ["Document"] = new JObject
                {
                    ["Selected"] = comboBox_Document.SelectedItem?.ToString()
                }
            };

            // Save JSON back to file
            string filePath = "Config_Convert.json";
            File.WriteAllText(filePath, jsonObject.ToString());

            MessageBox.Show("Configuration saved successfully!", "Save Config", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}