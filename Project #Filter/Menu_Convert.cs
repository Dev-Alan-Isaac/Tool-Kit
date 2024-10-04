using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SharpCompress.Common;
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
    public partial class Menu_Convert : UserControl
    {
        public Menu_Convert()
        {
            InitializeComponent();
        }

        private void Menu_Transform_Load(object sender, EventArgs e)
        {
            while (true)
            {
                if (!File.Exists("Config_Transform.json"))
                {
                    // Create the JSON object
                    var jsonContent = new JObject(
                        new JProperty("Option", new JObject(
                            new JProperty("Delete", true),
                            new JProperty("Subfolder", true),
                            new JProperty("Original", true),
                            new JProperty("Custom", false),
                            new JProperty("ByDate", true),
                            new JProperty("ByName", false),
                            new JProperty("BySize", false)
                        ))
                    );

                    // Save to a file (e.g., "Extensions.json")
                    File.WriteAllText("Config_Transform.json", jsonContent.ToString());
                }

                // File already exists; get the filepath
                string filePath = Path.GetFullPath("Config_Transform.json");
                PopulateInputs(filePath);
                break;
            }
        }

        private void PopulateInputs(string filePath)
        {
            if (File.Exists(filePath))
            {
                // Read the JSON content from the file
                string jsonContent = File.ReadAllText(filePath);

                // Deserialize the JSON content into a JObject
                var jsonObject = JObject.Parse(jsonContent);

                // Check if the "Option" property exists
                if (jsonObject["Option"] != null)
                {
                    bool isDelete = jsonObject["Option"]["Delete"]?.ToObject<bool>() ?? false;
                    bool isSubfolder = jsonObject["Option"]["Subfolder"]?.ToObject<bool>() ?? false;
                    bool isOriginal = jsonObject["Option"]["Original"]?.ToObject<bool>() ?? false;
                    bool isCustom = jsonObject["Option"]["Custom"]?.ToObject<bool>() ?? false;
                    bool isDate = jsonObject["Option"]["ByDate"]?.ToObject<bool>() ?? false;
                    bool isName = jsonObject["Option"]["ByName"]?.ToObject<bool>() ?? false;
                    bool isSize = jsonObject["Option"]["BySize"]?.ToObject<bool>() ?? false;


                    checkBox_Delete.Checked = isDelete;
                    checkBox_Subfolders.Checked = isSubfolder;

                    if (isDate)
                    {
                        radioButton_Date.Checked = isDate;
                    }
                    else if (isName)
                    {
                        radioButton_Name.Checked = isName;
                    }
                    else if (isSize)
                    {
                        radioButton_Size.Checked = isSize;
                    }
                }
            }
        }

        private void button_Saved_Click(object sender, EventArgs e)
        {

        }
    }
}