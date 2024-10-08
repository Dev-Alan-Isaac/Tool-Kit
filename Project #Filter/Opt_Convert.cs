using System.Data;
using ImageMagick;
using NAudio.Wave;
using Newtonsoft.Json.Linq;

namespace Project__Filter
{
    public partial class Opt_Transform : UserControl
    {
        private string Path;

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
            string Config_covnvert = "Config_Convert.json";

            if (radioButton_Image.Checked)
            {
                await Task.Run(() => ImageConvert(Path, Config_covnvert));
            }
            else if (radioButton_Audio.Checked)
            {
                await Task.Run(() => AudioConvert(Path, Config_covnvert));
            }
            else if (radioButton_Video.Checked)
            {
                await Task.Run(() => VideoConvert(Path, Config_covnvert));
            }
            else if (radioButton_Document.Checked)
            {
                await Task.Run(() => DocumentConvert(Path, Config_covnvert));
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

        private async void Populated_Treeview()
        {
            // Check if the config file exists
            if (!File.Exists("Config_Convert.json"))
            {
                MessageBox.Show("Config file not found.");
                return;
            }

            // Load the JSON configuration
            var json = File.ReadAllText("Config_Convert.json");
            var config = JObject.Parse(json);

            // Clear the TreeView first
            treeView1.Nodes.Clear();

            // Define which set of extensions to use depending on the selected radio button
            JArray allowedExtensions = null;

            if (radioButton_Image.Checked)
            {
                allowedExtensions = (JArray)config["Extensions"]["Image"];
            }
            else if (radioButton_Audio.Checked)
            {
                allowedExtensions = (JArray)config["Extensions"]["Audio"];
            }
            else if (radioButton_Video.Checked)
            {
                allowedExtensions = (JArray)config["Extensions"]["Video"];
            }
            else if (radioButton_Document.Checked)
            {
                allowedExtensions = (JArray)config["Extensions"]["Document"];
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

        private async void ImageConvert(string folderPath, string jsonPath)
        {

        }

        private async void AudioConvert(string folderPath, string jsonPath)
        {

        }

        private async void VideoConvert(string folderPath, string jsonPath)
        {

        }

        private async void DocumentConvert(string folderPath, string jsonPath)
        {

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

        ////private string[] askContent(string selectedPath)
        ////{
        ////    DialogResult result = MessageBox.Show("Do you want a custom content?", "Title", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        ////    if (result == DialogResult.Yes)
        ////    {
        ////        string selectedItem = string.Empty;

        ////        foreach (RadioButton radioButton in panel_Action.Controls.OfType<RadioButton>())
        ////        {
        ////            if (radioButton.Checked)
        ////            {
        ////                selectedItem = radioButton.Text; // Use the text of the selected radio button
        ////                break; // Exit the loop once a selection is found
        ////            }
        ////        }

        ////        // Get the files in the selected path
        ////        string[] files = Directory.GetFiles(selectedPath);
        ////        string[] sort = [];

        ////        // Sort the files based on the user's selection
        ////        switch (selectedItem)
        ////        {
        ////            case "Sort by name":
        ////                sort = SortByName(files);
        ////                break;
        ////            case "Sort by date":
        ////                sort = SortByDate(files);
        ////                break;
        ////            case "Sort by size":
        ////                sort = SortBySize(files);
        ////                break;
        ////            default:
        ////                break;
        ////        }
        ////        return sort;
        ////    }
        ////    else
        ////    {
        ////        // Get the files in the selected path without sorting
        ////        string[] files = Directory.GetFiles(selectedPath);

        ////        var filteredFiles = files.Where(file => PDFExtensions.Contains(System.IO.Path.GetExtension(file))).ToArray();

        ////        return filteredFiles;
        ////    }
        ////}

        //public string[] SortByName(string[] arrayFiles)
        //{
        //    // Filter files by allowed extensions
        //    var filteredFiles = arrayFiles.Where(file => PDFExtensions.Contains(System.IO.Path.GetExtension(file))).ToArray();

        //    // Sort by file name (alphabetical order)
        //    Array.Sort(filteredFiles);

        //    return filteredFiles;
        //}

        //public string[] SortByDate(string[] arrayFiles)
        //{
        //    // Filter files by allowed extensions
        //    var filteredFiles = arrayFiles.Where(file => PDFExtensions.Contains(System.IO.Path.GetExtension(file))).ToArray();

        //    // Sort by creation date
        //    Array.Sort(filteredFiles, (a, b) => File.GetCreationTime(a).CompareTo(File.GetCreationTime(b)));

        //    return filteredFiles;
        //}

        //public string[] SortBySize(string[] arrayFiles)
        //{
        //    // Filter files by allowed extensions
        //    var filteredFiles = arrayFiles.Where(file => PDFExtensions.Contains(System.IO.Path.GetExtension(file))).ToArray();

        //    // Sort by file size
        //    Array.Sort(filteredFiles, (a, b) => new FileInfo(a).Length.CompareTo(new FileInfo(b).Length));

        //    return filteredFiles;
        //}

        ////private async Task<byte[]> PDFBuilder(string[] arrayFiles)
        ////{
        ////    var progress = new Progress<int>(value =>
        ////    {
        ////        // Update your progress bar here
        ////        progressBar_Time.Value = value;
        ////    });

        ////    return await Task.Run(() =>
        ////    {
        ////        // Create a new PDF document
        ////        Document document = new Document();
        ////        using (MemoryStream stream = new MemoryStream())
        ////        {
        ////            // Create a new PdfWriter object, pointing it to our MemoryStream
        ////            PdfWriter writer = PdfWriter.GetInstance(document, stream);

        ////            // Open the Document for writing
        ////            document.Open();

        ////            for (int i = 0; i < arrayFiles.Length; i++)
        ////            {
        ////                string file = arrayFiles[i];
        ////                // Add the image to the document
        ////                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(file);
        ////                document.SetPageSize(new Rectangle(0, 0, image.Width, image.Height));
        ////                document.NewPage();
        ////                image.SetAbsolutePosition(0, 0);
        ////                document.Add(image);

        ////                // Calculate progress percentage
        ////                int progressPercentage = (i + 1) * 100 / arrayFiles.Length;

        ////                // Report progress
        ////                ((IProgress<int>)progress).Report(progressPercentage);
        ////            }

        ////            // Close the Document - this saves it to the MemoryStream
        ////            document.Close();

        ////            // Convert the MemoryStream to an array and return it
        ////            return stream.ToArray();
        ////        }
        ////    });

        ////}

        ////private string[] askContent(string selectedPath)
        ////      {
        ////          DialogResult result = MessageBox.Show("Do you want a custom content?", "Title", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        ////          if (result == DialogResult.Yes)
        ////          {
        ////              string selectedItem = string.Empty;

        ////              foreach (RadioButton radioButton in panel_Action.Controls.OfType<RadioButton>())
        ////              {
        ////                  if (radioButton.Checked)
        ////                  {
        ////                      selectedItem = radioButton.Text; // Use the text of the selected radio button
        ////                      break; // Exit the loop once a selection is found
        ////                  }
        ////              }

        ////              // Get the files in the selected path
        ////              string[] files = Directory.GetFiles(selectedPath);
        ////              string[] sort = [];

        ////              // Sort the files based on the user's selection
        ////              switch (selectedItem)
        ////              {
        ////                  case "Sort by name":
        ////                      sort = SortByName(files);
        ////                      break;
        ////                  case "Sort by date":
        ////                      sort = SortByDate(files);
        ////                      break;
        ////                  case "Sort by size":
        ////                      sort = SortBySize(files);
        ////                      break;
        ////                  default:
        ////                      break;
        ////              }
        ////              return sort;
        ////          }
        ////          else
        ////          {
        ////              // Get the files in the selected path without sorting
        ////              string[] files = Directory.GetFiles(selectedPath);

        ////              var filteredFiles = files.Where(file => PDFExtensions.Contains(System.IO.Path.GetExtension(file))).ToArray();

        ////              return filteredFiles;
        ////          }
        ////      }

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

        //private async Task IconBuilder(string fileName)
        //{
        //    await Task.Run(() =>
        //    {
        //        // Define the maximum width and height
        //        int maxWidth = 256;
        //        int maxHeight = 256;

        //        if (string.IsNullOrEmpty(fileName))
        //        {
        //            // Handle the case when no file is selected
        //            MessageBox.Show($"Missing file", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        }
        //        else
        //        {
        //            string path = System.IO.Path.Combine(selectedPath, selectedFileName);

        //            if (!File.Exists(path))
        //            {
        //                // Handle the case when the selected file is no longer in the specified path
        //                MessageBox.Show($"The file '{selectedFileName}' is no longer in the specified path.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            }
        //            else
        //            {
        //                using (MagickImage image = new MagickImage(path))
        //                {
        //                    if (image.Width <= maxWidth && image.Height <= maxHeight)
        //                    {
        //                        // Convert the image to .ico format
        //                        image.Format = MagickFormat.Icon;

        //                        // Create a unique icon file name
        //                        int iconCount = 1;
        //                        string iconBaseName = "Icon";
        //                        string iconExtension = ".ico";
        //                        string iconPath = System.IO.Path.Combine(selectedPath, $"{iconBaseName} {iconCount}{iconExtension}");

        //                        // Check if the icon file already exists and increment the count if needed
        //                        while (File.Exists(iconPath))
        //                        {
        //                            iconCount++;
        //                            iconPath = System.IO.Path.Combine(selectedPath, $"{iconBaseName} {iconCount}{iconExtension}");
        //                        }

        //                        // Save the icon file
        //                        image.Write(iconPath);
        //                    }
        //                    else
        //                    {
        //                        // Handle the case when the selected file exceeds the limit of 256 x 256
        //                        MessageBox.Show($"The file '{selectedFileName}' is over the limit of 256 x 256.", "File Limit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                    }
        //                }
        //            }
        //        }
        //    });
        //}

        //private async Task WebpBuilder(string fileName)
        //{
        //    await Task.Run(() =>
        //    {
        //        if (string.IsNullOrEmpty(fileName))
        //        {
        //            // Handle the case when no file is selected
        //            MessageBox.Show($"Missing file", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        }
        //        else
        //        {
        //            string Path = System.IO.Path.Combine(selectedPath, selectedFileName);

        //            if (!File.Exists(Path))
        //            {
        //                // Handle the case when the selected file is no longer in the specified path
        //                MessageBox.Show($"The file '{selectedFileName}' is no longer in the specified path.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            }
        //            else
        //            {
        //                using (MagickImage image = new MagickImage(Path))
        //                {
        //                    // Convert the image to .webp format
        //                    image.Format = MagickFormat.WebP;

        //                    // Create a unique icon file name
        //                    int Count = 1;
        //                    string BaseName = "Web Picture";
        //                    string Extension = ".webp";
        //                    string NPath = System.IO.Path.Combine(selectedPath, $"{BaseName} ({Count}){Extension}");

        //                    // Check if the icon file already exists and increment the count if needed
        //                    while (File.Exists(NPath))
        //                    {
        //                        Count++;
        //                        NPath = System.IO.Path.Combine(selectedPath, $"{BaseName} ({Count}){Extension}");
        //                    }

        //                    // Save the icon file
        //                    image.Write(NPath);
        //                }
        //            }
        //        }
        //    });
        //}

        //private async Task BmpBuilder(string fileName)
        //{
        //    await Task.Run(() =>
        //    {
        //        if (string.IsNullOrEmpty(fileName))
        //        {
        //            // Handle the case when no file is selected
        //            MessageBox.Show($"Missing file", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        }
        //        else
        //        {
        //            string Path = System.IO.Path.Combine(selectedPath, selectedFileName);

        //            if (!File.Exists(Path))
        //            {
        //                // Handle the case when the selected file is no longer in the specified path
        //                MessageBox.Show($"The file '{selectedFileName}' is no longer in the specified path.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            }
        //            else
        //            {
        //                using (MagickImage image = new MagickImage(Path))
        //                {
        //                    // Convert the image to .webp format
        //                    image.Format = MagickFormat.Bmp;

        //                    // Create a unique icon file name
        //                    int Count = 1;
        //                    string BaseName = "Bump";
        //                    string Extension = ".Bmp";
        //                    string NPath = System.IO.Path.Combine(selectedPath, $"{BaseName} ({Count}){Extension}");

        //                    // Check if the icon file already exists and increment the count if needed
        //                    while (File.Exists(NPath))
        //                    {
        //                        Count++;
        //                        NPath = System.IO.Path.Combine(selectedPath, $"{BaseName} ({Count}){Extension}");
        //                    }

        //                    // Save the icon file
        //                    image.Write(NPath);
        //                }
        //            }
        //        }
        //    });
        //}

        //private async Task GIFBuilder(string fileName)
        //{
        //    await Task.Run(() =>
        //    {
        //        if (string.IsNullOrEmpty(fileName))
        //        {
        //            // Handle the case when no file is selected
        //            MessageBox.Show($"Missing file", "File Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        }
        //        else
        //        {
        //            string Path = System.IO.Path.Combine(selectedPath, selectedFileName);

        //            if (!File.Exists(Path))
        //            {
        //                // Handle the case when the selected file is no longer in the specified path
        //                MessageBox.Show($"The file '{selectedFileName}' is no longer in the specified path.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            }
        //            else
        //            {
        //                // Create a new instance of FFProbe
        //                var ffProbe = new NReco.VideoInfo.FFProbe();

        //                // Get the duration of the video
        //                var videoInfo = ffProbe.GetMediaInfo(Path);
        //                double videoDuration = videoInfo.Duration.TotalSeconds;

        //                if (videoDuration <= 15)
        //                {

        //                    // Create a unique icon file name
        //                    int Count = 1;
        //                    string BaseName = "Animated";
        //                    string Extension = ".gif";
        //                    string NPath = System.IO.Path.Combine(selectedPath, $"{BaseName} ({Count}){Extension}");

        //                    // Check if the icon file already exists and increment the count if needed
        //                    while (File.Exists(NPath))
        //                    {
        //                        Count++;
        //                        NPath = System.IO.Path.Combine(selectedPath, $"{BaseName} ({Count}){Extension}");
        //                    }

        //                    var converter = new NReco.VideoConverter.FFMpegConverter();
        //                    converter.ConvertMedia(fileName, NPath, NReco.VideoConverter.Format.gif);
        //                }
        //                else
        //                {
        //                    Console.WriteLine($"The video at {fileName} is longer than 15 seconds and will not be converted.");
        //                }
        //            }
        //        }
        //    });
        //}

        //private async Task WEBMBuilder(string fileName)
        //{
        //    await Task.Run(() =>
        //    {
        //        if (string.IsNullOrEmpty(fileName))
        //        {
        //            // Handle the case when no file is selected
        //            MessageBox.Show($"Missing file", "File Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        }
        //        else
        //        {
        //            string Path = System.IO.Path.Combine(selectedPath, selectedFileName);

        //            if (!File.Exists(Path))
        //            {
        //                // Handle the case when the selected file is no longer in the specified path
        //                MessageBox.Show($"The file '{selectedFileName}' is no longer in the specified path.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            }
        //            else
        //            {
        //                // Create a unique icon file name
        //                int Count = 1;
        //                string BaseName = "Web Video";
        //                string Extension = ".webm";
        //                string NPath = System.IO.Path.Combine(selectedPath, $"{BaseName} ({Count}){Extension}");

        //                // Check if the icon file already exists and increment the count if needed
        //                while (File.Exists(NPath))
        //                {
        //                    Count++;
        //                    NPath = System.IO.Path.Combine(selectedPath, $"{BaseName} ({Count}){Extension}");
        //                }

        //                var converter = new NReco.VideoConverter.FFMpegConverter();
        //                converter.ConvertMedia(fileName, NPath, NReco.VideoConverter.Format.webm);
        //            }
        //        }
        //    });
        //}

        //private async Task AVIBuilder(string fileName)
        //{
        //    await Task.Run(() =>
        //    {
        //        if (string.IsNullOrEmpty(fileName))
        //        {
        //            // Handle the case when no file is selected
        //            MessageBox.Show($"Missing file", "File Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        }
        //        else
        //        {
        //            string Path = System.IO.Path.Combine(selectedPath, selectedFileName);

        //            if (!File.Exists(Path))
        //            {
        //                // Handle the case when the selected file is no longer in the specified path
        //                MessageBox.Show($"The file '{selectedFileName}' is no longer in the specified path.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            }
        //            else
        //            {
        //                // Create a unique icon file name
        //                int Count = 1;
        //                string BaseName = "Video";
        //                string Extension = ".avi";
        //                string NPath = System.IO.Path.Combine(selectedPath, $"{BaseName} ({Count}){Extension}");

        //                // Check if the icon file already exists and increment the count if needed
        //                while (File.Exists(NPath))
        //                {
        //                    Count++;
        //                    NPath = System.IO.Path.Combine(selectedPath, $"{BaseName} ({Count}){Extension}");
        //                }

        //                var converter = new NReco.VideoConverter.FFMpegConverter();
        //                converter.ConvertMedia(fileName, NPath, NReco.VideoConverter.Format.avi);
        //            }
        //        }
        //    });
        //}

        //private async Task AudioBuilder(string fileName)
        //{
        //    await Task.Run(() =>
        //    {
        //        if (string.IsNullOrEmpty(fileName))
        //        {
        //            // Handle the case when no file is selected
        //            MessageBox.Show($"Missing file", "File Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        }
        //        else
        //        {
        //            string Path = System.IO.Path.Combine(selectedPath, selectedFileName);

        //            if (!File.Exists(Path))
        //            {
        //                // Handle the case when the selected file is no longer in the specified path
        //                MessageBox.Show($"The file '{selectedFileName}' is no longer in the specified path.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            }
        //            else
        //            {
        //                // Create a unique icon file name
        //                int Count = 1;
        //                string BaseName = "Video";
        //                string Extension = ".avi";
        //                string NPath = System.IO.Path.Combine(selectedPath, $"{BaseName} ({Count}){Extension}");

        //                // Check if the icon file already exists and increment the count if needed
        //                while (File.Exists(NPath))
        //                {
        //                    Count++;
        //                    NPath = System.IO.Path.Combine(selectedPath, $"{BaseName} ({Count}){Extension}");
        //                }

        //                using (var reader = new NAudio.Wave.AudioFileReader(NPath))
        //                {
        //                    MediaFoundationEncoder.EncodeToMp3(reader, NPath);
        //                }
        //            }
        //        }
        //    });
        //}

        //private async Task WAVBuilder(string fileName)
        //{
        //    await Task.Run(() =>
        //    {
        //        if (string.IsNullOrEmpty(fileName))
        //        {
        //            // Handle the case when no file is selected
        //            MessageBox.Show($"Missing file", "File Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        }
        //        else
        //        {
        //            string Path = System.IO.Path.Combine(selectedPath, selectedFileName);

        //            if (!File.Exists(Path))
        //            {
        //                // Handle the case when the selected file is no longer in the specified path
        //                MessageBox.Show($"The file '{selectedFileName}' is no longer in the specified path.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            }
        //            else
        //            {
        //                // Create a unique icon file name
        //                int Count = 1;
        //                string BaseName = "Video";
        //                string Extension = ".avi";
        //                string NPath = System.IO.Path.Combine(selectedPath, $"{BaseName} ({Count}){Extension}");

        //                // Check if the icon file already exists and increment the count if needed
        //                while (File.Exists(NPath))
        //                {
        //                    Count++;
        //                    NPath = System.IO.Path.Combine(selectedPath, $"{BaseName} ({Count}){Extension}");
        //                }

        //                using (var reader = new AudioFileReader(NPath))
        //                {
        //                    WaveFileWriter.CreateWaveFile(NPath, reader);
        //                }
        //            }
        //        }
        //    });
        //}

        //private async Task DocBuilder(string fileName)
        //{
        //    await Task.Run(() =>
        //    {
        //        if (string.IsNullOrEmpty(fileName))
        //        {
        //            // Handle the case when no file is selected
        //            MessageBox.Show($"Missing file", "File Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        }
        //        else
        //        {
        //            string path = System.IO.Path.Combine(selectedPath, selectedFileName);

        //            if (!File.Exists(path))
        //            {
        //                // Handle the case when the selected file is no longer in the specified path
        //                MessageBox.Show($"The file '{selectedFileName}' is no longer in the specified path.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            }
        //            else
        //            {
        //                try
        //                {
        //                    // Load the PDF document
        //                    var pdfDocument = new Aspose.Pdf.Document(path);

        //                    // Get the total number of pages in the PDF
        //                    int totalPages = pdfDocument.Pages.Count;

        //                    // Set the output format (DOC or DOCX)
        //                    var saveOptions = new Aspose.Pdf.DocSaveOptions();
        //                    saveOptions.Format = Aspose.Pdf.DocSaveOptions.DocFormat.DocX; // Choose either Docx or Doc

        //                    // Save the PDF as a Word document
        //                    var outputPath = System.IO.Path.Combine(selectedPath, $"{System.IO.Path.GetFileNameWithoutExtension(selectedFileName)}.docx");
        //                    pdfDocument.Save(outputPath, saveOptions);

        //                    MessageBox.Show($"PDF successfully converted to Word document ({totalPages} pages): {outputPath}", "Conversion Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                }
        //                catch (Exception ex)
        //                {
        //                    MessageBox.Show($"An error occurred during PDF-to-Word conversion: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                }

        //            }
        //        }
        //    });
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
        //                MessageBox.Show($"Deleted: {directory}");
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show($"An error occurred while deleting the directory. Details: {ex.Message}");
        //            }
        //        }
        //    }
        //}

    }


}