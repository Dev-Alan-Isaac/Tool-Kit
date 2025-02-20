using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using NReco.VideoInfo;

namespace Project__Filter
{
    public partial class Option_Sort : UserControl
    {
        private string Path;
        private List<string> checkedItems = new List<string>();

        public Option_Sort()
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
            const string Config_Sort = "Config_Sort.json";
            if (!string.IsNullOrEmpty(Path))
            {
                button_Filter.Enabled = false;
                treeView1.Nodes.Clear();

                foreach (string item in checkedItems)
                {
                    switch (item)
                    {
                        case "File Type":
                            await SortTypes(Path, Config_Sort);
                            break;
                        case "File Size":
                            await SortSize(Path, Config_Sort);
                            break;
                        case "File Date":
                            await SortDates(Path, Config_Sort);
                            break;
                        case "File Name":
                            await SortNames(Path, Config_Sort);
                            break;
                        case "File Hash":
                            await SortHash(Path, Config_Sort);
                            break;
                        case "File Permissions":
                            await SortPermissions(Path, Config_Sort);
                            break;
                        case "Custom Tags":
                            await SortCustomTags(Path, Config_Sort);
                            break;
                        case "Folder Location":
                            await SortFolderLocation(Path, Config_Sort);
                            break;
                        case "Media Metadata":
                            await SortMedia(Path, Config_Sort);
                            break;
                        default:
                            break;
                    }
                }

                // After all sorts are done, delete empty folders
                DeleteEmptyFolders(Path);
            }
            // Re-enable the button after processing is done
            button_Filter.Enabled = true;
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

            bool processSubfolders = (bool)jsonContent["General"]["Subfolder"];

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
            treeView1.Invoke(() => treeView1.Nodes.Clear());

            // Create the root node for the parent folder
            TreeNode rootNode = new TreeNode(System.IO.Path.GetFileName(folderPath));
            treeView1.Invoke((Action)(() => treeView1.Nodes.Add(rootNode)));

            // Get all files from the folder and its subfolders (after sorting)
            var files = await ProcessFiles(folderPath);

            int totalFiles = files.Count();
            File_Count.Text = $"{totalFiles}";

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

