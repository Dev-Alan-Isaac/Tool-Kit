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
    public partial class Menu_Name : UserControl
    {
        public Menu_Name()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            while (true)
            {
                if (!File.Exists("Config_Names.json"))
                {
                    // Create the JSON object
                    var jsonContent = new JObject(
                         new JProperty("Option", new JObject(
                             new JProperty("Alphabetically", true),
                             new JProperty("AlphabeticallyExtension", false)
                         )),
                         new JProperty("Additional", new JObject(
                             new JProperty("Case", true),
                             new JProperty("Special", true)
                         ))
                     );


                    // Save to a file (e.g., "Extensions.json")
                    File.WriteAllText("Config_Names.json", jsonContent.ToString());
                }

                // File already exists; get the filepath
                string filePath = Path.GetFullPath("Config_Names.json");
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

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
