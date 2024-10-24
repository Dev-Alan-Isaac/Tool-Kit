using System.Data;
using ImageMagick;
using iTextSharp.text;
using iTextSharp.text.pdf;
using NAudio.Lame;
using NAudio.Wave;
using Newtonsoft.Json.Linq;
using NReco.VideoConverter;
using Paragraph_iTextSharp = iTextSharp.text.Paragraph;
using DocumentPDF_iTextSharp = iTextSharp.text.Document;
using Xceed.Words.NET;
using Xceed.Document.NET;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using iTextSharp.text.pdf.parser;


namespace Project__Filter
{
    public partial class Opt_Transform : UserControl
    {
        private string Path;
        private bool isProgrammaticChange = false;
        private string Extension = string.Empty;
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
            // If the change was programmatically triggered, ignore it
            if (isProgrammaticChange)
                return;

            label_SelectedNode.Text = "#";
            label_Output.Text = "#";

            // Enable the filter button when any radio button is checked
            if (radioButton_Image.Checked || radioButton_Audio.Checked || radioButton_Video.Checked || radioButton_Document.Checked)
            {
                button_Filter.Enabled = true;
            }
            else
            {
                button_Filter.Enabled = false;
            }

            if (!string.IsNullOrEmpty(Path))
            {
                Populated_Treeview(Path);
            }
            else
            {
                MessageBox.Show("No Path Selected");

                // Temporarily set the flag to true to prevent triggering the event multiple times
                isProgrammaticChange = true;
                try
                {
                    radioButton_Image.Checked = false;
                    radioButton_Audio.Checked = false;
                    radioButton_Video.Checked = false;
                    radioButton_Document.Checked = false;
                }
                finally
                {
                    isProgrammaticChange = false;
                }
            }
        }


