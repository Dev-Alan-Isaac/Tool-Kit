using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Project__Filter
{
    public partial class Menu_Date : UserControl
    {
        public Menu_Date()
        {
            InitializeComponent();
        }

        private void Menu_Date_Load(object sender, EventArgs e)
        {
            while (true)
            {
                if (File.Exists("Config_Sort.json"))
                {
                    // File already exists; get the filepath
                    string filePath = Path.GetFullPath("Config_Sort.json");
                    Populate_Inputs(filePath);
                    break;
                }
            }
        }

        private void Populate_Inputs(string FilePath)
        {
            if (File.Exists(FilePath))
            {
                // Read the JSON content once
                string jsonContent = File.ReadAllText(FilePath);
                var jsonObject = JsonConvert.DeserializeObject<JObject>(jsonContent);

                // Check the state of "Alphabetically" and "AlphabeticallyExtension" and set radio buttons accordingly
                bool isAccessed = jsonObject["Date"]["Accessed"]?.ToObject<bool>() ?? false;
                bool isCreation = jsonObject["Date"]["Creation"]?.ToObject<bool>() ?? false;
                bool isModified = jsonObject["Date"]["Modified"]?.ToObject<bool>() ?? false;

                if (isAccessed)
                {
                    radioButton_Accessed.Checked = true; // Assuming this is the radio button for "Alphabetically"
                }
                else if (isCreation)
                {
                    radioButton_Creation.Checked = true; // Assuming this is the radio button for "AlphabeticallyExtension"
                }
                else if (isModified)
                {
                    radioButton_Modified.Checked = true; // Assuming this is the radio button for "AlphabeticallyExtension"
                }
            }
        }

        private void button_Saved_Click(object sender, EventArgs e)
        {
            // Define the path to the JSON file
            string filePath = "Config_Sort.json";

            // Load the JSON file
            JObject jsonObject;
            if (File.Exists(filePath))
            {
                jsonObject = JObject.Parse(File.ReadAllText(filePath));
            }
            else
            {
                MessageBox.Show("Configuration file not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            jsonObject["Date"]["Accessed"] = radioButton_Accessed.Checked;
            jsonObject["Date"]["Creation"] = radioButton_Creation.Checked;
            jsonObject["Date"]["Modified"] = radioButton_Modified.Checked;

            // Write the modified JSON object back to the file
            File.WriteAllText(filePath, jsonObject.ToString(Formatting.Indented));

            // Show a message to indicate that the file was saved
            MessageBox.Show("Configuration saved successfully!", "Save Config", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
