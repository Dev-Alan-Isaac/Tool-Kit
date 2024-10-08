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
                if (!File.Exists("Config_Media.json"))
                {
                    // Create the JSON object
                    var jsonContent = new JObject(
                         new JProperty("Option", new JObject(
                             new JProperty("Duration", true),
                             new JProperty("Resolution", false),
                             new JProperty("Frame_Rate", false),
                             new JProperty("Codec", false),
                             new JProperty("Aspect", false)
                        ))
                    );


                    // Save to a file (e.g., "Extensions.json")
                    File.WriteAllText("Config_Media.json", jsonContent.ToString());
                }
                string filePath = Path.GetFullPath("Config_Media.json");
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
                    bool isDuration = jsonObject["Option"]["Duration"]?.ToObject<bool>() ?? false;
                    bool isResolution = jsonObject["Option"]["Resolution"]?.ToObject<bool>() ?? false;
                    bool isFrame_Rate = jsonObject["Option"]["Frame_Rate"]?.ToObject<bool>() ?? false;
                    bool isCodec = jsonObject["Option"]["Codec"]?.ToObject<bool>() ?? false;
                    bool isAudio = jsonObject["Option"]["Audio"]?.ToObject<bool>() ?? false;
                    bool isAspect = jsonObject["Option"]["Aspect"]?.ToObject<bool>() ?? false;
                    bool isBitDepth = jsonObject["Option"]["BitDepth"]?.ToObject<bool>() ?? false;

                    if (isDuration)
                    {
                        radioButton_Duration.Checked = true; // Assuming this is the radio button for "Alphabetically"
                    }
                    else if (isResolution)
                    {
                        radioButton_Resolution.Checked = true; // Assuming this is the radio button for "AlphabeticallyExtension"
                    }
                    else if (isFrame_Rate)
                    {
                        radioButton_Frames.Checked = true; // Assuming this is the radio button for "AlphabeticallyExtension"
                    }
                    else if (isCodec)
                    {
                        radioButton_Codec.Checked = true; // Assuming this is the radio button for "AlphabeticallyExtension"
                    }
                    else if (isAspect)
                    {
                        radioButton_AspectRatio.Checked = true; // Assuming this is the radio button for "AlphabeticallyExtension"
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
                    ["Duration"] = radioButton_Duration.Checked,
                    ["Resolution"] = radioButton_Resolution.Checked,
                    ["Frame_Rate"] = radioButton_Frames.Checked,
                    ["Codec"] = radioButton_Codec.Checked,
                    ["Aspect"] = radioButton_AspectRatio.Checked,
                }
            };

            // Define the path to the JSON file
            string filePath = "Config_Media.json";

            // Write the JSON object to the file
            File.WriteAllText(filePath, jsonObject.ToString());

            // Optionally, show a message to indicate that the file was saved
            MessageBox.Show("Configuration saved successfully!", "Save Config", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
