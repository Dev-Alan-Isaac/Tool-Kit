﻿using Newtonsoft.Json;
using SharpCompress;

namespace Project__Filter
{
    public partial class Filter : UserControl
    {
        string selectedPath;
        Dictionary<string, List<string>> myDict;

        public Filter()
        {
            InitializeComponent();
        }

        private void Filter_Load(object sender, EventArgs e)
        {
            if (File.Exists("Config.json"))
            {
                string json = File.ReadAllText("Config.json");
                myDict = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(json);
            }
        }

        private void button_Path_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    selectedPath = fbd.SelectedPath;
                    textBox_Path.Text = selectedPath;
                }
            }
        }

        private void button_Filter_Click(object sender, EventArgs e)
        {
            List<string> checkedBoxes = new List<string>();

            foreach (Control control in this.Controls)
            {
                if (control is CheckBox)
                {
                    CheckBox checkBox = control as CheckBox;
                    if (checkBox.Checked)
                    {
                        checkedBoxes.Add(checkBox.Name);
                    }
                }
            }

            if (checkedBoxes.Count > 0)
            {
                // Call the Filter function
                if (!string.IsNullOrEmpty(selectedPath))
                {
                    FilterSort(selectedPath, myDict, checkedBoxes);
                }
                else
                {
                    MessageBox.Show("Not selected path");
                }
            }
            else
            {
                MessageBox.Show("No checkboxes are checked.");
            }
        }

        private void FilterSort(string path, Dictionary<string, List<string>> myDict, List<string> Check)
        {
            string[] files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);

            foreach (string file in files)
            {
                // Get the file extension
                string extension = Path.GetExtension(file).TrimStart('.').ToLower();

                // Check if the dictionary contains the extension
                foreach (var entry in myDict)
                {
                    if (entry.Value.Contains(extension))
                    {
                        // Get the destination folder
                        string destinationFolder = Path.Combine(path, entry.Key);

                        // Create the destination folder, if it doesn't exist
                        Directory.CreateDirectory(destinationFolder);

                        // Get the destination file path
                        string destinationFile = Path.Combine(destinationFolder, Path.GetFileName(file));

                        // Move the file
                        File.Move(file, destinationFile);


                        break;
                    }
                }
            }

            // Call the appropriate sorting method based on the Check list
            foreach (string check in Check)
            {
                switch (check)
                {
                    case "checkBox_Include":
                        string searchText = Microsoft.VisualBasic.Interaction.InputBox("Enter the text to search for:", "Search Text", "Default", -1, -1);
                        if (!string.IsNullOrEmpty(searchText))
                        {
                            sortContain(selectedPath, searchText);
                        }
                        break;
                    case "checkBox_AtoZ":
                        sortAlphabetical(selectedPath);
                        break;
                    case "checkBox_Resolution":
                        sortResolution(selectedPath);
                        break;
                    case "checkBox_Size":
                        sortSize(selectedPath);
                        break;
                    case "checkBox_Duration":
                        sortDuration(selectedPath);
                        break;
                }
            }
        }

        private void sortContain(string path, string searchText)
        {
            // If the user clicked "Cancel" in the InputBox, the searchText will be an empty string
            if (!string.IsNullOrEmpty(searchText))
            {
                // Get all files in the directory and its subdirectories
                string[] files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);

                // Convert the search text to lowercase for case-insensitive comparison
                string lowerCaseSearchText = searchText.ToLower();

                // Search for files that contain the search text in their names
                var foundFiles = files.Where(file => Path.GetFileName(file).ToLower().Contains(lowerCaseSearchText)).ToList();

                if (foundFiles.Count > 0)
                {
                    // Show a message box with the paths of the found files
                    string message = "Found files:\n" + string.Join("\n", foundFiles);
                    MessageBox.Show(message);
                }
                else
                {
                    // Show a message box indicating that no files were found
                    MessageBox.Show("No files found with the name: " + searchText);
                }
            }
        }

        private void sortAlphabetical(string path)
        {
            // Get all files in the directory and its subdirectories
            string[] files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);

            // Sort the files alphabetically by name
            var sortedFiles = files.OrderBy(file => Path.GetFileName(file)).ToList();

            if (sortedFiles.Count > 0)
            {
                // Create a dictionary to store the files grouped by the first letter of their names
                var filesGroupedByFirstLetter = new Dictionary<string, List<string>>();

                foreach (var file in sortedFiles)
                {
                    string fileName = Path.GetFileName(file);
                    string firstLetter = fileName.Substring(0, 1).ToUpper();

                    if (!filesGroupedByFirstLetter.ContainsKey(firstLetter))
                    {
                        filesGroupedByFirstLetter[firstLetter] = new List<string>();
                    }

                    filesGroupedByFirstLetter[firstLetter].Add(file);
                }

                // Show a message box with the paths of the sorted files
                string message = "";
                foreach (var group in filesGroupedByFirstLetter)
                {
                    message += group.Key + ": Files\n" + string.Join("\n", group.Value) + "\n\n";
                }
                MessageBox.Show(message);
            }
            else
            {
                // Show a message box indicating that no files were found
                MessageBox.Show("No files found in the directory: " + path);
            }
        }

        private void sortSize(string path)
        {
            // Get all files in the directory and its subdirectories
            string[] files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);

            // Sort the files by size
            var sortedFiles = files.OrderBy(file => new FileInfo(file).Length).ToList();

            if (sortedFiles.Count > 0)
            {
                // Show a message box with the paths of the sorted files
                string message = "Files sorted by size:\n" + string.Join("\n", sortedFiles.Select(file => $"{file}: {new FileInfo(file).Length} bytes"));
                MessageBox.Show(message);
            }
            else
            {
                // Show a message box indicating that no files were found
                MessageBox.Show("No files found in the directory: " + path);
            }
        }


        private void sortResolution(string path) { }

        private void sortDuration(string path) { }
    }
}