using Newtonsoft.Json.Linq;

namespace Project__Filter
{
    public partial class Menu_Name : UserControl
    {
        public Menu_Name()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            while (true)
            {
                if (!File.Exists("Config_Names.json"))
                {
                    // Create the JSON object
                    var jsonContent = new JObject(
                         new JProperty("Option", new JObject(
                             new JProperty("Alphabetically", true),
                             new JProperty("AlphabeticallyExtension", false)
                         )),
                         new JProperty("Additional", new JObject(
                             new JProperty("Case", true),
                             new JProperty("Special", true)
                         ))
                     );
                    // Save to a file (e.g., "Extensions.json")
                    File.WriteAllText("Config_Names.json", jsonContent.ToString());
                }
                string filePath = Path.GetFullPath("Config_Names.json");
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
                    bool isAlphabetically = jsonObject["Option"]["Alphabetically"]?.ToObject<bool>() ?? false;
                    bool isAlphabeticallyExtension = jsonObject["Option"]["AlphabeticallyExtension"]?.ToObject<bool>() ?? false;

                    if (isAlphabetically)
                    {
                        radioButton_FileName.Checked = true; // Assuming this is the radio button for "Alphabetically"
                    }
                    else if (isAlphabeticallyExtension)
                    {
                        radioButton_FileExtension.Checked = true; // Assuming this is the radio button for "AlphabeticallyExtension"
                    }
                }

                // Check if the "Additional" property exists
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
            // Create a new JObject to represent the JSON structure
            var jsonObject = new JObject
            {
                ["Option"] = new JObject
                {
                    ["Alphabetically"] = radioButton_FileName.Checked,
                    ["AlphabeticallyExtension"] = radioButton_FileExtension.Checked
                },
                ["Additional"] = new JObject
                {
                    ["Case"] = checkBox_CapsSens.Checked,
                    ["Special"] = checkBox_IgnoreSpecialChar.Checked
                }
            };

            // Define the path to the JSON file
            string filePath = "Config_Names.json";

            // Write the JSON object to the file
            File.WriteAllText(filePath, jsonObject.ToString());

            // Optionally, show a message to indicate that the file was saved
            MessageBox.Show("Configuration saved successfully!", "Save Config", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
