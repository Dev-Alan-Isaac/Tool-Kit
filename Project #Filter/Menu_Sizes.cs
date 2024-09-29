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

        private void button_Saved_Click(object sender, EventArgs e)
        {
            // A helper function to convert size + unit into bytes for comparison
            long ConvertToBytes(string sizeText, string unit)
            {
                if (!long.TryParse(sizeText, out long size))
                {
                    MessageBox.Show("Invalid size input. Please enter valid numbers.");
                    return -1;
                }

                switch (unit.ToLower())
                {
                    case "bytes": return size;
                    case "kb": return size * 1024;
                    case "mb": return size * 1024 * 1024;
                    case "gb": return size * 1024 * 1024 * 1024;
                    case "tb": return size * 1024L * 1024L * 1024L * 1024L;
                    default:
                        MessageBox.Show("Invalid unit input.");
                        return -1;
                }
            }

            // Ensure the config file exists
            if (!File.Exists("Config_Size.json"))
            {
                MessageBox.Show("Config_Size.json file not found.");
                return;
            }

            // Read the existing JSON content
            string jsonString = File.ReadAllText("Config_Size.json");
            var jsonContent = JObject.Parse(jsonString);

            // Access the "Size" section
            var sizeSection = jsonContent["Size"] as JObject;

            if (sizeSection != null)
            {
                // Convert each size value to bytes for comparison
                long smallSize = ConvertToBytes(textBox_Small.Text, comboBox_SmallUnit.SelectedItem.ToString());
                long mediumSizeMin = ConvertToBytes(textBox_Medium.Text, comboBox_MediumUnit.SelectedItem.ToString());
                long mediumSizeMax = ConvertToBytes(textBox_Medium1.Text, comboBox_MediumUnit1.SelectedItem.ToString());
                long largeSizeMin = ConvertToBytes(textBox_Large.Text, comboBox_LargeUnit.SelectedItem.ToString());
                long largeSizeMax = ConvertToBytes(textBox_Large1.Text, comboBox_LargeUnit1.SelectedItem.ToString());
                long veryLargeSize = ConvertToBytes(textBox_VeryLarge.Text, comboBox_VeryLargeUnit.SelectedItem.ToString());

                // Ensure all sizes are valid (not -1)
                if (smallSize == -1 || mediumSizeMin == -1 || mediumSizeMax == -1 || largeSizeMin == -1 || largeSizeMax == -1 || veryLargeSize == -1)
                {
                    return;
                }

                // Validate size logic
                if (smallSize >= mediumSizeMin || mediumSizeMin >= mediumSizeMax || mediumSizeMax >= largeSizeMin || largeSizeMin >= largeSizeMax || largeSizeMax >= veryLargeSize)
                {
                    MessageBox.Show("Invalid size logic. Ensure that Small < Medium < Large < Very Large.");
                    return;
                }

                // Update Small
                sizeSection["Small"] = new JArray
                {
                    textBox_Small.Text,
                    comboBox_SmallUnit.SelectedItem.ToString()
                };

                // Update Medium
                sizeSection["Medium"] = new JArray
                {
                    textBox_Medium.Text,
                    comboBox_MediumUnit.SelectedItem.ToString(),
                    textBox_Medium1.Text,
                    comboBox_MediumUnit1.SelectedItem.ToString()
                };

                // Update Large
                sizeSection["Large"] = new JArray
                {
                    textBox_Large.Text,
                    comboBox_LargeUnit.SelectedItem.ToString(),
                    textBox_Large1.Text,
                    comboBox_LargeUnit1.SelectedItem.ToString()
                };

                // Update Very Large
                sizeSection["Very Large"] = new JArray
                {
                    textBox_VeryLarge.Text,
                    comboBox_VeryLargeUnit.SelectedItem.ToString()
                };

                // Write the updated JSON content back to the file
                File.WriteAllText("Config_Size.json", jsonContent.ToString());
                MessageBox.Show("Size configuration saved successfully.");
            }
        }
    }
}