        public async Task SortTypes(string folderPath, string jsonPath)
        {
            if (!File.Exists(jsonPath))
            {
                MessageBox.Show("Config file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string jsonString = await File.ReadAllTextAsync(jsonPath);
            var jsonContent = JObject.Parse(jsonString);

            var extensions = jsonContent["Type"].ToObject<JObject>();
            var allow = jsonContent["Type_Additional"].ToObject<JObject>();

            var files = await ProcessFiles(folderPath);
            int totalFiles = files.Length;

            // Initialize progress bar
            Invoke(() =>
            {
                progressBar_Time.Maximum = totalFiles;
                progressBar_Time.Value = 0;
            });

            var directoryCache = new ConcurrentDictionary<string, string>();
            int processedFiles = 0;
            int batchUpdateSize = 50;

            await Task.Run(() =>
            {
                Parallel.ForEach(files, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, file =>
                {
                    try
                    {
                        string fileExtension = System.IO.Path.GetExtension(file).TrimStart('.').ToLower();
                        bool fileMoved = false;

                        foreach (var allowCategory in allow)
                        {
                            bool isAllowed = (bool)allowCategory.Value;
                            string category = allowCategory.Key;

                            if (isAllowed)
                            {
                                JArray categoryExtensions = (JArray)extensions[category];
                                if (categoryExtensions.Select(ext => ext.ToString().Trim().ToLower()).Contains(fileExtension))
                                {
                                    string targetDirectory = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(file), category);
                                    if (!directoryCache.ContainsKey(targetDirectory))
                                    {
                                        if (!Directory.Exists(targetDirectory)) Directory.CreateDirectory(targetDirectory);
                                        directoryCache[targetDirectory] = targetDirectory;
                                    }

                                    string targetPath = System.IO.Path.Combine(targetDirectory, System.IO.Path.GetFileName(file));
                                    if (File.Exists(targetPath))
                                    {
                                        targetPath = System.IO.Path.Combine(targetDirectory, "[Type]" + System.IO.Path.GetFileName(file));
                                    }
                                    File.Move(file, targetPath);
                                    fileMoved = true;
                                    break; // Exit loop after moving the file
                                }
                            }
                        }

                        if (fileMoved)
                        {
                            Interlocked.Increment(ref processedFiles);

                            // Update the progress bar only in batches to avoid UI freezing
                            if (processedFiles % batchUpdateSize == 0)
                            {
                                Invoke(() =>
                                {
                                    progressBar_Time.Value = Math.Min(processedFiles, progressBar_Time.Maximum);
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error processing file {file}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                });
            });

            // Final UI Update after all files are processed
            Invoke(() =>
            {
                progressBar_Time.Value = progressBar_Time.Maximum;
                progressBar_Time.Value = 0;
                Populated_Treeview(folderPath);
                MessageBox.Show("Sorting completed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button_Filter.Enabled = true;
            });
        }


        private async Task SortSize(string folderPath, string jsonPath)
        {
            if (!File.Exists(jsonPath))
            {
                MessageBox.Show("Config file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // "Danger" type for errors
                return;
            }

            // Read and parse the JSON file
            string jsonString = await File.ReadAllTextAsync(jsonPath);
            var jsonContent = JObject.Parse(jsonString);

            // Get the "Size" section from the JSON
            var sizeSection = jsonContent["Size"] as JObject;

            if (sizeSection == null)
            {
                MessageBox.Show("Invalid JSON structure.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // "Danger" type for errors
                return;
            }

            // Function to convert size strings and units to bytes
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

            // Convert size ranges to bytes
            long smallMax = ConvertToBytes(sizeSection["Small"][0].ToString(), sizeSection["Small"][1].ToString());
            long mediumMin = ConvertToBytes(sizeSection["Medium"][0].ToString(), sizeSection["Medium"][1].ToString());
            long mediumMax = ConvertToBytes(sizeSection["Medium"][2].ToString(), sizeSection["Medium"][3].ToString());
            long largeMin = ConvertToBytes(sizeSection["Large"][0].ToString(), sizeSection["Large"][1].ToString());
            long largeMax = ConvertToBytes(sizeSection["Large"][2].ToString(), sizeSection["Large"][3].ToString());
            long veryLargeMin = ConvertToBytes(sizeSection["Very Large"][0].ToString(), sizeSection["Very Large"][1].ToString());

            // Get all files in the folder
            var files = await ProcessFiles(folderPath);
            int totalFiles = files.Length;

            // Set progress bar maximum value
            progressBar_Time.Invoke((Action)(() => progressBar_Time.Maximum = totalFiles));

            // Cache directories to avoid redundant creation checks
            var directoryCache = new Dictionary<string, string>();

            // Update the file count label
            Invoke((MethodInvoker)(() => File_Count.Text = $"{totalFiles}"));

            // Counter for processed files
            int processedFiles = 0;
            int batchUpdateSize = 50; // Progress bar update batch size

            await Task.Run(() =>
            {
                // Process files in parallel for efficiency
                Parallel.ForEach(files, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, file =>
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
                            string originalDirectory = System.IO.Path.GetDirectoryName(file);
                            string targetDirectory = System.IO.Path.Combine(originalDirectory, targetCategory);

                            // Check the directory cache to avoid redundant checks
                            if (!directoryCache.ContainsKey(targetDirectory))
                            {
                                if (!Directory.Exists(targetDirectory))
                                {
                                    Directory.CreateDirectory(targetDirectory);
                                }
                                directoryCache[targetDirectory] = targetDirectory;
                            }

                            string targetFileName = System.IO.Path.GetFileName(file);
                            string targetPath = System.IO.Path.Combine(targetDirectory, targetFileName);

                            // Check if a file with the same name already exists
                            if (File.Exists(targetPath))
                            {
                                // Add [Duplicate] prefix to the file name if a duplicate exists
                                string duplicateFileName = "[Size]" + targetFileName;
                                targetPath = System.IO.Path.Combine(targetDirectory, duplicateFileName);
                            }

                            // Move the file to the target directory
                            File.Move(file, targetPath);
                        }

                        // Increment processed file count
                        Interlocked.Increment(ref processedFiles);

                        // Update the progress bar only in batches
                        if (processedFiles % batchUpdateSize == 0)
                        {
                            progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = processedFiles));
                        }
                    });
            });

            // Final update to progress bar
            progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = totalFiles));

            // Reset progress bar after completion
            progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = 0));

            // Call Populated_Treeview on the UI thread
            Invoke(() => Populated_Treeview(folderPath));

            // Display a message informing the user that sorting is completed
            MessageBox.Show("Sorting completed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async Task SortDates(string folderPath, string jsonPath)
        {
            if (!File.Exists(jsonPath))
            {
                MessageBox.Show("Config file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string jsonString = await File.ReadAllTextAsync(jsonPath);
            var jsonContent = JObject.Parse(jsonString);

            var extensions = jsonContent["Type"].ToObject<Dictionary<string, List<string>>>();
            var allow = jsonContent["Type_Additional"].ToObject<Dictionary<string, bool>>();
            var filter = jsonContent["Date"].ToObject<Dictionary<string, bool>>();

            var files = await ProcessFiles(folderPath);

            var directoryCache = new ConcurrentDictionary<string, string>();

            int processedFiles = 0;
            int batchUpdateSize = 50;

            await Task.Run(() =>
            {
             
                
            });

            progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = 0));
            Invoke(() => Populated_Treeview(folderPath));
            MessageBox.Show("Sorting completed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            button_Filter.Invoke((Action)(() => button_Filter.Enabled = true));
        }

        private bool FileCompare(string file1, string file2)
        {
            int file1Byte, file2Byte;
            FileStream fs1 = new FileStream(file1, FileMode.Open);
            FileStream fs2 = new FileStream(file2, FileMode.Open);

            if (fs1.Length != fs2.Length)
            {
                fs1.Close();
                fs2.Close();
                return false;
            }

            do
            {
                file1Byte = fs1.ReadByte();
                file2Byte = fs2.ReadByte();
            }
            while (file1Byte == file2Byte && file1Byte != -1);

            fs1.Close();
            fs2.Close();

            return ((file1Byte - file2Byte) == 0);
        }

        private async Task SortNames(string folderPath, string jsonPath)
        {
            if (!File.Exists(jsonPath))
            {
                MessageBox.Show("Config file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Read and parse the JSON file
            string jsonString = await File.ReadAllTextAsync(jsonPath);
            var jsonContent = JObject.Parse(jsonString);

            var option = jsonContent["Name"] as JObject;
            var additional = jsonContent["Name_Additional"] as JObject;

            // Determine sorting options
            bool sortAlphabetically = (bool)option["Alphabetically"];
            bool sortByExtension = (bool)option["AlphabeticallyExtension"];
            bool caseSensitive = (bool)additional["Case"];
            bool ignoreSpecialCharacters = (bool)additional["Special"];

            // Get all files in the folder
            var files = await ProcessFiles(folderPath);
            int totalFiles = files.Length;
            var fileInfoList = files.Select(f => new FileInfo(f)).ToList();

            progressBar_Time.Invoke((Action)(() => progressBar_Time.Maximum = totalFiles));
            int processedFiles = 0;

            // Update the file count label
            Invoke((MethodInvoker)(() => File_Count.Text = $"{totalFiles}"));

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
                MessageBox.Show("No sorting option selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Process file moving in parallel using Task.Run and Parallel.ForEach
            await Task.Run(() =>
            {
                Parallel.ForEach(sortedFiles, file =>
                {
                    string fileName = file.Name;
                    string folderName = caseSensitive ? fileName.Substring(0, 1) : fileName.Substring(0, 1).ToUpper();
                    string targetDirectory = System.IO.Path.Combine(folderPath, folderName);

                    // Ensure directory exists
                    Directory.CreateDirectory(targetDirectory);

                    // Construct target path and handle duplicates
                    string targetPath = System.IO.Path.Combine(targetDirectory, file.Name);
                    if (File.Exists(targetPath))
                    {
                        int duplicateCount = 1;
                        string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(file.Name);
                        string extension = System.IO.Path.GetExtension(file.Name);
                        string duplicateFileName;

                        do
                        {
                            duplicateFileName = $"[Name]_{fileNameWithoutExtension}{duplicateCount}{extension}";
                            targetPath = System.IO.Path.Combine(targetDirectory, duplicateFileName);
                            duplicateCount++;
                        } while (File.Exists(targetPath));
                    }

                    try
                    {
                        // Move file
                        File.Move(file.FullName, targetPath);
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show($"Error while moving a file! \n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    // Update progress in a thread-safe manner
                    Interlocked.Increment(ref processedFiles);
                    progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = processedFiles));
                });
            });

            // Reset progress bar on the UI thread
            progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = 0));

            // Call Populated_Treeview on the UI thread
            Invoke(() => Populated_Treeview(folderPath));

            MessageBox.Show("Sorting completed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public async Task SortHash(string folderPath, string jsonPath)
        {
            if (!File.Exists(jsonPath))
            {
                MessageBox.Show("Config file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Load JSON configurations
            string jsonString = await File.ReadAllTextAsync(jsonPath);
            var jsonContent = JObject.Parse(jsonString);
            var extensions = jsonContent["Type"].ToObject<JObject>();
            var allow = jsonContent["Type_Additional"].ToObject<JObject>();
            HashSet<string> allowedExtensions = new HashSet<string>(
                allow.Properties()
                     .Where(p => (bool)p.Value)
                     .SelectMany(p => extensions[p.Name].Select(e => e.ToString().Trim().ToLower()))
            );

            // Filter files by allowed extensions
            var files = (await ProcessFiles(folderPath))
                        .Where(file => allowedExtensions.Contains(System.IO.Path.GetExtension(file).TrimStart('.').ToLower()))
                        .ToArray();

            int totalFiles = files.Length;
            Invoke(() =>
            {
                progressBar_Time.Maximum = totalFiles;
                File_Count.Text = $"{totalFiles}";
            });

            // Initialize data structures
            var fileHashes = new ConcurrentDictionary<string, ConcurrentBag<string>>();
            int processedFiles = 0;
            bool duplicatesFound = false;

            var parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount };

            // Hash files in parallel
            await Task.Run(() =>
            {
                Parallel.ForEach(files, parallelOptions, file =>
                {
                    try
                    {
                        using var sha256 = SHA256.Create();
                        string fileHash = GetQuickOrFullFileHash(file, sha256);

                        fileHashes.AddOrUpdate(fileHash, new ConcurrentBag<string> { file }, (key, list) =>
                        {
                            list.Add(file);
                            return list;
                        });

                        // Update progress after a batch of files
                        int currentCount = Interlocked.Increment(ref processedFiles);
                        if (currentCount % 100 == 0)
                        {
                            Invoke(() => progressBar_Time.Value = Math.Min(currentCount, progressBar_Time.Maximum));
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"Error processing file {file}: {ex.Message}");
                    }
                });
            });

            // Reset progress for duplicates handling and set max to the number of duplicate groups
            int duplicateGroups = fileHashes.Count(h => h.Value.Count > 1);
            Invoke(() => progressBar_Time.Maximum = duplicateGroups);

            // Handle duplicates
            string duplicatesDirectory = System.IO.Path.Combine(folderPath, "Duplicates");
            Directory.CreateDirectory(duplicatesDirectory);

            int processedGroups = 0;
            foreach (var hashGroup in fileHashes.Where(h => h.Value.Count > 1))
            {
                duplicatesFound = true;

                foreach (var duplicateFile in hashGroup.Value)
                {
                    string originalName = System.IO.Path.GetFileNameWithoutExtension(duplicateFile);
                    string extension = System.IO.Path.GetExtension(duplicateFile);
                    string newFileName = $"[Hash]_{originalName}{extension}";
                    string targetFilePath = System.IO.Path.Combine(duplicatesDirectory, newFileName);

                    // Ensure uniqueness by appending a counter if necessary
                    int counter = 1;
                    while (File.Exists(targetFilePath))
                    {
                        newFileName = $"[Hash]_{originalName}_{counter}{extension}";
                        targetFilePath = System.IO.Path.Combine(duplicatesDirectory, newFileName);
                        counter++;
                    }

                    File.Move(duplicateFile, targetFilePath);
                }

                processedGroups++;
                Invoke(() =>
                {
                    progressBar_Time.Value = Math.Min(processedGroups, progressBar_Time.Maximum);
                });
            }

            Invoke(() =>
            {
                progressBar_Time.Value = 0;
                button_Filter.Enabled = true;
                Populated_Treeview(folderPath);
                MessageBox.Show(
                    duplicatesFound ? "Duplicates found and sorted!" : "No duplicates found.",
                    "Duplicate Check",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            });
        }

        private string GetQuickOrFullFileHash(string filePath, SHA256 sha256, int quickBytes = 1024 * 1024)
        {
            using var fileStream = File.OpenRead(filePath);
            byte[] buffer = new byte[quickBytes];
            int bytesRead = fileStream.Read(buffer, 0, buffer.Length);

            sha256.TransformBlock(buffer, 0, bytesRead, null, 0);
            if (bytesRead == quickBytes && fileStream.Length > quickBytes)
            {
                sha256.TransformFinalBlock(new byte[0], 0, 0);
            }
            else
            {
                fileStream.Seek(0, SeekOrigin.Begin);
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    sha256.TransformBlock(buffer, 0, bytesRead, null, 0);
                }
                sha256.TransformFinalBlock(new byte[0], 0, 0);
            }

            return BitConverter.ToString(sha256.Hash).Replace("-", "").ToLowerInvariant();
        }


        private async Task SortPermissions(string folderPath, string jsonPath)
        {
            if (!File.Exists(jsonPath))
            {
                MessageBox.Show("Config file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // "Danger" type for errors
                return;
            }

            // Read and parse the JSON files
            string jsonString = await File.ReadAllTextAsync(jsonPath);
            var jsonContent = JObject.Parse(jsonString);

            string configTypeString = jsonString;
            var configTypeContent = JObject.Parse(configTypeString);

            var option = jsonContent["Auth"] as JObject;

            // Get the executable extensions from Config_Type.json
            var executableExtensions = configTypeContent["Type"]["Executables"].ToObject<List<string>>();

            // Get all files in the folder
            var files = await ProcessFiles(folderPath);
            int totalFiles = files.Length;

            // Set the progress bar maximum
            progressBar_Time.Invoke((Action)(() => progressBar_Time.Maximum = totalFiles));
            int processedFiles = 0;
            int batchUpdateSize = 50; // Batch UI updates

            // Cache folder creation results to avoid redundant checks
            var directoryCache = new Dictionary<string, string>();

            // Update file count label
            Invoke((MethodInvoker)(() => File_Count.Text = $"{totalFiles}"));

            // Process each sorting option (Readable, Writable, Executable)
            foreach (var allowOption in option)
            {
                bool isAllowed = (bool)allowOption.Value;
                string sortingOption = allowOption.Key;

                if (isAllowed)
                {
                    await Task.Run(() =>
                    {

                        Parallel.ForEach(files, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, file =>
                        {
                            FileInfo fileInfo = new FileInfo(file);
                            bool moveFile = false;

                            // Check the file properties based on the sorting option
                            switch (sortingOption)
                            {
                                case "Readable":
                                    if (!fileInfo.IsReadOnly) moveFile = true;
                                    break;
                                case "Writable":
                                    if (!fileInfo.IsReadOnly) moveFile = true;
                                    break;
                                case "Executable":
                                    string fileExtension = fileInfo.Extension.TrimStart('.').ToLower();
                                    if (executableExtensions.Contains(fileExtension)) moveFile = true;
                                    break;
                            }

                            if (moveFile)
                            {
                                // Move file logic in place of MoveFileToFolder function
                                string targetDirectory = System.IO.Path.Combine(folderPath, sortingOption);

                                // Check and cache folder creation
                                if (!directoryCache.ContainsKey(targetDirectory))
                                {
                                    Directory.CreateDirectory(targetDirectory);
                                    directoryCache[targetDirectory] = targetDirectory;
                                }

                                string targetPath = System.IO.Path.Combine(targetDirectory, fileInfo.Name);

                                // If the file already exists, add a prefix to avoid overwriting
                                if (File.Exists(targetPath))
                                {
                                    string newFileName = $"[Permissions]_{fileInfo.Name}";
                                    targetPath = System.IO.Path.Combine(targetDirectory, newFileName);
                                }

                                // Move the file to the target directory
                                File.Move(fileInfo.FullName, targetPath);
                            }

                            // Increment the progress
                            Interlocked.Increment(ref processedFiles);

                            // Update progress bar in batches
                            if (processedFiles % batchUpdateSize == 0)
                            {
                                progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = processedFiles));
                            }
                        });
                    });
                }
            }

            // Final progress update and reset progress bar
            progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = totalFiles));
            progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = 0));

            // Refresh UI
            Invoke(() => Populated_Treeview(folderPath));

            MessageBox.Show("Sorting completed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async Task SortCustomTags(string folderPath, string jsonPath)
        {
            if (!File.Exists(jsonPath))
            {
                MessageBox.Show("Config file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // "Danger" type for errors
                return;
            }

            // Read and parse the JSON file
            string jsonString = await File.ReadAllTextAsync(jsonPath);
            var jsonContent = JObject.Parse(jsonString);

            // Get the "Tags" array from the JSON
            var tagsArray = jsonContent["Tag"]["Tags"] as JArray;

            if (tagsArray == null || !tagsArray.Any())
            {
                MessageBox.Show("No tags found in the JSON file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // "Danger" type for errors
                return;
            }

            // Get all files in the target folder
            var files = await ProcessFiles(folderPath);
            int totalFiles = files.Length;

            if (totalFiles == 0)
            {
                MessageBox.Show("No files found in the target folder.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // "Danger" type for errors
                return;
            }

            progressBar_Time.Invoke((Action)(() => progressBar_Time.Maximum = totalFiles));
            int processedFiles = 0;

            // Update the file count label
            Invoke((MethodInvoker)(() => File_Count.Text = $"{totalFiles}"));

            await Task.Run(() =>
            {
                // Use Parallel.ForEach for faster processing
                Parallel.ForEach(files, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, file =>
                {
                    try
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
                                // Create the "Tags" folder and tag-specific subfolder
                                string tagsFolder = System.IO.Path.Combine(folderPath, "Tags");
                                string targetDirectory = System.IO.Path.Combine(tagsFolder, tagString);

                                // Use Directory.CreateDirectory, it will only create if it doesn't exist
                                Directory.CreateDirectory(targetDirectory);

                                // Build the target path for the file
                                string targetPath = System.IO.Path.Combine(targetDirectory, fileName);

                                // Check if a file with the same name exists
                                if (File.Exists(targetPath))
                                {
                                    // If file already exists, add [Duplicate] prefix to the file name
                                    string duplicateFileName = $"[Tags]_{fileName}";
                                    targetPath = System.IO.Path.Combine(targetDirectory, duplicateFileName);
                                }

                                // Move the file to the target directory
                                File.Move(file, targetPath);
                                break; // Once the file is moved, stop checking other tags for this file
                            }
                        }

                        // Increment the progress bar after processing each file
                        Interlocked.Increment(ref processedFiles);
                        progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = processedFiles));
                    }
                    catch (Exception ex)
                    {
                        // Log error in debug or handle it here
                        Debug.WriteLine($"Error processing file {file}: {ex.Message}");
                    }
                });
            });
            // Reset progress bar on the UI thread
            progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = 0));

            // Call Populated_Treeview on the UI thread
            Invoke(() => Populated_Treeview(folderPath));

            MessageBox.Show("Sorting completed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information); // "Information" for success
        }

        private async Task SortFolderLocation(string folderPath, string jsonPath)
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
                await SortAlphabetical(folderPath, caseSensitive, skipSpecialCharacters);
            }

            if (sortByDepth)
            {
                await SortByDepth(folderPath, skipSpecialCharacters);
            }

            MessageBox.Show("Folders sorted!");
        }

