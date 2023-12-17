using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using SharpCompress.Archives;
using SharpCompress.Archives.Rar;
using SharpCompress.Common;
using SharpCompress.Writers;
using System.Security.Cryptography;
using System.Text;

namespace Project__Filter
{
    public partial class Main : Form
    {
        Dictionary<string, object> data;

        public Main()
        {
            InitializeComponent();
            // Index
            Panel_Index.Height = button_Home.Height;
            Panel_Index.Top = button_Home.Top;
            home1.BringToFront();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_Git_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://github.com/Dev-Alan-Isaac",
                UseShellExecute = true
            });
        }

        private void button_Home_Click(object sender, EventArgs e)
        {
            Panel_Index.Height = button_Home.Height;
            Panel_Index.Top = button_Home.Top;
            home1.BringToFront();
        }

        private void button_Filter_Click_1(object sender, EventArgs e)
        {
            Panel_Index.Height = button_Filter.Height;
            Panel_Index.Top = button_Filter.Top;
            filter1.BringToFront();
        }

        private void button_Convert_Click(object sender, EventArgs e)
        {
            Panel_Index.Height = button_Convert.Height;
            Panel_Index.Top = button_Convert.Top;
            convert1.BringToFront();
        }

        private void button_Extract_Click(object sender, EventArgs e)
        {
            Panel_Index.Height = button_Extract.Height;
            Panel_Index.Top = button_Extract.Top;
            extract1.BringToFront();
        }

        private void button_Merge_Click(object sender, EventArgs e)
        {
            Panel_Index.Height = button_Merge.Height;
            Panel_Index.Top = button_Merge.Top;
            merge1.BringToFront();
        }

        private void button_Privacy_Click(object sender, EventArgs e)
        {
            Panel_Index.Height = button_Privacy.Height;
            Panel_Index.Top = button_Privacy.Top;
            privacy1.BringToFront();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            string filePath = "Config.json";

            if (!File.Exists(filePath))
            {
                // Create a dictionary to hold the data
                data = new Dictionary<string, object>();

                // Add a section for video extensions
                List<string> videoExtensions = new List<string> { ".mp4", ".avi", ".mkv" };
                data.Add("VideoExtensions", videoExtensions);

                // Add a section for file size in bytes
                List<int> fileSizes = new List<int> { 1024, 2048, 4096 }; // replace with actual file sizes
                data.Add("FileSize", fileSizes);

                // Add a section for duration in seconds
                List<int> durations = new List<int> { 5400, 7200, 9000 }; // replace with actual durations
                data.Add("Duration", durations);

                // Add a section for resolution
                List<string> resolutions = new List<string> { "1920x1080", "1280x720", "640x480" };
                data.Add("Resolution", resolutions);

                // Convert the dictionary to a JSON string
                string json = JsonConvert.SerializeObject(data, Formatting.Indented);

                // Save the JSON string to a file
                File.WriteAllText(filePath, json);
            }
            else
            {
                // Read the JSON file
                string json = File.ReadAllText(filePath);

                // Deserialize the JSON string to a dictionary
                data = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            }
        }

        private void button_Config_Click(object sender, EventArgs e)
        {
            config1.BringToFront();
        }
    }
}

public class Actions
{
    // Filter
    public List<CheckBox> GetCheckedCheckBoxes(UserControl userControl)
    {
        List<CheckBox> checkedCheckBoxes = new List<CheckBox>();

        foreach (Control control in userControl.Controls)
        {
            if (control is CheckBox)
            {
                CheckBox? checkBox = control as CheckBox;
                if (checkBox.Checked)
                {
                    checkedCheckBoxes.Add(checkBox);
                }
            }
        }

        return checkedCheckBoxes; // Return the list of checked checkboxes
    }

    public void FilterVideoFilesBasedOnCriteria(string folderPath, Dictionary<string, object> data, string Include)
    {
        // Get the video extensions from the dictionary
        var videoExtensions = ((JArray)data["VideoExtensions"]).ToObject<string[]>();

        // Get all the files in the folder and its subfolders
        var files = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories);

        // Filter the files based on the video extensions
        var filteredFiles = files.Where(file => videoExtensions.Contains(Path.GetExtension(file))).ToList();

        // If there are any filtered files, create the "Filter/Videos" directory and move the files there
        if (filteredFiles.Any())
        {
            var videoDirectory = Path.Combine(folderPath, "Filter", "Videos");
            Directory.CreateDirectory(videoDirectory);

            foreach (var file in filteredFiles)
            {
                var destinationPath = Path.Combine(videoDirectory, Path.GetFileName(file));
                File.Move(file, destinationPath);
            }
        }

