using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public partial class Menu_Sizes : UserControl
    {
        public Menu_Sizes()
        {
            InitializeComponent();
        }

        private void Menu_Sizes_Load(object sender, EventArgs e)
        {
            while (true)
            {
                if (!File.Exists("Size.json"))
                {
                    var jsonContent = new JObject(
                         new JProperty("Size", new JObject(
                             new JProperty("Small", "100", "MB"),
                             new JProperty("Medium", "100", "MB", "1", "GB"),
                             new JProperty("Large", "1", "GB", "10", "GB"),
                             new JProperty("Very Large", "10", "GB")
                         ))
                    );

                    File.WriteAllText("Size.json", jsonContent.ToString());
                }

                // File already exists; get the filepath
                string filePath = Path.GetFullPath("Size.json");
                PopulateTree(filePath);
                break;
            }
        }

        private void button_Saved_Click(object sender, EventArgs e)
        {

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
                var extensionsObject = jsonObject["Size"] as JObject; // Explicit cast to JObject

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
    }
}