        private async Task SortAlphabetical(string folderPath, bool caseSensitive, bool skipSpecialCharacters)
        {
            string alphabeticalFolder = System.IO.Path.Combine(folderPath, "Alphabetical");
            Directory.CreateDirectory(alphabeticalFolder);

            // Cache the created directories
            var directoryCache = new ConcurrentDictionary<string, bool>();

            // Precompile regex for performance
            Regex specialCharRegex = new Regex(@"^[a-zA-Z0-9_\-]+$", RegexOptions.Compiled);

            // Get directories and process them in parallel
            var directories = Directory.GetDirectories(folderPath, "*", SearchOption.TopDirectoryOnly);
            await Task.Run(() =>
            {

                Parallel.ForEach(directories, dir =>
                {
                    string dirName = System.IO.Path.GetFileName(dir);

                    // Skip folders with special characters if the option is set
                    if (skipSpecialCharacters && !specialCharRegex.IsMatch(dirName))
                    {
                        return;
                    }

                    // Handle case sensitivity
                    string firstChar = caseSensitive ? dirName.Substring(0, 1) : dirName.Substring(0, 1).ToUpperInvariant();

                    string targetDir = System.IO.Path.Combine(alphabeticalFolder, firstChar);

                    // Only create the directory once
                    directoryCache.GetOrAdd(targetDir, _ => Directory.CreateDirectory(targetDir) != null);

                    // Move the directory
                    Directory.Move(dir, System.IO.Path.Combine(targetDir, dirName));
                });
            });
        }

