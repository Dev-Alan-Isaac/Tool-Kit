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
                if (!File.Exists("Config_Size.json"))
                {
                    var jsonContent = new JObject(
                         new JProperty("Size", new JObject(
                             new JProperty("Small", "100", "MB"),
                             new JProperty("Medium", "100", "MB", "1", "GB"),
                             new JProperty("Large", "1", "GB", "10", "GB"),
                             new JProperty("Very Large", "10", "GB")
                         ))
                    );

                    File.WriteAllText("Config_Size.json", jsonContent.ToString());
                }
                string filePath = Path.GetFullPath("Config_Size.json");
                Populate_Inputs(filePath);
                break;
            }
        }

        private void Populate_Inputs(string FilePath)
        {
            if (File.Exists(FilePath))
            {
                // Read the JSON content from the file
                string jsonContent = File.ReadAllText(FilePath);

                // Deserialize the JSON content into a JObject
                var jsonObject = JsonConvert.DeserializeObject<JObject>(jsonContent);

                // Access the "Size" object inside the JSON
                var sizeObject = jsonObject["Size"] as JObject;

                if (sizeObject != null)
                {
                    // Populate Small
                    var smallValues = sizeObject["Small"]?.ToObject<string[]>();
                    if (smallValues != null && smallValues.Length > 0)
                    {
                        textBox_Small.Text = smallValues[0]; // The numeric value
                        comboBox_SmallUnit.SelectedItem = smallValues[1]; // The unit
                    }

                    // Populate Medium
                    var mediumValues = sizeObject["Medium"]?.ToObject<string[]>();
                    if (mediumValues != null && mediumValues.Length > 0)
                    {
                        textBox_Medium.Text = mediumValues[0]; // First numeric value
                        comboBox_MediumUnit.SelectedItem = mediumValues[1]; // First unit
                        textBox_Medium1.Text = mediumValues[2];
                        comboBox_MediumUnit1.SelectedItem = mediumValues[3];

                    }

                    // Populate Large
                    var largeValues = sizeObject["Large"]?.ToObject<string[]>();
                    if (largeValues != null && largeValues.Length > 0)
                    {
                        textBox_Large.Text = largeValues[0]; // First numeric value
                        comboBox_LargeUnit.SelectedItem = largeValues[1]; // First unit
                        textBox_Large1.Text = largeValues[2];
                        comboBox_LargeUnit1.SelectedItem = largeValues[3];
                    }

                    // Populate Very Large
                    var veryLargeValues = sizeObject["Very Large"]?.ToObject<string[]>();
                    if (veryLargeValues != null && veryLargeValues.Length > 0)
                    {
                        textBox_VeryLarge.Text = veryLargeValues[0]; // The numeric value
                        comboBox_VeryLargeUnit.SelectedItem = veryLargeValues[1]; // The unit
                    }
                }
            }
        }

    }
}
