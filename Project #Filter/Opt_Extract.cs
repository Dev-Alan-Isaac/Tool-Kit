using Newtonsoft.Json.Linq;
using SharpCompress.Archives;
using SharpCompress.Archives.Rar;
using SharpCompress.Archives.Tar;
using SharpCompress.Common;
using SharpCompress.Writers;
using System.Collections.Concurrent;
using System.IO.Compression;
using System.Security.Cryptography;

namespace Project__Filter
{
    public partial class Opt_Extract : UserControl
    {
        private string Path;

        public Opt_Extract()
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
                    var files = Directory.GetFiles(fbd.SelectedPath, "*.*", SearchOption.AllDirectories);
                    int filestotal = files.Length;
                    File_Count.Text = $"{filestotal}";
                }
            }
        }

        private async void Populated_Treeview(string folderPath)
        {
            // Clear the TreeView first
            treeView1.Nodes.Clear();

            // Get all files from the folder and its subfolders (after sorting)
            var files = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories);

            // Group files by their parent folder
            var groupedFiles = files
                .GroupBy(file => System.IO.Path.GetDirectoryName(file))
                .ToList();

            // Iterate over each group (each folder)
            foreach (var group in groupedFiles)
            {
                // Create a node for the folder
                TreeNode folderNode = new TreeNode(System.IO.Path.GetFileName(group.Key));

                // Add file names as child nodes under the folder node
                foreach (var file in group)
                {
                    TreeNode fileNode = new TreeNode(System.IO.Path.GetFileName(file));
                    folderNode.Nodes.Add(fileNode);
                }

                // Add the folder node to the TreeView
                treeView1.Nodes.Add(folderNode);
            }
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            // Enable the filter button when any radio button is checked
            if (radioButton_Rar.Checked || radioButton_Zip.Checked
                || radioButton_Tar.Checked || radioButton_Extract.Checked)
            {
                button_Filter.Enabled = true;
            }
            else
            {
                button_Filter.Enabled = false;
            }
        }

        private async void button_Filter_Click(object sender, EventArgs e)
        {
            button_Filter.Enabled = false;

            if (radioButton_Extract.Checked)
            {
                await Task.Run(() => Extact_Option(Path));
            }
            else if (radioButton_Rar.Checked)
            {
                await Task.Run(() => Decompress_RAR(Path));
            }
            else if (radioButton_Zip.Checked)
            {
                await Task.Run(() => Decompress_ZIP(Path));
            }
            else if (radioButton_Tar.Checked)
            {
                await Task.Run(() => Decompress_TAR(Path));
            }
        }

        private async void Extact_Option(string path)
        {
            string config_Path = System.IO.Path.GetFullPath("Config_Extract.json");
            if (!File.Exists(config_Path))
            {
                MessageBox.Show("Config file not found.");
                return;
            }

            string jsonString = await File.ReadAllTextAsync(config_Path);
            var jsonContent = JObject.Parse(jsonString);

            var extensionsObject = jsonContent["Option"] as JObject;
            if (extensionsObject != null)
            {
                bool isDelete = jsonContent["Option"]["Delete"]?.ToObject<bool>() ?? false;
                bool isSubfolder = jsonContent["Option"]["Subfolder"]?.ToObject<bool>() ?? false;
                bool isName = jsonContent["Option"]["ByName"]?.ToObject<bool>() ?? false;
                bool isHash = jsonContent["Option"]["ByHash"]?.ToObject<bool>() ?? false;
                bool isRoot = jsonContent["Option"]["Root"]?.ToObject<bool>() ?? false;
                bool isSplit = jsonContent["Option"]["Split"]?.ToObject<bool>() ?? false;
                bool isGroup = jsonContent["Option"]["Group"]?.ToObject<bool>() ?? false;
                bool isRootDecompress = jsonContent["Option"]["RootDecompress"]?.ToObject<bool>() ?? false;
                bool isFolder = jsonContent["Option"]["Folder"]?.ToObject<bool>() ?? false;

                if (isName)
                {
                    await Task.Run(() => Extract_Name(path));
                }

                if (isHash)
                {
                    await Task.Run(() => Extract_Hash(path, isRoot, isSplit, isGroup));
                }
            }
        }

        private async void Extract_Name(string sourcePath)
        {
            var files = await ProcessFiles(sourcePath);
            int totalFiles = files.Length;

            progressBar_Time.Invoke((Action)(() => progressBar_Time.Maximum = files.Length));
            int processedFiles = 0;

            bool duplicateFolderCreated = false;

            foreach (var file in files)
            {
                try
                {
                    // Get the file name and the destination path for this file
                    string fileName = System.IO.Path.GetFileName(file);
                    string destinationFilePath = System.IO.Path.Combine(sourcePath, fileName);

                    // Check if a file with the same full name (including extension) already exists in the destination path
                    if (File.Exists(destinationFilePath) && file != destinationFilePath)
                    {
                        // Ensure the "Duplicated" folder exists in the source path only when a duplicate is found
                        if (!duplicateFolderCreated)
                        {
                            string duplicatedFolder = System.IO.Path.Combine(sourcePath, "Duplicates");
                            Directory.CreateDirectory(duplicatedFolder);
                            duplicateFolderCreated = true;
                        }

                        // Move the file to the "Duplicated" folder instead
                        string duplicateFilePath = System.IO.Path.Combine(sourcePath, "Duplicates", fileName);
                        // If a file with the same name already exists in the Duplicated folder, create a unique name
                        if (File.Exists(duplicateFilePath))
                        {
                            // Create a unique file name to avoid overwriting
                            string newFileName = System.IO.Path.GetFileNameWithoutExtension(fileName) + "_" + Guid.NewGuid() + System.IO.Path.GetExtension(fileName);
                            duplicateFilePath = System.IO.Path.Combine(sourcePath, "Duplicates", newFileName);
                        }
                        File.Move(file, duplicateFilePath);
                    }
                    else
                    {
                        // Move the file to the destination path
                        File.Move(file, destinationFilePath);
                    }

                    processedFiles++;
                    // Update the progress bar
                    progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = processedFiles));
                }
                catch (Exception ex)
                {
                    // Handle errors (e.g., file in use or permission issues)
                    MessageBox.Show($"Error processing file {file}: {ex.Message}");
                }
            }

            button_Filter.Invoke((Action)(() => button_Filter.Enabled = true));
            progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = 0));
            MessageBox.Show("Files have been moved and duplicates have been handled.");
        }

        private async void Extract_Hash(string path, bool isRoot, bool isSplit, bool isGroup)
        {
            if (isRoot)
            {
                Hash_Root(path);
            }
            else if (isSplit)
            {
                Hash_Split(path);
            }
            else if (isGroup)
            {
                Hash_Group(path);
            }
        }

        private async void Hash_Root(string path)
        {
            // Define paths for non-duplicate and duplicate files
            string duplicatesFolderPath = System.IO.Path.Combine(path, "Duplicates");

            // Ensure the directory for duplicates exists
            if (!Directory.Exists(duplicatesFolderPath))
            {
                Directory.CreateDirectory(duplicatesFolderPath);
            }

            // Dictionary to store file hashes and corresponding file paths
            Dictionary<string, string> fileHashes = new Dictionary<string, string>();

            // Get all files from the directory (and subdirectories, if necessary)
            string[] files = await ProcessFiles(path);

            // Initialize the progress bar
            progressBar_Time.Invoke((Action)(() => progressBar_Time.Maximum = files.Length));
            int processedFiles = 0;

            // Process each file in the directory
            foreach (var file in files)
            {
                // Compute the hash of the current file
                string fileHash = await ComputeFileHashAsync(file);

                // Check if this hash already exists in the dictionary (indicating a duplicate)
                if (fileHashes.ContainsKey(fileHash))
                {
                    // File is a duplicate, move it to the Duplicates folder
                    string destinationPath = System.IO.Path.Combine(duplicatesFolderPath, System.IO.Path.GetFileName(file));

                    // If a file with the same name already exists, generate a unique file name
                    if (File.Exists(destinationPath))
                    {
                        string uniqueDestination = System.IO.Path.Combine(
                            System.IO.Path.GetDirectoryName(destinationPath),
                            System.IO.Path.GetFileNameWithoutExtension(destinationPath) + "_" + Guid.NewGuid().ToString() + System.IO.Path.GetExtension(destinationPath)
                        );
                        File.Move(file, uniqueDestination);
                    }
                    else
                    {
                        File.Move(file, destinationPath);
                    }
                }
                else
                {
                    // File is unique, add its hash to the dictionary
                    fileHashes[fileHash] = file;

                    // Keep the file in the same folder
                    string destinationPath = System.IO.Path.Combine(path, System.IO.Path.GetFileName(file));

                    // If a file with the same name already exists, generate a unique file name
                    if (File.Exists(destinationPath))
                    {
                        string uniqueDestination = System.IO.Path.Combine(
                            System.IO.Path.GetDirectoryName(destinationPath),
                            System.IO.Path.GetFileNameWithoutExtension(destinationPath) + "_" + Guid.NewGuid().ToString() + System.IO.Path.GetExtension(destinationPath)
                        );
                        File.Move(file, uniqueDestination);
                    }
                    else
                    {
                        File.Move(file, destinationPath);
                    }
                }

                // Update the progress bar
                processedFiles++;
                progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = processedFiles));
            }

            // Enable the filter button and reset the progress bar when done
            button_Filter.Invoke((Action)(() => button_Filter.Enabled = true));
            progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = 0));

            // Show completion message
            MessageBox.Show("Files relocated successfully.");
        }

        private async void Hash_Split(string path)
        {
            // Ensure the target "Files" directory exists
            string filesFolder = System.IO.Path.Combine(path, "Files");
            Directory.CreateDirectory(filesFolder);

            // Get all files from the path, including subfolders
            string[] files = await ProcessFiles(path);

            progressBar_Time.Invoke(() =>
            {
                progressBar_Time.Maximum = files.Length;
                progressBar_Time.Value = 0;
            });

            int processedFiles = 0;
            List<string> errorFiles = new List<string>(); // List to track files with errors
            ConcurrentDictionary<string, string> fileHashes = new ConcurrentDictionary<string, string>(); // To track file hashes
            bool duplicatesFound = false;
            string duplicatesFolder = System.IO.Path.Combine(path, "Duplicates");

            await Task.Run(() =>
            {
                Parallel.ForEach(files, file =>
                {
                    try
                    {
                        // Compute a hash for the file (or use file name as the key)
                        string fileHash = ComputeFileHashAsync(file).Result;

                        // Check if the file's hash is already in the dictionary (duplicate)
                        if (fileHashes.ContainsKey(fileHash))
                        {
                            // Create the "Duplicates" folder if any duplicate is found
                            if (!duplicatesFound)
                            {
                                Directory.CreateDirectory(duplicatesFolder);
                                duplicatesFound = true; // Mark that duplicates have been found
                            }

                            // Move the duplicate file to the "Duplicates" folder
                            string duplicateFilePath = System.IO.Path.Combine(duplicatesFolder, System.IO.Path.GetFileName(file));

                            // Handle possible file name collisions in "Duplicates" folder
                            if (File.Exists(duplicateFilePath))
                            {
                                string relocatedFileName = "[Duplicate]" + System.IO.Path.GetFileName(file);
                                duplicateFilePath = System.IO.Path.Combine(duplicatesFolder, relocatedFileName);
                            }

                            File.Move(file, duplicateFilePath);
                        }
                        else
                        {
                            // Define the new file path in the "Files" folder
                            string newFilePath = System.IO.Path.Combine(filesFolder, System.IO.Path.GetFileName(file));

                            // Check if a file with the same name already exists in the destination folder
                            if (File.Exists(newFilePath))
                            {
                                // Rename the file by adding the "[Relocated]" prefix
                                string relocatedFileName = "[Relocated]" + System.IO.Path.GetFileName(file);
                                newFilePath = System.IO.Path.Combine(filesFolder, relocatedFileName);
                            }

                            // Move the file to the "Files" folder
                            File.Move(file, newFilePath);

                            // Add the file's hash to the dictionary
                            fileHashes.TryAdd(fileHash, newFilePath);
                        }

                        // Update the processed file count and progress bar
                        Interlocked.Increment(ref processedFiles);
                        progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = processedFiles));
                    }
                    catch (Exception ex)
                    {
                        // Log the file and exception message in the error list
                        lock (errorFiles)
                        {
                            errorFiles.Add($"{file}: {ex.Message}");
                        }
                    }
                });
            });

            // Handle post-processing of errors
            if (errorFiles.Count == 1)
            {
                MessageBox.Show($"Error processing file {errorFiles[0]}");
            }
            else if (errorFiles.Count > 1)
            {
                string errorLogPath = System.IO.Path.Combine(path, "ErrorLog.txt");
                File.WriteAllLines(errorLogPath, errorFiles);
                MessageBox.Show($"Multiple files failed to process. See error log at {errorLogPath}");
            }

            // Reset progress bar and re-enable filter button
            progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = 0));
            button_Filter.Invoke((Action)(() => button_Filter.Enabled = true));
            MessageBox.Show("Files relocated successfully.");
        }

        private async void Hash_Group(string path)
        {
            string[] files = await ProcessFiles(path);
            ConcurrentDictionary<string, List<string>> hashGroups = new ConcurrentDictionary<string, List<string>>();
            int folderNumber = 1;

            // Ensure progress bar minimum and maximum values are set
            progressBar_Time.Invoke(() =>
            {
                progressBar_Time.Minimum = 0;
                progressBar_Time.Maximum = files.Length;
                progressBar_Time.Value = 0;
            });

            int processedFiles = 0;

            // Compute hashes and group files by hash
            await Task.Run(() =>
            {
                Parallel.ForEach(files, file =>
                {
                    try
                    {
                        string hash = ComputeFileHashAsync(file).Result;
                        hashGroups.AddOrUpdate(hash,
                            new List<string> { file },
                            (key, existingList) =>
                            {
                                lock (existingList)
                                {
                                    existingList.Add(file);
                                }
                                return existingList;
                            });

                        Interlocked.Increment(ref processedFiles);
                        progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = processedFiles));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error processing file {file}: {ex.Message}");
                    }
                });
            });

            // Reset the progress bar for moving files
            progressBar_Time.Invoke((Action)(() =>
            {
                progressBar_Time.Minimum = 0;
                progressBar_Time.Value = 0;
                progressBar_Time.Maximum = hashGroups.Values.Sum(group => group.Count > 1 ? group.Count : 0);
            }));
            processedFiles = 0;

            // Move duplicate files into separate folders
            await Task.Run(() =>
            {
                foreach (var group in hashGroups)
                {
                    if (group.Value.Count > 1)
                    {
                        // Create "Hashes" folder if it doesn't exist
                        string hashesFolder = System.IO.Path.Combine(path, "Hashes");
                        Directory.CreateDirectory(hashesFolder);

                        // Create a numbered folder for the group
                        string numberedFolder = System.IO.Path.Combine(hashesFolder, folderNumber.ToString());
                        Directory.CreateDirectory(numberedFolder);

                        foreach (var file in group.Value)
                        {
                            try
                            {
                                string fileName = System.IO.Path.GetFileName(file);
                                string destinationFilePath = System.IO.Path.Combine(numberedFolder, fileName);

                                // If the destination file already exists, append a unique identifier
                                if (File.Exists(destinationFilePath))
                                {
                                    string fileWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(fileName);
                                    string extension = System.IO.Path.GetExtension(fileName);
                                    destinationFilePath = System.IO.Path.Combine(
                                        numberedFolder,
                                        $"{fileWithoutExtension}_{Guid.NewGuid()}{extension}" // Append GUID to the file name
                                    );
                                }

                                File.Move(file, destinationFilePath);
                                processedFiles++;

                                // Update the progress bar
                                progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = processedFiles));
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error moving file {file}: {ex.Message}");
                            }
                        }
                        folderNumber++;
                    }
                }
            });

            // Final reset of the progress bar
            progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = 0));
            button_Filter.Invoke((Action)(() => button_Filter.Enabled = true));
            MessageBox.Show("Files have been processed and duplicates moved.");
        }

        private async Task<string> ComputeFileHashAsync(string filePath)
        {
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, true))
            using (var sha256 = SHA256.Create())
            {
                byte[] hashBytes = await sha256.ComputeHashAsync(stream);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
            }
        }

        public async Task<string[]> ProcessFiles(string parentPath)
        {
            string config_file = "Config_Extract.json";

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

        private async void Decompress_RAR(string path)
        {

        }

        private async void Decompress_ZIP(string path)
        {

        }

        private async void Decompress_TAR(string path)
        {

        }
    }
}
