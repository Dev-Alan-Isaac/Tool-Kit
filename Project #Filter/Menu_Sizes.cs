using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

                // Access the "Size" object inside the JSON
                var sizeObject = jsonObject["Size"] as JObject;

                if (sizeObject != null)
                {
                    // Populate Small
                    var smallValues = sizeObject["Small"]?.ToObject<string[]>();
                    if (smallValues != null && smallValues.Length > 0)
                    {
                        numericUpDown_Small.Text = smallValues[0]; // The numeric value
                        comboBox_SmallUnit.SelectedItem = smallValues[1]; // The unit
                    }

                    // Populate Medium
                    var mediumValues = sizeObject["Medium"]?.ToObject<string[]>();
                    if (mediumValues != null && mediumValues.Length > 0)
                    {
                        numericUpDown_MediumMin.Text = mediumValues[0]; // First numeric value
                        comboBox_MediumUnit.SelectedItem = mediumValues[1]; // First unit
                        numericUpDown_MediumMax.Text = mediumValues[2];
                        comboBox_MediumUnit1.SelectedItem = mediumValues[3];

                    }

                    // Populate Large
                    var largeValues = sizeObject["Large"]?.ToObject<string[]>();
                    if (largeValues != null && largeValues.Length > 0)
                    {
                        numericUpDown_LargeMin.Text = largeValues[0]; // First numeric value
                        comboBox_LargeUnit.SelectedItem = largeValues[1]; // First unit
                        numericUpDown_LargeMax.Text = largeValues[2];
                        comboBox_LargeUnit1.SelectedItem = largeValues[3];
                    }

                    // Populate Very Large
                    var veryLargeValues = sizeObject["Very Large"]?.ToObject<string[]>();
                    if (veryLargeValues != null && veryLargeValues.Length > 0)
                    {
                        numericUpDown_VeryLarge.Text = veryLargeValues[0]; // The numeric value
                        comboBox_VeryLargeUnit.SelectedItem = veryLargeValues[1]; // The unit
                    }
                }
            }
        }

        private void button_Saved_Click(object sender, EventArgs e)
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

            // ConvertToBytes method to handle the conversion
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

            // Convert the input values
            long smallSizeMax = ConvertToBytes(numericUpDown_Small.Value.ToString(), comboBox_SmallUnit.SelectedItem.ToString());
            long mediumSizeMin = ConvertToBytes(numericUpDown_MediumMin.Value.ToString(), comboBox_MediumUnit.SelectedItem.ToString());
            long mediumSizeMax = ConvertToBytes(numericUpDown_MediumMax.Value.ToString(), comboBox_MediumUnit1.SelectedItem.ToString());
            long largeSizeMin = ConvertToBytes(numericUpDown_LargeMin.Value.ToString(), comboBox_LargeUnit.SelectedItem.ToString());
            long largeSizeMax = ConvertToBytes(numericUpDown_LargeMax.Value.ToString(), comboBox_LargeUnit1.SelectedItem.ToString());
            long veryLargeSize = ConvertToBytes(numericUpDown_VeryLarge.Value.ToString(), comboBox_VeryLargeUnit.SelectedItem.ToString());

            // Check for invalid sizes
            if (smallSizeMax == -1 || mediumSizeMin == -1 || mediumSizeMax == -1 || largeSizeMin == -1 || largeSizeMax == -1 || veryLargeSize == -1)
            {
                return;
            }

            if (mediumSizeMin < smallSizeMax || mediumSizeMin >= mediumSizeMax || largeSizeMin < mediumSizeMax || largeSizeMin >= largeSizeMax || veryLargeSize < largeSizeMax)
            {
                MessageBox.Show("Invalid size logic. Ensure correct ranges for Small, Medium, Large, and Very Large.");
                return;
            }

            // Save the values into the JSON object
            jsonObject["Size"]["Small"] = new JArray(numericUpDown_Small.Value.ToString(), comboBox_SmallUnit.SelectedItem.ToString());
            jsonObject["Size"]["MediumMin"] = new JArray(numericUpDown_MediumMin.Value.ToString(), comboBox_MediumUnit.SelectedItem.ToString());
            jsonObject["Size"]["MediumMax"] = new JArray(numericUpDown_MediumMax.Value.ToString(), comboBox_MediumUnit1.SelectedItem.ToString());
            jsonObject["Size"]["LargeMin"] = new JArray(numericUpDown_LargeMin.Value.ToString(), comboBox_LargeUnit.SelectedItem.ToString());
            jsonObject["Size"]["LargeMax"] = new JArray(numericUpDown_LargeMax.Value.ToString(), comboBox_LargeUnit1.SelectedItem.ToString());
            jsonObject["Size"]["VeryLarge"] = new JArray(numericUpDown_VeryLarge.Value.ToString(), comboBox_VeryLargeUnit.SelectedItem.ToString());

            // Write the modified JSON object back to the file
            File.WriteAllText(filePath, jsonObject.ToString(Formatting.Indented));

            // Show a message to indicate that the file was saved
            MessageBox.Show("Configuration saved successfully!", "Save Config", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}