        // Get the remaining files
        var otherFiles = files.Except(filteredFiles);

        // If there are any other files, create the "Filter/Files" directory and move the files there
        if (otherFiles.Any())
        {
            var filesDirectory = Path.Combine(folderPath, "Filter", "Files");
            Directory.CreateDirectory(filesDirectory);

            foreach (var file in otherFiles)
            {
                var destinationPath = Path.Combine(filesDirectory, Path.GetFileName(file));
                File.Move(file, destinationPath);
            }
        }

        // Create the "Filter/Include" directory
        var includedDirectory = Path.Combine(folderPath, "Filter", Include);
        Directory.CreateDirectory(includedDirectory);

        // Get all the files in the "Filter/Videos" and "Filter/Files" directories
        var filterFiles = Directory.GetFiles(Path.Combine(folderPath, "Filter"), "*.*", SearchOption.AllDirectories);

        // Filter the files based on the Include string
        var includeFiles = filterFiles.Where(file => Path.GetFileName(file).Contains(Include));

        // Move the include files to the "Filter/Include" directory
        foreach (var file in includeFiles)
        {
            var destinationPath = Path.Combine(includedDirectory, Path.GetFileName(file));
            File.Move(file, destinationPath);
        }
    }

    //public List<string> HandleExclude(string folderPath, string exclude)
    //{
    //    // Create the "filtered" directory if it doesn't exist
    //    string filteredPath = Path.Combine(folderPath, "Filtered");
    //    if (!Directory.Exists(filteredPath))
    //    {
    //        Directory.CreateDirectory(filteredPath);
    //    }

    //    // Create the "exclude" directory inside the "filtered" directory
    //    string excludePath = Path.Combine(filteredPath, "Excludes");
    //    if (!Directory.Exists(excludePath))
    //    {
    //        Directory.CreateDirectory(excludePath);
    //    }

    //    // Get all files in the folder and its subfolders
    //    List<string> allFiles = GetAllFiles(folderPath);

    //    // Filter the files based on the exclude string
    //    List<string> excludedFiles = allFiles.Where(file => Path.GetFileNameWithoutExtension(file).IndexOf(exclude, StringComparison.OrdinalIgnoreCase) < 0).ToList();

    //    // List to store the destination paths of the moved files
    //    List<string> destinationPaths = new List<string>();

    //    // Move the excluded files to the "exclude" directory
    //    foreach (string file in excludedFiles)
    //    {
    //        string destinationPath = Path.Combine(excludePath, Path.GetFileName(file));
    //        File.Move(file, destinationPath, true);

    //        // Add the destination path to the list
    //        destinationPaths.Add(destinationPath);
    //    }

    //    // Return the list of destination paths
    //    return destinationPaths;
    //}

    public void HandleExtension(string folderPath)
    {
        // Get all files in the directory and its subdirectories
        List<string> allFiles = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories).ToList();

        // Move the files to directories based on their extensions
        foreach (string file in allFiles)
        {
            string extension = Path.GetExtension(file).TrimStart('.').ToLower();
            string fileDirectory = Path.GetDirectoryName(file);
            string extensionPath = Path.Combine(fileDirectory, extension);

            if (!Directory.Exists(extensionPath))
            {
                Directory.CreateDirectory(extensionPath);
            }

            string destinationPath = Path.Combine(extensionPath, Path.GetFileName(file));
            File.Move(file, destinationPath, true);
        }
    }

    public void HandleResolution(string folderPath)
    {

    }

    public void HandleDuration(string folderPath)
    {

    }

    public void HandleSize(string folderPath)
    {
        // Read the JSON file
        string json = File.ReadAllText("Config.json");

        // Deserialize the JSON string to a dictionary
        Dictionary<string, object> data = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);

        // Get the list of file sizes from the dictionary
        List<int> fileSizes = ((JArray)data["FileSize"]).ToObject<List<int>>();
        fileSizes.Sort();

        // Get all files in the directory and its subdirectories
        string[] files = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories);

        foreach (string file in files)
        {
            // Get the size of the file
            FileInfo fileInfo = new FileInfo(file);
            long size = fileInfo.Length;

            // Find the appropriate folder for this file size
            int folderSize = fileSizes.FirstOrDefault(s => size <= s);
            if (folderSize == 0)
            {
                // If the file is larger than all specified sizes, put it in a separate folder
                folderSize = fileSizes.Max() + 1;
            }

            // Convert the folder size to gigabytes
            double folderSizeInGb = folderSize / 1024.0;

            // Create the size folder if it doesn't exist
            string sizeFolder = Path.Combine(folderPath, $"{folderSizeInGb} GB");
            if (!Directory.Exists(sizeFolder))
            {
                Directory.CreateDirectory(sizeFolder);
            }

            // Move the file into the size folder
            string fileName = Path.GetFileName(file);
            File.Move(file, Path.Combine(sizeFolder, fileName));
        }
    }

    public void HandleDate(string folderPath)
    {
        // Get all files in the directory and its subdirectories
        string[] files = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories);

        foreach (string file in files)
        {
            // Get the date of the file
            DateTime lastWriteTime = File.GetLastWriteTime(file);
            string dateFolder = Path.Combine(folderPath, lastWriteTime.ToString("yyyy-MM-dd"));

            // Create the date folder if it doesn't exist
            if (!Directory.Exists(dateFolder))
            {
                Directory.CreateDirectory(dateFolder);
            }

            // Move the file into the date folder
            string fileName = Path.GetFileName(file);
            File.Move(file, Path.Combine(dateFolder, fileName));
        }
    }

    public void HandleAToZ(string folderPath)
    {
        // Get all files in the directory and its subdirectories
        var files = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories);

        foreach (var file in files)
        {
            // Get the first letter of the file name
            var firstLetter = Path.GetFileName(file)[0];

            // Create a new directory path based on the first letter
            var newDirPath = Path.Combine(folderPath, firstLetter.ToString());

            // Create the directory if it doesn't exist
            Directory.CreateDirectory(newDirPath);

            // Create a new file path in the new directory
            var newFilePath = Path.Combine(newDirPath, Path.GetFileName(file));

            // Move the file to the new directory
            File.Move(file, newFilePath);
        }
    }

    // Univresal
    public string? OpenFolderManager()
    {
        FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
        if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
        {
            return folderBrowserDialog.SelectedPath;
        }
        else
        {
            return null;
        }
    }

    public void CreateConfigFile()
    {

    }

    // Extract
    public List<RadioButton> GetCheckedRadioButtons(UserControl userControl)
    {
        List<RadioButton> checkedRadioButtons = new List<RadioButton>();

        foreach (Control control in userControl.Controls)
        {
            if (control is RadioButton)
            {
                RadioButton? radioButton = control as RadioButton;
                if (radioButton.Checked)
                {
                    checkedRadioButtons.Add(radioButton);
                }
            }
        }

        return checkedRadioButtons; // Return the list of checked radio buttons
    }

    public void HandleFolder(string folderPath)
    {
        // Create the 'Extracted' directory
        string extractedFolderPath = Path.Combine(folderPath, "Extracted");
        Directory.CreateDirectory(extractedFolderPath);

        // Get all files in the specified directory and its subdirectories
        string[] files = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories);

        // Move each file to the 'Extracted' directory
        foreach (string file in files)
        {
            // Get the file name
            string fileName = Path.GetFileName(file);

            // Create the destination path
            string destPath = Path.Combine(extractedFolderPath, fileName);

            // Ensure that the destination file name is unique
            int count = 1;
            string fileNameOnly = Path.GetFileNameWithoutExtension(destPath);
            string extension = Path.GetExtension(destPath);
            while (File.Exists(destPath))
            {
                string tempFileName = string.Format("{0}({1})", fileNameOnly, count++);
                destPath = Path.Combine(extractedFolderPath, tempFileName + extension);
            }

            // Move the file
            File.Move(file, destPath);
        }
    }

    public void HandleZip(string folderPath)
    {
        // Get the name of the folder
        string folderName = new DirectoryInfo(folderPath).Name;

        // Define the path of the zip file
        string zipFilePath = Path.Combine(Directory.GetParent(folderPath).FullName, $"{folderName}.zip");

        // Create the zip file from the directory
        using (var archive = SharpCompress.Archives.Zip.ZipArchive.Create())
        {
            archive.AddAllFromDirectory(folderPath);
            archive.SaveTo(zipFilePath, SharpCompress.Common.CompressionType.Deflate);
        }
    }

    public void HandleTar(string folderPath)
    {
        // Get the name of the folder
        string folderName = new DirectoryInfo(folderPath).Name;

        // Define the path of the tar file
        string tarFilePath = Path.Combine(Directory.GetParent(folderPath).FullName, $"{folderName}.tar");

        // Create the tar file from the directory
        using (var stream = File.OpenWrite(tarFilePath))
        {
            using (var writer = WriterFactory.Open(stream, ArchiveType.Tar, CompressionType.None))
            {
                writer.WriteAll(folderPath, "*", SearchOption.AllDirectories);
            }
        }
    }

    public void HandleUnRar(string rarFilePath)
    {
        // Get the directory of the rar file
        string directoryPath = Path.GetDirectoryName(rarFilePath);

        // Get the name of the rar file without the extension
        string folderName = Path.GetFileNameWithoutExtension(rarFilePath);

        // Define the path of the folder to unrar to
        string folderPath = Path.Combine(directoryPath, folderName);

        // Create the directory if it doesn't exist
        Directory.CreateDirectory(folderPath);

        // Unrar the rar file to the directory
        using (var archive = RarArchive.Open(rarFilePath))
        {
            foreach (var entry in archive.Entries.Where(entry => !entry.IsDirectory))
            {
                entry.WriteToDirectory(folderPath, new ExtractionOptions()
                {
                    ExtractFullPath = true,
                    Overwrite = true
                });
            }
        }
    }

    public void HandleUnZip(string zipFilePath)
    {
        // Get the directory of the zip file
        string directoryPath = Path.GetDirectoryName(zipFilePath);

        // Get the name of the zip file without the extension
        string folderName = Path.GetFileNameWithoutExtension(zipFilePath);

        // Define the path of the folder to unzip to
        string folderPath = Path.Combine(directoryPath, folderName);

        // Create the directory if it doesn't exist
        Directory.CreateDirectory(folderPath);

        // Unzip the zip file to the directory
        using (var archive = SharpCompress.Archives.Zip.ZipArchive.Open(zipFilePath))
        {
            foreach (var entry in archive.Entries.Where(entry => !entry.IsDirectory))
            {
                entry.WriteToDirectory(folderPath, new SharpCompress.Common.ExtractionOptions()
                {
                    ExtractFullPath = true,
                    Overwrite = true
                });
            }
        }
    }

    public void HandleUnTar(string tarFilePath)
    {
        // Get the directory of the tar file
        string directoryPath = Path.GetDirectoryName(tarFilePath);

        // Get the name of the tar file without the extension
        string folderName = Path.GetFileNameWithoutExtension(tarFilePath);

        // Define the path of the folder to untar to
        string folderPath = Path.Combine(directoryPath, folderName);

        // Create the directory if it doesn't exist
        Directory.CreateDirectory(folderPath);

        // Untar the tar file to the directory
        using (var archive = ArchiveFactory.Open(tarFilePath))
        {
            foreach (var entry in archive.Entries.Where(entry => !entry.IsDirectory))
            {
                entry.WriteToDirectory(folderPath, new ExtractionOptions()
                {
                    ExtractFullPath = true,
                    Overwrite = true
                });
            }
        }
    }

    // Merge
    public void MergePDFs(List<string> filePaths)
    {
        // Sort the file names
        var sortedFileNames = filePaths.OrderBy(name => name);

        // Save the document in the same directory as the selected files...
        string filename = Path.Combine(Path.GetDirectoryName(sortedFileNames.First()), "Simple Merged.pdf");

        // Check if a file with the same name already exists and change the name accordingly
        int count = 2;
        while (File.Exists(filename))
        {
            filename = Path.Combine(Path.GetDirectoryName(sortedFileNames.First()), $"Simple Merged ({count}).pdf");
            count++;
        }

        // Initialize a new PDF document
        PdfDocument outputDocument = new PdfDocument();

        // Iterate through the selected files
        foreach (string pdfFile in sortedFileNames)
        {
            // Open the document to import pages from it.
            PdfDocument inputDocument = PdfReader.Open(pdfFile, PdfDocumentOpenMode.Import);

            // Add each page to the output document
            for (int page = 0; page < inputDocument.PageCount; page++)
            {
                outputDocument.AddPage(inputDocument.Pages[page]);
            }

            // Update your progress bar here
            Console.WriteLine($"Merged {pdfFile}");
        }

        // Save and close the output document
        outputDocument.Save(filename);
        outputDocument.Close();

        Console.WriteLine($"Done! Successfully merged {sortedFileNames.Count()} PDF files into {filename}.");
    }

    public void MergePDFsWithIndex(List<string> filePaths)
    {
        // Sort the file names
        var sortedFileNames = filePaths.OrderBy(name => name);

        // Save the document in the same directory as the selected files...
        string filename = Path.Combine(Path.GetDirectoryName(sortedFileNames.First()), "Title Merged.pdf");

        // Check if a file with the same name already exists and change the name accordingly
        int count = 2;
        while (File.Exists(filename))
        {
            filename = Path.Combine(Path.GetDirectoryName(sortedFileNames.First()), $"Title Merged ({count}).pdf");
            count++;
        }

        // Initialize a new PDF document
        PdfDocument outputDocument = new PdfDocument();

        // Iterate through the selected files
        foreach (string pdfFile in sortedFileNames)
        {
            // Add a new page with the file name
            PdfPage fileNamePage = outputDocument.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(fileNamePage);
            XFont font = new XFont("Verdana Bold", 20);
            gfx.DrawString(Path.GetFileNameWithoutExtension(pdfFile), font, XBrushes.Black, new XRect(0, 0, fileNamePage.Width, fileNamePage.Height), XStringFormats.Center);

            // Open the document to import pages from it.
            PdfDocument inputDocument = PdfReader.Open(pdfFile, PdfDocumentOpenMode.Import);

            // Iterate through the pages
            int pageCount = inputDocument.PageCount;
            for (int idx = 0; idx < pageCount; idx++)
            {
                PdfPage page = inputDocument.Pages[idx];
                outputDocument.AddPage(page);
            }

            // Update your progress bar here
            Console.WriteLine($"Merged {pdfFile}");
        }

        // Save and close the PDF document
        outputDocument.Save(filename);

        Console.WriteLine($"Done! Successfully merged {sortedFileNames.Count()} PDF files into {filename}.");
    }

    // Encrypt
    public void HandleEncrypt(string encryptFilePath)
    {
        string password = Microsoft.VisualBasic.Interaction.InputBox("Enter your password:", "Password Entry", "", -1, -1);

        // Get all files in the folder and subfolders
        string[] files = Directory.GetFiles(encryptFilePath, "*.*", SearchOption.AllDirectories);

        foreach (string file in files)
        {
            byte[] bytesToBeEncrypted = File.ReadAllBytes(file);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);

            string fileEncrypted = $"{file}.aes";

            File.WriteAllBytes(fileEncrypted, bytesEncrypted);

            // Delete the original file
            File.Delete(file);
        }
    }

    public static byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
    {
        byte[] encryptedBytes = null;

        // Create salt bytes
        byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

        using (MemoryStream ms = new MemoryStream())
        {
            using AesCryptoServiceProvider AES = new AesCryptoServiceProvider();
            AES.KeySize = 256;
            AES.BlockSize = 128;

            var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);

            AES.Mode = CipherMode.CBC;

            using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
            {
                cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                cs.Close();
            }
            encryptedBytes = ms.ToArray();
        }
        return encryptedBytes;
    }

    public void HandleDecrypt(string decryptFilePath)
    {
        string password = Microsoft.VisualBasic.Interaction.InputBox("Enter your password:", "Password Entry", "", -1, -1);

        // Get all files in the folder and subfolders
        string[] files = Directory.GetFiles(decryptFilePath, "*.*", SearchOption.AllDirectories);

        bool errorShown = false; // Add this line

        foreach (string file in files)
        {
            byte[] bytesToBeDecrypted = File.ReadAllBytes(file);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            try
            {
                byte[] bytesDecrypted = AES_Decrypt(bytesToBeDecrypted, passwordBytes);

                // Delete the original encrypted file
                File.Delete(file);

                // Get the directory of the original file
                string directoryPath = Path.GetDirectoryName(file);

                // Get the original file name without the extension
                string fileName = Path.GetFileNameWithoutExtension(file);

                // Combine the directory path and file name
                string fileDecrypted = Path.Combine(directoryPath, fileName);

                File.WriteAllBytes(fileDecrypted, bytesDecrypted);
            }
            catch (System.Security.Cryptography.CryptographicException)
            {
                if (!errorShown)
                {
                    MessageBox.Show("The password you entered is incorrect. Please try again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    errorShown = true;
                }
            }
        }
    }

    public static byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
    {
        byte[] decryptedBytes = null;

        // Set your salt here, change it to meet your flavor:
        // The salt bytes must be at least 8 bytes.
        byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

        using (MemoryStream ms = new MemoryStream())
        {
            using var AES = new AesCryptoServiceProvider();
            AES.KeySize = 256;
            AES.BlockSize = 128;

            var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);

            AES.Mode = CipherMode.CBC;

            using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
            {
                try
                {
                    cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                    cs.Close();
                }
                catch (System.Security.Cryptography.CryptographicException)
                {
                    MessageBox.Show("The password you entered is incorrect. Please try again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            decryptedBytes = ms.ToArray();
        }
        return decryptedBytes;
    }

}
