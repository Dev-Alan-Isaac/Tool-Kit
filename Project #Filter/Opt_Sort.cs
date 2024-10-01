using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using NReco.VideoInfo;

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
            string config_Path, config_Path2;
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
                    case "Media Metadata (Videos/Audio)":
                        config_Path = System.IO.Path.GetFullPath("Config_Media.json");
                        config_Path2 = System.IO.Path.GetFullPath("Config_Type.json");
                        await Task.Run(() => SortMedia(Path, config_Path, config_Path2));
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
            var files = Directory.GetFiles(folderPath);

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
            var files = Directory.GetFiles(folderPath);

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
            bool isAudio = (bool)option["Audio"];
            bool isAspect = (bool)option["Aspect"];
            bool isBitDepth = (bool)option["BitDepth"];

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
            var files = Directory.GetFiles(folderPath);

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

            // Sort the media files based on the selected criteria
            if (isDuration)
            {
                sortByDuration(filteredFiles);
            }
            else if (isResolution)
            {
                sortByResolution(filteredFiles);
            }
            else if (isFrameRate)
            {
                sortByFrameRate(filteredFiles);
            }
            else if (isCodec)
            {
                sortByCodec(filteredFiles);
            }
            else if (isAudio)
            {
                sortByAudio(filteredFiles);
            }
            else if (isAspect)
            {
                sortByAspect(filteredFiles);
            }
            else if (isBitDepth)
            {
                sortByBitDepth(filteredFiles);
            }
        }

        // Sorting methods based on different criteria (you will need to implement these)
        private void sortByDuration(string[] files)
        {
            // Check if the files array is empty
            if (files.Length == 0)
            {
                Debug.WriteLine("No files to display.");
                return;
            }

            // Dictionary to hold the durations and corresponding files
            var durationFiles = new Dictionary<TimeSpan, List<string>>();

            // Initialize the VideoInfo tool
            var videoInfo = new NReco.VideoInfo.FFProbe();

            foreach (var file in files)
            {
                try
                {
                    // Get the duration of the video file
                    var info = videoInfo.GetMediaInfo(file);
                    TimeSpan duration = info.Duration;

                    // Add the file to the corresponding duration entry
                    if (!durationFiles.ContainsKey(duration))
                    {
                        durationFiles[duration] = new List<string>();
                    }
                    durationFiles[duration].Add(file);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error processing file {file}: {ex.Message}");
                }
            }

            // Create folders based on duration and move the files
            foreach (var kvp in durationFiles)
            {
                TimeSpan duration = kvp.Key;
                var filesToMove = kvp.Value;

                // Create a folder name based on duration (e.g., "00:05:30" for 5 minutes and 30 seconds)
                string folderName = duration.ToString(@"hh\:mm\:ss");
                string baseFolder = "SortedVideos"; // Change this to your desired base folder
                string folderPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), baseFolder, folderName);

                // Create the folder if it doesn't exist
                Directory.CreateDirectory(folderPath);

                // Move each file to the corresponding duration folder
                foreach (var file in filesToMove)
                {
                    string destinationFile = System.IO.Path.GetFullPath(folderPath, System.IO.Path.GetFullPath(file));
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
            }

        }


        private void sortByResolution(string[] files)
        {
            // Implement sorting by resolution here
        }

        private void sortByFrameRate(string[] files)
        {
            // Implement sorting by frame rate here
        }

        private void sortByCodec(string[] files)
        {
            // Implement sorting by codec here
        }

        private void sortByAudio(string[] files)
        {
            // Implement sorting by audio properties here
        }

        private void sortByAspect(string[] files)
        {
            // Implement sorting by aspect ratio here
        }

        private void sortByBitDepth(string[] files)
        {
            // Implement sorting by bit depth here
        }
    }
}