        private async Task SortByDepth(string folderPath, bool skipSpecialCharacters)
        {
            string depthFolder = System.IO.Path.Combine(folderPath, "Depth");
            Directory.CreateDirectory(depthFolder);

            // Cache the created directories
            var directoryCache = new ConcurrentDictionary<string, bool>();

            // Precompile regex for performance
            Regex specialCharRegex = new Regex(@"^[a-zA-Z0-9_\-]+$", RegexOptions.Compiled);

            // Get directories and process them in parallel
            var directories = Directory.GetDirectories(folderPath, "*", SearchOption.TopDirectoryOnly);

            await Task.Run(() =>
            {

                Parallel.ForEach(directories, dir =>
                {
                    string dirName = System.IO.Path.GetFileName(dir);

                    if (skipSpecialCharacters && !specialCharRegex.IsMatch(dirName))
                    {
                        return;
                    }

                    int depth = GetFolderDepth(dir);
                    string depthDir = System.IO.Path.Combine(depthFolder, $"Depth_{depth}");

                    // Only create the directory once
                    directoryCache.GetOrAdd(depthDir, _ => Directory.CreateDirectory(depthDir) != null);

                    // Move the directory
                    Directory.Move(dir, System.IO.Path.Combine(depthDir, dirName));
                });
            });
        }

