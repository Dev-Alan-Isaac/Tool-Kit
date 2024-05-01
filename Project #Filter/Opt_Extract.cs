﻿using SharpCompress.Archives;
using SharpCompress.Archives.Rar;
using SharpCompress.Archives.Tar;
using SharpCompress.Common;
using SharpCompress.Writers;
using System.IO.Compression;

namespace Project__Filter
{
    public partial class Opt_Extract : UserControl
    {
        string selectedPath;

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
                    selectedPath = fbd.SelectedPath;
                    textBox_Path.Text = selectedPath;

                    radioButton_Folder.Enabled = true;
                    radioButton_Unrar.Enabled = true;
                    radioButton_Untar.Enabled = true;
                    radioButton_Unzip.Enabled = true;
                    button_Extract.Enabled = true;
                    // Get all files in the directory and subdirectories
                    string[] files = Directory.GetFiles(selectedPath, "*.*", SearchOption.AllDirectories);

                    // Count the files
                    int fileCount = files.Length;

                    // Display just the count in label_Count
                    label_Count.Text = fileCount.ToString();

                    // Clear the TreeView
                    treeView1.Nodes.Clear();

                    // Create the root node
                    TreeNode rootNode = new TreeNode(selectedPath);
                    treeView1.Nodes.Add(rootNode);

                    // Populate the TreeView with directories and files
                    PopulateTreeView(selectedPath, rootNode);

                    // Expand the root node
                    rootNode.Expand();
                }
            }
        }

        private void PopulateTreeView(string directoryValue, TreeNode parentNode)
        {
            string[] directories = Directory.GetDirectories(directoryValue);
            foreach (string directory in directories)
            {
                TreeNode directoryNode = new TreeNode(Path.GetFileName(directory));
                parentNode.Nodes.Add(directoryNode);
                PopulateTreeView(directory, directoryNode); // Recursively add subdirectories
            }

            string[] files = Directory.GetFiles(directoryValue);
            foreach (string file in files)
            {
                // Add files to the TreeView
                parentNode.Nodes.Add(new TreeNode(Path.GetFileName(file)));
            }
        }

        private void button_Extract_Click(object sender, EventArgs e)
        {
            if (radioButton_Folder.Checked)
            {
                MoveFiles(selectedPath);
            }
            else if (radioButton_Unrar.Checked)
            {
                UncompressRar(selectedPath);
            }
            else if (radioButton_Untar.Checked)
            {
                UncompressTar(selectedPath);
            }
            else if (radioButton_Unzip.Checked)
            {
                UnzipDirectory(selectedPath);
            }
        }

        private void checkBox_Delete_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Delete.Checked)
            {
                DeleteFolders(selectedPath);
            }
        }

        public void MoveFiles(string rootPath)
        {
            // Construct the destination folder path
            string destinationFolder = Path.Combine(rootPath, "Extracted");

            // Ensure the destination folder exists
            Directory.CreateDirectory(destinationFolder);

            // Get all files in the root path and its subdirectories
            string[] files = Directory.GetFiles(rootPath, "*.*", SearchOption.AllDirectories);

            foreach (string file in files)
            {
                // Skip if the file is in the destination folder
                if (file.StartsWith(destinationFolder))
                    continue;

                // Get the file name
                string fileName = Path.GetFileName(file);

                // Construct the destination path
                string destPath = Path.Combine(destinationFolder, fileName);

                // Move the file
                File.Move(file, destPath);
            }
        }

        public void UncompressRar(string rootPath)
        {
            string destinationPath = Path.Combine(Path.GetDirectoryName(rootPath), Path.GetFileNameWithoutExtension(rootPath));
            Directory.CreateDirectory(destinationPath);

            try
            {
                using (var archive = RarArchive.Open(rootPath))
                {
                    foreach (var entry in archive.Entries)
                    {
                        if (!entry.IsDirectory)
                        {
                            Console.WriteLine("Extracting: " + entry.Key);
                            entry.WriteToDirectory(destinationPath, new ExtractionOptions()
                            {
                                ExtractFullPath = true,
                                Overwrite = true
                            });
                        }
                    }
                }
                Console.WriteLine("Extraction completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while extracting the file. Details: " + ex.Message);
            }
        }

        public void UncompressTar(string rootpPath)
        {
            string destinationPath = Path.Combine(Path.GetDirectoryName(rootpPath), Path.GetFileNameWithoutExtension(rootpPath));
            Directory.CreateDirectory(destinationPath);

            try
            {
                using (var archive = TarArchive.Open(rootpPath))
                {
                    foreach (var entry in archive.Entries)
                    {
                        if (!entry.IsDirectory)
                        {
                            Console.WriteLine("Extracting: " + entry.Key);
                            entry.WriteToDirectory(destinationPath, new ExtractionOptions()
                            {
                                ExtractFullPath = true,
                                Overwrite = true
                            });
                        }
                    }
                }
                Console.WriteLine("Extraction completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while extracting the file. Details: " + ex.Message);
            }
        }

        public static void CompressTar(string rootPath)
        {
            string tarFilePath = Path.Combine(Path.GetDirectoryName(rootPath), Path.GetFileName(rootPath) + ".tar");

            try
            {
                using (var stream = File.OpenWrite(tarFilePath))
                {
                    using (var writer = WriterFactory.Open(stream, ArchiveType.Tar, CompressionType.None))
                    {
                        writer.WriteAll(rootPath, "*", SearchOption.AllDirectories);
                    }
                }
                Console.WriteLine("Compression completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while compressing the directory. Details: " + ex.Message);
            }
        }

        public static void CompressRar(string rootPath)
        {
            string rarFilePath = Path.Combine(Path.GetDirectoryName(rootPath), Path.GetFileName(rootPath) + ".rar");

            try
            {
                using (var stream = File.OpenWrite(rarFilePath))
                {
                    using (var writer = WriterFactory.Open(stream, ArchiveType.Rar, CompressionType.Rar))
                    {
                        writer.WriteAll(rootPath, "*", SearchOption.AllDirectories);
                    }
                }
                Console.WriteLine("Compression completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while compressing the directory. Details: " + ex.Message);
            }
        }

        public static void ZipDirectory(string rootPath)
        {
            string zipFilePath = Path.Combine(rootPath, "archive.zip");

            try
            {
                ZipFile.CreateFromDirectory(rootPath, zipFilePath);
                Console.WriteLine("Zipping completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while zipping the directory. Details: " + ex.Message);
            }
        }

        public static void UnzipDirectory(string rootPath)
        {
            string extractPath = Path.Combine(Path.GetDirectoryName(rootPath), Path.GetFileNameWithoutExtension(rootPath));
            Directory.CreateDirectory(extractPath);

            try
            {
                ZipFile.ExtractToDirectory(rootPath, extractPath);
                Console.WriteLine("Unzipping completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while unzipping the file. Details: " + ex.Message);
            }
        }

        public static void DeleteFolders(string rootPath)
        {
            foreach (var directory in Directory.GetDirectories(rootPath))
            {
                DeleteFolders(directory);  // Recursively call the function for all subdirectories

                if (Directory.GetFiles(directory).Length == 0 &&
                    Directory.GetDirectories(directory).Length == 0)  // If directory is empty
                {
                    try
                    {
                        Directory.Delete(directory);  // Delete the directory
                        Console.WriteLine($"Deleted: {directory}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred while deleting the directory. Details: {ex.Message}");
                    }
                }
            }
        }

    }
}