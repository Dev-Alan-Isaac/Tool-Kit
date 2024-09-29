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
                            new JProperty("Depth", true)
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
                    bool isReadable = jsonObject["Option"]["Readable"]?.ToObject<bool>() ?? false;
                    bool isWritable = jsonObject["Option"]["Writable"]?.ToObject<bool>() ?? false;

                    if (isReadable)
                    {
                        radioButton_Readable.Checked = true; // Assuming this is the radio button for "Alphabetically"
                    }
                    else if (isWritable)
                    {
                        radioButton_Writable.Checked = true; // Assuming this is the radio button for "AlphabeticallyExtension"
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
                    ["Readable"] = radioButton_Readable.Checked,
                    ["Writable"] = radioButton_Writable.Checked,
                    ["Executable"] = radioButton_Executable.Checked
                }
            };

            // Define the path to the JSON file
            string filePath = "Config_Permissions.json";

            // Write the JSON object to the file
            File.WriteAllText(filePath, jsonObject.ToString());

            // Optionally, show a message to indicate that the file was saved
            MessageBox.Show("Configuration saved successfully!", "Save Config", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
