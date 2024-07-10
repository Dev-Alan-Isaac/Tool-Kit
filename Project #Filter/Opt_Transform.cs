using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using Aspose.Cells.Charts;
using ImageMagick;
using iTextSharp.text;
using iTextSharp.text.pdf;
using NAudio.Wave;
using Rectangle = iTextSharp.text.Rectangle;

namespace Project__Filter
{
    public partial class Opt_Transform : UserControl
    {
        private string selectedPath = string.Empty;

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
            string selectedItem = comboBox_Select.SelectedItem.ToString();
            switch (selectedItem)
            {
                case "IMAGE To PDF[TITLE]":
                    askTitle(selectedPath);
                    break;
                case "IMAGE To PDF[NO TITLE]":

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
        }

        private void askTitle(string selectedPath)
        {
            DialogResult result = MessageBox.Show("Do you want a custom title?", "Title Prompt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Y");
            }
            else
            {
                MessageBox.Show("N");
            }
        }

        private void askContent()
        {
            DialogResult result = MessageBox.Show("Do you want a custom content?", "Title", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Y");
            }
            else
            {
                MessageBox.Show("N");
            }
        }

        private void sortByName()
        {

        }

        private void sortBySize()
        {

        }

        private void sortByDate()
        {

        }

        //private async Task<byte[]> PDFBuilder(string rootpath)
        //{
        //    // Create a new PDF document
        //    Document document = new Document();
        //    using (MemoryStream stream = new MemoryStream())
        //    {
        //        // Create a new PdfWriter object, pointing it to our MemoryStream
        //        PdfWriter writer = PdfWriter.GetInstance(document, stream);

        //        // Open the Document for writing
        //        document.Open();

        //        // Iterate through the list of selected file paths
        //        foreach (string filePath in selectedFilePaths)
        //        {
        //            // Add the image to the document
        //            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(filePath);
        //            document.SetPageSize(new Rectangle(0, 0, image.Width, image.Height));
        //            document.NewPage();
        //            image.SetAbsolutePosition(0, 0);
        //            document.Add(image);
        //        }

        //        // Close the Document - this saves it to the MemoryStream
        //        document.Close();

        //        // Convert the MemoryStream to an array and return it
        //        return stream.ToArray();
        //    }
        //}

    }
}