using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                if (!File.Exists("Config_Tags.json"))
                {
                    // Create the JSON object
                    var jsonContent = new JObject(
                         new JProperty("Option", new JObject(
                             new JProperty("Tags", new JArray())
                         ))
                     );

                    // Save to a file (e.g., "Extensions.json")
                    File.WriteAllText("Config_Tags.json", jsonContent.ToString());
                }

                // File already exists; get the filepath
                string filePath = Path.GetFullPath("Config_Tags.json");
                PopulateTree(filePath);
                break;
            }
        }

        private void PopulateTree(string FilePath)
        {
            if (File.Exists(FilePath))
            {
                treeView_Tags.Nodes.Clear();
                string jsonContent = File.ReadAllText(FilePath);

                // Deserialize the JSON content into a JObject
                var jsonObject = JsonConvert.DeserializeObject<JObject>(jsonContent);

                // Access the Extensions object
                var extensionsObject = jsonObject["Option"] as JObject; // Explicit cast to JObject

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
            string filePath = "Config_Tags.json";

            // Read the existing JSON file content
            JObject jsonContent;
            if (File.Exists(filePath))
            {
                string existingJson = File.ReadAllText(filePath);

                // Check if the JSON content is empty
                if (string.IsNullOrWhiteSpace(existingJson))
                {
                    // If empty, create a new JSON object
                    jsonContent = new JObject(new JProperty("Option", new JObject(new JProperty("Tags", new JArray()))));
                }
                else
                {
                    // Parse the existing JSON content
                    jsonContent = JObject.Parse(existingJson);
                }
            }
            else
            {
                // If the file doesn't exist, create a new JSON object with an empty "Tags" array
                jsonContent = new JObject(new JProperty("Option", new JObject(new JProperty("Tags", new JArray()))));
            }

            // Ensure that the "Option" object exists
            if (jsonContent["Option"] == null)
            {
                jsonContent["Option"] = new JObject();
            }

            // Ensure that the "Tags" array exists
            if (jsonContent["Option"]["Tags"] == null)
            {
                jsonContent["Option"]["Tags"] = new JArray();
            }

            // Get the "Tags" array from the JSON content
            JArray tagsArray = (JArray)jsonContent["Option"]["Tags"];

            // Get the new tag from the textbox
            string newTag = textBox_Tag.Text.Trim();

            // Check if the new tag is not empty and doesn't already exist in the array
            if (!string.IsNullOrEmpty(newTag) && !tagsArray.Contains(newTag))
            {
                // Add the new tag to the "Tags" array
                tagsArray.Add(newTag);
            }

            // Write the updated JSON content back to the file
            File.WriteAllText(filePath, jsonContent.ToString());

            // Optionally, clear the textbox and show a message
            textBox_Tag.Clear();
            MessageBox.Show("Tag added successfully!", "Add Tag", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Call the PopulateTree method
            PopulateTree(filePath);
        }

        private void button_Remove_Click(object sender, EventArgs e)
        {
            // Ensure a node is selected in the TreeView
            if (treeView_Tags.SelectedNode == null)
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
                string filePath = "Config_Tags.json";

                if (File.Exists(filePath))
                {
                    // Read the existing JSON content
                    string jsonString = File.ReadAllText(filePath);
                    var jsonContent = JObject.Parse(jsonString);

                    // Get the "Tags" array from the JSON content
                    JArray tagsArray = (JArray)jsonContent["Option"]["Tags"];

                    // Debug: Print tags to verify structure
                    Console.WriteLine(tagsArray.ToString());

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
                        File.WriteAllText(filePath, jsonContent.ToString());

                        // Remove the node from the TreeView
                        treeView_Tags.Nodes.Remove(treeView_Tags.SelectedNode);

                        // Optionally, show a message indicating success
                        MessageBox.Show("Tag removed successfully!", "Delete Tag", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Tag not found in the JSON file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Config_Tags.json file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


    }
}
