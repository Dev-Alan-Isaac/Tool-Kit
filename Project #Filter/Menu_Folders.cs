using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SharpCompress.Common;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Project__Filter
{
    public partial class Menu_Folders : UserControl
    {
        private List<string> checkedItems = new List<string>();
        private string NodeBranch;

        public Menu_Folders()
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            while (true)
            {
                if (!File.Exists("Extensions.json"))
                {
                    // Create the JSON object
                    var jsonContent = new JObject(
                         new JProperty("Extensions", new JObject(
                             new JProperty("Images", new JArray("jpg", "png", "gif", "bmp", "jpeg")),
                             new JProperty("Videos", new JArray("mp4", "m4v", "avi", "mkv", "3gp", "mov", "wmv", "webm", "ts", "mpg", "asf", "flv", "mpeg")),
                             new JProperty("Documents", new JArray("txt", "docx", "pdf", "pptx")),
                             new JProperty("Audio", new JArray("mp3", "wav", "aac", "flac", "ogg", "m4a", "wma", "alac", "aiff")),
                             new JProperty("Archives", new JArray("zip", "rar", "7z", "tar", "gz", "bz2", "iso", "xz")),
                             new JProperty("Executables", new JArray("exe", "bat", "sh", "msi", "bin", "cmd", "apk", "com", "jar"))
                         )),
                         new JProperty("Allow", new JObject(
                             new JProperty("Documents", true),
                             new JProperty("Images", true),
                             new JProperty("Audio", true),
                             new JProperty("Videos", true),
                             new JProperty("Archives", true),
                             new JProperty("Executables", true)
                         ))
                     );


                    // Save to a file (e.g., "Extensions.json")
                    File.WriteAllText("Extensions.json", jsonContent.ToString());
                }

                // File already exists; get the filepath
                string filePath = Path.GetFullPath("Extensions.json");
                PopulateTree(filePath);
                break;
            }
        }

        private void PopulateTree(string FilePath)
        {
            if (File.Exists(FilePath))
            {
                treeView1.Nodes.Clear();
                string jsonContent = File.ReadAllText(FilePath);

                // Deserialize the JSON content into a JObject
                var jsonObject = JsonConvert.DeserializeObject<JObject>(jsonContent);

                // Access the Extensions object
                var extensionsObject = jsonObject["Extensions"] as JObject; // Explicit cast to JObject

                if (extensionsObject != null)
                {
                    // Iterate through extension categories
                    foreach (var category in extensionsObject.Properties())
                    {
                        // Create a branch node for the category
                        var categoryNode = new TreeNode(category.Name);

                        // Get the list of extensions for this category
                        var extensionList = category.Value.ToObject<List<string>>();

                        // Create child nodes for each extension
                        foreach (var extension in extensionList)
                        {
                            categoryNode.Nodes.Add(extension);
                        }

                        // Add the category node to the TreeView
                        treeView1.Nodes.Add(categoryNode);
                    }
                }
                else
                {
                    // Handle the case where "Extensions" is not found in the JSON
                    // You might want to log an error or display a message to the user
                }
            }
        }

        private void button_Saved_Click(object sender, EventArgs e)
        {
            // Replace 'panelCheckBoxes' with the actual container where your checkboxes are placed
            Control container = this.Controls["panel5"]; // Change this if necessary

            if (File.Exists("Extensions.json"))
            {
                // Read the existing JSON content
                string jsonString = File.ReadAllText("Extensions.json");
                var jsonContent = JObject.Parse(jsonString);

                // Get the "Allow" section
                var allowSection = (JObject)jsonContent["Allow"];

                // Process each item in the list, setting true if checked, false if unchecked
                foreach (string item in checkedItems)
                {
                    // Check if the corresponding checkbox is checked or unchecked
                    bool isChecked = false;

                    foreach (Control control in container.Controls) // Use the container, not this.Controls
                    {
                        if (control is System.Windows.Forms.CheckBox checkBox && checkBox.Text == item)
                        {
                            isChecked = checkBox.Checked;
                            break;
                        }
                    }

                    // Update the "Allow" section in the JSON
                    allowSection[item] = isChecked;
                }

                // Save the updated JSON back to the file
                File.WriteAllText("Extensions.json", jsonContent.ToString());

                // Optional: Notify the user that the file has been saved
                MessageBox.Show("Extensions.json has been updated with allowed/disallowed items.");
            }
            else
            {
                MessageBox.Show("Extensions.json file not found!");
            }
        }

        private void button_Add_Click(object sender, EventArgs e)
        {

        }

        private void button_Remove_Click(object sender, EventArgs e)
        {
            if (File.Exists("Extensions.json"))
            {
                // Read the existing JSON content
                string jsonString = File.ReadAllText("Extensions.json");
                var jsonContent = JObject.Parse(jsonString);

                // Find the "Extensions" section in the JSON
                var extensionsSection = (JObject)jsonContent["Extensions"];

                bool isRemoved = false;

                // Iterate through each extension category (Images, Videos, Documents, etc.)
                foreach (var category in extensionsSection)
                {
                    // Get the array of extensions for this category
                    var extensionArray = (JArray)category.Value;

                    // Check if the extension exists in this category (case-insensitive comparison)
                    var itemToRemove = extensionArray.FirstOrDefault(x => string.Equals(x.ToString().Trim(), NodeBranch.Trim(), StringComparison.OrdinalIgnoreCase));

                    if (itemToRemove != null)
                    {
                        // Remove the extension
                        extensionArray.Remove(itemToRemove);
                        isRemoved = true;
                        break; // Exit the loop once the extension is found and removed
                    }
                }


                if (isRemoved)
                {
                    // Save the updated JSON back to the file
                    File.WriteAllText("Extensions.json", jsonContent.ToString());

                    // Notify the user that the extension was removed
                    MessageBox.Show($"{NodeBranch} has been removed from the extensions.");

                    // After successful removal, repopulate the TreeView
                    string filePath = Path.GetFullPath("Extensions.json");
                    PopulateTree(filePath);
                }
                else
                {
                    // Notify the user if the extension was not found
                    MessageBox.Show($"{NodeBranch} was not found in the extensions.");
                }
            }
            else
            {
                // Notify the user that the file doesn't exist
                MessageBox.Show("Extensions.json file not found!");
            }
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            // Cast the sender to a CheckBox
            if (sender is System.Windows.Forms.CheckBox checkBox)
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
                    // If unchecked, we still keep the item in the list but mark it as false later
                    if (!checkedItems.Contains(checkboxText))
                        checkedItems.Add(checkboxText);
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Get the selected node
            TreeNode selectedNode = e.Node;

            NodeBranch = selectedNode.Text;
        }

    }
}
