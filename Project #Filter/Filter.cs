﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using static System.Windows.Forms.Design.AxImporter;

namespace Project__Filter
{
    public partial class Filter : UserControl
    {
        private string folderPath;
        Dictionary<string, object> JsonData;
        Actions actions = new Actions();

        public Filter()
        {
            InitializeComponent();
        }

        private void Filter_Load(object sender, EventArgs e)
        {
            string filePath = "Config.json";

            if (!File.Exists(filePath))
            {
                MessageBox.Show("Error No config File Found");
            }
            else
            {
                // Read the JSON file
                string json = File.ReadAllText(filePath);

                // Deserialize the JSON string to a dictionary
                JsonData = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            }
        }

        private void button_Path_Click(object sender, EventArgs e)
        {
            folderPath = actions.OpenFolderManager();
            textBox_Path.Text = folderPath;
        }

        private void button_Filter_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(folderPath))
            {
                List<CheckBox> checkedCheckBoxes = actions.GetCheckedCheckBoxes(this);

                if (checkedCheckBoxes.Count > 0)
                {
                    // Handle the action for each checked checkbox
                    foreach (CheckBox checkBox in checkedCheckBoxes)
                    {
                        switch (checkBox.Name)
                        {
                            case "checkBox_Include":
                                string inputInclude = Microsoft.VisualBasic.Interaction.InputBox("Enter the text to search for:", "Search Text", "Default", -1, -1);
                                actions.OrganizeFilesBasedOnCriteria(folderPath, JsonData, inputInclude);
                                break;
                            case "checkBox_Exclude":
                                string inputExclude = Microsoft.VisualBasic.Interaction.InputBox("Enter the text to search for:", "Search Text", "Default", -1, -1);
                                //actions.HandleExclude(folderPath, inputExclude);
                                break;
                            case "checkBox_Extension":
                                actions.HandleExtension(folderPath);
                                break;
                            case "checkBox_Resolution":
                                break;
                            case "checkBox_Duration":
                                break;
                            case "checkBox_Size":
                                break;
                            case "checkBox_Date":
                                break;
                            case "checkBox_AtoZ":
                                break;
                            case "checkBox_Delete":
                                break;
                            default:
                                MessageBox.Show("Error !!!");
                                break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No checkbox is checked.");
                }
            }
            else
            {
                MessageBox.Show("No Folder Selected.");
            }
        }

        private void checkBox_Include_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Include.Checked)
            {
                checkBox_Exclude.Checked = false;
            }
        }

        private void checkBox_Exclude_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Exclude.Checked)
            {
                checkBox_Include.Checked = false;
            }
        }


    }
}
