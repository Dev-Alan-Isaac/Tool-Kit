﻿using System.Data;
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
        private string FilePath;
        string extension = string.Empty;

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

        private async void button_Filter_Click_1(object sender, EventArgs e)
        {
            button_Filter.Enabled = false;
            if (radioButton_Image.Checked)
            {
                await Task.Run(() => ImageConvert(FilePath, extension));
                button_Filter.Enabled = true;
            }
            else if (radioButton_Audio.Checked)
            {
                await Task.Run(() => AudioConvert(Path, extension));
                button_Filter.Enabled = true;
            }
            else if (radioButton_Video.Checked)
            {
                await Task.Run(() => VideoConvert(Path, extension));
                button_Filter.Enabled = true;
            }
            else if (radioButton_Document.Checked)
            {
                await Task.Run(() => DocumentConvert(Path, extension));
                button_Filter.Enabled = true;
            }
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
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
            Populated_Treeview();
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

        private async void Populated_Treeview()
        {
            // Clear the TreeView first
            treeView1.Nodes.Clear();

            // Define which set of extensions to use depending on the selected radio button
            JArray allowedExtensions = null;

            if (radioButton_Image.Checked)
            {
                allowedExtensions = ["BMP", "JPEG", "PNG", "TIFF", "JIFF", "ICO"];
            }
            else if (radioButton_Audio.Checked)
            {
                allowedExtensions = ["MP3", "WAV", "AAC", "FLAC"];
            }
            else if (radioButton_Video.Checked)
            {
                allowedExtensions = ["MP4", "WEBM", "AVI", "WAV", "GIF", "MP3"];
            }
            else if (radioButton_Document.Checked)
            {
                allowedExtensions = ["DOC", "DOCX", "XLSX", "XLS", "PDF", "TXT"];
            }

            if (allowedExtensions != null)
            {
                if (!string.IsNullOrEmpty(Path))
                {
                    // Fetch the files
                    string[] files = await ProcessFiles(Path);

                    // Ensure unique files
                    var filteredFiles = files
                        .Where(file => allowedExtensions
                            .Any(ext => file.EndsWith($".{ext}", StringComparison.OrdinalIgnoreCase)))
                        .Distinct() // Ensures files are unique
                        .ToList();

                    int filestotal = filteredFiles.Count;
                    File_Count.Text = $"{filestotal}";

                    // Populate TreeView with filtered files
                    foreach (var file in filteredFiles)
                    {
                        string fileName = System.IO.Path.GetFileName(file);

                        // Check if the file is already in the TreeView
                        if (!treeView1.Nodes.Cast<TreeNode>().Any(node => node.Text == fileName))
                        {
                            treeView1.Nodes.Add(fileName);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Not Path Selected");
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Get the selected node
            TreeNode selectedNode = e.Node;

            // Remove the extension from the selected node's text
            string nodeNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(selectedNode.Text);

            // Update label with the selected node's name (without extension)
            label_SelectedNode.Text = nodeNameWithoutExtension;

            // Set the full file path
            FilePath = System.IO.Path.Combine(Path, selectedNode.Text);

            // Read the JSON content from the file
            string jsonContent = File.ReadAllText("Config_Convert.json");

            // Deserialize the JSON content into a JObject
            var jsonObject = JObject.Parse(jsonContent);

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

            // Update label with the selected node's name and extension
            label_Output.Text = $"{nodeNameWithoutExtension}.{extension}";
        }

        private async void ImageConvert(string filePath, string extension)
        {
            try
            {
                using (MagickImage image = new MagickImage(filePath))
                {
                    // Set the format of the image to the desired extension
                    image.Format = GetMagickFormat(extension);

                    // Save the converted image
                    string newFilePath = System.IO.Path.ChangeExtension(filePath, extension);
                    await image.WriteAsync(newFilePath);
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

        private async void AudioConvert(string file, string extension)
        {
            try
            {
                using var reader = new AudioFileReader(file);
                string newFilePath = System.IO.Path.ChangeExtension(file, extension);

                // Write to the appropriate format
                using var writer = GetAudioFileWriter(newFilePath, extension, reader.WaveFormat);
                await Task.Run(() => reader.CopyTo(writer));

                MessageBox.Show($"Audio converted successfully to {extension.ToUpper()}!", "Conversion Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private async void VideoConvert(string filePath, string extension)
        {
            try
            {
                var files = Directory.GetFiles(filePath, "*.*", SearchOption.AllDirectories);
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

        private async void DocumentConvert(string folderPath, string extension)
        {

        }


        private string askTitle(string selectedPath)
        {
            string Title = string.Empty;
            DialogResult result = MessageBox.Show("Do you want a custom title?", "Title Prompt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Title = Microsoft.VisualBasic.Interaction.InputBox("Enter the custom title:", "Title", "", -1, -1);
                return Title;
            }
            else
            {
                Title = System.IO.Path.GetFileName(selectedPath);
                return Title;
            }
        }

        private string[] askContent(string selectedPath)
        {
            DialogResult result = MessageBox.Show("Do you want a custom content?", "Title", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string selectedItem = string.Empty;

                foreach (RadioButton radioButton in panel_Action.Controls.OfType<RadioButton>())
                {
                    if (radioButton.Checked)
                    {
                        selectedItem = radioButton.Text; // Use the text of the selected radio button
                        break; // Exit the loop once a selection is found
                    }
                }

                // Get the files in the selected path
                string[] files = Directory.GetFiles(selectedPath);
                string[] sort = [];

                // Sort the files based on the user's selection
                switch (selectedItem)
                {
                    case "Sort by name":
                        sort = SortByName(files);
                        break;
                    case "Sort by date":
                        sort = SortByDate(files);
                        break;
                    case "Sort by size":
                        sort = SortBySize(files);
                        break;
                    default:
                        break;
                }
                return sort;
            }
            else
            {
                // Get the files in the selected path without sorting
                string[] files = Directory.GetFiles(selectedPath);

                var filteredFiles = files.Where(file => PDFExtensions.Contains(System.IO.Path.GetExtension(file))).ToArray();

                return filteredFiles;
            }
        }

        public string[] SortByName(string[] arrayFiles)
        {
            // Filter files by allowed extensions
            var filteredFiles = arrayFiles.Where(file => PDFExtensions.Contains(System.IO.Path.GetExtension(file))).ToArray();

            // Sort by file name (alphabetical order)
            Array.Sort(filteredFiles);

            return filteredFiles;
        }

        public string[] SortByDate(string[] arrayFiles)
        {
            // Filter files by allowed extensions
            var filteredFiles = arrayFiles.Where(file => PDFExtensions.Contains(System.IO.Path.GetExtension(file))).ToArray();

            // Sort by creation date
            Array.Sort(filteredFiles, (a, b) => File.GetCreationTime(a).CompareTo(File.GetCreationTime(b)));

            return filteredFiles;
        }

        public string[] SortBySize(string[] arrayFiles)
        {
            // Filter files by allowed extensions
            var filteredFiles = arrayFiles.Where(file => PDFExtensions.Contains(System.IO.Path.GetExtension(file))).ToArray();

            // Sort by file size
            Array.Sort(filteredFiles, (a, b) => new FileInfo(a).Length.CompareTo(new FileInfo(b).Length));

            return filteredFiles;
        }

        //private async Task<byte[]> PDFBuilder(string[] arrayFiles)
        //{
        //    var progress = new Progress<int>(value =>
        //    {
        //        // Update your progress bar here
        //        progressBar_Time.Value = value;
        //    });

        //    return await Task.Run(() =>
        //    {
        //        // Create a new PDF document
        //        Document document = new Document();
        //        using (MemoryStream stream = new MemoryStream())
        //        {
        //            // Create a new PdfWriter object, pointing it to our MemoryStream
        //            PdfWriter writer = PdfWriter.GetInstance(document, stream);

        //            // Open the Document for writing
        //            document.Open();

        //            for (int i = 0; i < arrayFiles.Length; i++)
        //            {
        //                string file = arrayFiles[i];
        //                // Add the image to the document
        //                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(file);
        //                document.SetPageSize(new Rectangle(0, 0, image.Width, image.Height));
        //                document.NewPage();
        //                image.SetAbsolutePosition(0, 0);
        //                document.Add(image);

        //                // Calculate progress percentage
        //                int progressPercentage = (i + 1) * 100 / arrayFiles.Length;

        //                // Report progress
        //                ((IProgress<int>)progress).Report(progressPercentage);
        //            }

        //            // Close the Document - this saves it to the MemoryStream
        //            document.Close();

        //            // Convert the MemoryStream to an array and return it
        //            return stream.ToArray();
        //        }
        //    });

        //}

        //private string[] askContent(string selectedPath)
        //      {
        //          DialogResult result = MessageBox.Show("Do you want a custom content?", "Title", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        //          if (result == DialogResult.Yes)
        //          {
        //              string selectedItem = string.Empty;

        //              foreach (RadioButton radioButton in panel_Action.Controls.OfType<RadioButton>())
        //              {
        //                  if (radioButton.Checked)
        //                  {
        //                      selectedItem = radioButton.Text; // Use the text of the selected radio button
        //                      break; // Exit the loop once a selection is found
        //                  }
        //              }

        //              // Get the files in the selected path
        //              string[] files = Directory.GetFiles(selectedPath);
        //              string[] sort = [];

        //              // Sort the files based on the user's selection
        //              switch (selectedItem)
        //              {
        //                  case "Sort by name":
        //                      sort = SortByName(files);
        //                      break;
        //                  case "Sort by date":
        //                      sort = SortByDate(files);
        //                      break;
        //                  case "Sort by size":
        //                      sort = SortBySize(files);
        //                      break;
        //                  default:
        //                      break;
        //              }
        //              return sort;
        //          }
        //          else
        //          {
        //              // Get the files in the selected path without sorting
        //              string[] files = Directory.GetFiles(selectedPath);

        //              var filteredFiles = files.Where(file => PDFExtensions.Contains(System.IO.Path.GetExtension(file))).ToArray();

        //              return filteredFiles;
        //          }
        //      }

        private async void CreatedPdf(byte[] pdfByteArray, string title)
        {
            // Specify the output file path
            string outputPath = System.IO.Path.Combine(selectedPath, $"{title}.pdf");

            // Check if the file already exists
            int count = 1;
            string originalOutputPath = outputPath;
            while (File.Exists(outputPath))
            {
                // Append (Count) to the title
                outputPath = System.IO.Path.Combine(selectedPath, $"{title} ({count}).pdf");
                count++;
            }

            // Save the byte array to the modified output path
            File.WriteAllBytes(outputPath, pdfByteArray);
        }

        private async Task IconBuilder(string fileName)
        {
            await Task.Run(() =>
            {
                // Define the maximum width and height
                int maxWidth = 256;
                int maxHeight = 256;

                if (string.IsNullOrEmpty(fileName))
                {
                    // Handle the case when no file is selected
                    MessageBox.Show($"Missing file", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string path = System.IO.Path.Combine(selectedPath, selectedFileName);

                    if (!File.Exists(path))
                    {
                        // Handle the case when the selected file is no longer in the specified path
                        MessageBox.Show($"The file '{selectedFileName}' is no longer in the specified path.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        using (MagickImage image = new MagickImage(path))
                        {
                            if (image.Width <= maxWidth && image.Height <= maxHeight)
                            {
                                // Convert the image to .ico format
                                image.Format = MagickFormat.Icon;

                                // Create a unique icon file name
                                int iconCount = 1;
                                string iconBaseName = "Icon";
                                string iconExtension = ".ico";
                                string iconPath = System.IO.Path.Combine(selectedPath, $"{iconBaseName} {iconCount}{iconExtension}");

                                // Check if the icon file already exists and increment the count if needed
                                while (File.Exists(iconPath))
                                {
                                    iconCount++;
                                    iconPath = System.IO.Path.Combine(selectedPath, $"{iconBaseName} {iconCount}{iconExtension}");
                                }

                                // Save the icon file
                                image.Write(iconPath);
                            }
                            else
                            {
                                // Handle the case when the selected file exceeds the limit of 256 x 256
                                MessageBox.Show($"The file '{selectedFileName}' is over the limit of 256 x 256.", "File Limit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            });
        }

        private async Task WebpBuilder(string fileName)
        {
            await Task.Run(() =>
            {
                if (string.IsNullOrEmpty(fileName))
                {
                    // Handle the case when no file is selected
                    MessageBox.Show($"Missing file", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string Path = System.IO.Path.Combine(selectedPath, selectedFileName);

                    if (!File.Exists(Path))
                    {
                        // Handle the case when the selected file is no longer in the specified path
                        MessageBox.Show($"The file '{selectedFileName}' is no longer in the specified path.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        using (MagickImage image = new MagickImage(Path))
                        {
                            // Convert the image to .webp format
                            image.Format = MagickFormat.WebP;

                            // Create a unique icon file name
                            int Count = 1;
                            string BaseName = "Web Picture";
                            string Extension = ".webp";
                            string NPath = System.IO.Path.Combine(selectedPath, $"{BaseName} ({Count}){Extension}");

                            // Check if the icon file already exists and increment the count if needed
                            while (File.Exists(NPath))
                            {
                                Count++;
                                NPath = System.IO.Path.Combine(selectedPath, $"{BaseName} ({Count}){Extension}");
                            }

                            // Save the icon file
                            image.Write(NPath);
                        }
                    }
                }
            });
        }

        private async Task BmpBuilder(string fileName)
        {
            await Task.Run(() =>
            {
            if (string.IsNullOrEmpty(fileName))
            {
                // Handle the case when no file is selected
                MessageBox.Show($"Missing file", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string Path = System.IO.Path.Combine(selectedPath, selectedFileName);

                if (!File.Exists(Path))
                {
                    // Handle the case when the selected file is no longer in the specified path
                    MessageBox.Show($"The file '{selectedFileName}' is no longer in the specified path.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    using (MagickImage image = new MagickImage(Path))
                    {
                        // Convert the image to .webp format
                        image.Format = MagickFormat.Bmp;

                        // Create a unique icon file name
                        int Count = 1;
                        string BaseName = "Bump";
                        string Extension = ".Bmp";
                        string NPath = System.IO.Path.Combine(selectedPath, $"{BaseName} ({Count}){Extension}");

                        // Check if the icon file already exists and increment the count if needed
                        while (File.Exists(NPath))
                        {
                            Count++;
                            NPath = System.IO.Path.Combine(selectedPath, $"{BaseName} ({Count}){Extension}");
                        }

                        // Save the icon file
                        image.Write(NPath);
                    }
                }
            }

