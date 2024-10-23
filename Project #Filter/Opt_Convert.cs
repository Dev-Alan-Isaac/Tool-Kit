﻿using System.Data;
using Aspose.Cells;
using Aspose.Slides;
using ImageMagick;
using NAudio.Lame;
using NAudio.Wave;
using Newtonsoft.Json.Linq;
using NReco.VideoConverter;
using SharpCompress.Common;

namespace Project__Filter
{
    public partial class Opt_Transform : UserControl
    {
        private string Path;
        private string extension = string.Empty;
        private string[] FileList;

        public Opt_Transform()
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

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            label_SelectedNode.Text = "#";
            label_Output.Text = "#";

            // Enable the filter button when any radio button is checked
            if (radioButton_Image.Checked || radioButton_Audio.Checked ||
                radioButton_Video.Checked || radioButton_Document.Checked)
            {
                button_Filter.Enabled = true;
            }
            else
            {
                button_Filter.Enabled = false;
            }

            // Populate the TreeView based on the selected radio button
            Populated_Treeview(Path);
        }

        private async void button_Filter_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Path))
            {
                button_Filter.Enabled = false;
                if (radioButton_Image.Checked)
                {
                    await Task.Run(() => ImageConvert(FileList, extension));
                }
                else if (radioButton_Audio.Checked)
                {
                    await Task.Run(() => AudioConvert(FileList, extension));
                }
                else if (radioButton_Video.Checked)
                {
                    await Task.Run(() => VideoConvert(FileList, extension));
                }
                else if (radioButton_Document.Checked)
                {
                    await Task.Run(() => DocumentConvert(FileList, extension));
                }
            }
            button_Filter.Enabled = true;
        }

        private async void Populated_Treeview(string folderPath)
        {
            // Clear the TreeView first
            treeView1.Nodes.Clear();

            // Define which set of extensions to use depending on the selected radio button
            JArray allowedExtensions = null;
            if (radioButton_Image.Checked)
            {
                allowedExtensions = new JArray { "BMP", "JPEG", "PNG", "TIFF", "JIFF", "ICO" };
            }
            else if (radioButton_Audio.Checked)
            {
                allowedExtensions = new JArray { "MP3", "WAV", "AAC", "FLAC" };
            }
            else if (radioButton_Video.Checked)
            {
                allowedExtensions = new JArray { "MP4", "WEBM", "AVI", "WAV", "GIF", "MP3" };
            }
            else if (radioButton_Document.Checked)
            {
                allowedExtensions = new JArray { "DOC", "DOCX", "XLSX", "XLS", "PDF", "TXT" };
            }

            if (allowedExtensions != null)
            {
                if (!string.IsNullOrEmpty(folderPath))
                {
                    // Fetch the files
                    var files = await ProcessFiles(folderPath);
                    // Ensure unique files
                    var filteredFiles = files
                        .Where(file => allowedExtensions
                            .Any(ext => file.EndsWith($".{ext}", StringComparison.OrdinalIgnoreCase)))
                        .Distinct() // Ensures files are unique
                        .ToList();
                    FileList = filteredFiles.ToArray();
                    int filestotal = filteredFiles.Count;
                    File_Count.Text = $"{filestotal}";

                    // Populate TreeView with filtered files
                    foreach (var file in filteredFiles)
                    {
                        string fileName = System.IO.Path.GetFileName(file); // Get only the file name
                                                                            // Check if the folder node already exists in the TreeView
                        string folderName = System.IO.Path.GetFileName(System.IO.Path.GetDirectoryName(file)); // Get the folder name
                        TreeNode folderNode = FindOrCreateNode(treeView1.Nodes, folderName);
                        // Check if the file is already in the folder node
                        if (!folderNode.Nodes.Cast<TreeNode>().Any(node => node.Text == fileName))
                        {
                            folderNode.Nodes.Add(new TreeNode(fileName));
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No Path Selected");
                }
            }
        }

        private TreeNode FindOrCreateNode(TreeNodeCollection nodes, string folderName)
        {
            TreeNode folderNode = nodes.Cast<TreeNode>().FirstOrDefault(n => n.Text == folderName);
            if (folderNode == null)
            {
                folderNode = new TreeNode(folderName);
                nodes.Add(folderNode);
            }
            return folderNode;
        }

        public async Task<string[]> ProcessFiles(string parentPath)
        {
            string config_file = "Config_Convert.json";

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

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Get the selected node
            TreeNode selectedNode = e.Node;

            // Read the JSON content from the file
            string jsonContent = File.ReadAllText("Config_Convert.json");
            // Deserialize the JSON content into a JObject
            var jsonObject = JObject.Parse(jsonContent);

            // Initialize extension variable
            string extension = string.Empty;

            // Check which radio button is checked and get the corresponding extension from JSON
            if (radioButton_Image.Checked)
            {
                extension = jsonObject["Image"]["Selected"].ToString();
            }
            else if (radioButton_Audio.Checked)
            {
                extension = jsonObject["Audio"]["Selected"].ToString();
            }
            else if (radioButton_Video.Checked)
            {
                extension = jsonObject["Video"]["Selected"].ToString();
            }
            else if (radioButton_Document.Checked)
            {
                extension = jsonObject["Document"]["Selected"].ToString();
            }

            // Convert extension to lowercase
            extension = extension.ToLower();

            // Check if the node is a folder or a file
            if (selectedNode.Nodes.Count > 0) // If the node has child nodes, it's a folder
            {
                label_SelectedNode.Text = "Folder";  // Display "Folder" in the label
                label_Output.Text = $"Files.{extension}";    // Clear the output label for folders        
            }
            else
            {
                // Remove the extension from the selected node's text (if it's a file)
                string nodeNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(selectedNode.Text);
                // Update label with the selected node's name (without extension)
                label_SelectedNode.Text = nodeNameWithoutExtension;
                // Set the full file path
                string FilePath = System.IO.Path.Combine(Path, selectedNode.Text);

                // Clear FileList and add only the selected file
                FileList = new string[] { FilePath };

                // Update label with the selected node's name and extension
                label_Output.Text = $"{nodeNameWithoutExtension}.{extension}";
            }
        }

        private async void ImageConvert(string[] files, string extension)
        {
            try
            {
                foreach (var file in files)
                {
                    using (MagickImage image = new MagickImage(file))
                    {
                        // Set the format of the image to the desired extension
                        image.Format = GetMagickFormat(extension);

                        // Save the converted image
                        string newFilePath = System.IO.Path.ChangeExtension(file, extension);
                        await image.WriteAsync(newFilePath);
                    }
                }

                MessageBox.Show($"Image converted successfully to {extension.ToUpper()}!", "Conversion Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error converting image: {ex.Message}", "Conversion Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private MagickFormat GetMagickFormat(string extension)
        {
            return extension.ToLower() switch
            {
                "bmp" => MagickFormat.Bmp,
                "jpeg" => MagickFormat.Jpeg,
                "png" => MagickFormat.Png,
                "tiff" => MagickFormat.Tiff,
                "gif" => MagickFormat.Gif,
                "ico" => MagickFormat.Ico,
                _ => throw new NotSupportedException($"The extension '{extension}' is not supported."),
            };
        }

        private async void AudioConvert(string[] files, string extension)
        {
            try
            {
                foreach (var file in files)
                {
                    using var reader = new AudioFileReader(file);
                    string newFilePath = System.IO.Path.ChangeExtension(file, extension);

                    // Write to the appropriate format
                    using var writer = GetAudioFileWriter(newFilePath, extension, reader.WaveFormat);
                    await Task.Run(() => reader.CopyTo(writer));

                    MessageBox.Show($"Audio converted successfully to {extension.ToUpper()}!", "Conversion Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error converting audio: {ex.Message}", "Conversion Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Stream GetAudioFileWriter(string filePath, string extension, WaveFormat waveFormat)
        {
            return extension.ToLower() switch
            {
                "wav" => new WaveFileWriter(filePath, waveFormat),
                "mp3" => new LameMP3FileWriter(filePath, waveFormat, LAMEPreset.STANDARD),
                _ => throw new NotSupportedException($"The extension '{extension}' is not supported."),
            };
        }

        private async void VideoConvert(string[] files, string extension)
        {
            try
            {
                var ffmpeg = new FFMpegConverter();

                foreach (var file in files)
                {
                    var outputFilePath = System.IO.Path.ChangeExtension(file, extension);

                    await Task.Run(() =>
                        ffmpeg.ConvertMedia(file, outputFilePath, extension)
                    );

                    MessageBox.Show($"Video converted successfully to {extension.ToUpper()}!", "Conversion Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error converting video: {ex.Message}", "Conversion Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void DocumentConvert(string[] files, string extension)
        {
            try
            {

                foreach (var file in files)
                {
                    string newFilePath = System.IO.Path.ChangeExtension(file, extension);

                    if (file.EndsWith(".docx") || file.EndsWith(".doc"))
                    {
                        await Task.Run(() =>
                        {
                            var doc = new Aspose.Words.Document(file);
                            doc.Save(newFilePath);
                        });
                    }
                    else if (file.EndsWith(".xlsx") || file.EndsWith(".xls"))
                    {
                        await Task.Run(() =>
                        {
                            var workbook = new Workbook(file);
                            workbook.Save(newFilePath);
                        });
                    }
                    else if (file.EndsWith(".pptx") || file.EndsWith(".ppt"))
                    {
                        await Task.Run(() =>
                        {
                            var presentation = new Presentation(file);
                            presentation.Save(newFilePath, GetSlideFormat(extension));
                        });
                    }
                    else if (file.EndsWith(".pdf"))
                    {
                        await Task.Run(() =>
                        {
                            var pdfDocument = new Aspose.Pdf.Document(file);
                            pdfDocument.Save(newFilePath);
                        });
                    }
                    else
                    {
                        MessageBox.Show($"File format for {file} not supported for conversion.", "Format Not Supported", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    MessageBox.Show($"Documents converted successfully to {extension.ToUpper()}!", "Conversion Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error converting document: {ex.Message}", "Conversion Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Aspose.Slides.Export.SaveFormat GetSlideFormat(string extension)
        {
            return extension.ToLower() switch
            {
                "pptx" => Aspose.Slides.Export.SaveFormat.Pptx,
                "ppt" => Aspose.Slides.Export.SaveFormat.Ppt,
                "pdf" => Aspose.Slides.Export.SaveFormat.Pdf,
                _ => throw new NotSupportedException($"The extension '{extension}' is not supported for slides."),
            };

        }

        //private string askTitle(string selectedPath)
        //{
        //    string Title = string.Empty;
        //    DialogResult result = MessageBox.Show("Do you want a custom title?", "Title Prompt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //    if (result == DialogResult.Yes)
        //    {
        //        Title = Microsoft.VisualBasic.Interaction.InputBox("Enter the custom title:", "Title", "", -1, -1);
        //        return Title;
        //    }
        //    else
        //    {
        //        Title = System.IO.Path.GetFileName(selectedPath);
        //        return Title;
        //    }
        //}

        //private async void CreatedPdf(byte[] pdfByteArray, string title)
        //{
        //    // Specify the output file path
        //    string outputPath = System.IO.Path.Combine(selectedPath, $"{title}.pdf");

        //    // Check if the file already exists
        //    int count = 1;
        //    string originalOutputPath = outputPath;
        //    while (File.Exists(outputPath))
        //    {
        //        // Append (Count) to the title
        //        outputPath = System.IO.Path.Combine(selectedPath, $"{title} ({count}).pdf");
        //        count++;
        //    }

        //    // Save the byte array to the modified output path
        //    File.WriteAllBytes(outputPath, pdfByteArray);
        //}
    }

}