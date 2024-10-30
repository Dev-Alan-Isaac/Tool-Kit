using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Project__Filter
{
    public partial class Menu_Sort : UserControl
    {
        public Menu_Sort()
        {
            InitializeComponent();
        }

        private void Menu_Sort_Load(object sender, EventArgs e)
        {
            while (true)
            {
                if (!File.Exists("Config_Sort.json"))
                {
                    // Create the JSON object
                    var jsonContent = new JObject(
                         new JProperty("General", new JObject(
                             new JProperty("Delete", true),
                             new JProperty("Subfolder", false)
                         )),
                         new JProperty("Type", new JObject(
                            new JProperty("Images", new JArray("jpg", "png", "gif", "bmp", "jpeg")),
                             new JProperty("Videos", new JArray("mp4", "m4v", "avi", "mkv", "3gp", "mov", "wmv", "webm", "ts", "mpg", "asf", "flv", "mpeg")),
                             new JProperty("Documents", new JArray("txt", "docx", "pdf", "pptx")),
                             new JProperty("Audio", new JArray("mp3", "wav", "aac", "flac", "ogg", "m4a", "wma", "alac", "aiff")),
                             new JProperty("Archives", new JArray("zip", "rar", "7z", "tar", "gz", "bz2", "iso", "xz")),
                             new JProperty("Executables", new JArray("exe", "bat", "sh", "msi", "bin", "cmd", "apk", "com", "jar"))
                         )),
                         new JProperty("Type_Additional", new JObject(
                             new JProperty("Documents", true),
                             new JProperty("Images", true),
                             new JProperty("Audio", true),
                             new JProperty("Videos", true),
                             new JProperty("Archives", true),
                             new JProperty("Executables", true)
                         )),
                         new JProperty("Date", new JObject(
                             new JProperty("Accessed", true),
                             new JProperty("Creation", false),
                             new JProperty("Modified", false)
                         )),
                         new JProperty("Size", new JObject(
                             new JProperty("Small", "100", "MB"),
                             new JProperty("Medium", "100", "MB", "1", "GB"),
                             new JProperty("Large", "1", "GB", "10", "GB"),
                             new JProperty("Very Large", "10", "GB")
                         )),
                         new JProperty("Name", new JObject(
                              new JProperty("Alphabetically", true),
                              new JProperty("AlphabeticallyExtension", false)
                         )),
                         new JProperty("Name_Additional", new JObject(
                             new JProperty("Case", true),
                             new JProperty("Special", true)
                         )),
                         new JProperty("Auth", new JObject(
                             new JProperty("Readable", true),
                             new JProperty("Writable", false),
                             new JProperty("Executable", false)
                         )),
                         new JProperty("Tag", new JObject(
                             new JProperty("Tags", new JArray())
                         )),
                         new JProperty("Folder", new JObject(
                            new JProperty("Alphabetical", true),
                            new JProperty("Depth", false)
                         )),
                         new JProperty("Folder_Additional", new JObject(
                             new JProperty("Case", true),
                             new JProperty("Special", true)
                         )),
                         new JProperty("Media", new JObject(
                             new JProperty("Duration", true),
                             new JProperty("Resolution", false),
                             new JProperty("Frame_Rate", false),
                             new JProperty("Codec", false),
                             new JProperty("Aspect", false)
                         ))
                    );

                    // Save to a file (e.g., "Extensions.json")
                    File.WriteAllText("Config_Sort.json", jsonContent.ToString());
                }

                // File already exists; get the filepath
                string filePath = Path.GetFullPath("Config_Sort.json");
                PopulateInputs(filePath);
                break;
            }
        }

        private void PopulateInputs(string FilePath)
        {
            if (File.Exists(FilePath))
            {
                // Read the JSON content from the file
                string jsonContent = File.ReadAllText(FilePath);

                // Deserialize the JSON content into a JObject
                var jsonObject = JsonConvert.DeserializeObject<JObject>(jsonContent);

                // Access the "Allow" object inside the JSON
                var extensionsObject = jsonObject["General"] as JObject;

                if (extensionsObject != null)
                {
                    // Update checkboxes based on JSON values
                    checkBox_Delete.Checked = extensionsObject["Delete"]?.Value<bool>() ?? false;
                    checkBox_Subfolders.Checked = extensionsObject["Subfolder"]?.Value<bool>() ?? false;
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

            jsonObject["General"]["Delete"] = checkBox_Delete.Checked; 
            jsonObject["General"]["Subfolder"] = checkBox_Subfolders.Checked; 

            // Write the modified JSON object back to the file
            File.WriteAllText(filePath, jsonObject.ToString(Newtonsoft.Json.Formatting.Indented));

            // Show a message to indicate that the file was saved
            MessageBox.Show("Configuration saved successfully!", "Save Config", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
