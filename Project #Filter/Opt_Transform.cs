using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Speech.Synthesis;
using System.Threading.Tasks;
using Aspose.Cells.Charts;
using ImageMagick;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using iTextSharp.xmp.impl.xpath;
using NAudio.Wave;
using SharpCompress.Common;
using Windows.Devices.Geolocation;
using static System.Net.Mime.MediaTypeNames;
using Rectangle = iTextSharp.text.Rectangle;

namespace Project__Filter
{
    public partial class Opt_Transform : UserControl
    {
        private string selectedPath = string.Empty;
        string selectedFileName = string.Empty;

        private static readonly HashSet<string> PDFExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            ".jpg", ".jpeg", ".png", ".tiff", ".bmp"
        };
        private static readonly HashSet<string> IconExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            ".jpg", ".jpeg", ".png", ".bmp", ".gif", ".svg"
        };
        private static readonly HashSet<string> WebPExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            ".jpg", ".jpeg", ".png", ".bmp", ".gif", ".svg", ".tiff"
        };
        private static readonly HashSet<string> BMPExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            ".jpg", ".jpeg", ".png", ".bmp", ".svg", ".tiff", ".webp"
        };
        private static readonly HashSet<string> GifExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            ".mp4", ".avi", ".mkv", ".flv", ".mov", ".wmv"
        };
        private static readonly HashSet<string> AudioExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            ".mp4", ".avi", ".mkv", ".flv", ".mov", ".wmv"
        };
        private static readonly HashSet<string> WebMExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
           ".mp4", ".avi", ".mkv", ".flv", ".mov", ".wmv", ".m4v", ".mpeg", ".mpg"
        };
        private static readonly HashSet<string> AviExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
           ".mp4", ".mkv", ".flv", ".mov", ".wmv", ".m4v", ".mpeg", ".mpg"
        };
        private static readonly HashSet<string> WavExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
           ".mp3", ".aac", ".flac", ".m4a", ".ogg", ".wma", ".mpeg", ".mpg"
        };
        private static readonly HashSet<string> DocxExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
           ".pdf"
        };

        public Opt_Transform()
        {
            InitializeComponent();
        }

        private void button_Path_Click(object sender, EventArgs e)
        {

        }

        private async void button_Convert_Click(object sender, EventArgs e)
        {
            //string title = string.Empty;
            //string[] files = [];
            //byte[] pdfByteArray = [];

            ////string selectedItem = comboBox_Select.SelectedItem?.ToString();
            //switch (selectedItem)
            //{
            //    case "IMAGE To PDF [TITLE]":
            //        title = askTitle(selectedPath);
            //        files = askContent(selectedPath);
            //        pdfByteArray = await PDFBuilder(files);
            //        pdfByteArray = await PDFBuilderTitle(pdfByteArray, title);
            //        CreatedPdf(pdfByteArray, title);
            //        break;
            //    case "IMAGE To PDF [NO TITLE]":
            //        title = "Untitled";
            //        files = askContent(selectedPath);
            //        pdfByteArray = await PDFBuilder(files);
            //        CreatedPdf(pdfByteArray, title);
            //        break;
            //    case "IMAGE To ICO":
            //        IconBuilder(selectedFileName);
            //        break;
            //    case "IMAGE To WEBP":
            //        WebpBuilder(selectedFileName);
            //        break;
            //    case "IMAGE To BMP":
            //        BmpBuilder(selectedFileName);
            //        break;
            //    case "VIDEO To GIF":
            //        GIFBuilder(selectedFileName);
            //        break;
            //    case "VIDEO To WEBM":
            //        WEBMBuilder(selectedFileName);
            //        break;
            //    case "VIDEO To AVI":
            //        AVIBuilder(selectedFileName);
            //        break;
            //    case "VIDEO To AUDIO":
            //        AudioBuilder(selectedFileName);
            //        break;
            //    case "AUDIO To WAV":
            //        WAVBuilder(selectedFileName);
            //        break;
            //    case "DOC To PDF":
            //        DocBuilder(selectedFileName);
            //        break;
            //    default:
            //        MessageBox.Show("Please select an option first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        break;
            //}

            //if (checkBox_Delete.Checked)
            //{
            //    DeleteFolders(selectedPath);
            //}
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

        //private string[] askContent(string selectedPath)
        //{
        //    DialogResult result = MessageBox.Show("Do you want a custom content?", "Title", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        //    if (result == DialogResult.Yes)
        //    {
        //        string selectedItem = string.Empty;

        //        foreach (RadioButton radioButton in panel_Action.Controls.OfType<RadioButton>())
        //        {
        //            if (radioButton.Checked)
        //            {
        //                selectedItem = radioButton.Text; // Use the text of the selected radio button
        //                break; // Exit the loop once a selection is found
        //            }
        //        }

        //        // Get the files in the selected path
        //        string[] files = Directory.GetFiles(selectedPath);
        //        string[] sort = [];

        //        // Sort the files based on the user's selection
        //        switch (selectedItem)
        //        {
        //            case "Sort by name":
        //                sort = SortByName(files);
        //                break;
        //            case "Sort by date":
        //                sort = SortByDate(files);
        //                break;
        //            case "Sort by size":
        //                sort = SortBySize(files);
        //                break;
        //            default:
        //                break;
        //        }
        //        return sort;
        //    }
        //    else
        //    {
        //        // Get the files in the selected path without sorting
        //        string[] files = Directory.GetFiles(selectedPath);

        //        var filteredFiles = files.Where(file => PDFExtensions.Contains(System.IO.Path.GetExtension(file))).ToArray();

        //        return filteredFiles;
        //    }
        //}

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
            });
        }

        private async Task GIFBuilder(string fileName)
        {
            await Task.Run(() =>
            {
                if (string.IsNullOrEmpty(fileName))
                {
                    // Handle the case when no file is selected
                    MessageBox.Show($"Missing file", "File Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        // Create a new instance of FFProbe
                        var ffProbe = new NReco.VideoInfo.FFProbe();

                        // Get the duration of the video
                        var videoInfo = ffProbe.GetMediaInfo(Path);
                        double videoDuration = videoInfo.Duration.TotalSeconds;

                        if (videoDuration <= 15)
                        {

                            // Create a unique icon file name
                            int Count = 1;
                            string BaseName = "Animated";
                            string Extension = ".gif";
                            string NPath = System.IO.Path.Combine(selectedPath, $"{BaseName} ({Count}){Extension}");

                            // Check if the icon file already exists and increment the count if needed
                            while (File.Exists(NPath))
                            {
                                Count++;
                                NPath = System.IO.Path.Combine(selectedPath, $"{BaseName} ({Count}){Extension}");
                            }

                            var converter = new NReco.VideoConverter.FFMpegConverter();
                            converter.ConvertMedia(fileName, NPath, NReco.VideoConverter.Format.gif);
                        }
                        else
                        {
                            Console.WriteLine($"The video at {fileName} is longer than 15 seconds and will not be converted.");
                        }
                    }
                }
            });
        }

        private async Task WEBMBuilder(string fileName)
        {
            await Task.Run(() =>
            {
                if (string.IsNullOrEmpty(fileName))
                {
                    // Handle the case when no file is selected
                    MessageBox.Show($"Missing file", "File Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        // Create a unique icon file name
                        int Count = 1;
                        string BaseName = "Web Video";
                        string Extension = ".webm";
                        string NPath = System.IO.Path.Combine(selectedPath, $"{BaseName} ({Count}){Extension}");

                        // Check if the icon file already exists and increment the count if needed
                        while (File.Exists(NPath))
                        {
                            Count++;
                            NPath = System.IO.Path.Combine(selectedPath, $"{BaseName} ({Count}){Extension}");
                        }

                        var converter = new NReco.VideoConverter.FFMpegConverter();
                        converter.ConvertMedia(fileName, NPath, NReco.VideoConverter.Format.webm);
                    }
                }
            });
        }

        private async Task AVIBuilder(string fileName)
        {
            await Task.Run(() =>
            {
                if (string.IsNullOrEmpty(fileName))
                {
                    // Handle the case when no file is selected
                    MessageBox.Show($"Missing file", "File Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        // Create a unique icon file name
                        int Count = 1;
                        string BaseName = "Video";
                        string Extension = ".avi";
                        string NPath = System.IO.Path.Combine(selectedPath, $"{BaseName} ({Count}){Extension}");

                        // Check if the icon file already exists and increment the count if needed
                        while (File.Exists(NPath))
                        {
                            Count++;
                            NPath = System.IO.Path.Combine(selectedPath, $"{BaseName} ({Count}){Extension}");
                        }

                        var converter = new NReco.VideoConverter.FFMpegConverter();
                        converter.ConvertMedia(fileName, NPath, NReco.VideoConverter.Format.avi);
                    }
                }
            });
        }

        private async Task AudioBuilder(string fileName)
        {
            await Task.Run(() =>
            {
                if (string.IsNullOrEmpty(fileName))
                {
                    // Handle the case when no file is selected
                    MessageBox.Show($"Missing file", "File Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        // Create a unique icon file name
                        int Count = 1;
                        string BaseName = "Video";
                        string Extension = ".avi";
                        string NPath = System.IO.Path.Combine(selectedPath, $"{BaseName} ({Count}){Extension}");

                        // Check if the icon file already exists and increment the count if needed
                        while (File.Exists(NPath))
                        {
                            Count++;
                            NPath = System.IO.Path.Combine(selectedPath, $"{BaseName} ({Count}){Extension}");
                        }

                        using (var reader = new NAudio.Wave.AudioFileReader(NPath))
                        {
                            MediaFoundationEncoder.EncodeToMp3(reader, NPath);
                        }
                    }
                }
            });
        }

        private async Task WAVBuilder(string fileName)
        {
            await Task.Run(() =>
            {
                if (string.IsNullOrEmpty(fileName))
                {
                    // Handle the case when no file is selected
                    MessageBox.Show($"Missing file", "File Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        // Create a unique icon file name
                        int Count = 1;
                        string BaseName = "Video";
                        string Extension = ".avi";
                        string NPath = System.IO.Path.Combine(selectedPath, $"{BaseName} ({Count}){Extension}");

                        // Check if the icon file already exists and increment the count if needed
                        while (File.Exists(NPath))
                        {
                            Count++;
                            NPath = System.IO.Path.Combine(selectedPath, $"{BaseName} ({Count}){Extension}");
                        }

                        using (var reader = new AudioFileReader(NPath))
                        {
                            WaveFileWriter.CreateWaveFile(NPath, reader);
                        }
                    }
                }
            });
        }

        private async Task DocBuilder(string fileName)
        {
            await Task.Run(() =>
            {
                if (string.IsNullOrEmpty(fileName))
                {
                    // Handle the case when no file is selected
                    MessageBox.Show($"Missing file", "File Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        try
                        {
                            // Load the PDF document
                            var pdfDocument = new Aspose.Pdf.Document(path);

                            // Get the total number of pages in the PDF
                            int totalPages = pdfDocument.Pages.Count;

                            // Set the output format (DOC or DOCX)
                            var saveOptions = new Aspose.Pdf.DocSaveOptions();
                            saveOptions.Format = Aspose.Pdf.DocSaveOptions.DocFormat.DocX; // Choose either Docx or Doc

                            // Save the PDF as a Word document
                            var outputPath = System.IO.Path.Combine(selectedPath, $"{System.IO.Path.GetFileNameWithoutExtension(selectedFileName)}.docx");
                            pdfDocument.Save(outputPath, saveOptions);

                            MessageBox.Show($"PDF successfully converted to Word document ({totalPages} pages): {outputPath}", "Conversion Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"An error occurred during PDF-to-Word conversion: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
            });
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
                        MessageBox.Show($"Deleted: {directory}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while deleting the directory. Details: {ex.Message}");
                    }
                }
            }
        }
    }
}