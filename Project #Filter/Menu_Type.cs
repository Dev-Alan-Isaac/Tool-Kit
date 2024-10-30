using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Project__Filter
{
    public partial class Menu_Type : UserControl
    {
        private List<string> checkedItems = new List<string>();
        private string NodeBranch;

        public Menu_Type()
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
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


                if (jsonObject.ContainsKey("Type_Additional"))
                {
                    var allowObject = jsonObject["Type_Additional"] as JObject;
                    if (allowObject != null)
                    {
                        checkBox_Documents.Checked = allowObject["Documents"]?.Value<bool>() ?? false;
                        checkBox_Images.Checked = allowObject["Images"]?.Value<bool>() ?? false;
                        checkBox_Audio.Checked = allowObject["Audio"]?.Value<bool>() ?? false;
                        checkBox_Videos.Checked = allowObject["Videos"]?.Value<bool>() ?? false;
                        checkBox_Archives.Checked = allowObject["Archives"]?.Value<bool>() ?? false;
                        checkBox_Executables.Checked = allowObject["Executables"]?.Value<bool>() ?? false;
                    }
                }

                // Populate the TreeView with extension categories from the "Extensions" object
                if (jsonObject.ContainsKey("Type"))
                {
                    var extensionsObject = jsonObject["Type"] as JObject;
                    if (extensionsObject != null)
                    {
                        treeView1.Nodes.Clear(); // Clear existing nodes

                        // Iterate through each category in "Extensions"
                        foreach (var category in extensionsObject.Properties())
                        {
                            // Create a category node
                            var categoryNode = new TreeNode(category.Name);

                            // Add each extension as a child node under the category node
                            var extensionList = category.Value.ToObject<List<string>>() ?? new List<string>();
                            foreach (var extension in extensionList)
                            {
                                categoryNode.Nodes.Add(new TreeNode(extension));
                            }

                            // Add the category node to the TreeView
                            treeView1.Nodes.Add(categoryNode);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Configuration file not found.", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_Saved_Click(object sender, EventArgs e)
        {
            // Replace 'panelCheckBoxes' with the actual container where your checkboxes are placed
            Control container = this.Controls["panel5"]; // Change this if necessary

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

            jsonObject["Type_Additional"]["Documents"] = checkBox_Documents.Checked;
            jsonObject["Type_Additional"]["Images"] = checkBox_Images.Checked;
            jsonObject["Type_Additional"]["Audio"] = checkBox_Audio.Checked;
            jsonObject["Type_Additional"]["Videos"] = checkBox_Videos.Checked;
            jsonObject["Type_Additional"]["Archives"] = checkBox_Archives.Checked;
            jsonObject["Type_Additional"]["Executables"] = checkBox_Executables.Checked;


            // Write the modified JSON object back to the file
            File.WriteAllText(filePath, jsonObject.ToString(Newtonsoft.Json.Formatting.Indented));

            // Show a message to indicate that the file was saved
            MessageBox.Show("Configuration saved successfully!", "Save Config", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            string config_Path = "Config_Sort.json";
            if (File.Exists(config_Path))
            {
                // Read the existing JSON content
                string jsonString = File.ReadAllText(config_Path);
                var jsonContent = JObject.Parse(jsonString);

                // Find the "Extensions" section in the JSON
                var extensionsSection = (JObject)jsonContent["Type"];

                // Get the selected node in the treeView1
                TreeNode selectedNode = treeView1.SelectedNode;

                if (selectedNode != null && selectedNode.Parent == null) // Check if it's a category node
                {
                    // Prompt the user for the new extension to add
                    string newExtension = Microsoft.VisualBasic.Interaction.InputBox("Enter the new extension:", "New Extension", "", -1, -1);

                    if (!string.IsNullOrWhiteSpace(newExtension))
                    {
                        // Get the category from the selected node
                        string category = selectedNode.Text;

                        // Check if the category exists in the Extensions section
                        var categoryExtensions = (JArray)extensionsSection[category];

                        if (categoryExtensions != null)
                        {
                            // Add the new extension to the category
                            if (!categoryExtensions.Contains(newExtension))
                            {
                                categoryExtensions.Add(newExtension);

                                // Save the updated JSON back to the file
                                File.WriteAllText(config_Path, jsonContent.ToString());

                                // Update the TreeView by adding the new extension under the selected node
                                selectedNode.Nodes.Add(new TreeNode(newExtension));

                                MessageBox.Show($"New extension '{newExtension}' added to category '{category}'.");
                            }
                            else
                            {
                                MessageBox.Show("This extension already exists in the category.");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a valid category node to add the extension.");
                }
            }
        }

        private void button_Remove_Click(object sender, EventArgs e)
        {
            if (File.Exists("Config_Sort.json"))
            {
                // Read the existing JSON content
                string jsonString = File.ReadAllText("Config_Sort.json");
                var jsonContent = JObject.Parse(jsonString);

                // Find the "Extensions" section in the JSON
                var extensionsSection = (JObject)jsonContent["Type"];

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
                    File.WriteAllText("Config_Sort.json", jsonContent.ToString());

                    // Notify the user that the extension was removed
                    MessageBox.Show($"{NodeBranch} has been removed from the extensions.");

                    // After successful removal, repopulate the TreeView
                    string filePath = Path.GetFullPath("Config_Sort.json");
                    Populate_Inputs(filePath);
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
