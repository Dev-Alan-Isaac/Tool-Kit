using Newtonsoft.Json;

namespace Project__Filter
{
    public partial class Form1 : Form
    {
        public string pathDir = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string path = "Path.json";

            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                var data = JsonConvert.DeserializeObject<dynamic>(json);
                pathDir = data.Directory;
            }
            else
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedDirectory = folderBrowserDialog.SelectedPath;
                    // Create a new JSON file in the project directory
                    var data = new { Directory = selectedDirectory };
                    string json = JsonConvert.SerializeObject(data, Formatting.Indented);
                    File.WriteAllText(path, json);
                }
            }
        }

        private void nameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedDirectory = folderBrowserDialog.SelectedPath;
                string filterDirectory = Path.Combine(selectedDirectory, "filter");
                Directory.CreateDirectory(filterDirectory);

                var files = Directory.GetFiles(selectedDirectory);
                foreach (var file in files)
                {
                    string fileName = Path.GetFileName(file);
                    char firstLetter = char.ToUpper(fileName[0]);
                    string subDirectory = Path.Combine(filterDirectory, firstLetter.ToString());
                    Directory.CreateDirectory(subDirectory);

                    string destinationPath = Path.Combine(subDirectory, fileName);
                    File.Move(file, destinationPath);
                }
                MessageBox.Show("\nDone");
            }
        }

        private void filterToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_view_sort_ascending_256;
        }

        private void typeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedDirectory = folderBrowserDialog.SelectedPath;
                string filterDirectory = Path.Combine(selectedDirectory, "filter");
                Directory.CreateDirectory(filterDirectory);

                var files = Directory.GetFiles(selectedDirectory);
                foreach (var file in files)
                {
                    string extension = Path.GetExtension(file).TrimStart('.').ToLower();
                    string destinationDirectory = Path.Combine(filterDirectory, extension);
                    Directory.CreateDirectory(destinationDirectory);

                    string fileName = Path.GetFileName(file);
                    string destinationPath = Path.Combine(destinationDirectory, fileName);
                    File.Move(file, destinationPath);
                }
                MessageBox.Show("\nDone");
            }
        }

        private void sizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedDirectory = folderBrowserDialog.SelectedPath;
                string filterDirectory = Path.Combine(selectedDirectory, "filter");
                Directory.CreateDirectory(filterDirectory);

                var files = Directory.GetFiles(selectedDirectory);
                foreach (var file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    long sizeInMB = fileInfo.Length / (1024 * 1024);

                    string sizeFolder;
                    if (sizeInMB > 1000)
                        sizeFolder = "More than 1GB";
                    else if (sizeInMB > 500)
                        sizeFolder = "500MB to 1GB";
                    else if (sizeInMB > 250)
                        sizeFolder = "250MB to 500MB";
                    else
                        sizeFolder = "Less than 250MB";

                    string destinationDirectory = Path.Combine(filterDirectory, sizeFolder);
                    Directory.CreateDirectory(destinationDirectory);

                    string fileName = Path.GetFileName(file);
                    string destinationPath = Path.Combine(destinationDirectory, fileName);
                    File.Move(file, destinationPath);
                }
            }
        }
    }
}