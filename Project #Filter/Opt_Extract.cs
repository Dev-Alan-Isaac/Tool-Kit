using SharpCompress.Archives;
using SharpCompress.Archives.Rar;
using SharpCompress.Archives.Tar;
using SharpCompress.Common;
using SharpCompress.Writers;
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
            if (radioButton_Relocate.Checked || radioButton_Rar.Checked ||
                radioButton_Zip.Checked || radioButton_Tar.Checked)
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
            if (radioButton_Relocate.Checked)
            {
                await Task.Run(() => Relocate(Path));
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

        private async void Relocate(string path)
        {
            // Ensure the target "Files" directory exists
            string filesFolder = System.IO.Path.Combine(path, "Files");
            Directory.CreateDirectory(filesFolder);

            // Get all files from the path, including subfolders
            var files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);

            progressBar_Time.Invoke((Action)(() => progressBar_Time.Maximum = files.Length));
            int processedFiles = 0;

            // Dictionary to track file hashes (or use file names if you don't want to compare hashes)
            Dictionary<string, string> fileHashes = new Dictionary<string, string>();

            // Track if any duplicates are found
            bool duplicatesFound = false;

            foreach (var file in files)
            {
                try
                {
                    // Compute a hash for the file to check for duplicates (or use file name as the key)
                    string fileHash = await ComputeFileHashAsync(file);

                    // Check if the file's hash is already in the dictionary (duplicate) 
                    if (fileHashes.ContainsKey(fileHash))
                    {
                        // If this is the first duplicate, create the "Duplicates" folder
                        if (!duplicatesFound)
                        {
                            string duplicatesFolder = System.IO.Path.Combine(path, "Duplicates");
                            Directory.CreateDirectory(duplicatesFolder);
                            duplicatesFound = true; // Mark that duplicates have been found
                        }

                        // Move the duplicate file to the "Duplicates" folder
                        string duplicatesFolderPath = System.IO.Path.Combine(path, "Duplicates");
                        string duplicateFilePath = System.IO.Path.Combine(duplicatesFolderPath, System.IO.Path.GetFileName(file));
                        File.Move(file, duplicateFilePath);
                    }
                    else
                    {
                        // Move the file to the "Files" folder
                        string newFilePath = System.IO.Path.Combine(filesFolder, System.IO.Path.GetFileName(file));
                        File.Move(file, newFilePath);

                        // Add the file's hash to the dictionary
                        fileHashes[fileHash] = newFilePath;
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

            // Reset the progress bar after the operation is complete
            progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = 0));

            // Notify the user when the relocation process is done
            MessageBox.Show("Files relocated successfully.");
        }


        // Example method to compute file hash (SHA256 in this case)
        private async Task<string> ComputeFileHashAsync(string filePath)
        {
            using (var sha256 = SHA256.Create())
            {
                using (var fileStream = File.OpenRead(filePath))
                {
                    var hash = await sha256.ComputeHashAsync(fileStream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
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

        // Functions
        //public async Task MoveFiles(string rootPath)
        //{
        //    // Construct the destination folder paths
        //    string extractedFolder = Path.Combine(rootPath, "Extracted");
        //    string duplicatedFolder = Path.Combine(rootPath, "Duplicated");

        //    // Create a Progress<T> object to report progress from the background task to the UI thread
        //    var progress = new Progress<int>(value =>
        //    {
        //        // Update your progress bar here
        //        progressBar_Time.Value = value;
        //    });

        //    await Task.Run(() =>
        //    {
        //        // Get all files in the root path and its subdirectories
        //        var files = Directory.EnumerateFiles(rootPath, "*.*", SearchOption.AllDirectories).ToList();

        //        for (int i = 0; i < files.Count; i++)
        //        {
        //            var file = files[i];

        //            // Skip if the file is in the destination folders
        //            if (file.StartsWith(extractedFolder) || file.StartsWith(duplicatedFolder))
        //            {
        //                continue;
        //            }

        //            // Get the file name
        //            string fileName = Path.GetFileName(file);

        //            // Construct the destination paths
        //            string destPathExtracted = Path.Combine(extractedFolder, fileName);
        //            string destPathDuplicated = Path.Combine(duplicatedFolder, fileName);

        //            // Check if the file already exists in the extracted folder
        //            if (File.Exists(destPathExtracted))
        //            {
        //                // If the file exists, move it to the duplicated folder, Ensure the destination folder exists
        //                Directory.CreateDirectory(duplicatedFolder);

        //                // Check if the file already exists in the duplicated folder
        //                int count = 1;
        //                string fileNameOnly = Path.GetFileNameWithoutExtension(fileName);
        //                string extension = Path.GetExtension(fileName);
        //                string newFullPath = destPathDuplicated;
        //                while (File.Exists(newFullPath))
        //                {
        //                    string tempFileName = $"{fileNameOnly} ({count++}){extension}";
        //                    newFullPath = Path.Combine(duplicatedFolder, tempFileName);
        //                }
        //                File.Move(file, newFullPath);
        //            }
        //            else
        //            {
        //                // If the file does not exist, move it to the extracted folder, Ensure the destination folder exists
        //                Directory.CreateDirectory(extractedFolder);
        //                File.Move(file, destPathExtracted);
        //            }
        //            // Report progress
        //            ((IProgress<int>)progress).Report((i + 1) * 100 / files.Count);
        //        }
        //    });
        //    progressBar_Time.Value = 0;
        //}

        //public void UncompressRar(string rootPath)
        //{
        //    string destinationPath = Path.Combine(Path.GetDirectoryName(rootPath), Path.GetFileNameWithoutExtension(rootPath));
        //    Directory.CreateDirectory(destinationPath);

        //    try
        //    {
        //        using (var archive = RarArchive.Open(rootPath))
        //        {
        //            foreach (var entry in archive.Entries)
        //            {
        //                if (!entry.IsDirectory)
        //                {
        //                    Console.WriteLine("Extracting: " + entry.Key);
        //                    entry.WriteToDirectory(destinationPath, new ExtractionOptions()
        //                    {
        //                        ExtractFullPath = true,
        //                        Overwrite = true
        //                    });
        //                }
        //            }
        //        }
        //        Console.WriteLine("Extraction completed successfully.");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("An error occurred while extracting the file. Details: " + ex.Message);
        //    }
        //}

        //public void UncompressTar(string rootpPath)
        //{
        //    string destinationPath = Path.Combine(Path.GetDirectoryName(rootpPath), Path.GetFileNameWithoutExtension(rootpPath));
        //    Directory.CreateDirectory(destinationPath);

        //    try
        //    {
        //        using (var archive = TarArchive.Open(rootpPath))
        //        {
        //            foreach (var entry in archive.Entries)
        //            {
        //                if (!entry.IsDirectory)
        //                {
        //                    Console.WriteLine("Extracting: " + entry.Key);
        //                    entry.WriteToDirectory(destinationPath, new ExtractionOptions()
        //                    {
        //                        ExtractFullPath = true,
        //                        Overwrite = true
        //                    });
        //                }
        //            }
        //        }
        //        Console.WriteLine("Extraction completed successfully.");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("An error occurred while extracting the file. Details: " + ex.Message);
        //    }
        //}

        //public static void CompressTar(string rootPath)
        //{
        //    string tarFilePath = Path.Combine(Path.GetDirectoryName(rootPath), Path.GetFileName(rootPath) + ".tar");

        //    try
        //    {
        //        using (var stream = File.OpenWrite(tarFilePath))
        //        {
        //            using (var writer = WriterFactory.Open(stream, ArchiveType.Tar, CompressionType.None))
        //            {
        //                writer.WriteAll(rootPath, "*", SearchOption.AllDirectories);
        //            }
        //        }
        //        Console.WriteLine("Compression completed successfully.");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("An error occurred while compressing the directory. Details: " + ex.Message);
        //    }
        //}

        //public static void CompressRar(string rootPath)
        //{
        //    string rarFilePath = Path.Combine(Path.GetDirectoryName(rootPath), Path.GetFileName(rootPath) + ".rar");

        //    try
        //    {
        //        using (var stream = File.OpenWrite(rarFilePath))
        //        {
        //            using (var writer = WriterFactory.Open(stream, ArchiveType.Rar, CompressionType.Rar))
        //            {
        //                writer.WriteAll(rootPath, "*", SearchOption.AllDirectories);
        //            }
        //        }
        //        Console.WriteLine("Compression completed successfully.");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("An error occurred while compressing the directory. Details: " + ex.Message);
        //    }
        //}

        //public static void ZipDirectory(string rootPath)
        //{
        //    string zipFilePath = Path.Combine(rootPath, "archive.zip");

        //    try
        //    {
        //        ZipFile.CreateFromDirectory(rootPath, zipFilePath);
        //        Console.WriteLine("Zipping completed successfully.");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("An error occurred while zipping the directory. Details: " + ex.Message);
        //    }
        //}

        //public static void UnzipDirectory(string rootPath)
        //{
        //    string extractPath = Path.Combine(Path.GetDirectoryName(rootPath), Path.GetFileNameWithoutExtension(rootPath));
        //    Directory.CreateDirectory(extractPath);

        //    try
        //    {
        //        ZipFile.ExtractToDirectory(rootPath, extractPath);
        //        Console.WriteLine("Unzipping completed successfully.");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("An error occurred while unzipping the file. Details: " + ex.Message);
        //    }
        //}

        //public static void DeleteFolders(string rootPath)
        //{
        //    foreach (var directory in Directory.GetDirectories(rootPath))
        //    {
        //        DeleteFolders(directory);  // Recursively call the function for all subdirectories

        //        if (Directory.GetFiles(directory).Length == 0 &&
        //            Directory.GetDirectories(directory).Length == 0)  // If directory is empty
        //        {
        //            try
        //            {
        //                Directory.Delete(directory);  // Delete the directory
        //                Console.WriteLine($"Deleted: {directory}");
        //            }
        //            catch (Exception ex)
        //            {
        //                Console.WriteLine($"An error occurred while deleting the directory. Details: {ex.Message}");
        //            }
        //        }
        //    }
        //}
    }
}