        private async void button_Filter_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Path))
            {
                button_Filter.Enabled = false;
                if (radioButton_Image.Checked)
                {
                    await ImageConvert(FileList, Extension);
                }
                else if (radioButton_Audio.Checked)
                {
                    await AudioConvert(FileList, Extension);
                }
                else if (radioButton_Video.Checked)
                {
                    await VideoConvert(FileList, Extension);
                }
                else if (radioButton_Document.Checked)
                {
                    await DocumentConvert(FileList, Extension);
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
                allowedExtensions = new JArray { "MP3", "WAV", "AAC" };
            }
            else if (radioButton_Video.Checked)
            {
                allowedExtensions = new JArray { "MP4", "WEBM", "AVI", "WAV", "GIF", "MP3" };
            }
            else if (radioButton_Document.Checked)
            {
                allowedExtensions = new JArray { "DOC", "DOCX", "PDF", "TXT" };
            }

            if (allowedExtensions != null)
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

            Extension = extension;

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

        private async Task ImageConvert(string[] files, string targetExtension)
        {
            if (targetExtension == "docx" || targetExtension == "pdf")
            {
                await ConvertDocument(files, targetExtension);
            }
            else
            {
                try
                {
                    progressBar_Time.Invoke((Action)(() => progressBar_Time.Maximum = files.Length));
                    int processedFiles = 0;

                    foreach (var file in files)
                    {
                        string fileExtension = System.IO.Path.GetExtension(file).ToLower();


                        // Proceed with image conversion
                        using (MagickImage image = new MagickImage(file))
                        {
                            image.Format = GetMagickFormat(targetExtension);
                            string newFilePath = System.IO.Path.ChangeExtension(file, targetExtension);
                            await image.WriteAsync(newFilePath);
                        }

                        processedFiles++;
                        progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = processedFiles));
                    }

                    progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = 0));
                    MessageBox.Show($"Files converted successfully to {targetExtension.ToUpper()}!", "Conversion Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error converting file: {ex.Message}", "Conversion Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async Task ConvertDocument(string[] files, string targetExtension)
        {
            string config_file = "Config_Convert.json";

            if (!File.Exists(config_file))
            {
                MessageBox.Show("Config file not found.");
            }

            DialogResult result = MessageBox.Show("Do you want a custom title?", "Title Prompt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            string Title = string.Empty;

            if (result == DialogResult.Yes)
            {
                Title = Microsoft.VisualBasic.Interaction.InputBox("Enter the custom title:", "Title", "", -1, -1);
            }

            try
            {
                if (targetExtension.ToLower() == "pdf")
                {
                    await PDFBuilder(files, Title);
                }
                else if (targetExtension.ToLower() == "docx")
                {
                    await DocxBuilder(files, Title);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error converting document: {ex.Message}", "Conversion Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task PDFBuilder(string[] arrayFiles, string title)
        {
            var document = new DocumentPDF_iTextSharp();
            progressBar_Time.Invoke((Action)(() => progressBar_Time.Maximum = arrayFiles.Length));
            int processedFiles = 0;
            string outputFilePath = System.IO.Path.Combine(Path, string.IsNullOrEmpty(title) ? "untitled.pdf" : $"{title}.pdf");

            try
            {
                using (var ms = new MemoryStream())
                {
                    PdfWriter.GetInstance(document, ms);
                    document.Open();

                    if (!string.IsNullOrEmpty(title))
                    {
                        // Add title page
                        document.SetPageSize(PageSize.LETTER);
                        document.NewPage();
                        for (int i = 0; i < 20; i++) document.Add(new Paragraph_iTextSharp("\n"));
                        var titleParagraph = new Paragraph_iTextSharp(title, FontFactory.GetFont(FontFactory.HELVETICA, 50f, iTextSharp.text.Font.BOLD));
                        titleParagraph.Alignment = Element.ALIGN_CENTER;
                        document.Add(titleParagraph);
                        for (int i = 0; i < 10; i++) document.Add(new Paragraph_iTextSharp("\n"));
                    }

                    foreach (var file in arrayFiles)
                    {
                        var image = iTextSharp.text.Image.GetInstance(file);
                        document.SetPageSize(new iTextSharp.text.Rectangle(0, 0, image.Width, image.Height));
                        document.NewPage();
                        image.SetAbsolutePosition(0, 0);
                        document.Add(image);
                        processedFiles++;
                        progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = processedFiles));
                    }

                    document.Close();
                    File.WriteAllBytes(outputFilePath, ms.ToArray());
                    progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = 0));
                    MessageBox.Show($"PDF created successfully!", "PDF Creation Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating PDF: {ex.Message}", "PDF Creation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task DocxBuilder(string[] arrayFiles, string title)
        {
            // Create a new document
            var doc = DocX.Create(!string.IsNullOrEmpty(title) ? $"{Path}\\{title}.docx" : $"{Path}\\untitled.docx");

            // Set up the progress bar
            progressBar_Time.Invoke((Action)(() => progressBar_Time.Maximum = arrayFiles.Length));
            int processedFiles = 0;

            try
            {
                if (!string.IsNullOrEmpty(title))
                {
                    // Add the title to the document
                    var titleParagraph = doc.InsertParagraph(title)
                                             .FontSize(50)
                                             .Bold()
                                             .Alignment = Alignment.center;

                    // Add some spacing
                    doc.InsertParagraph(new string('\n', 10));
                }

                foreach (var file in arrayFiles)
                {
                    var image = doc.AddImage(file);
                    var picture = image.CreatePicture();

                    // Ensure the picture fits the entire page
                    picture.Width = doc.PageWidth - doc.MarginLeft - doc.MarginRight;
                    picture.Height = doc.PageHeight - doc.MarginTop - doc.MarginBottom;

                    // Add the picture to a new paragraph
                    var pictureParagraph = doc.InsertParagraph()
                                               .AppendPicture(picture)
                                               .Alignment = Alignment.center;

                    // Ensure each image gets its own page
                    if (processedFiles < arrayFiles.Length - 1) // Prevents adding a blank page after the last image
                    {
                        doc.InsertParagraph().InsertPageBreakAfterSelf();
                    }

                    processedFiles++;
                    progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = processedFiles));
                }

                // Save the document to the specified path
                doc.Save();

                // Reset progress bar
                progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = 0));
                MessageBox.Show($"DOCX created successfully!", "DOCX Creation Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating DOCX: {ex.Message}", "DOCX Creation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private async Task AudioConvert(string[] files, string extension)
        {
            try
            {
                progressBar_Time.Invoke((Action)(() => progressBar_Time.Maximum = files.Length));
                int processedFiles = 0;

                foreach (var file in files)
                {
                    using (var reader = new AudioFileReader(file))
                    {
                        string newFilePath = System.IO.Path.ChangeExtension(file, extension);
                        using (var writer = GetAudioFileWriter(newFilePath, extension, reader.WaveFormat))
                        {
                            await Task.Run(() => reader.CopyTo(writer));
                        }
                    }

                    processedFiles++;
                    progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = processedFiles));
                }

                progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = 0));
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

        private async Task VideoConvert(string[] files, string extension)
        {
            try
            {
                var ffmpeg = new FFMpegConverter();

                // Set up the progress bar
                progressBar_Time.Invoke((Action)(() => progressBar_Time.Maximum = files.Length));
                int processedFiles = 0;

                foreach (var file in files)
                {
                    var outputFilePath = System.IO.Path.ChangeExtension(file, extension);

                    await Task.Run(() => ffmpeg.ConvertMedia(file, outputFilePath, extension));

                    processedFiles++;
                    progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = processedFiles));
                }

                MessageBox.Show($"All videos converted successfully to {extension.ToUpper()}!", "Conversion Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = 0));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error converting video: {ex.Message}", "Conversion Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task DocumentConvert(string[] files, string extension)
        {
            progressBar_Time.Invoke((Action)(() => progressBar_Time.Maximum = files.Length));
            int processedFiles = 0;

            try
            {
                foreach (var file in files)
                {
                    string newFilePath = System.IO.Path.ChangeExtension(file, extension);

                    if (file.EndsWith(".docx") || file.EndsWith(".doc"))
                    {
                        await Task.Run(() =>
                        {
                            var doc = DocX.Load(file);
                            if (extension == ".pdf")
                            {
                                // Convert DocX to PDF using iTextSharp
                                using (FileStream fs = new FileStream(newFilePath, FileMode.Create, FileAccess.Write, FileShare.None))
                                {
                                    var document = new DocumentPDF_iTextSharp(PageSize.A4);
                                    PdfWriter writer = PdfWriter.GetInstance(document, fs);
                                    document.Open();
                                    document.Add(new Paragraph_iTextSharp(doc.Text));
                                    document.Close();
                                }
                            }
                            else if (extension == ".txt")
                            {
                                // Convert DocX to plain text (.txt)
                                File.WriteAllText(newFilePath, doc.Text);
                            }
                            doc.SaveAs(newFilePath);
                        });
                    }
                    else if (file.EndsWith(".pdf"))
                    {
                        await Task.Run(() =>
                        {
                            if (extension == ".docx" || extension == ".doc")
                            {
                                // Convert PDF to Word using iTextSharp
                                using (PdfReader pdfReader = new PdfReader(file))
                                {
                                    using (var doc = DocX.Create(newFilePath))
                                    {
                                        for (int i = 1; i <= pdfReader.NumberOfPages; i++)
                                        {
                                            string text = PdfTextExtractor.GetTextFromPage(pdfReader, i);
                                            doc.InsertParagraph(text);
                                        }
                                        doc.Save();
                                    }
                                }
                            }
                            else if (extension == ".txt")
                            {
                                // Convert PDF to plain text (.txt) using iTextSharp
                                using (PdfReader pdfReader = new PdfReader(file))
                                {
                                    using (StreamWriter sw = new StreamWriter(newFilePath))
                                    {
                                        for (int i = 1; i <= pdfReader.NumberOfPages; i++)
                                        {
                                            string text = PdfTextExtractor.GetTextFromPage(pdfReader, i);
                                            sw.WriteLine(text);
                                        }
                                    }
                                }
                            }
                        });
                    }
                    else
                    {
                        MessageBox.Show($"File format for {file} not supported for conversion.", "Format Not Supported", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    processedFiles++;
                    progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = processedFiles));
                }

                MessageBox.Show($"Documents converted successfully to {extension.ToUpper()}!", "Conversion Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                progressBar_Time.Invoke((Action)(() => progressBar_Time.Value = 0));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error converting document: {ex.Message}", "Conversion Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}