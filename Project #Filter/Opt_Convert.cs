using System.Data;
using ImageMagick;
using NAudio.Wave;
using Newtonsoft.Json.Linq;

namespace Project__Filter
{
    public partial class Opt_Transform : UserControl
    {
        private string Path;
        private List<string> checkedItems = new List<string>();

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

        private void button_Filter_Click_1(object sender, EventArgs e)
        {
            // Iterate through each item in the checkedItems list
            foreach (string item in checkedItems)
            {
                switch (item)
                {
                    case "File Type":
                        await Task.Run(() => SortTypes(Path, config_Path));
                        break;
                    case "File Size":
                        await Task.Run(() => SortSize(Path, config_Path));
                        break;
                    case "File Date":
                        await Task.Run(() => SortDates(Path, config_Path));
                        break;
                    case "File Name":
                        await Task.Run(() => SortNames(Path, config_Path));
                        break;
                    case "File Permissions":
                        await Task.Run(() => SortPermissions(Path, config_Path, config_Path2));
                        break;
                    case "Custom Tags":
                        await Task.Run(() => SortCustomTags(Path, config_Path));
                        break;
                    case "Folder Location":
                        await Task.Run(() => SortFolderLocation(Path, config_Path));
                        break;
                    case "Media Metadata":

                        await Task.Run(() => SortMedia(Path, config_Path, config_Path2));
                        break;
                    case "File Hash":
                        await Task.Run(() => SortHash(Path, config_Path));
                        break;
                    default:
                        break;
                }
            }
        }

        private void Opt_Transform_Load(object sender, EventArgs e)
        {
            while (true)
            {
                if (!File.Exists("Config_Convert.json"))
                {
                    // Create the JSON object
                    var jsonContent = new JObject(
                         new JProperty("Allow", new JObject(
                             new JProperty("Image", new JArray("jpeg", "png", "tiff", "ico", "svg","webp")),
                             new JProperty("Audio", new JArray("wav", "mp3", "wma")),
                             new JProperty("Video", new JArray("gif", "webm", "avi", "mp4","flv","mov","mkv")),
                             new JProperty("Document", new JArray())
                         ))
                         //,
                         //new JProperty("Convert", new JObject(
                         //    new JProperty("Image", new JArray("jpeg", "png", "tiff", "ico", "svg", "webp"), new JArray("jpeg", "png", "tiff", "ico", "svg", "webp")),
                         //    new JProperty("Audio", new JArray("wav", "mp3", "wma"), new JArray("jpeg", "png", "tiff", "ico", "svg", "webp")),
                         //    new JProperty("Video", new JArray("gif", "docx", "pdf", "pptx"), new JArray("jpeg", "png", "tiff", "ico", "svg", "webp")),
                         //    new JProperty("Document", new JArray("mp3", "wav", "aac", "flac", "ogg", "m4a", "wma", "alac", "aiff"), new JArray("jpeg", "png", "tiff", "ico", "svg", "webp"))
                         //))
                    );

                    // Save to a file (e.g., "Extensions.json")
                    File.WriteAllText("Config_Type.json", jsonContent.ToString());
                }
                break;
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


        private void Populated_Treeview()
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