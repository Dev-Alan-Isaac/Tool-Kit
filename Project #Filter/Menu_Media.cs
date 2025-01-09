using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Project__Filter
{
    public partial class Menu_Media : UserControl
    {
        public Menu_Media()
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
                // Read the JSON content once
                string jsonContent = File.ReadAllText(FilePath);
                var jsonObject = JsonConvert.DeserializeObject<JObject>(jsonContent);

                // Check the state of "Alphabetically" and "AlphabeticallyExtension" and set radio buttons accordingly
                bool isDuration = jsonObject["Media"]["Duration"]?.ToObject<bool>() ?? false;
                bool isResolution = jsonObject["Media"]["Resolution"]?.ToObject<bool>() ?? false;
                bool isFrame_Rate = jsonObject["Media"]["Frame_Rate"]?.ToObject<bool>() ?? false;
                bool isCodec = jsonObject["Media"]["Codec"]?.ToObject<bool>() ?? false;
                bool isAspect = jsonObject["Media"]["Aspect"]?.ToObject<bool>() ?? false;

                if (isDuration)
                {
                    radioButton_Duration.Checked = isDuration;
                }
                else if (isResolution)
                {
                    radioButton_Resolution.Checked = isResolution;
                }
                else if (isFrame_Rate)
                {
                    radioButton_Frames.Checked = isFrame_Rate;
                }
                else if (isCodec)
                {
                    radioButton_Codec.Checked = isCodec;
                }
                else if (isAspect)
                {
                    radioButton_AspectRatio.Checked = isAspect;
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

            jsonObject["Media"]["Duration"] = radioButton_Duration.Checked;
            jsonObject["Media"]["Resolution"] = radioButton_Resolution.Checked;
            jsonObject["Media"]["Frame_Rate"] = radioButton_Frames.Checked;
            jsonObject["Media"]["Codec"] = radioButton_Codec.Checked;
            jsonObject["Media"]["Aspect"] = radioButton_AspectRatio.Checked;

            // Write the modified JSON object back to the file
            File.WriteAllText(filePath, jsonObject.ToString(Formatting.Indented));

            // Show a message to indicate that the file was saved
            MessageBox.Show("Configuration saved successfully!", "Save Config", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
