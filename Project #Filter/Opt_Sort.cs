﻿using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace Project__Filter
{
    public partial class Opt_Sort : UserControl
    {
        private string Path;
        private List<string> checkedItems = new List<string>();

        public Opt_Sort()
        {
            InitializeComponent();
        }

        private void button_Path_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    Path = fbd.SelectedPath;
                    textBox_Path.Text = Path;
                }
            }
        }

        private async void button_Filter_Click_1(object sender, EventArgs e)
        {
            string config_Path;
            // Iterate through each item in the checkedItems list
            foreach (string item in checkedItems)
            {
                switch (item)
                {
                    case "File Type":
                        config_Path = System.IO.Path.GetFullPath("Config_Type.json");
                        await Task.Run(() => SortTypes(Path, config_Path));
                        break;
                    case "File Size":
                        config_Path = System.IO.Path.GetFullPath("Config_Size.json");
                        await Task.Run(() => SortSize(Path, config_Path));
                        break;
                    case "File Date":
                        config_Path = System.IO.Path.GetFullPath("Config_Date.json");
                        await Task.Run(() => SortDates(Path, config_Path));
                        break;
                    case "File Name":
                        await Task.Run(() => SortNames(Path, "Config_Names.json"));
                        break;
                    case "File Permissions":
                        await Task.Run(() => SortPermissions(Path, "Config_Permissions.json"));
                        break;
                    case "Custom Tags":
                        await Task.Run(() => SortCustomTags(Path, "Config_Tags.json"));
                        break;
                    case "Folder Location":
                        await Task.Run(() => SortFolderLocation(Path, "Config_Folder.json"));
                        break;
                    case "Media Metadata (Videos/Audio)":
                        await Task.Run(() => SortMedia(Path, "Config_Media.json"));
                        break;
                    default:
                        break;
                }
            }
            // Optionally, you can split the list into sub-lists or do other kinds of processing here.
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            // Cast the sender to a CheckBox
            if (sender is CheckBox checkBox)
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
                    // Remove from the list if unchecked
                    checkedItems.Remove(checkboxText);
                }
            }

            // Enable the button if one or more items are checked, disable it if none are checked
            button_Filter.Enabled = checkedItems.Count > 0;
        }

        public async void SortTypes(string folderPath, string jsonPath)
        {
            if (!File.Exists(jsonPath))
            {
                MessageBox.Show("Config file not found.");
                return;
            }

            // Read and parse the JSON file
            string jsonString = await File.ReadAllTextAsync(jsonPath);
            var jsonContent = JObject.Parse(jsonString);

            // Get the "Extensions" and "Allow" sections from the JSON
            var extensions = jsonContent["Extensions"].ToObject<JObject>();
            var allow = jsonContent["Allow"].ToObject<JObject>();

            // Get all files in the target folder
            var files = Directory.GetFiles(folderPath);
            int totalFiles = files.Length;
            int processedFiles = 0;

            // Update the file count label
            Invoke((MethodInvoker)(() => File_Count.Text = $"Total Files: {totalFiles}"));

            // Process each file in the folder
            foreach (var file in files)
            {
                // Get the file extension (without the dot, in lowercase)
                string fileExtension = System.IO.Path.GetExtension(file).TrimStart('.').ToLower();

                // Check each category in "Allow"
                foreach (var allowCategory in allow)
                {
                    bool isAllowed = (bool)allowCategory.Value;
                    string category = allowCategory.Key;

                    // If the category is allowed
                    if (isAllowed)
                    {
                        // Get the list of extensions for this category
                        JArray categoryExtensions = (JArray)extensions[category];

                        // Ensure the comparison is string-based and case-insensitive
                        bool extensionExists = categoryExtensions
                            .Select(ext => ext.ToString().Trim().ToLower()) // Convert each extension to lowercase string
                            .Contains(fileExtension);

                        // If the file's extension matches any of the allowed extensions
                        if (extensionExists)
                        {
                            // Get the original directory of the file
                            string originalDirectory = System.IO.Path.GetDirectoryName(file);

                            // Create the target directory at the file's original location
                            string targetDirectory = System.IO.Path.Combine(originalDirectory, category);
                            if (!Directory.Exists(targetDirectory))
                            {
                                Directory.CreateDirectory(targetDirectory);
                            }

                            // Move the file to the target directory
                            string targetPath = System.IO.Path.Combine(targetDirectory, System.IO.Path.GetFileName(file));
                            File.Move(file, targetPath);
                        }
                    }
                }

                // Update the progress bar
                processedFiles++;
                int progress = (int)((double)processedFiles / totalFiles * 100);

                // Update the ProgressBar using Invoke to ensure thread safety
                progressBar_Time.Invoke((MethodInvoker)(() => progressBar_Time.Value = progress));
            }

            // Ensure the progress bar reaches 0% at the end
            progressBar_Time.Invoke((MethodInvoker)(() => progressBar_Time.Value = 0));
            MessageBox.Show("Sorting completed!");
        }

        private async void SortSize(string folderPath, string jsonPath)
        {
            if (!File.Exists(jsonPath))
            {
                MessageBox.Show("Config file not found.");
                return;
            }

            // Read and parse the JSON file
            string jsonString = await File.ReadAllTextAsync(jsonPath);
            var jsonContent = JObject.Parse(jsonString);

            // Get the "Size" section from the JSON
            var sizeSection = jsonContent["Size"] as JObject;

            if (sizeSection == null)
            {
                MessageBox.Show("Invalid JSON structure.");
                return;
            }

            // Define a function to convert size strings and units to bytes
            long ConvertToBytes(string sizeText, string unit)
            {
                if (!long.TryParse(sizeText, out long size))
                {
                    return -1;  // Invalid size
                }

                switch (unit.ToLower())
                {
                    case "bytes": return size;
                    case "kb": return size * 1024;
                    case "mb": return size * 1024 * 1024;
                    case "gb": return size * 1024 * 1024 * 1024;
                    case "tb": return size * 1024L * 1024L * 1024L * 1024L;
                    default: return -1;
                }
            }

            // Extract and convert size ranges to bytes
            long smallMax = ConvertToBytes(sizeSection["Small"][0].ToString(), sizeSection["Small"][1].ToString());
            long mediumMin = ConvertToBytes(sizeSection["Medium"][0].ToString(), sizeSection["Medium"][1].ToString());
            long mediumMax = ConvertToBytes(sizeSection["Medium"][2].ToString(), sizeSection["Medium"][3].ToString());
            long largeMin = ConvertToBytes(sizeSection["Large"][0].ToString(), sizeSection["Large"][1].ToString());
            long largeMax = ConvertToBytes(sizeSection["Large"][2].ToString(), sizeSection["Large"][3].ToString());
            long veryLargeMin = ConvertToBytes(sizeSection["Very Large"][0].ToString(), sizeSection["Very Large"][1].ToString());

            // Get all files in the folder
            var files = Directory.GetFiles(folderPath);
            int totalFiles = files.Length;
            int processedFiles = 0;

            // Update the file count label
            Invoke((MethodInvoker)(() => File_Count.Text = $"Total Files: {totalFiles}"));

            // Process each file in the folder
            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                long fileSize = fileInfo.Length;  // Size in bytes

                string targetCategory = null;

                // Determine the size category for the file
                if (fileSize <= smallMax)
                {
                    targetCategory = "Small";
                }
                else if (fileSize >= mediumMin && fileSize <= mediumMax)
                {
                    targetCategory = "Medium";
                }
                else if (fileSize >= largeMin && fileSize <= largeMax)
                {
                    targetCategory = "Large";
                }
                else if (fileSize >= veryLargeMin)
                {
                    targetCategory = "Very Large";
                }

                // If a category was determined, move the file
                if (targetCategory != null)
                {
                    // Get the original directory of the file
                    string originalDirectory = System.IO.Path.GetDirectoryName(file);

                    // Create the target directory at the file's original location
                    string targetDirectory = System.IO.Path.Combine(originalDirectory, targetCategory);

                    if (!Directory.Exists(targetDirectory))
                    {
                        Directory.CreateDirectory(targetDirectory);
                    }

                    // Move the file to the target directory
                    string targetPath = System.IO.Path.Combine(targetDirectory, System.IO.Path.GetFileName(file));
                    File.Move(file, targetPath);
                }

                // Update the progress bar
                processedFiles++;
                int progress = (int)((double)processedFiles / totalFiles * 100);

                // Update the ProgressBar using Invoke to ensure thread safety
                progressBar_Time.Invoke((MethodInvoker)(() => progressBar_Time.Value = progress));
            }

            // Ensure the progress bar reaches 0% at the end
            progressBar_Time.Invoke((MethodInvoker)(() => progressBar_Time.Value = 0));

            MessageBox.Show("Sorting completed!");
        }

        private async void SortDates(string folderPath, string jsonPath)
        {
            if (!File.Exists(jsonPath))
            {
                MessageBox.Show("Config file not found.");
                return;
            }

            // Read and parse the JSON file
            string jsonString = await File.ReadAllTextAsync(jsonPath);
            var jsonContent = JObject.Parse(jsonString);

            var option = jsonContent["Option"] as JObject;

            // Get all files in the folder
            var files = Directory.GetFiles(folderPath);
            var fileInfoList = files.Select(f => new FileInfo(f)).ToList();

            // Process each sorting option (Accessed, Creation, Modified) if it's set to true
            foreach (var allowOption in option)
            {
                bool isAllowed = (bool)allowOption.Value;
                string sortingOption = allowOption.Key;

                if (isAllowed)
                {
                    IEnumerable<FileInfo> sortedFiles;

                    // Sort the files based on the current option (Accessed, Creation, or Modified)
                    switch (sortingOption)
                    {
                        case "Accessed":
                            sortedFiles = fileInfoList.OrderBy(f => f.LastAccessTime);
                            break;
                        case "Creation":
                            sortedFiles = fileInfoList.OrderBy(f => f.CreationTime);
                            break;
                        case "Modified":
                            sortedFiles = fileInfoList.OrderBy(f => f.LastWriteTime);
                            break;
                        default:
                            continue; // Skip invalid options
                    }

                    // Move each file to a folder based on its date
                    foreach (var file in sortedFiles)
                    {
                        // Get the appropriate date depending on the sorting option
                        DateTime folderDate;
                        switch (sortingOption)
                        {
                            case "Accessed":
                                folderDate = file.LastAccessTime.Date;
                                break;
                            case "Creation":
                                folderDate = file.CreationTime.Date;
                                break;
                            case "Modified":
                                folderDate = file.LastWriteTime.Date;
                                break;
                            default:
                                continue; // Skip invalid options
                        }

                        // Create a folder named after the file's date
                        string targetDirectory = System.IO.Path.Combine(folderPath, folderDate.ToString("yyyy-MM-dd"));
                        if (!Directory.Exists(targetDirectory))
                        {
                            Directory.CreateDirectory(targetDirectory);
                        }

                        // Move the file to the respective date-named folder
                        string targetPath = System.IO.Path.Combine(targetDirectory, System.IO.Path.GetFileName(file.FullName));

                        // Ensure the file is not moved if it already exists in the target location
                        if (!File.Exists(targetPath))
                        {
                            File.Move(file.FullName, targetPath);
                        }
                    }
                }
            }

            MessageBox.Show("Files sorted by the selected date attributes!");
        }

        private async void SortNames(string folderPath, string jsonPath)
        {
            if (!File.Exists(jsonPath))
            {
                MessageBox.Show("Config file not found.");
                return;
            }

            // Read and parse the JSON file
            string jsonString = await File.ReadAllTextAsync(jsonPath);
            var jsonContent = JObject.Parse(jsonString);

            var option = jsonContent["Option"] as JObject;
            var additional = jsonContent["Additional"] as JObject;

            // Determine sorting options
            bool sortAlphabetically = (bool)option["Alphabetically"];
            bool sortByExtension = (bool)option["AlphabeticallyExtension"];
            bool caseSensitive = (bool)additional["Case"];
            bool ignoreSpecialCharacters = (bool)additional["Special"];

            // Get all files in the folder
            var files = Directory.GetFiles(folderPath);
            var fileInfoList = files.Select(f => new FileInfo(f)).ToList();

            // Define a function to remove special characters if needed
            string RemoveSpecialCharacters(string input)
            {
                return new string(input.Where(c => char.IsLetterOrDigit(c)).ToArray());
            }

            // Sort files based on the options
            IEnumerable<FileInfo> sortedFiles;
            if (sortByExtension)
            {
                // Sort by extension first, then by name
                sortedFiles = fileInfoList.OrderBy(f => f.Extension)
                                          .ThenBy(f => ignoreSpecialCharacters ? RemoveSpecialCharacters(f.Name) : f.Name);
            }
            else if (sortAlphabetically)
            {
                // Sort by name
                sortedFiles = fileInfoList.OrderBy(f => ignoreSpecialCharacters ? RemoveSpecialCharacters(f.Name) : f.Name);
            }
            else
            {
                MessageBox.Show("No sorting option selected.");
                return;
            }

            // Create folders and move files
            foreach (var file in sortedFiles)
            {
                string fileName = file.Name;
                string folderName;

                // Handle case sensitivity
                if (caseSensitive)
                {
                    folderName = fileName.Substring(0, 1); // First character of the file name
                }
                else
                {
                    folderName = fileName.Substring(0, 1).ToUpper(); // First character, case-insensitive
                }

                // Create folder based on first letter (with case-sensitivity if enabled)
                string targetDirectory = System.IO.Path.Combine(folderPath, folderName);
                if (!Directory.Exists(targetDirectory))
                {
                    Directory.CreateDirectory(targetDirectory);
                }

                // Move the file to the respective folder
                string targetPath = System.IO.Path.Combine(targetDirectory, file.Name);

                // Ensure the file is not moved if it already exists in the target location
                if (!File.Exists(targetPath))
                {
                    File.Move(file.FullName, targetPath);
                }
            }

            MessageBox.Show("Files sorted by the selected name attributes!");
        }


        private async void SortPermissions(string folderPath, string jsonPath)
        {

        }

        private async void SortCustomTags(string folderPath, string jsonPath)
        {

        }

        private async void SortFolderLocation(string folderPath, string jsonPath)
        {

        }

        private async void SortFileContent(string folderPath, string jsonPath)
        {

        }

        private async void SortMedia(string folderPath, string jsonPath)
        {

        }
    }
}