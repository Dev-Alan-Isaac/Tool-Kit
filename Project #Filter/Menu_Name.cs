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

                // Access the "Option" object
                var optionObject = jsonObject["Option"] as JObject;
                if (optionObject != null)
                {
                    // Create a parent node for Options
                    var optionNode = new TreeNode("Option");

                    // Iterate through each key-value pair in the Option object
                    foreach (var option in optionObject.Properties())
                    {
                        var optionChildNode = new TreeNode($"{option.Name}: {option.Value}");
                        optionNode.Nodes.Add(optionChildNode);
                    }

                    // Add the Option node to the TreeView
                    treeView1.Nodes.Add(optionNode);
                }

                // Access the "Additional" object
                var additionalObject = jsonObject["Additional"] as JObject;
                if (additionalObject != null)
                {
                    // Create a parent node for Additional
                    var additionalNode = new TreeNode("Additional");

                    // Iterate through each key-value pair in the Additional object
                    foreach (var additional in additionalObject.Properties())
                    {
                        var additionalChildNode = new TreeNode($"{additional.Name}: {additional.Value}");
                        additionalNode.Nodes.Add(additionalChildNode);
                    }

                    // Add the Additional node to the TreeView
                    treeView1.Nodes.Add(additionalNode);
                }
            }
        }


        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
