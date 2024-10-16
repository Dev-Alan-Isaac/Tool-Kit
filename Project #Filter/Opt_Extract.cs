using Newtonsoft.Json.Linq;
using System.Collections.Concurrent;
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
            // Ensure the target directories for "Files" and "Duplicates" exist
            string filesFolder = System.IO.Path.Combine(path, "Files");
            Directory.CreateDirectory(filesFolder);

            string duplicatesFolder = System.IO.Path.Combine(path, "Duplicates");
            Directory.CreateDirectory(duplicatesFolder);

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

            await Task.Run(() =>
            {
                Parallel.ForEach(files, file =>
                {
                    try
                    {
                        // Compute a hash for the file (or use file name as the key)
                        string fileHash = ComputeFileHashAsync(file).Result;

                        // Check if the file's hash is already in the dictionary (duplicate by hash)
                        if (fileHashes.ContainsKey(fileHash))
                        {
                            // Move the duplicate file to the "Duplicates" folder
                            string duplicateFilePath = System.IO.Path.Combine(duplicatesFolder, System.IO.Path.GetFileName(file));

                            // Handle possible file name collisions in the "Duplicates" folder
                            if (File.Exists(duplicateFilePath))
                            {
                                string relocatedFileName = "[Duplicated]" + System.IO.Path.GetFileName(file);
                                duplicateFilePath = System.IO.Path.Combine(duplicatesFolder, relocatedFileName);
                            }

                            File.Move(file, duplicateFilePath);
                        }
                        else
                        {
                            // Define the new file path in the "Files" folder
                            string newFilePath = System.IO.Path.Combine(filesFolder, System.IO.Path.GetFileName(file));

                            // Check if a file with the same name already exists in the "Files" folder (same name, different hash)
                            if (File.Exists(newFilePath))
                            {
                                // Rename the file by adding the "[File]" prefix to indicate it's the same name but not a duplicate by hash
                                string relocatedFileName = "[File]" + System.IO.Path.GetFileName(file);
                                newFilePath = System.IO.Path.Combine(filesFolder, relocatedFileName);
                            }

                            // Move the file to the "Files" folder
                            File.Move(file, newFilePath);

                            // Add the file's hash to the dictionary
                            fileHashes.TryAdd(fileHash, newFilePath);
                        }

                        // Update the processed file count and progress bar
                        Interlocked.Increment(ref processedFiles);
                        progressBar_Time.Invoke(() => progressBar_Time.Value = processedFiles);
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
            progressBar_Time.Invoke(() => progressBar_Time.Value = 0);
            button_Filter.Invoke(() => button_Filter.Enabled = true);
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
                        progressBar_Time.Invoke(() => progressBar_Time.Value = processedFiles);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error processing file {file}: {ex.Message}");
                    }
                });
            });

            // Reset the progress bar for moving files
            progressBar_Time.Invoke(() =>
            {
                progressBar_Time.Minimum = 0;
                progressBar_Time.Value = 0;
                progressBar_Time.Maximum = hashGroups.Values.Sum(group => group.Count > 1 ? group.Count : 0);
            });
            processedFiles = 0;

            // Create "File" folder for non-duplicate files
            string fileFolder = System.IO.Path.Combine(path, "File");
            Directory.CreateDirectory(fileFolder);

            // Create "Hashes" folder for groups of duplicates
            string hashesFolder = System.IO.Path.Combine(path, "Hashes");
            Directory.CreateDirectory(hashesFolder);

            // Move files based on their hash groups
            await Task.Run(() =>
            {
                foreach (var group in hashGroups)
                {
                    if (group.Value.Count > 1)
                    {
                        // For duplicate files, create a new folder for the group (Hash_Group[Number])
                        string numberedFolder = System.IO.Path.Combine(hashesFolder, $"Hash_Group{folderNumber}");
                        Directory.CreateDirectory(numberedFolder);

                        // Move each file in the group to the numbered folder
                        foreach (var file in group.Value)
                        {
                            try
                            {
                                string fileName = System.IO.Path.GetFileName(file);
                                string destinationFilePath = System.IO.Path.Combine(numberedFolder, fileName);

                                // If the file already exists in the folder (same name), add [Hash] prefix
                                if (File.Exists(destinationFilePath))
                                {
                                    string hashPrefix = "[Hash]" + fileName;
                                    destinationFilePath = System.IO.Path.Combine(numberedFolder, hashPrefix);
                                }

                                File.Move(file, destinationFilePath);
                                processedFiles++;

                                // Update the progress bar
                                progressBar_Time.Invoke(() => progressBar_Time.Value = processedFiles);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error moving file {file}: {ex.Message}");
                            }
                        }
                        folderNumber++;
                    }
                    else
                    {
                        // Move non-duplicate files to the "File" folder
                        string file = group.Value.First();
                        string fileName = System.IO.Path.GetFileName(file);
                        string newFilePath = System.IO.Path.Combine(fileFolder, fileName);

                        // Handle name collisions in the "File" folder
                        if (File.Exists(newFilePath))
                        {
                            string relocatedFileName = "[File]" + fileName;
                            newFilePath = System.IO.Path.Combine(fileFolder, relocatedFileName);
                        }

                        try
                        {
                            File.Move(file, newFilePath);
                            processedFiles++;
                            progressBar_Time.Invoke(() => progressBar_Time.Value = processedFiles);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error moving file {file}: {ex.Message}");
                        }
                    }
                }
            });

            // Final reset of the progress bar
            progressBar_Time.Invoke(() => progressBar_Time.Value = 0);
            button_Filter.Invoke(() => button_Filter.Enabled = true);
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
