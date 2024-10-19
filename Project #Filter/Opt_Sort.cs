using System.Collections.Concurrent;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
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
                    Populated_Treeview(fbd.SelectedPath);
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

            button_Filter.Enabled = false;
            treeView1.Nodes.Clear();

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
                        await Task.Run(() => SortHash(Path, config_Path, CancellationToken.None));
                        break;
                    default:
                        break;
                }
            }

            DeleteEmptyFolders(Path);
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

        private async void Populated_Treeview(string folderPath)
        {
            // Clear the TreeView on the UI thread
            treeView1.Invoke((Action)(() => treeView1.Nodes.Clear()));

            // Create the root node for the parent folder
            TreeNode rootNode = new TreeNode(System.IO.Path.GetFileName(folderPath));
            treeView1.Invoke((Action)(() => treeView1.Nodes.Add(rootNode)));

            // Get all files from the folder and its subfolders (after sorting)
            var files = await ProcessFiles(folderPath);

            // Iterate over each file
            foreach (var file in files)
            {
                var fileParts = file.Replace(folderPath, "").TrimStart(System.IO.Path.DirectorySeparatorChar).Split(System.IO.Path.DirectorySeparatorChar);

                TreeNode currentNode = rootNode;
                foreach (var part in fileParts)
                {
                    // Make sure node creation is invoked on the UI thread
                    currentNode = await Task.Run(() => FindOrCreateNode(currentNode.Nodes, part));
                }
            }
        }

        private TreeNode FindOrCreateNode(TreeNodeCollection nodes, string nodeName)
        {
            if (InvokeRequired)
            {
                // Use Invoke to run the method on the UI thread
                return Invoke(new Func<TreeNode>(() => FindOrCreateNode(nodes, nodeName)));
            }

            // If already on the UI thread, proceed as normal
            TreeNode node = nodes.Cast<TreeNode>().FirstOrDefault(n => n.Text == nodeName);
            if (node == null)
            {
                node = new TreeNode(nodeName);
                nodes.Add(node);
            }
            return node;
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

            var extensions = jsonContent["Extensions"].ToObject<JObject>();
            var allow = jsonContent["Allow"].ToObject<JObject>();

            var files = await ProcessFiles(folderPath);
            int totalFiles = files.Length;

            // Set progress bar maximum value on the UI thread
            progressBar_Time.Invoke((Action)(() => progressBar_Time.Maximum = files.Length));
            int processedFiles = 0;

            // Update the file count label on the UI thread
            Invoke((MethodInvoker)(() => File_Count.Text = $"Total Files: {totalFiles}"));

            foreach (var file in files)
            {
                string fileExtension = System.IO.Path.GetExtension(file).TrimStart('.').ToLower();

                foreach (var allowCategory in allow)
                {
                    bool isAllowed = (bool)allowCategory.Value;
                    string category = allowCategory.Key;

                    if (isAllowed)
                    {
                        JArray categoryExtensions = (JArray)extensions[category];
                        bool extensionExists = categoryExtensions
                            .Select(ext => ext.ToString().Trim().ToLower())
                            .Contains(fileExtension);

                        if (extensionExists)
                        {
                            string originalDirectory = System.IO.Path.GetDirectoryName(file);
                            string targetDirectory = System.IO.Path.Combine(originalDirectory, category);
                            if (!Directory.Exists(targetDirectory))
                            {
                                Directory.CreateDirectory(targetDirectory);
                            }

                            string targetPath = System.IO.Path.Combine(targetDirectory, System.IO.Path.GetFileName(file));
                            File.Move(file, targetPath);
                        }
                    }
                }

                processedFiles++;

                // Update the progress bar on the UI thread
                progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = processedFiles));
            }

            // Reset progress bar on the UI thread
            progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = 0));

            // Call Populated_Treeview on the UI thread
            Invoke(() => Populated_Treeview(folderPath));

            MessageBox.Show("Sorting completed!");

            button_Filter.Invoke((Action)(() => button_Filter.Enabled = true));
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

            progressBar_Time.Invoke((Action)(() => progressBar_Time.Maximum = files.Length));
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

                // Increment the progress bar after processing each file
                processedFiles++;

                // Update the progress bar
                progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = processedFiles));
            }

            // Reset progress bar on the UI thread
            progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = 0));

            // Call Populated_Treeview on the UI thread
            Invoke(() => Populated_Treeview(folderPath));

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

            progressBar_Time.Invoke((Action)(() => progressBar_Time.Maximum = files.Length));
            int processedFiles = 0;

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
                        // Increment the progress bar after processing each file
                        processedFiles++;

                        // Update the progress bar
                        progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = processedFiles));
                    }
                }

            }

            // Reset progress bar on the UI thread
            progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = 0));

            // Call Populated_Treeview on the UI thread
            Invoke(() => Populated_Treeview(folderPath));

            MessageBox.Show("Sorting completed!");
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

            progressBar_Time.Invoke((Action)(() => progressBar_Time.Maximum = files.Length));
            int processedFiles = 0;

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

                // Increment the progress bar after processing each file
                processedFiles++;

                // Update the progress bar
                progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = processedFiles));
            }

            // Reset progress bar on the UI thread
            progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = 0));

            // Call Populated_Treeview on the UI thread
            Invoke(() => Populated_Treeview(folderPath));

            MessageBox.Show("Sorting completed!");
        }

        private async Task SortHash(string folderPath, string jsonPath, CancellationToken cancellationToken)
        {
            if (!File.Exists(jsonPath))
            {
                MessageBox.Show("Config file not found.");
                return;
            }

            // Read and parse the JSON file
            string jsonString = await File.ReadAllTextAsync(jsonPath, cancellationToken);
            var jsonContent = JObject.Parse(jsonString);

            // Get the "Extensions" and "Allow" sections from the JSON
            var extensions = jsonContent["Extensions"].ToObject<JObject>();
            var allow = jsonContent["Allow"].ToObject<JObject>();

            // Create a HashSet for allowed extensions (faster lookup)
            HashSet<string> allowedExtensions = new HashSet<string>(
                allow.Properties()
                     .Where(p => (bool)p.Value)
                     .SelectMany(p => extensions[p.Name].Select(e => e.ToString().Trim().ToLower()))
            );

            // Get all files in the target folder
            var files = await ProcessFiles(folderPath);
            int totalFiles = files.Length;

            // UI updates on the main thread
            Invoke(() =>
            {
                progressBar_Time.Maximum = totalFiles;
                File_Count.Text = $"Total Files: {totalFiles}";
            });

            // Use a thread-safe ConcurrentDictionary for storing file hashes and files
            ConcurrentDictionary<string, List<string>> fileHashes = new ConcurrentDictionary<string, List<string>>();
            int processedFiles = 0;
            bool duplicatesFound = false;

            // Create ParallelOptions to control the degree of parallelism
            var parallelOptions = new ParallelOptions
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount, // Utilize all available cores
                CancellationToken = cancellationToken
            };

            // Process files in parallel
            await Task.Run(() =>
            {
                Parallel.ForEach(files, parallelOptions, file =>
                {
                    try
                    {
                        // Early exit if cancellation is requested
                        parallelOptions.CancellationToken.ThrowIfCancellationRequested();

                        // Check file extension
                        string fileExtension = System.IO.Path.GetExtension(file).TrimStart('.').ToLower();
                        if (!allowedExtensions.Contains(fileExtension)) return;

                        // Calculate the hash of the file with buffered stream for performance
                        string fileHash = GetFileHash(file);

                        // Safely add/update file hashes
                        fileHashes.AddOrUpdate(fileHash, new List<string> { file }, (key, existingList) =>
                        {
                            existingList.Add(file);
                            return existingList;
                        });

                        // Update progress every 500 files to reduce UI thread congestion
                        Interlocked.Increment(ref processedFiles);
                        if (processedFiles % 500 == 0)
                        {
                            Invoke(() =>
                            {
                                progressBar_Time.Value = processedFiles;
                            });
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"Error processing file {file}: {ex.Message}");
                    }
                });
            }, cancellationToken);

            // Handle duplicates
            await HandleDuplicates(fileHashes, folderPath);

            // Reset progress bar and update UI
            Invoke(() =>
            {
                progressBar_Time.Value = 0;
                button_Filter.Enabled = true;
                Populated_Treeview(folderPath);
                MessageBox.Show(duplicatesFound ? "Duplicates found and sorted!" : "No duplicates found.");
            });
        }

        // Helper to calculate hash with BufferedStream for performance
        private string GetFileHash(string filePath)
        {
            using (var sha256 = SHA256.Create())
            using (var fileStream = new BufferedStream(File.OpenRead(filePath), 1024 * 32)) // Buffer size 32KB
            {
                byte[] hashBytes = sha256.ComputeHash(fileStream);
                Debug.WriteLine($"Hash: > {BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant()}");
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
            }
        }

        // Handle duplicates (move files into Duplicates folder)
        private async Task HandleDuplicates(ConcurrentDictionary<string, List<string>> fileHashes, string folderPath)
        {
            bool duplicatesFound = false;
            string mainSubfolder = null;
            string dateSubfolder = null;

            foreach (var hashEntry in fileHashes)
            {
                var filesWithSameHash = hashEntry.Value;

                if (filesWithSameHash.Count > 1)
                {
                    if (!duplicatesFound)
                    {
                        duplicatesFound = true;
                        mainSubfolder = System.IO.Path.Combine(folderPath, "Duplicates");
                        Directory.CreateDirectory(mainSubfolder);
                        dateSubfolder = System.IO.Path.Combine(mainSubfolder, DateTime.Now.ToString("yyyy-MM-dd"));
                        Directory.CreateDirectory(dateSubfolder);
                    }

                    foreach (var file in filesWithSameHash)
                    {
                        string destinationPath = System.IO.Path.Combine(dateSubfolder, System.IO.Path.GetFileName(file));

                        // Avoid file name conflicts
                        if (File.Exists(destinationPath))
                        {
                            string fileNameFolder = System.IO.Path.Combine(dateSubfolder, System.IO.Path.GetFileNameWithoutExtension(file));
                            Directory.CreateDirectory(fileNameFolder);
                            destinationPath = System.IO.Path.Combine(fileNameFolder, System.IO.Path.GetFileName(file));
                        }

                        // Move the file
                        File.Move(file, destinationPath);
                    }
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

            progressBar_Time.Invoke((Action)(() => progressBar_Time.Maximum = files.Length));
            int processedFiles = 0;

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
                        // Increment the progress bar after processing each file
                        processedFiles++;

                        // Update the progress bar
                        progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = processedFiles));
                    }
                }
            }

            // Reset progress bar on the UI thread
            progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = 0));

            // Call Populated_Treeview on the UI thread
            Invoke(() => Populated_Treeview(folderPath));

            MessageBox.Show("Sorting completed!");
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

            progressBar_Time.Invoke((Action)(() => progressBar_Time.Maximum = files.Length));
            int processedFiles = 0;

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
                    // Increment the progress bar after processing each file
                    processedFiles++;

                    // Update the progress bar
                    progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = processedFiles));
                }
            }

            // Reset progress bar on the UI thread
            progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = 0));

            // Call Populated_Treeview on the UI thread
            Invoke(() => Populated_Treeview(folderPath));

            MessageBox.Show("Sorting completed!");
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

            bool sortByAlphabetical = jsonContent["Option"]["Alphabetical"]?.ToObject<bool>() ?? false;
            bool sortByDepth = jsonContent["Option"]["Depth"]?.ToObject<bool>() ?? false;
            bool caseSensitive = jsonContent["Additional"]["Case"]?.ToObject<bool>() ?? false;
            bool skipSpecialCharacters = jsonContent["Additional"]["Special"]?.ToObject<bool>() ?? false;

            if (sortByAlphabetical)
            {
                SortAlphabetical(folderPath, caseSensitive, skipSpecialCharacters);
            }

            if (sortByDepth)
            {
                SortByDepth(folderPath, skipSpecialCharacters);
            }

            MessageBox.Show("Folders sorted!");
        }

        private void SortAlphabetical(string folderPath, bool caseSensitive, bool skipSpecialCharacters)
        {
            string alphabeticalFolder = System.IO.Path.Combine(folderPath, "Alphabetical");
            Directory.CreateDirectory(alphabeticalFolder);

            var directories = Directory.GetDirectories(folderPath, "*", SearchOption.TopDirectoryOnly);

            foreach (var dir in directories)
            {
                string dirName = System.IO.Path.GetFileName(dir);

                // Skip folders with special characters if the option is set
                if (skipSpecialCharacters && !Regex.IsMatch(dirName, @"^[a-zA-Z0-9_\-]+$"))
                {
                    continue;
                }

                // Handle case sensitivity
                string firstChar = caseSensitive ? dirName.Substring(0, 1) : dirName.Substring(0, 1).ToUpperInvariant();

                string targetDir = System.IO.Path.Combine(alphabeticalFolder, firstChar);
                Directory.CreateDirectory(targetDir);
                Directory.Move(dir, System.IO.Path.Combine(targetDir, dirName));
            }
        }

        private void SortByDepth(string folderPath, bool skipSpecialCharacters)
        {
            string depthFolder = System.IO.Path.Combine(folderPath, "Depth");
            Directory.CreateDirectory(depthFolder);

            var directories = Directory.GetDirectories(folderPath, "*", SearchOption.TopDirectoryOnly);

            foreach (var dir in directories)
            {
                if (skipSpecialCharacters && !Regex.IsMatch(System.IO.Path.GetFileName(dir), @"^[a-zA-Z0-9_\-]+$"))
                {
                    continue;
                }

                int depth = GetFolderDepth(dir);
                string depthDir = System.IO.Path.Combine(depthFolder, $"Depth_{depth}");
                Directory.CreateDirectory(depthDir);

                string targetDir = System.IO.Path.Combine(depthDir, System.IO.Path.GetFileName(dir));
                Directory.Move(dir, targetDir);
            }
        }

        private int GetFolderDepth(string folder)
        {
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
            // Reset progress bar on the UI thread
            progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = 0));

            // Call Populated_Treeview on the UI thread
            Invoke(() => Populated_Treeview(Path));

            MessageBox.Show("Sorting completed!");
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

            progressBar_Time.Invoke((Action)(() => progressBar_Time.Maximum = files.Length));
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

                    // Update the progress bar
                    progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = processedFiles));
                }
                catch (Exception ex)
                {
                    // Handle any exceptions (e.g., if FFProbe fails or access is denied)
                    Debug.WriteLine($"Error processing file {file}: {ex.Message}");
                }
            }

            // Reset progress bar on the UI thread
            progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = 0));

            // Call Populated_Treeview on the UI thread
            Invoke(() => Populated_Treeview(Path));

            MessageBox.Show("Sorting completed!");
        }

        private void sortByResolution_Images(string[] files)
        {
            if (files.Length == 0)
            {
                Debug.WriteLine("No files to display.");
                return;
            }

            progressBar_Time.Invoke((Action)(() => progressBar_Time.Maximum = files.Length));
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

                        // Update the progress bar
                        progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = processedFiles));
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions (e.g., if FFProbe fails or access is denied)
                    Debug.WriteLine($"Error processing file {file}: {ex.Message}");
                }
            }
            // Reset progress bar on the UI thread
            progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = 0));

            // Call Populated_Treeview on the UI thread
            Invoke(() => Populated_Treeview(Path));

            MessageBox.Show("Sorting completed!");
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

            progressBar_Time.Invoke((Action)(() => progressBar_Time.Maximum = files.Length));
            int processedFiles = 0;

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

                // Increment the progress bar after processing each file
                processedFiles++;

                // Update the progress bar
                progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = processedFiles));
            }
            // Reset progress bar on the UI thread
            progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = 0));

            // Call Populated_Treeview on the UI thread
            Invoke(() => Populated_Treeview(Path));

            MessageBox.Show("Sorting completed!");
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

            progressBar_Time.Invoke((Action)(() => progressBar_Time.Maximum = files.Length));
            int processedFiles = 0;

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

                // Increment the progress bar after processing each file
                processedFiles++;

                // Update the progress bar
                progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = processedFiles));
            }
            // Reset progress bar on the UI thread
            progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = 0));

            // Call Populated_Treeview on the UI thread
            Invoke(() => Populated_Treeview(Path));

            MessageBox.Show("Sorting completed!");
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

            progressBar_Time.Invoke((Action)(() => progressBar_Time.Maximum = files.Length));
            int processedFiles = 0;

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
                // Increment the progress bar after processing each file
                processedFiles++;

                // Update the progress bar
                progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = processedFiles));
            }
            // Reset progress bar on the UI thread
            progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = 0));

            // Call Populated_Treeview on the UI thread
            Invoke(() => Populated_Treeview(Path));

            MessageBox.Show("Sorting completed!");
        }

        private void sortByAspect_Images(string[] files)
        {
            if (files.Length == 0)
            {
                Debug.WriteLine("No files to display.");
                return;
            }

            progressBar_Time.Invoke((Action)(() => progressBar_Time.Maximum = files.Length));
            int processedFiles = 0;

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
                // Increment the progress bar after processing each file
                processedFiles++;

                // Update the progress bar
                progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = processedFiles));
            }

            // Reset progress bar on the UI thread
            progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = 0));

            // Call Populated_Treeview on the UI thread
            Invoke(() => Populated_Treeview(Path));

            MessageBox.Show("Sorting completed!");
        }
    }
}