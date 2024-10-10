using System.Text;
using HtmlAgilityPack;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Newtonsoft.Json.Linq;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace Project__Filter
{
    public partial class Opt_Merge : UserControl
    {
        private string Path;

        public Opt_Merge()
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
            // Enable the filter button when any radio button is checked
            if (radioButton_Text.Checked || radioButton_Word.Checked ||
                radioButton_PDF.Checked || radioButton_HTML.Checked)
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

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Get the selected node
            TreeNode selectedNode = e.Node;

            // Alternatively, update a label control with the selected node's name
            label_SelectedNode.Text = $"{selectedNode.Text}";
        }

        private async void Populated_Treeview()
        {
            string[] allowedExtensions = Array.Empty<string>(); // Initialize with an empty array

            // Determine allowed extensions based on the selected radio button
            if (radioButton_Text.Checked)
            {
                allowedExtensions = new[] { "txt" };
            }
            else if (radioButton_Word.Checked)
            {
                allowedExtensions = new[] { "doc", "docx" };
            }
            else if (radioButton_PDF.Checked)
            {
                allowedExtensions = new[] { "pdf" };
            }
            else if (radioButton_HTML.Checked)
            {
                allowedExtensions = new[] { "htm", "html" };
            }

            // Ensure that the Path is not empty
            if (!string.IsNullOrEmpty(Path))
            {
                // Fetch all files in the folder and subfolders
                string[] files = Directory.GetFiles(Path, "*.*", SearchOption.AllDirectories);

                // Filter files based on the selected extensions
                var filteredFiles = files
                    .Where(file => allowedExtensions
                        .Any(ext => file.EndsWith($".{ext}", StringComparison.OrdinalIgnoreCase))) // Match extensions
                    .Distinct() // Ensure unique files
                    .ToList();

                // Clear the TreeView before repopulating
                treeView1.Nodes.Clear();

                // Populate TreeView with filtered files
                foreach (var file in filteredFiles)
                {
                    string fileName = System.IO.Path.GetFileName(file);

                    // Add the file to the TreeView
                    TreeNode fileNode = new TreeNode(fileName);
                    treeView1.Nodes.Add(fileNode);
                }
            }
            else
            {
                MessageBox.Show("No path selected.");
            }
        }

        private async void button_Filter_Click(object sender, EventArgs e)
        {

            if (radioButton_Text.Checked)
            {
                await Task.Run(() => Text_Merge());
            }
            else if (radioButton_Word.Checked)
            {
                await Task.Run(() => Word_Merge());
            }
            else if (radioButton_PDF.Checked)
            {
                await Task.Run(() => PDF_Merge());
            }
            else if (radioButton_HTML.Checked)
            {
                await Task.Run(() => Html_Merge());
            }
        }

        private async void Text_Merge()
        {

        }

        private async void Word_Merge()
        {

        }

        private async void PDF_Merge()
        {

        }

        private async void Html_Merge()
        {

        }

        //private void Text_Files(List<string> filePaths)
        //{
        //    Task.Run(() =>
        //    {
        //        // Change the output file name to "Merge"
        //        using (StreamWriter fileDest = new StreamWriter(Path.Combine(selectedPath, "Merge.txt"), true))
        //        {
        //            int totalFiles = filePaths.Count;
        //            int processedFiles = 0;

        //            foreach (string filePath in filePaths)
        //            {
        //                using (StreamReader fileSrc = new StreamReader(filePath))
        //                {
        //                    string line;
        //                    while ((line = fileSrc.ReadLine()) != null)
        //                    {
        //                        fileDest.WriteLine(line);
        //                    }
        //                }

        //                // Calculate the progress percentage
        //                processedFiles++;
        //                int progressPercentage = (int)((double)processedFiles / totalFiles * 100);

        //                // Report the progress
        //                Invoke((MethodInvoker)delegate
        //                {
        //                    // Running on the UI thread
        //                    progressBar_Time.Value = progressPercentage;
        //                });
        //            }
        //        }

        //        // Reset the progress bar to 0 when done
        //        Invoke((MethodInvoker)delegate
        //        {
        //            // Running on the UI thread
        //            progressBar_Time.Value = 0;
        //        });
        //    });
        //}

        //private void Pdf_Files(List<string> filePaths)
        //{
        //    Task.Run(() =>
        //    {
        //        // Create the output file path
        //        string outputFilePath = Path.Combine(selectedPath, "Merge.pdf");

        //        // Create a new PDF document
        //        Document document = new Document();
        //        PdfCopy copy = new PdfCopy(document, new FileStream(outputFilePath, FileMode.Create));

        //        // Open the document for writing
        //        document.Open();

        //        int totalFiles = filePaths.Count;
        //        int processedFiles = 0;

        //        foreach (string filePath in filePaths)
        //        {
        //            // Create a new PdfReader for the current document
        //            PdfReader reader = new PdfReader(filePath);

        //            // Add each page from the reader to the PdfCopy
        //            for (int i = 1; i <= reader.NumberOfPages; i++)
        //            {
        //                copy.AddPage(copy.GetImportedPage(reader, i));
        //            }

        //            // Close the reader
        //            reader.Close();

        //            // Calculate the progress percentage
        //            processedFiles++;
        //            int progressPercentage = (int)((double)processedFiles / totalFiles * 100);

        //            // Report the progress
        //            Invoke((MethodInvoker)delegate
        //            {
        //                // Running on the UI thread
        //                progressBar_Time.Value = progressPercentage;
        //            });
        //        }

        //        // Close the document
        //        document.Close();

        //        // Reset the progress bar to 0 when done
        //        Invoke((MethodInvoker)delegate
        //        {
        //            // Running on the UI thread
        //            progressBar_Time.Value = 0;
        //        });
        //    });
        //}

        //public void Html_Files(List<string> filePaths)
        //{
        //    Task.Run(() =>
        //    {
        //        HtmlDocument doc = new HtmlDocument();
        //        HtmlNode bodyNode = doc.CreateElement("body");

        //        int totalFiles = filePaths.Count;
        //        int processedFiles = 0;

        //        foreach (string filePath in filePaths)
        //        {
        //            HtmlDocument fileDoc = new HtmlDocument();
        //            fileDoc.Load(filePath);
        //            HtmlNode fileBody = fileDoc.DocumentNode.SelectSingleNode("//body");
        //            if (fileBody != null)
        //            {
        //                foreach (HtmlNode child in fileBody.ChildNodes)
        //                {
        //                    bodyNode.AppendChild(child.CloneNode(true));
        //                }
        //            }

        //            // Dispose of the HtmlDocument manually
        //            fileDoc = null;

        //            // Calculate the progress percentage
        //            processedFiles++;
        //            int progressPercentage = (int)((double)processedFiles / totalFiles * 100);

        //            // Report the progress
        //            Invoke((MethodInvoker)delegate
        //            {
        //                // Running on the UI thread
        //                progressBar_Time.Value = progressPercentage;
        //            });

        //            // Force a garbage collection to free up memory
        //            GC.Collect();
        //            GC.WaitForPendingFinalizers();
        //        }

        //        doc.DocumentNode.AppendChild(bodyNode);
        //        string outputFilePath = Path.Combine(Path.GetDirectoryName(filePaths[0]), "Merged.html");
        //        File.WriteAllText(outputFilePath, doc.DocumentNode.OuterHtml, Encoding.UTF8);

        //        // Reset the progress bar to 0 when done
        //        Invoke((MethodInvoker)delegate
        //        {
        //            // Running on the UI thread
        //            progressBar_Time.Value = 0;
        //        });
        //    });
        //}

        //public void Docs_Files(List<string> filePaths)
        //{
        //    Task.Run(() =>
        //    {
        //        // Create a blank document
        //        Aspose.Words.Document mainDoc = new Aspose.Words.Document();

        //        int totalFiles = filePaths.Count;
        //        int processedFiles = 0;

        //        foreach (string filePath in filePaths)
        //        {
        //            // Load the document from file
        //            Aspose.Words.Document subDoc = new Aspose.Words.Document(filePath);

        //            // Append the document to the main document
        //            mainDoc.AppendDocument(subDoc, Aspose.Words.ImportFormatMode.KeepSourceFormatting);

        //            // Calculate the progress percentage
        //            processedFiles++;
        //            int progressPercentage = (int)((double)processedFiles / totalFiles * 100);

        //            // Report the progress
        //            Invoke((MethodInvoker)delegate
        //            {
        //                // Running on the UI thread
        //                progressBar_Time.Value = progressPercentage;
        //            });
        //        }

        //        // Save the merged document
        //        mainDoc.Save(Path.Combine(selectedPath, "Merge.docx"));

        //        // Reset the progress bar to 0 when done
        //        Invoke((MethodInvoker)delegate
        //        {
        //            // Running on the UI thread
        //            progressBar_Time.Value = 0;
        //        });
        //    });
        //}
    }
}
