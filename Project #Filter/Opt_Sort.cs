using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace Project__Filter
{
    public partial class Opt_Sort : UserControl
    {
        private string Path;
        private List<string> checkedItems = new List<string>();

        public Opt_Sort()
        {
            InitializeComponent();
        }

        private void button_Path_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    Path = fbd.SelectedPath;
                    textBox_Path.Text = Path;
                }
            }
        }

        private async void button_Filter_Click_1(object sender, EventArgs e)
        {
            string config_Path;
            // Iterate through each item in the checkedItems list
            foreach (string item in checkedItems)
            {
                switch (item)
                {
                    case "File Type":
                        config_Path = System.IO.Path.GetFullPath("Config_Type.json");
                        await Task.Run(() => SortTypes(Path, config_Path));
                        break;
                    case "File Size":
                        await Task.Run(() => SortSize(Path, "Config_Size.json"));
                        break;
                    case "File Date":
                        await Task.Run(() => SortDates(Path));
                        break;
                    case "File Name":
                        await Task.Run(() => SortNames(Path, "Config_Names.json"));
                        break;
                    case "File Permissions":
                        await Task.Run(() => SortPermissions(Path, "Config_Permissions.json"));
                        break;
                    case "Custom Tags":
                        await Task.Run(() => SortCustomTags(Path, "Config_Tags.json"));
                        break;
                    case "Folder Location":
                        await Task.Run(() => SortFolderLocation(Path, "Config_Folder.json"));
                        break;
                    case "Media Metadata (Videos/Audio)":
                        await Task.Run(() => SortMedia(Path, "Config_Media.json"));
                        break;
                    default:
                        break;
                }
            }

            // Optionally, you can split the list into sub-lists or do other kinds of processing here.
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            // Cast the sender to a CheckBox
            if (sender is CheckBox checkBox)
            {
                // Get the text of the checkbox
                string checkboxText = checkBox.Text;

                if (checkBox.Checked)
                {
                    // Add to the list if checked
                    if (!checkedItems.Contains(checkboxText))
                        checkedItems.Add(checkboxText);
                }
                else
                {
                    // Remove from the list if unchecked
                    checkedItems.Remove(checkboxText);
                }
            }

            // Enable the button if one or more items are checked, disable it if none are checked
            button_Filter.Enabled = checkedItems.Count > 0;
        }

        public async void SortTypes(string folderPath, string jsonPath)
        {
            if (!File.Exists(jsonPath))
            {
                MessageBox.Show("Config file not found.");
                return;
            }

            // Read and parse the JSON file
            string jsonString = await File.ReadAllTextAsync(jsonPath);
            var jsonContent = JObject.Parse(jsonString);

            // Get the "Extensions" and "Allow" sections from the JSON
            var extensions = jsonContent["Extensions"].ToObject<JObject>();
            var allow = jsonContent["Allow"].ToObject<JObject>();

            // Get all files in the target folder
            var files = Directory.GetFiles(folderPath);
            int totalFiles = files.Length;
            int processedFiles = 0;

            Invoke((MethodInvoker)(() => File_Count.Text = $"Total Files: {totalFiles}"));

            foreach (var file in files)
            {
                // Get the file extension (without the dot, in lowercase)
                string fileExtension = System.IO.Path.GetExtension(file).TrimStart('.').ToLower();

                // Check each category in "Allow"
                foreach (var allowCategory in allow)
                {
                    bool isAllowed = (bool)allowCategory.Value;
                    string category = allowCategory.Key;

                    // If the category is allowed
                    if (isAllowed)
                    {
                        // Get the list of extensions for this category
                        JArray categoryExtensions = (JArray)extensions[category];

                        // If the file's extension is in the allowed extensions
                        if (categoryExtensions.Contains(fileExtension))
                        {
                            // Create the target directory if it doesn't exist
                            string targetDirectory = System.IO.Path.Combine(folderPath, category); // Path.Combine correctly used here
                            if (!Directory.Exists(targetDirectory))
                            {
                                Directory.CreateDirectory(targetDirectory);
                            }

                            // Move the file to the target directory
                            string targetPath = System.IO.Path.Combine(targetDirectory, System.IO.Path.GetFileName(file)); // Correct use of Path.Combine
                            File.Move(file, targetPath);

                            MessageBox.Show($"Moved {file} to {targetDirectory}");
                        }
                    }
                }

                // Update progress
                processedFiles++;
                int progress = (int)((double)processedFiles / totalFiles * 100);

                // Update the ProgressBar using Invoke to update the UI from a non-UI thread
                progressBar_Time.Invoke((MethodInvoker)(() => progressBar_Time.Value = progress));
            }

            // Ensure the progress bar reaches 100% at the end
            progressBar_Time.Invoke((MethodInvoker)(() => progressBar_Time.Value = 100));
        }

        private async void SortSize(string Path, string File)
        {

        }

        private async void SortDates(string Path)
        {

        }

        private async void SortNames(string Path, string File)
        {

        }

        private async void SortPermissions(string Path, string File)
        {

        }

        private async void SortCustomTags(string Path, string File)
        {

        }

        private async void SortFolderLocation(string Path, string File)
        {

        }

        private async void SortFileContent(string Path, string File)
        {

        }

        private async void SortMedia(string Path, string File)
        {

        }
    }
}