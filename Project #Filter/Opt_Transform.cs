using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Speech.Synthesis;
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
            string title = string.Empty;
            string selectedItem = comboBox_Select.SelectedItem.ToString();
            switch (selectedItem)
            {
                case "IMAGE To PDF [TITLE]":
                    title = askTitle(selectedPath);
                    askContent(selectedPath);
                    break;
                case "IMAGE To PDF [NO TITLE]":
                    title = "Untitled";

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
                Title = Path.GetFileName(selectedPath);
                return Title;
            }
        }

        private void askContent(string selectedPath)
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

                switch (selectedItem)
                {
                    case "Sort by name":
                        sortByName();
                        break;
                    case "Sort by date":
                        sortByDate();
                        break;
                    case "Sort by size":
                        sortBySize();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("N");
            }
        }

        private void sortByName()
        {
            MessageBox.Show("Name");

        }

        private void sortBySize()
        {
            MessageBox.Show("size");

        }

        private void sortByDate()
        {
            MessageBox.Show("Date");

        }

        private async Task<byte[]> PDFBuilder(string rootpath)
        {
            return null;
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