        private int GetFolderDepth(string folder)
        {
            return Directory.GetDirectories(folder, "*", SearchOption.AllDirectories).Length;
        }

        private async Task SortMedia(string folderPath, string jsonPath)
        {
            if (!File.Exists(jsonPath))
            {
                MessageBox.Show("One or both config files not found.");
                return;
            }

            string jsonString = await File.ReadAllTextAsync(jsonPath);
            var jsonContent = JObject.Parse(jsonString);

            // Extract sorting options from jsonPath
            var option = jsonContent["Media"].ToObject<JObject>();
            bool isDuration = (bool)option["Duration"];
            bool isResolution = (bool)option["Resolution"];
            bool isFrameRate = (bool)option["Frame_Rate"];
            bool isCodec = (bool)option["Codec"];
            bool isAspect = (bool)option["Aspect"];

            // Extract file extensions and allowed types from configTypePath
            var extensions = jsonContent["Type"].ToObject<JObject>();
            var allow = jsonContent["Type_Additional"].ToObject<JObject>();

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
            Invoke((MethodInvoker)(() => File_Count.Text = $"{totalFiles}"));

            // Filter files by allowed extensions
            var allowedExtensions = allowedMediaTypes
                .SelectMany(type => extensions[type].ToObject<string[]>())
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            var filteredFiles = files
                .Where(file => allowedExtensions.Contains(System.IO.Path.GetExtension(file).TrimStart('.')))
                .ToArray();

            if (!filteredFiles.Any())
            {
                MessageBox.Show("No files with allowed extensions found.");
                return;
            }

            // Split files into different media type categories
            var videoFiles = filteredFiles
                .Where(file => extensions["Videos"].ToObject<string[]>()
                .Any(ext => file.EndsWith(ext, StringComparison.OrdinalIgnoreCase)))
                .ToArray();

            var imageFiles = filteredFiles
                .Where(file => extensions["Images"].ToObject<string[]>()
                .Any(ext => file.EndsWith(ext, StringComparison.OrdinalIgnoreCase)))
                .ToArray();


            if (isDuration)
            {
                await SortByDuration(videoFiles);
            }
            if (isFrameRate)
            {
                await SortByFrameRate(videoFiles);
            }
            if (isCodec)
            {
                await SortByCodec(videoFiles);
            }
            if (isResolution)
            {
                await SortByResolution(videoFiles, imageFiles);
            }
            if (isAspect)
            {
                await SortByAspect(videoFiles, imageFiles);
            }
            MessageBox.Show("Sorting completed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async Task SortByDuration(string[] videoFiles)
        {
            if (videoFiles.Length == 0)
            {
                Debug.WriteLine("No files to display.");
                return;
            }

            var ffProbe = new FFProbe();
            progressBar_Time.Invoke((Action)(() => progressBar_Time.Maximum = videoFiles.Length));
            int processedFiles = 0;
            var directoriesCreated = new ConcurrentDictionary<string, bool>();

            await Task.Run(() =>
            {
                Parallel.ForEach(videoFiles, file =>
                {
                    try
                    {
                        var videoInfo = ffProbe.GetMediaInfo(file);
                        TimeSpan duration = TimeSpan.FromSeconds((int)videoInfo.Duration.TotalSeconds);
                        string durationFolder = duration.ToString(@"hh\-mm\-ss");
                        string targetFolderPath = System.IO.Path.Combine(Path, durationFolder);

                        directoriesCreated.GetOrAdd(targetFolderPath, _ =>
                        {
                            Directory.CreateDirectory(targetFolderPath);
                            return true;
                        });

                        string destinationFile = System.IO.Path.Combine(targetFolderPath, System.IO.Path.GetFileName(file));

                        // Check if a file with the same name already exists in the destination folder
                        if (File.Exists(destinationFile))
                        {
                            // If the file exists, add the [Duplicate] prefix to the file name
                            string duplicateFileName = $"[Duration]_{System.IO.Path.GetFileName(file)}";
                            destinationFile = System.IO.Path.Combine(targetFolderPath, duplicateFileName);
                        }

                        // Move the file to the target folder
                        File.Move(file, destinationFile);
                        Debug.WriteLine($"Moved file {file} to {destinationFile}");

                        Interlocked.Increment(ref processedFiles);
                        progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = processedFiles));
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"Error processing file {file}: {ex.Message}");
                    }
                });
            });

            progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = 0));
            Invoke(() => Populated_Treeview(Path));
        }

        private async Task SortByResolution(string[] videoFiles, string[] imageFiles)
        {
            if (videoFiles.Length == 0 && imageFiles.Length == 0)
            {
                Debug.WriteLine("No files to display.");
                return;
            }

            var ffProbe = new FFProbe();
            progressBar_Time.Invoke((Action)(() => progressBar_Time.Maximum = videoFiles.Length + imageFiles.Length));
            int processedFiles = 0;
            var directoriesCreated = new ConcurrentDictionary<string, bool>();

            await Task.Run(() =>
            {
                Parallel.ForEach(videoFiles, file =>
                {
                    try
                    {
                        var videoInfo = ffProbe.GetMediaInfo(file);
                        string resolution = $"{videoInfo.Streams[0].Width}x{videoInfo.Streams[0].Height}";
                        string targetFolderPath = System.IO.Path.Combine(Path, resolution);

                        directoriesCreated.GetOrAdd(targetFolderPath, _ =>
                        {
                            Directory.CreateDirectory(targetFolderPath);
                            return true;
                        });

                        string destinationFile = System.IO.Path.Combine(targetFolderPath, System.IO.Path.GetFileName(file));

                        if (File.Exists(destinationFile))
                        {
                            string duplicateFileName = $"[Resolution]_{System.IO.Path.GetFileName(file)}";
                            destinationFile = System.IO.Path.Combine(targetFolderPath, duplicateFileName);
                        }

                        File.Move(file, destinationFile);
                        Debug.WriteLine($"Moved file {file} to {destinationFile}");

                        Interlocked.Increment(ref processedFiles);
                        progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = processedFiles));
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"Error processing file {file}: {ex.Message}");
                    }
                });

                Parallel.ForEach(imageFiles, file =>
                {
                    try
                    {
                        using (var img = Image.FromFile(file))
                        {
                            string resolution = $"{img.Width}x{img.Height}";
                            string targetFolderPath = System.IO.Path.Combine(Path, "SortedByResolution_Images", resolution);

                            directoriesCreated.GetOrAdd(targetFolderPath, _ =>
                            {
                                Directory.CreateDirectory(targetFolderPath);
                                return true;
                            });

                            string destinationFile = System.IO.Path.Combine(targetFolderPath, System.IO.Path.GetFileName(file));

                            if (File.Exists(destinationFile))
                            {
                                string duplicateFileName = $"[Duplicate]_{System.IO.Path.GetFileName(file)}";
                                destinationFile = System.IO.Path.Combine(targetFolderPath, duplicateFileName);
                            }

                            File.Move(file, destinationFile);
                            Debug.WriteLine($"Moved file {file} to {destinationFile}");

                            Interlocked.Increment(ref processedFiles);
                            progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = processedFiles));
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"Error processing file {file}: {ex.Message}");
                    }
                });
            });

            progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = 0));
            Invoke(() => Populated_Treeview(Path));
        }

        private async Task SortByFrameRate(string[] videoFiles)
        {
            if (videoFiles.Length == 0)
            {
                Debug.WriteLine("No files to display.");
                return;
            }

            var ffProbe = new FFProbe();
            progressBar_Time.Invoke((Action)(() => progressBar_Time.Maximum = videoFiles.Length));
            int processedFiles = 0;
            var directoriesCreated = new ConcurrentDictionary<string, bool>();

            await Task.Run(() =>
            {
                Parallel.ForEach(videoFiles, file =>
                {
                    try
                    {
                        var videoInfo = ffProbe.GetMediaInfo(file);
                        var codec = videoInfo.Streams.First().CodecName;
                        var folderName = $"Codec_{codec}";
                        var targetFolderPath = System.IO.Path.Combine(Path, folderName);

                        directoriesCreated.GetOrAdd(targetFolderPath, _ =>
                        {
                            Directory.CreateDirectory(targetFolderPath);
                            return true;
                        });

                        var destinationFile = System.IO.Path.Combine(targetFolderPath, System.IO.Path.GetFileName(file));

                        if (File.Exists(destinationFile))
                        {
                            string duplicateFileName = $"[FrameRate]_{System.IO.Path.GetFileName(file)}";
                            destinationFile = System.IO.Path.Combine(targetFolderPath, duplicateFileName);
                        }

                        File.Move(file, destinationFile);
                        Debug.WriteLine($"Moved file {file} to {destinationFile}");

                        Interlocked.Increment(ref processedFiles);
                        progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = processedFiles));
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"Error processing file {file}: {ex.Message}");
                    }
                });
            });

            progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = 0));
            Invoke(() => Populated_Treeview(Path));
        }

        private async Task SortByCodec(string[] videoFiles)
        {
            if (videoFiles.Length == 0)
            {
                Debug.WriteLine("No files to display.");
                return;
            }

            var ffProbe = new FFProbe();
            progressBar_Time.Invoke((Action)(() => progressBar_Time.Maximum = videoFiles.Length));
            int processedFiles = 0;
            var directoriesCreated = new ConcurrentDictionary<string, bool>();

            await Task.Run(() =>
            {
                Parallel.ForEach(videoFiles, file =>
                {
                    try
                    {
                        var videoInfo = ffProbe.GetMediaInfo(file);
                        var codec = videoInfo.Streams.First().CodecName;
                        var folderName = $"Codec_{codec}";
                        var targetFolderPath = System.IO.Path.Combine(Path, folderName);

                        directoriesCreated.GetOrAdd(targetFolderPath, _ =>
                        {
                            Directory.CreateDirectory(targetFolderPath);
                            return true;
                        });

                        var destinationFile = System.IO.Path.Combine(targetFolderPath, System.IO.Path.GetFileName(file));

                        if (File.Exists(destinationFile))
                        {
                            string duplicateFileName = $"[Codec]_{System.IO.Path.GetFileName(file)}";
                            destinationFile = System.IO.Path.Combine(targetFolderPath, duplicateFileName);
                        }

                        File.Move(file, destinationFile);
                        Debug.WriteLine($"Moved file {file} to {destinationFile}");

                        Interlocked.Increment(ref processedFiles);
                        progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = processedFiles));
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"Error processing file {file}: {ex.Message}");
                    }
                });
            });

            progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = 0));
            Invoke(() => Populated_Treeview(Path));
        }

        private async Task SortByAspect(string[] videoFiles, string[] imageFiles)
        {
            if (videoFiles.Length == 0 && imageFiles.Length == 0)
            {
                Debug.WriteLine("No files to display.");
                return;
            }

            var ffProbe = new FFProbe();
            progressBar_Time.Invoke((Action)(() => progressBar_Time.Maximum = videoFiles.Length + imageFiles.Length));
            int processedFiles = 0;
            var directoriesCreated = new ConcurrentDictionary<string, bool>();

            await Task.Run(() =>
            {
                Parallel.ForEach(videoFiles, file =>
                {
                    try
                    {
                        var videoInfo = ffProbe.GetMediaInfo(file);
                        var videoStream = videoInfo.Streams.FirstOrDefault(s => s.CodecType == "video");
                        if (videoStream != null)
                        {
                            var width = videoStream.Width;
                            var height = videoStream.Height;
                            var aspectRatio = (double)width / height;
                            var folderName = $"AspectRatio_{aspectRatio:F2}";
                            var targetFolderPath = System.IO.Path.Combine(Path, folderName);

                            directoriesCreated.GetOrAdd(targetFolderPath, _ =>
                            {
                                Directory.CreateDirectory(targetFolderPath);
                                return true;
                            });

                            var destinationFile = System.IO.Path.Combine(targetFolderPath, System.IO.Path.GetFileName(file));

                            if (File.Exists(destinationFile))
                            {
                                string duplicateFileName = $"[Aspect]_{System.IO.Path.GetFileName(file)}";
                                destinationFile = System.IO.Path.Combine(targetFolderPath, duplicateFileName);
                            }

                            File.Move(file, destinationFile);
                            Debug.WriteLine($"Moved file {file} to {destinationFile}");

                            Interlocked.Increment(ref processedFiles);
                            progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = processedFiles));
                        }
                        else
                        {
                            Debug.WriteLine("No video stream found.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"Error processing file {file}: {ex.Message}");
                    }
                });

                Parallel.ForEach(imageFiles, file =>
                {
                    try
                    {
                        using (var image = Image.FromFile(file))
                        {
                            var width = image.Width;
                            var height = image.Height;
                            var aspectRatio = (double)width / height;
                            var folderName = $"AspectRatio_{aspectRatio:F2}";
                            var targetFolderPath = System.IO.Path.Combine(Path, folderName);

                            directoriesCreated.GetOrAdd(targetFolderPath, _ =>
                            {
                                Directory.CreateDirectory(targetFolderPath);
                                return true;
                            });

                            var destinationFile = System.IO.Path.Combine(targetFolderPath, System.IO.Path.GetFileName(file));

                            if (File.Exists(destinationFile))
                            {
                                string duplicateFileName = $"[Duplicate]_{System.IO.Path.GetFileName(file)}";
                                destinationFile = System.IO.Path.Combine(targetFolderPath, duplicateFileName);
                            }

                            File.Move(file, destinationFile);
                            Debug.WriteLine($"Moved file {file} to {destinationFile}");

                            Interlocked.Increment(ref processedFiles);
                            progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = processedFiles));
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"Error processing file {file}: {ex.Message}");
                    }
                });
            });

            progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = 0));
            Invoke(() => Populated_Treeview(Path));
        }
    }
}