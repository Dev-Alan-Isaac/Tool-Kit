﻿using Newtonsoft.Json.Linq;
using SharpCompress.Archives;
using SharpCompress.Common;

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
                await Extract_Files(Path);
            }
            else if (radioButton_Rar.Checked)
            {
                await Decompress_RAR(Path);
            }
            else if (radioButton_Zip.Checked)
            {
                await Decompress_ZIP(Path);
            }
            else if (radioButton_Tar.Checked)
            {
                await Decompress_TAR(Path);
            }
        }

        private async Task Extract_Files(string path)
        {
            // Ensure the "Extracted" directory exists
            string extractedFolder = System.IO.Path.Combine(path, "Extracted");
            Directory.CreateDirectory(extractedFolder);

            // Get the files to process
            string[] files = await ProcessFiles(path);

            // Set up the progress bar
            progressBar_Time.Invoke(() =>
            {
                progressBar_Time.Maximum = files.Length;
                progressBar_Time.Value = 0;
            });

            int processedFiles = 0;

            await Task.Run(() =>
            {
                foreach (var file in files)
                {
                    try
                    {
                        // Get the file name and define the destination path in "Extracted"
                        string fileName = System.IO.Path.GetFileName(file);
                        string destinationFilePath = System.IO.Path.Combine(extractedFolder, fileName);

                        // If the file already exists in the "Extracted" folder
                        if (File.Exists(destinationFilePath))
                        {
                            // Create a unique folder inside "Extracted" (you can use timestamp or GUID)
                            string uniqueFolderName = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                            string uniqueFolderPath = System.IO.Path.Combine(extractedFolder, uniqueFolderName);
                            Directory.CreateDirectory(uniqueFolderPath);

                            // Move the file into the unique folder
                            destinationFilePath = System.IO.Path.Combine(uniqueFolderPath, fileName);
                        }

                        // Move the file to the "Extracted" folder (or the unique folder if it already existed)
                        File.Move(file, destinationFilePath);

                        // Increment the processed file count and update the progress bar
                        processedFiles++;
                        progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = processedFiles));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error moving file {file}: {ex.Message}");
                    }
                }
            });

            button_Filter.Invoke((Action)(() => button_Filter.Enabled = true));
            progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = 0));
            DeleteEmptyFolders(path);
            MessageBox.Show("Files extracted successfully.");
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

        private async Task Decompress_RAR(string rarPath)
        {
            try
            {
                await Task.Run(() =>
                {
                    using (var archive = ArchiveFactory.Open(rarPath))
                    {
                        // Decompress the archive into the specified path
                        archive.WriteToDirectory(Path, new ExtractionOptions()
                        {
                            ExtractFullPath = true,
                            Overwrite = true
                        });
                    }
                });

                MessageBox.Show($"RAR file decompressed successfully!", "Decompression Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error decompressing RAR file: {ex.Message}", "Decompression Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task Decompress_ZIP(string zipPath)
        {
            try
            {
                await Task.Run(() =>
                {
                    using (var archive = ArchiveFactory.Open(zipPath))
                    {
                        // Decompress the archive into the specified path
                        archive.WriteToDirectory(Path, new ExtractionOptions()
                        {
                            ExtractFullPath = true,
                            Overwrite = true
                        });
                    }
                });

                MessageBox.Show($"ZIP file decompressed successfully!", "Decompression Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error decompressing ZIP file: {ex.Message}", "Decompression Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task Decompress_TAR(string tarPath)
        {
            try
            {
                await Task.Run(() =>
                {
                    using (var archive = ArchiveFactory.Open(tarPath))
                    {
                        // Decompress the archive into the specified path
                        archive.WriteToDirectory(Path, new ExtractionOptions()
                        {
                            ExtractFullPath = true,
                            Overwrite = true
                        });
                    }
                });

                MessageBox.Show($"TAR file decompressed successfully!", "Decompression Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error decompressing TAR file: {ex.Message}", "Decompression Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
    }
}
