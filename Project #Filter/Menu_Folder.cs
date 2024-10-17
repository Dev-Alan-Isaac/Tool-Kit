using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Project__Filter
{
    public partial class Menu_Folder : UserControl
    {
        public Menu_Folder()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            while (true)
            {
                if (!File.Exists("Config_Folder.json"))
                {
                    // Create the JSON object
                    var jsonContent = new JObject(
                        new JProperty("Option", new JObject(
                            new JProperty("Alphabetical", true),
                            new JProperty("Depth", false)
                        )),
                         new JProperty("Additional", new JObject(
                             new JProperty("Case", true),
                             new JProperty("Special", true)
                         ))
                     );


                    // Save to a file (e.g., "Extensions.json")
                    File.WriteAllText("Config_Folder.json", jsonContent.ToString());
                }

                string filePath = Path.GetFullPath("Config_Folder.json");
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
                    bool isAlphabetical = jsonObject["Option"]["Alphabetical"]?.ToObject<bool>() ?? false;
                    bool isDeep = jsonObject["Option"]["Depth"]?.ToObject<bool>() ?? false;

                    if (isAlphabetical)
                    {
                        radioButton_Alphabetical.Checked = isAlphabetical; // Assuming this is the radio button for "Alphabetically"
                    }
                    else if (isDeep)
                    {
                        radioButton_Depth.Checked = isDeep; // Assuming this is the radio button for "AlphabeticallyExtension"
                    }
                }

                if (jsonObject["Additional"] != null)
                {
                    // Check the state of "Case" and "Special" and set checkboxes accordingly
                    bool isCase = jsonObject["Additional"]["Case"]?.ToObject<bool>() ?? false;
                    bool isSpecial = jsonObject["Additional"]["Special"]?.ToObject<bool>() ?? false;

                    checkBox_CapsSens.Checked = isCase; // Assuming this is the checkbox for "Case"
                    checkBox_IgnoreSpecialChar.Checked = isSpecial; // Assuming this is the checkbox for "Special"
                }
            }
        }

        private void button_Saved_Click(object sender, EventArgs e)
        {
            var jsonObject = new JObject
            {
                ["Option"] = new JObject
                {
                    ["Alphabetical"] = radioButton_Alphabetical.Checked,
                    ["Depth"] = radioButton_Depth.Checked,
                },
                ["Additional"] = new JObject
                {
                    ["Case"] = checkBox_CapsSens.Checked,
                    ["Special"] = checkBox_IgnoreSpecialChar.Checked
                }
            };

            // Define the path to the JSON file
            string filePath = "Config_Folder.json";

            // Write the JSON object to the file
            File.WriteAllText(filePath, jsonObject.ToString());

            // Optionally, show a message to indicate that the file was saved
            MessageBox.Show("Configuration saved successfully!", "Save Config", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
