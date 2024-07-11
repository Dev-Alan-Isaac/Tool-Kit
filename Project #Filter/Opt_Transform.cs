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
using NAudio.Wave;
using SharpCompress.Common;
using Rectangle = iTextSharp.text.Rectangle;

namespace Project__Filter
{
    public partial class Opt_Transform : UserControl
    {
        private string selectedPath = string.Empty;
        string selectedItem = string.Empty;
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

        public Opt_Transform()
        {
            InitializeComponent();
            listBox_File.SelectionMode = SelectionMode.MultiExtended;
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

                    comboBox_Select.Enabled = true;
                    button_Convert.Enabled = true;
                }
            }
        }

        private void button_Convert_Click(object sender, EventArgs e)
        {
            string title = string.Empty;
            string[] files = [];

            string selectedItem = comboBox_Select.SelectedItem.ToString();
            switch (selectedItem)
            {
                case "IMAGE To PDF [TITLE]":
                    title = askTitle(selectedPath);
                    files = askContent(selectedPath);
                    CreatedPdf(files, title);
                    break;
                case "IMAGE To PDF [NO TITLE]":
                    title = "Untitled";
                    files = askContent(selectedPath);
                    CreatedPdf(files, title);
                    break;
                case "IMAGE To ICO":

                    break;
                case "IMAGE To WEBP":
                    break;
                case "IMAGE To BMP":
                    break;
                case "VIDEO To GIF":
                    break;
                case "VIDEO To WEBM":
                    break;
                case "VIDEO To AVI":
                    break;
                case "VIDEO To AUDIO":
                    break;
                case "AUDIO To WAV":
                    break;
                default:
                    break;
            }

            if (checkBox_Delete.Checked)
            {
                DeleteFolders(selectedPath);
            }
        }

        private void comboBox_Select_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = comboBox_Select.SelectedItem.ToString();
            PopulatedList(selectedItem);
        }

        private void listBox_File_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected item (if any)
            selectedItem = listBox_File.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedItem))
            {
                // Handle the selected item (e.g., display it, process it, etc.)
                MessageBox.Show($"No file selected");
            }
            else
            {
                MessageBox.Show($"Selected: {selectedItem}");
            }
        }

        private void PopulatedList(string selectedItem)
        {
            string[] filteredFiles = [];
            string[] files = Directory.GetFiles(selectedPath);

            if (files.Length > 0)
            {
                listBox_File.Items.Clear();

                switch (selectedItem)
                {
                    case "IMAGE To PDF [TITLE]":
                    case "IMAGE To PDF [NO TITLE]":
                        filteredFiles = files.Where(file => PDFExtensions.Contains(System.IO.Path.GetExtension(file))).ToArray();

                        foreach (string file in filteredFiles)
                        {
                            listBox_File.Items.Add(System.IO.Path.GetFileName(file));
                        }

                        label_Count.Text = filteredFiles.Length.ToString();
                        break;
                    case "IMAGE To ICO":
                        filteredFiles = files.Where(file => IconExtensions.Contains(System.IO.Path.GetExtension(file))).ToArray();

                        foreach (string file in filteredFiles)
                        {
                            listBox_File.Items.Add(System.IO.Path.GetFileName(file));
                        }

                        label_Count.Text = filteredFiles.Length.ToString();
                        break;
                    case "IMAGE To WEBP":
                        filteredFiles = files.Where(file => WebPExtensions.Contains(System.IO.Path.GetExtension(file))).ToArray();

                        foreach (string file in filteredFiles)
                        {
                            listBox_File.Items.Add(System.IO.Path.GetFileName(file));
                        }

                        label_Count.Text = filteredFiles.Length.ToString();
                        break;
                    case "IMAGE To BMP":
                        filteredFiles = files.Where(file => BMPExtensions.Contains(System.IO.Path.GetExtension(file))).ToArray();

                        foreach (string file in filteredFiles)
                        {
                            listBox_File.Items.Add(System.IO.Path.GetFileName(file));
                        }

                        label_Count.Text = filteredFiles.Length.ToString();
                        break;
                    case "VIDEO To GIF":
                        filteredFiles = files.Where(file => GifExtensions.Contains(System.IO.Path.GetExtension(file))).ToArray();

                        foreach (string file in filteredFiles)
                        {
                            listBox_File.Items.Add(System.IO.Path.GetFileName(file));
                        }

                        label_Count.Text = filteredFiles.Length.ToString();
                        break;
                    case "VIDEO To WEBM":
                        filteredFiles = files.Where(file => WebMExtensions.Contains(System.IO.Path.GetExtension(file))).ToArray();

                        foreach (string file in filteredFiles)
                        {
                            listBox_File.Items.Add(System.IO.Path.GetFileName(file));
                        }

                        label_Count.Text = filteredFiles.Length.ToString();
                        break;
                    case "VIDEO To AVI":
                        filteredFiles = files.Where(file => AviExtensions.Contains(System.IO.Path.GetExtension(file))).ToArray();

                        foreach (string file in filteredFiles)
                        {
                            listBox_File.Items.Add(System.IO.Path.GetFileName(file));
                        }

                        label_Count.Text = filteredFiles.Length.ToString();
                        break;
                    case "VIDEO To AUDIO":
                        filteredFiles = files.Where(file => AudioExtensions.Contains(System.IO.Path.GetExtension(file))).ToArray();

                        foreach (string file in filteredFiles)
                        {
                            listBox_File.Items.Add(System.IO.Path.GetFileName(file));
                        }

                        label_Count.Text = filteredFiles.Length.ToString();
                        break;
                    case "AUDIO To WAV":
                        filteredFiles = files.Where(file => WavExtensions.Contains(System.IO.Path.GetExtension(file))).ToArray();

                        foreach (string file in filteredFiles)
                        {
                            listBox_File.Items.Add(System.IO.Path.GetFileName(file));
                        }

                        label_Count.Text = filteredFiles.Length.ToString();
                        break;
                    default:
                        break;
                }
            }
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

        private async Task<byte[]> PDFBuilder(string[] arrayFiles)
        {
            // Create a new PDF document
            Document document = new Document();
            using (MemoryStream stream = new MemoryStream())
            {
                // Create a new PdfWriter object, pointing it to our MemoryStream
                PdfWriter writer = PdfWriter.GetInstance(document, stream);

                // Open the Document for writing
                document.Open();

                foreach (string file in arrayFiles)
                {
                    // Add the image to the document
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(file);
                    document.SetPageSize(new Rectangle(0, 0, image.Width, image.Height));
                    document.NewPage();
                    image.SetAbsolutePosition(0, 0);
                    document.Add(image);
                }
                // Close the Document - this saves it to the MemoryStream
                document.Close();
                // Convert the MemoryStream to an array and return it
                return stream.ToArray();
            }
        }

        private async void CreatedPdf(string[] arrayFiles, string title)
        {
            byte[] pdfByteArray = await PDFBuilder(arrayFiles);

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

        private async Task IconBuilder(string file)
        {
            // Define the maximum width and height
            int maxWidth = 256;
            int maxHeight = 256;

            if (File.Exists(file))
            {
                using (MagickImage image = new MagickImage(file))
                {
                    if (image.Width <= maxWidth && image.Height <= maxHeight)
                    {
                    }
                }
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