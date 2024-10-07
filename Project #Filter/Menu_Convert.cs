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
                            new JProperty("Keep", true),
                            new JProperty("Original", true),
                            new JProperty("Custom", false),
                            new JProperty("ByDate", true),
                            new JProperty("ByName", false),
                            new JProperty("BySize", false)
                        )),
                         new JProperty("Video", new JObject(
                            new JProperty("GIF", true),
                            new JProperty("WEBP", false),
                            new JProperty("AVI", false),
                            new JProperty("MP4", false),
                            new JProperty("FLV", false),
                            new JProperty("MKV", false),
                            new JProperty("MOV", false),
                            new JProperty("AUDIO", false)
                         )),
                         new JProperty("Audio", new JObject(
                            new JProperty("WAV", true),
                            new JProperty("MP3", false),
                            new JProperty("WMA", false)
                         )),
                         new JProperty("Image", new JObject(
                            new JProperty("JPEG", true),
                            new JProperty("PNG", false),
                            new JProperty("TIFF", false),
                            new JProperty("ICO", false),
                            new JProperty("SVG", false),
                            new JProperty("WEBP", false)
                         )),
                          new JProperty("Document", new JObject(
                            new JProperty("WORD", true),
                            new JProperty("PDF", false),
                            new JProperty("WEB", false),
                            new JProperty("PLAIN", false),
                            new JProperty("EXCEL", false),
                            new JProperty("IMAGE", false)
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
                if (jsonObject["Option"] != null)
                {
                    bool isDelete = jsonObject["Option"]["Delete"]?.ToObject<bool>() ?? false;
                    bool isSubfolder = jsonObject["Option"]["Subfolder"]?.ToObject<bool>() ?? false;
                    bool isKeep = jsonObject["Option"]["Keep"]?.ToObject<bool>() ?? false;
                    bool isOriginal = jsonObject["Option"]["Original"]?.ToObject<bool>() ?? false;
                    bool isCustom = jsonObject["Option"]["Custom"]?.ToObject<bool>() ?? false;
                    bool isDate = jsonObject["Option"]["ByDate"]?.ToObject<bool>() ?? false;
                    bool isName = jsonObject["Option"]["ByName"]?.ToObject<bool>() ?? false;
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
        }

        private void button_Saved_Click(object sender, EventArgs e)
        {
            var jsonObject = new JObject
            {
                ["Option"] = new JObject
                {
                    ["Delete"] = checkBox_Delete.Checked,
                    ["Subfolder"] = checkBox_Subfolders.Checked,
                    ["Keep"] = checkBox_Keep.Checked,
                    ["Original"] = radioButton_Original.Checked,
                    ["Custom"] = radioButton_Custom.Checked,
                    ["ByDate"] = radioButton_Date.Checked,
                    ["ByName"] = radioButton_Name.Checked,
                    ["BySize"] = radioButton_Size.Checked,
                }
            };

            // Define the path to the JSON file
            string filePath = "Config_Convert.json";

            // Write the JSON object to the file
            File.WriteAllText(filePath, jsonObject.ToString());

            // Optionally, show a message to indicate that the file was saved
            MessageBox.Show("Configuration saved successfully!", "Save Config", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}