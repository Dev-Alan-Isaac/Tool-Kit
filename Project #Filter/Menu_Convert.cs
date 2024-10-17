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
                            new JProperty("Original", true), 
                            new JProperty("Keep", true)

                        )),
                        new JProperty("Additional", new JObject(
                             new JProperty("Name", true),
                             new JProperty("Custom", true)
                        )),
                        new JProperty("Video", new JObject(
                            new JProperty("GIF", true)
                        )),
                        new JProperty("Audio", new JObject(
                            new JProperty("WAV", true)
                        )),
                        new JProperty("Image", new JObject(
                            new JProperty("JPEG", true)
                        )),
                        new JProperty("Document", new JObject(
                            new JProperty("WORD", true)
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

                // Check if the "Option" property exists

                bool isDelete = jsonObject["Option"]["Delete"]?.ToObject<bool>() ?? false;
                bool isSubfolder = jsonObject["Option"]["Subfolder"]?.ToObject<bool>() ?? false;
                bool isOriginal = jsonObject["Option"]["Original"]?.ToObject<bool>() ?? false;
                bool isKeep = jsonObject["Option"]["Keep"]?.ToObject<bool>() ?? false;

                bool isName = jsonObject["Option"]["ByName"]?.ToObject<bool>() ?? false;
                bool isCustom = jsonObject["Option"]["Custom"]?.ToObject<bool>() ?? false;


                bool isDate = jsonObject["Option"]["ByDate"]?.ToObject<bool>() ?? false;
                bool isSize = jsonObject["Option"]["BySize"]?.ToObject<bool>() ?? false;


                checkBox_Delete.Checked = isDelete;
                checkBox_Subfolders.Checked = isSubfolder;
                checkBox_Keep.Checked = isKeep;

                if (isOriginal)
                {
                    radioButton_Original.Checked = isOriginal;
                }
                else if (isCustom)
                {
                    radioButton_Custom.Checked = isCustom;
                }

                if (isDate)
                {
                    radioButton_Date.Checked = isDate;
                }
                else if (isName)
                {
                    radioButton_Name.Checked = isName;
                }
                else if (isSize)
                {
                    radioButton_Size.Checked = isSize;
                }
            }
        }

        private void button_Saved_Click(object sender, EventArgs e)
        {
            string filePath = "Config_Convert.json";

            // Check if the JSON file exists
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Config file not found.");
                return;
            }

            // Load the existing JSON content
            var jsonString = File.ReadAllText(filePath);
            var jsonObject = JObject.Parse(jsonString);

            // Update the "Option" section without overwriting the rest of the file
            var optionSection = (JObject)jsonObject["Option"];
            optionSection["Delete"] = checkBox_Delete.Checked;
            optionSection["Subfolder"] = checkBox_Subfolders.Checked;
            optionSection["Keep"] = checkBox_Keep.Checked;
            optionSection["Original"] = radioButton_Original.Checked;
            optionSection["Custom"] = radioButton_Custom.Checked;
            optionSection["ByDate"] = radioButton_Date.Checked;
            optionSection["ByName"] = radioButton_Name.Checked;
            optionSection["BySize"] = radioButton_Size.Checked;

            // Save the updated JSON back to the file
            File.WriteAllText(filePath, jsonObject.ToString());

            // Optionally, show a message to indicate that the file was saved
            MessageBox.Show("Configuration saved successfully!", "Save Config", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}