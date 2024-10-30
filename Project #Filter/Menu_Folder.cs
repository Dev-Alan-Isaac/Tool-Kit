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

                bool isAlphabetically = jsonObject["Folder"]["Alphabetically"]?.ToObject<bool>() ?? false;
                bool isDepth = jsonObject["Folder"]["Depth"]?.ToObject<bool>() ?? false;

                if (isAlphabetically)
                {
                    radioButton_Alphabetical.Checked = isAlphabetically;
                }
                else if (isDepth)
                {
                    radioButton_Depth.Checked = isDepth;
                }

                bool isCase = jsonObject["Folder_Additional"]["Case"]?.ToObject<bool>() ?? false;
                bool isSpecial = jsonObject["Folder_Additional"]["Special"]?.ToObject<bool>() ?? false;

                if (isCase)
                {
                    checkBox_CapsSens.Checked = isCase;
                }
                else if (isSpecial)
                {
                    checkBox_IgnoreSpecialChar.Checked = isSpecial;
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
