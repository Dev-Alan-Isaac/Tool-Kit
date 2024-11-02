using Newtonsoft.Json;
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
                string jsonContent = File.ReadAllText(FilePath);
                var jsonObject = JsonConvert.DeserializeObject<JObject>(jsonContent);

                bool isAlphabetically = jsonObject["Name"]["Alphabetically"]?.ToObject<bool>() ?? false;
                bool isAlphabeticallyExtension = jsonObject["Name"]["AlphabeticallyExtension"]?.ToObject<bool>() ?? false;

                if (isAlphabetically)
                {
                    radioButton_FileName.Checked = isAlphabetically;
                }
                else if (isAlphabeticallyExtension)
                {
                    radioButton_FileExtension.Checked = isAlphabeticallyExtension;
                }

                bool isCase = jsonObject["Name_Additional"]["Case"]?.ToObject<bool>() ?? false;
                bool isSpecial = jsonObject["Name_Additional"]["Special"]?.ToObject<bool>() ?? false;

                checkBox_CapsSens.Checked = isCase;
                checkBox_IgnoreSpecialChar.Checked = isSpecial;
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

            jsonObject["Name"]["Alphabetically"] = radioButton_FileName.Checked;
            jsonObject["Name"]["AlphabeticallyExtension"] = radioButton_FileExtension.Checked;

            jsonObject["Name_Additional"]["Case"] = checkBox_CapsSens.Checked;
            jsonObject["Name_Additional"]["Special"] = checkBox_IgnoreSpecialChar.Checked;


            // Write the modified JSON object back to the file
            File.WriteAllText(filePath, jsonObject.ToString(Formatting.Indented));

            // Show a message to indicate that the file was saved
            MessageBox.Show("Configuration saved successfully!", "Save Config", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
