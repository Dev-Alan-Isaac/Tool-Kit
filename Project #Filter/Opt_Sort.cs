using System.Diagnostics;
using System.Security.Cryptography;
using Newtonsoft.Json.Linq;
using NReco.VideoInfo;
using Org.BouncyCastle.Crypto;

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

        private async void button_Filter_Click_1(object sender, EventArgs e)
        {
            string config_Path, config_Path2, Config_Sort = "Config_Sort.json";

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
                        config_Path = System.IO.Path.GetFullPath("Config_Names.json");
                        await Task.Run(() => SortNames(Path, config_Path));
                        break;
                    case "File Permissions":
                        config_Path = System.IO.Path.GetFullPath("Config_Names.json");
                        config_Path2 = System.IO.Path.GetFullPath("Config_Type.json");
                        await Task.Run(() => SortPermissions(Path, config_Path, config_Path2));
                        break;
                    case "Custom Tags":
                        config_Path = System.IO.Path.GetFullPath("Config_Tags.json");
                        await Task.Run(() => SortCustomTags(Path, config_Path));
                        break;
                    case "Folder Location":
                        config_Path = System.IO.Path.GetFullPath("Config_Folder.json");
                        await Task.Run(() => SortFolderLocation(Path, config_Path));
                        break;
                    case "Media Metadata":
                        config_Path = System.IO.Path.GetFullPath("Config_Media.json");
                        config_Path2 = System.IO.Path.GetFullPath("Config_Type.json");
                        await Task.Run(() => SortMedia(Path, config_Path, config_Path2));
                        break;
                    case "File Hash":
                        config_Path = System.IO.Path.GetFullPath("Config_Type.json");
                        await Task.Run(() => SortHash(Path, config_Path));
                        break;
                    default:
                        break;
                }
            }
        }

        public async Task<string[]> ProcessFiles(string parentPath)
        {
            string config_file = "Config_Sort.json";

            if (!File.Exists(config_file))
            {
                MessageBox.Show("Config file not found.");
                return Array.Empty<string>(); // Return an empty array if the config file doesn't exist
            }

            // Read and parse the JSON file
            string jsonString = await File.ReadAllTextAsync(config_file);
            var jsonContent = JObject.Parse(jsonString);

            bool processSubfolders = (bool)jsonContent["Option"]["Subfolder"];

            // Get files based on whether subfolder processing is allowed
            var files = processSubfolders
                ? Directory.GetFiles(parentPath, "*.*", SearchOption.AllDirectories)
                : Directory.GetFiles(parentPath);

            return files; // Return the list of file paths
        }

        public void DeleteEmptyFolders(string folderPath)
        {
            foreach (var directory in Directory.GetDirectories(folderPath))
            {
                DeleteEmptyFolders(directory); // Recursively delete empty subfolders

                // If the directory is empty after processing subfolders, delete it
                if (Directory.GetFiles(directory).Length == 0 && Directory.GetDirectories(directory).Length == 0)
                {
                    Directory.Delete(directory);
                }
            }
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
            var files = await ProcessFiles(folderPath);
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
            DeleteEmptyFolders(folderPath);
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
            var files = await ProcessFiles(folderPath);
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
            var files = await ProcessFiles(folderPath);
            int totalFiles = files.Length;
            var fileInfoList = files.Select(f => new FileInfo(f)).ToList();

            // Update the file count label
            Invoke((MethodInvoker)(() => File_Count.Text = $"Total Files: {totalFiles}"));

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
            var files = await ProcessFiles(folderPath);
            int totalFiles = files.Length;
            var fileInfoList = files.Select(f => new FileInfo(f)).ToList();

            // Update the file count label
            Invoke((MethodInvoker)(() => File_Count.Text = $"Total Files: {totalFiles}"));

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

        private async void SortHash(string folderPath, string jsonPath)
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

            // List to hold the filtered files
            List<string> allowedFiles = new List<string>();

            // Get all files in the target folder
            var files = await ProcessFiles(folderPath);

            // Filter the files based on the "Allow" section of the JSON
            foreach (var file in files)
            {
                string extension = System.IO.Path.GetExtension(file).ToLower();

                // Check which media types are allowed (e.g., Images, Videos, etc.)
                foreach (var mediaType in allow)
                {
                    bool isAllowed = (bool)mediaType.Value;

                    if (isAllowed && extensions[mediaType.Key] != null)
                    {
                        var allowedExtensions = extensions[mediaType.Key].ToObject<string[]>();

                        if (allowedExtensions.Any(ext => ext.Equals(extension, StringComparison.OrdinalIgnoreCase)))
                        {
                            allowedFiles.Add(file);
                        }
                    }
                }
            }

            int totalFiles = allowedFiles.Count;
            int processedFiles = 0;

            // Update the file count label
            Invoke((MethodInvoker)(() => File_Count.Text = $"Total Files: {totalFiles}"));

            // Dictionary to group files by hash
            Dictionary<string, List<string>> hashGroups = new Dictionary<string, List<string>>();

            // Process each allowed file
            foreach (var file in allowedFiles)
            {
                try
                {
                    // Compute the file's hash
                    string fileHash = ComputeFileHash(file);

                    // Add the file to the correct hash group
                    if (!hashGroups.ContainsKey(fileHash))
                    {
                        hashGroups[fileHash] = new List<string>();
                    }
                    hashGroups[fileHash].Add(file);

                    processedFiles++;

                    // Update progress bar or status (optional)
                    Invoke((MethodInvoker)(() => progressBar_Time.Value = processedFiles));

                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error processing file {file}: {ex.Message}");
                }
            }

            // Sort the files into folders based on their hash
            int hashFolderCount = 1;
            foreach (var group in hashGroups)
            {
                // Create a folder for the group of files that share the same hash
                string hashFolder = System.IO.Path.Combine(folderPath, $"Hash{hashFolderCount}");

                if (!Directory.Exists(hashFolder))
                {
                    Directory.CreateDirectory(hashFolder);
                }

                // Move the files into the folder
                foreach (var file in group.Value)
                {
                    string destinationFile = System.IO.Path.Combine(hashFolder, System.IO.Path.GetFileName(file));

                    if (!File.Exists(destinationFile))
                    {
                        File.Move(file, destinationFile);
                        Debug.WriteLine($"Moved file {file} to {destinationFile}");
                    }
                    else
                    {
                        Debug.WriteLine($"File already exists: {destinationFile}. Skipping move.");
                    }
                }

                hashFolderCount++;
            }

            // Done
            MessageBox.Show("File sorting by hash completed!");
        }

        private string ComputeFileHash(string filePath)
        {
            using (var sha256 = SHA256.Create())
            {
                using (var stream = File.OpenRead(filePath))
                {
                    byte[] hashBytes = sha256.ComputeHash(stream);
                    return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                }
            }
        }

        private async void SortPermissions(string folderPath, string jsonPath, string configTypePath)
        {
            if (!File.Exists(jsonPath) || !File.Exists(configTypePath))
            {
                MessageBox.Show("Config file not found.");
                return;
            }

            // Read and parse the JSON files
            string jsonString = await File.ReadAllTextAsync(jsonPath);
            var jsonContent = JObject.Parse(jsonString);

            string configTypeString = await File.ReadAllTextAsync(configTypePath);
            var configTypeContent = JObject.Parse(configTypeString);

            var option = jsonContent["Option"] as JObject;

            // Get the executable extensions from Config_Type.json
            var executableExtensions = configTypeContent["Extensions"]["Executables"].ToObject<List<string>>();

            // Get all files in the folder
            var files = await ProcessFiles(folderPath);
            int totalFiles = files.Length;

            // Update the file count label
            Invoke((MethodInvoker)(() => File_Count.Text = $"Total Files: {totalFiles}"));

            // Process each sorting option (Readable, Writable, Executable)
            foreach (var allowOption in option)
            {
                bool isAllowed = (bool)allowOption.Value;
                string sortingOption = allowOption.Key;

                if (isAllowed)
                {
                    foreach (var file in files)
                    {
                        FileInfo fileInfo = new FileInfo(file);

                        // Check the file properties based on sorting option
                        switch (sortingOption)
                        {
                            case "Readable":
                                if (fileInfo.IsReadOnly == false) // Check if file is readable
                                {
                                    MoveFileToFolder(fileInfo, sortingOption, folderPath);
                                }
                                break;
                            case "Writable":
                                if (fileInfo.IsReadOnly == false) // Check if file is writable
                                {
                                    MoveFileToFolder(fileInfo, sortingOption, folderPath);
                                }
                                break;
                            case "Executable":
                                string fileExtension = fileInfo.Extension.TrimStart('.').ToLower();
                                if (executableExtensions.Contains(fileExtension)) // Check if file is executable
                                {
                                    MoveFileToFolder(fileInfo, sortingOption, folderPath);
                                }
                                break;
                        }
                    }
                }
            }

            MessageBox.Show("Files sorted by permissions!");
        }

        private void MoveFileToFolder(FileInfo file, string folderName, string baseFolderPath)
        {
            string targetDirectory = System.IO.Path.Combine(baseFolderPath, folderName);

            if (!Directory.Exists(targetDirectory))
            {
                Directory.CreateDirectory(targetDirectory);
            }

            string targetPath = System.IO.Path.Combine(targetDirectory, file.Name);
            if (!File.Exists(targetPath))
            {
                File.Move(file.FullName, targetPath);
            }
        }

        private async void SortCustomTags(string folderPath, string jsonPath)
        {
            if (!File.Exists(jsonPath))
            {
                MessageBox.Show("Config file not found.");
                return;
            }

            // Read and parse the JSON file
            string jsonString = await File.ReadAllTextAsync(jsonPath);
            var jsonContent = JObject.Parse(jsonString);

            // Get the "Tags" array from the JSON
            var tagsArray = jsonContent["Option"]["Tags"] as JArray;

            if (tagsArray == null || !tagsArray.Any())
            {
                MessageBox.Show("No tags found in the JSON file.");
                return;
            }

            // Get all files in the target folder
            var files = await ProcessFiles(folderPath);
            int totalFiles = files.Length;

            // Update the file count label
            Invoke((MethodInvoker)(() => File_Count.Text = $"Total Files: {totalFiles}"));


            foreach (var file in files)
            {
                // Get the file name (without the path)
                string fileName = System.IO.Path.GetFileName(file);

                // Check if the file name starts with any tag
                foreach (var tag in tagsArray)
                {
                    string tagString = tag.ToString();
                    string tagPrefix = $"[{tagString}]";

                    if (fileName.StartsWith(tagPrefix))
                    {
                        // Create the target directory based on the tag if it doesn't exist
                        string targetDirectory = System.IO.Path.Combine(folderPath, tagString);
                        if (!Directory.Exists(targetDirectory))
                        {
                            Directory.CreateDirectory(targetDirectory);
                        }

                        // Move the file to the target directory
                        string targetPath = System.IO.Path.Combine(targetDirectory, fileName);
                        File.Move(file, targetPath);

                        // Optionally, show a message indicating the file has been moved
                        MessageBox.Show($"Moved {fileName} to {targetDirectory}");
                        break; // Once the file is moved, stop checking other tags for this file
                    }
                }
            }
        }

        private async void SortFolderLocation(string folderPath, string jsonPath)
        {
            if (!File.Exists(jsonPath))
            {
                MessageBox.Show("Config file not found.");
                return;
            }

            // Read and parse the JSON file
            string jsonString = await File.ReadAllTextAsync(jsonPath);
            var jsonContent = JObject.Parse(jsonString);

            // Get the "Option" section from the JSON
            bool sortByAlphabetical = (bool)jsonContent["Option"]["Alphabetical"];
            bool sortByDepth = (bool)jsonContent["Option"]["Depth"];

            // Ensure only one of them is true
            if (sortByAlphabetical && sortByDepth)
            {
                MessageBox.Show("Error: Both Alphabetical and Depth sorting cannot be enabled at the same time.");
                return;
            }

            // Get all directories in the target folder
            var directories = Directory.GetDirectories(folderPath);

            // Prepare a list to store directories and their depth
            var directoryDepths = new List<(string Directory, int Depth)>();

            foreach (var dir in directories)
            {
                // Get the number of subfolders (depth) inside this directory
                int depth = GetFolderDepth(dir);
                directoryDepths.Add((dir, depth));
            }

            // Sort directories based on the specified criteria
            if (sortByAlphabetical)
            {
                // Sort only by name (alphabetical order)
                directoryDepths = directoryDepths.OrderBy(d => System.IO.Path.GetFileName(d.Directory)).ToList();
            }
            else if (sortByDepth)
            {
                // Sort only by depth (number of subfolders)
                directoryDepths = directoryDepths.OrderBy(d => d.Depth).ToList();
            }

            // Move the folders based on the sorted list
            foreach (var (dir, depth) in directoryDepths)
            {
                // Create a folder for each depth level if it doesn't exist
                string targetDirectory;
                if (sortByAlphabetical)
                {
                    // If sorting alphabetically, create folders for each alphabet group
                    string firstLetter = System.IO.Path.GetFileName(dir).Substring(0, 1).ToUpper();
                    targetDirectory = System.IO.Path.Combine(folderPath, firstLetter);
                }
                else
                {
                    // If sorting by depth, create folders for each depth level
                    targetDirectory = System.IO.Path.Combine(folderPath, depth.ToString());
                }

                if (!Directory.Exists(targetDirectory))
                {
                    Directory.CreateDirectory(targetDirectory);
                }

                // Move the folder to the target location
                string newFolderPath = System.IO.Path.Combine(targetDirectory, System.IO.Path.GetFileName(dir));
                Directory.Move(dir, newFolderPath);

                // Optionally, show a message indicating the folder has been moved
                MessageBox.Show($"Moved {System.IO.Path.GetFileName(dir)} to {(sortByAlphabetical ? $"alphabetical folder {targetDirectory}" : $"depth folder {depth}")}");
            }
        }

        private int GetFolderDepth(string folder)
        {
            // Count how many subfolders are present
            return Directory.GetDirectories(folder, "*", SearchOption.AllDirectories).Length;
        }

        private async void SortMedia(string folderPath, string jsonPath, string configTypePath)
        {
            // Check if both config files exist
            if (!File.Exists(jsonPath) || !File.Exists(configTypePath))
            {
                MessageBox.Show("One or both config files not found.");
                return;
            }

            // Read and parse the JSON files
            string jsonStringOptions = await File.ReadAllTextAsync(jsonPath);
            string jsonStringConfig = await File.ReadAllTextAsync(configTypePath);

            var jsonOptions = JObject.Parse(jsonStringOptions);
            var jsonConfig = JObject.Parse(jsonStringConfig);

            // Extract sorting options from jsonPath
            var option = jsonOptions["Option"].ToObject<JObject>();
            bool isDuration = (bool)option["Duration"];
            bool isResolution = (bool)option["Resolution"];
            bool isFrameRate = (bool)option["Frame_Rate"];
            bool isCodec = (bool)option["Codec"];
            bool isAspect = (bool)option["Aspect"];

            // Extract file extensions and allowed types from configTypePath
            var extensions = jsonConfig["Extensions"].ToObject<JObject>();
            var allow = jsonConfig["Allow"].ToObject<JObject>();

            // Define media types (Images, Videos, Audio)
            var mediaTypes = new[] { "Images", "Videos", "Audio" };

            // Filter allowed media types based on the "Allow" section
            var allowedMediaTypes = mediaTypes.Where(type => (bool)allow[type]).ToList();

            if (!allowedMediaTypes.Any())
            {
                MessageBox.Show("No media types are allowed for sorting.");
                return;
            }

            // Get all files in the target folder
            var files = await ProcessFiles(folderPath);
            int totalFiles = files.Length;

            // Update the file count label
            Invoke((MethodInvoker)(() => File_Count.Text = $"Total Files: {totalFiles}"));

            // Filter files by allowed extensions
            var filteredFiles = files.Where(file => allowedMediaTypes.Any(type =>
            {
                var allowedExtensions = extensions[type].ToObject<string[]>();
                return allowedExtensions.Any(ext => file.EndsWith(ext, StringComparison.OrdinalIgnoreCase));
            })).ToArray();

            if (!filteredFiles.Any())
            {
                MessageBox.Show("No files with allowed extensions found.");
                return;
            }

            // Split files into different media type categories
            var videoFiles = filteredFiles.Where(file => extensions["Videos"].ToObject<string[]>().Any(ext => file.EndsWith(ext, StringComparison.OrdinalIgnoreCase))).ToArray();
            var imageFiles = filteredFiles.Where(file => extensions["Images"].ToObject<string[]>().Any(ext => file.EndsWith(ext, StringComparison.OrdinalIgnoreCase))).ToArray();

            if (isDuration)
            {
                sortByDuration(videoFiles);
            }
            else if (isFrameRate)
            {
                sortByFrameRate(videoFiles);
            }
            else if (isCodec)
            {
                sortByCodec(videoFiles);
            }
            else if (isResolution)
            {
                sortByResolution_Videos(videoFiles);
                sortByResolution_Images(imageFiles);
            }
            else if (isAspect)
            {
                sortByAspect_Videos(videoFiles);
                sortByAspect_Images(imageFiles);
            }
        }

        private void sortByDuration(string[] files)
        {
            // Check if the files array is empty
            if (files.Length == 0)
            {
                Debug.WriteLine("No files to display.");
                return;
            }

            // Initialize FFProbe
            var ffProbe = new FFProbe();

            // Set the progress bar maximum to the total number of files
            progressBar_Time.Invoke((Action)(() => progressBar_Time.Maximum = files.Length));

            int processedFiles = 0;

            foreach (var file in files)
            {
                try
                {
                    // Get media info of the file
                    var videoInfo = ffProbe.GetMediaInfo(file);

                    // Get the duration in total seconds and convert to hh:mm:ss
                    TimeSpan duration = TimeSpan.FromSeconds((int)videoInfo.Duration.TotalSeconds);
                    string durationFolder = duration.ToString(@"hh\-mm\-ss"); // Folder name in hh-mm-ss format (use '-' instead of ':')

                    // Define the base folder where sorted videos will be stored
                    string baseFolder = "SortedVideos"; // Adjust this to the desired base folder

                    // Construct the full path to the folder based on duration
                    string targetFolderPath = System.IO.Path.Combine(Path, baseFolder, durationFolder);

                    // Create the folder if it doesn't exist
                    if (!Directory.Exists(targetFolderPath))
                    {
                        Directory.CreateDirectory(targetFolderPath);
                    }

                    // Construct the target file path (same file name in the new folder)
                    string destinationFile = System.IO.Path.Combine(targetFolderPath, System.IO.Path.GetFileName(file));

                    // Check if the file already exists in the target folder
                    if (!File.Exists(destinationFile))
                    {
                        // Move the file to the target folder
                        File.Move(file, destinationFile);
                        Debug.WriteLine($"Moved file {file} to {destinationFile}");
                    }
                    else
                    {
                        Debug.WriteLine($"File already exists: {destinationFile}. Skipping move.");
                    }

                    // Increment the progress bar after processing each file
                    processedFiles++;

                    // Update the progress bar
                    progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = processedFiles));
                }
                catch (Exception ex)
                {
                    // Handle any exceptions (e.g., if FFProbe fails or access is denied)
                    Debug.WriteLine($"Error processing file {file}: {ex.Message}");
                }
            }

            // Reset or hide the progress bar once sorting is complete
            progressBar_Time.Invoke((Action)(() =>
            {
                progressBar_Time.Value = progressBar_Time.Maximum; // Ensure it reaches 100%
                MessageBox.Show("Sorting completed!");
            }));
        }


        private void sortByResolution_Videos(string[] files)
        {
            //Check if the files array is empty
            if (files.Length == 0)
            {
                Debug.WriteLine("No files to display.");
                return;
            }

            // Initialize FFProbe
            var ffProbe = new FFProbe();

            int processedFiles = 0;

            foreach (var file in files)
            {
                try
                {
                    // Get media info of the file
                    var videoInfo = ffProbe.GetMediaInfo(file);

                    // Get the resolution of the video (Width x Height)
                    string resolution = $"{videoInfo.Streams[0].Width}x{videoInfo.Streams[0].Height}";

                    // Define the base folder where sorted videos will be stored
                    string baseFolder = "SortedByResolution_Videos"; // Adjust this to the desired base folder

                    // Construct the full path to the folder based on resolution
                    string targetFolderPath = System.IO.Path.Combine(Path, baseFolder, resolution);

                    // Create the folder if it doesn't exist
                    if (!Directory.Exists(targetFolderPath))
                    {
                        Directory.CreateDirectory(targetFolderPath);
                    }

                    // Construct the target file path (same file name in the new folder)
                    string destinationFile = System.IO.Path.Combine(targetFolderPath, System.IO.Path.GetFileName(file));

                    // Check if the file already exists in the target folder
                    if (!File.Exists(destinationFile))
                    {
                        // Move the file to the target folder
                        File.Move(file, destinationFile);
                        Debug.WriteLine($"Moved file {file} to {destinationFile}");
                    }
                    else
                    {
                        Debug.WriteLine($"File already exists: {destinationFile}. Skipping move.");
                    }

                    // Increment the progress bar after processing each file
                    processedFiles++;

                    // Ensure the progress value does not exceed the maximum
                    if (processedFiles <= progressBar_Time.Maximum)
                    {
                        progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = processedFiles));
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions (e.g., if FFProbe fails or access is denied)
                    Debug.WriteLine($"Error processing file {file}: {ex.Message}");
                }
            }
        }

        private void sortByResolution_Images(string[] files)
        {
            if (files.Length == 0)
            {
                Debug.WriteLine("No files to display.");
                return;
            }

            int processedFiles = 0;

            foreach (var file in files)
            {
                try
                {
                    using (var img = Image.FromFile(file))
                    {
                        string resolution = $"{img.Width}x{img.Height}";
                        string targetFolderPath = System.IO.Path.Combine(Path, resolution);

                        // Check if the file already exists in the target folder
                        if (!File.Exists(targetFolderPath))
                        {
                            // Move the file to the target folder
                            File.Move(file, targetFolderPath);
                            Debug.WriteLine($"Moved file {file} to {targetFolderPath}");
                        }
                        else
                        {
                            Debug.WriteLine($"File already exists: {targetFolderPath}. Skipping move.");
                        }

                        // Increment the progress bar after processing each file
                        processedFiles++;

                        // Ensure the progress value does not exceed the maximum
                        if (processedFiles <= progressBar_Time.Maximum)
                        {
                            progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = processedFiles));
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions (e.g., if FFProbe fails or access is denied)
                    Debug.WriteLine($"Error processing file {file}: {ex.Message}");
                }
            }
        }

        private void sortByFrameRate(string[] files)
        {
            if (files.Length == 0)
            {
                Debug.WriteLine("No files to display.");
                return;
            }

            // Initialize FFProbe
            var ffProbe = new FFProbe();

            foreach (var file in files)
            {
                try
                {
                    // Get media info
                    var videoInfo = ffProbe.GetMediaInfo(file);
                    var codec = videoInfo.Streams.First().CodecName;

                    // Create folder name based on framerate
                    var folderName = $"Codec {codec}";

                    // Create directory if it doesn't exist
                    if (!Directory.Exists(folderName))
                    {
                        Directory.CreateDirectory(folderName);
                    }

                    // Move file to the corresponding folder
                    var destinationPath = System.IO.Path.Combine(Path, folderName);
                    File.Move(file, destinationPath);

                    Debug.WriteLine($"Moved file {file} to {destinationPath}");
                }
                catch (Exception ex)
                {
                    // Handle any exceptions (e.g., if FFProbe fails or access is denied)
                    Debug.WriteLine($"Error processing file {file}: {ex.Message}");
                }
            }
        }

        private void sortByCodec(string[] files)
        {
            if (files.Length == 0)
            {
                Debug.WriteLine("No files to display.");
                return;
            }

            // Initialize FFProbe
            var ffProbe = new FFProbe();

            foreach (var file in files)
            {
                try
                {
                    // Get media info
                    var videoInfo = ffProbe.GetMediaInfo(file);
                    var codec = videoInfo.Streams.First().CodecName;

                    // Create folder name based on codec
                    var folderName = $"Codec_{codec}";

                    // Create directory if it doesn't exist
                    if (!Directory.Exists(folderName))
                    {
                        Directory.CreateDirectory(folderName);
                    }

                    // Move file to the corresponding folder
                    var destinationPath = System.IO.Path.Combine(Path, folderName);
                    File.Move(file, destinationPath);

                    Debug.WriteLine($"Moved file {file} to {destinationPath}");
                }
                catch (Exception ex)
                {
                    // Handle any exceptions (e.g., if FFProbe fails or access is denied)
                    Debug.WriteLine($"Error processing file {file}: {ex.Message}");
                }
            }
        }

        private void sortByAspect_Videos(string[] files)
        {
            if (files.Length == 0)
            {
                Debug.WriteLine("No files to display.");
                return;
            }

            // Initialize FFProbe
            var ffProbe = new FFProbe();

            foreach (var file in files)
            {
                try
                {
                    // Get media info
                    var videoInfo = ffProbe.GetMediaInfo(file);
                    var videoStream = videoInfo.Streams.FirstOrDefault(s => s.CodecType == "video");

                    if (videoStream != null)
                    {
                        var width = videoStream.Width;
                        var height = videoStream.Height;
                        var aspectRatio = (double)width / height;

                        // Create folder name based on aspect ratio
                        var folderName = $"AspectRatio_{aspectRatio:F2}";

                        // Create directory if it doesn't exist
                        if (!Directory.Exists(folderName))
                        {
                            Directory.CreateDirectory(folderName);
                        }

                        // Move file to the corresponding folder
                        var destinationPath = System.IO.Path.Combine(Path, folderName);
                        File.Move(file, destinationPath);

                        Debug.WriteLine($"Moved file {file} to {destinationPath}");
                    }
                    else
                    {
                        Debug.WriteLine("No video stream found.");
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions (e.g., if FFProbe fails or access is denied)
                    Debug.WriteLine($"Error processing file {file}: {ex.Message}");
                }
            }
        }

        private void sortByAspect_Images(string[] files)
        {
            if (files.Length == 0)
            {
                Debug.WriteLine("No files to display.");
                return;
            }

            foreach (var file in files)
            {
                try
                {
                    // Load the image
                    using (var image = Image.FromFile(file))
                    {
                        var width = image.Width;
                        var height = image.Height;
                        var aspectRatio = (double)width / height;

                        // Create folder name based on aspect ratio
                        var folderName = $"AspectRatio_{aspectRatio:F2}";

                        // Create directory if it doesn't exist
                        if (!Directory.Exists(folderName))
                        {
                            Directory.CreateDirectory(folderName);
                        }

                        // Move file to the corresponding folder
                        var destinationPath = System.IO.Path.Combine(folderName, System.IO.Path.GetFileName(file));
                        File.Move(file, destinationPath);

                        Debug.WriteLine($"Moved file {file} to {destinationPath}");
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions (e.g., if the image fails to load or access is denied)
                    Debug.WriteLine($"Error processing file {file}: {ex.Message}");
                }
            }
        }
    }
}