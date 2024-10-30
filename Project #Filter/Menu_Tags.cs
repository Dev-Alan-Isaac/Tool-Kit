using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Project__Filter
{
    public partial class Menu_Tags : UserControl
    {
        public Menu_Tags()
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
                    Populate_Tree(filePath);
                    break;
                }
            }
        }

        private void Populate_Tree(string FilePath)
        {
            if (File.Exists(FilePath))
            {
                treeView_Tags.Nodes.Clear();

                // Read the JSON content once
                string jsonContent = File.ReadAllText(FilePath);
                var jsonObject = JsonConvert.DeserializeObject<JObject>(jsonContent);

                // Access the Extensions object
                var extensionsObject = jsonObject["Tag"] as JObject; // Explicit cast to JObject
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
                        treeView_Tags.Nodes.Add(categoryNode);
                    }
                }
            }
        }

        private void button_Add_Click(object sender, EventArgs e)
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

            // Get the new tag from the text box
            string newTag = textBox_Tag.Text.Trim();

            // Check if the new tag is not empty
            if (!string.IsNullOrEmpty(newTag))
            {
                // Add the new tag to the JSON array
                JArray tagsArray = (JArray)jsonObject["Tag"]["Tags"];
                tagsArray.Add(newTag);

                // Write the modified JSON object back to the file
                File.WriteAllText(filePath, jsonObject.ToString(Formatting.Indented));

                // Show a message to indicate that the tag was added and configuration saved
                MessageBox.Show("Tag added and configuration saved successfully!", "Save Config", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Call the PopulateTree method
                Populate_Tree(filePath);
            }
            else
            {
                MessageBox.Show("Please enter a valid tag.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_Remove_Click(object sender, EventArgs e)
        {
            // Ensure a tag node is selected in the TreeView
            if (treeView_Tags.SelectedNode == null || treeView_Tags.SelectedNode.Parent == null)
            {
                MessageBox.Show("Please select a tag to remove.", "No Tag Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the selected tag (node text)
            string selectedTag = treeView_Tags.SelectedNode.Text.Trim();

            // Ask the user for confirmation
            DialogResult result = MessageBox.Show($"Are you sure you want to delete the tag '{selectedTag}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // If the user confirms deletion
            if (result == DialogResult.Yes)
            {
                string filePath = "Config_Sort.json";
                if (File.Exists(filePath))
                {
                    // Read the existing JSON content
                    string jsonString = File.ReadAllText(filePath);
                    var jsonContent = JObject.Parse(jsonString);

                    // Get the "Tags" array from the JSON content
                    JArray tagsArray = (JArray)jsonContent["Tag"]["Tags"];

                    // Flag to check if tag was found
                    bool tagFound = false;

                    // Loop through the tags array and find the matching tag
                    for (int i = 0; i < tagsArray.Count; i++)
                    {
                        string tag = tagsArray[i].ToString().Trim(); // Trim any whitespace

                        // Compare the tag from the array with the selected tag
                        if (string.Equals(tag, selectedTag, StringComparison.OrdinalIgnoreCase))
                        {
                            // Remove the tag
                            tagsArray.RemoveAt(i);
                            tagFound = true;
                            break;
                        }
                    }

                    // Check if the tag was found and removed
                    if (tagFound)
                    {
                        // Write the updated JSON content back to the file
                        File.WriteAllText(filePath, jsonContent.ToString(Formatting.Indented));

                        // Remove the node from the TreeView
                        treeView_Tags.Nodes.Remove(treeView_Tags.SelectedNode);

                        // Show a message indicating success
                        MessageBox.Show("Tag removed successfully!", "Delete Tag", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Tag not found in the JSON file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Config_Sort.json file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
