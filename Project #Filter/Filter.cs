﻿using System.Text;
using Newtonsoft.Json;
using SharpCompress;

namespace Project__Filter
{
    public partial class Filter : UserControl
    {
        string selectedPath;
        Dictionary<string, List<string>> myDict;
        List<CheckBox> checkedBoxesInOrder = new List<CheckBox>();

        public Filter()
        {
            InitializeComponent();
        }

        private void Filter_Load(object sender, EventArgs e)
        {
            if (File.Exists("Folders.json"))
            {
                string json = File.ReadAllText("Folders.json");
                myDict = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(json);
            }
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

                    checkBox_Size.Enabled = true;
                    checkBox_Resolution.Enabled = true;
                    checkBox_AtoZ.Enabled = true;
                    checkBox_Duration.Enabled = true;
                    checkBox_Include.Enabled = true;
                    button_Filter.Enabled = true;
                }
            }
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox.Checked)
            {
                checkedBoxesInOrder.Add(checkBox);
            }
            else
            {
                checkedBoxesInOrder.Remove(checkBox);
            }
        }

        private void button_Filter_Click(object sender, EventArgs e)
        {
            List<string> checkedBoxesNames = new List<string>();

            // Now checkedBoxesInOrder contains the CheckBoxes in the order they were checked
            foreach (CheckBox checkBox in checkedBoxesInOrder)
            {
                checkedBoxesNames.Add(checkBox.Name);
            }

            FirstSort();

            foreach (string checkBoxName in checkedBoxesNames)
            {
                switch (checkBoxName)
                {
                    case "checkBox_Resolution":
                        break;
                    case "checkBox_Duration":
                        break;
                    case "checkBox_Include":
                        break;
                    case "checkBox_Size":
                        break;
                    case "checkBox_AtoZ":
                        break;
                    default:
                        // Optional: Perform a default action
                        break;
                }
            }
            if (checkBox_Delete.Checked)
            {

            }
        }

        // Functions
        private void FirstSort()
        {
            string[] files = Directory.GetFiles(selectedPath, "*.*", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                string extension = Path.GetExtension(file).TrimStart('.').ToLower();
                string destinationDirectory;

                if (myDict.Any(kvp => kvp.Value.Contains(extension)))
                {
                    string key = myDict.First(kvp => kvp.Value.Contains(extension)).Key;
                    destinationDirectory = Path.Combine(selectedPath, key);
                }
                else
                {
                    destinationDirectory = Path.Combine(selectedPath, "Other");
                }

                Directory.CreateDirectory(destinationDirectory);
                File.Move(file, Path.Combine(destinationDirectory, Path.GetFileName(file)));
            }
        }

        private void Resolution()
        {

        }

        private void sortresolution(string path)
        {
            // create a new instance of the ffprobe class
            var ffprobe = new nreco.videoinfo.ffprobe();

            // get the path of the "videos" directory
            string videospath = path.combine(path, "videos");

            // check if the "videos" directory exists
            if (!directory.exists(videospath))
            {
                messagebox.show("no 'videos' folder or video files found in the directory: " + path);
                return;
            }

            // get all video files in the "videos" directory and its subdirectories
            string[] videofiles = directory.getfiles(videospath, "*.*", searchoption.alldirectories);

            foreach (string videofile in videofiles)
            {
                try
                {
                    // get the media information of the video file
                    var videoinfo = ffprobe.getmediainfo(videofile);

                    // get the resolution of the video
                    string resolution = videoinfo.streams[0].width + "x" + videoinfo.streams[0].height;

                    // create the directory if it doesn't exist
                    var directorypath = path.combine(new fileinfo(videofile).directoryname, resolution);
                    directory.createdirectory(directorypath);

                    // move the file to the new directory
                    var destinationpath = path.combine(directorypath, path.getfilename(videofile));
                    file.move(videofile, destinationpath);
                }
                catch
                {
                    // if the file doesn't have a resolution or is damaged, move it to a separate folder
                    var errordirectorypath = path.combine(new fileinfo(videofile).directoryname, "error");
                    directory.createdirectory(errordirectorypath);
                    var errordestinationpath = path.combine(errordirectorypath, path.getfilename(videofile));
                    file.move(videofile, errordestinationpath);
                }
            }
        }


        //private void FilterSort(string path, Dictionary<string, List<string>> myDict, List<string> Check)
        //{
        //    string[] files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);

        //    foreach (string file in files)
        //    {
        //        // Get the file extension
        //        string extension = Path.GetExtension(file).TrimStart('.').ToLower();
        //        bool found = false;

        //        // Check if the dictionary contains the extension
        //        foreach (var entry in myDict)
        //        {
        //            if (entry.Value.Contains(extension))
        //            {
        //                // Get the destination folder
        //                string destinationFolder = Path.Combine(path, entry.Key);

        //                // Create the destination folder, if it doesn't exist
        //                Directory.CreateDirectory(destinationFolder);

        //                // Get the destination file path
        //                string destinationFile = Path.Combine(destinationFolder, Path.GetFileName(file));

        //                // Check if the destination file already exists
        //                int count = 1;
        //                while (File.Exists(destinationFile))
        //                {
        //                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file);
        //                    string fileExtension = Path.GetExtension(file);
        //                    destinationFile = Path.Combine(destinationFolder, $"{fileNameWithoutExtension}_{count++}{fileExtension}");
        //                }

        //                // Move the file
        //                File.Move(file, destinationFile);

        //                found = true;
        //                break;
        //            }
        //        }

        //        // If the extension was not found in the dictionary, move the file to a new folder
        //        if (!found)
        //        {
        //            string destinationFolder = Path.Combine(path, "Others");

        //            // Create the destination folder, if it doesn't exist
        //            Directory.CreateDirectory(destinationFolder);

        //            // Get the destination file path
        //            string destinationFile = Path.Combine(destinationFolder, Path.GetFileName(file));

        //            // Check if the destination file already exists
        //            int count = 1;
        //            while (File.Exists(destinationFile))
        //            {
        //                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file);
        //                string fileExtension = Path.GetExtension(file);
        //                destinationFile = Path.Combine(destinationFolder, $"{fileNameWithoutExtension}_{count++}{fileExtension}");
        //            }

        //            // Move the file
        //            File.Move(file, destinationFile);
        //        }
        //    }

        //    // Call the appropriate sorting method based on the Check list
        //    foreach (string check in Check)
        //    {
        //        switch (check)
        //        {
        //            case "checkBox_Include":
        //                string searchText = Microsoft.VisualBasic.Interaction.InputBox("Enter the text to search for:", "Search Text", "Default", -1, -1);
        //                if (!string.IsNullOrEmpty(searchText))
        //                {
        //                    sortContain(selectedPath, searchText);
        //                }
        //                break;
        //            case "checkBox_AtoZ":
        //                sortAlphabetical(selectedPath);
        //                break;
        //            case "checkBox_Resolution":
        //                sortResolution(selectedPath);
        //                break;
        //            case "checkBox_Size":
        //                sortSize(selectedPath);
        //                break;
        //            case "checkBox_Duration":
        //                sortDuration(selectedPath);
        //                break;
        //            case "checkBox_Delete":
        //                DeleteDirectories(selectedPath);
        //                break;
        //        }
        //    }
        //}

        //private void sortContain(string path, string searchText)
        //{
        //    // If the user clicked "Cancel" in the InputBox, the searchText will be an empty string
        //    if (!string.IsNullOrEmpty(searchText))
        //    {
        //        // Get all files in the directory and its subdirectories
        //        string[] files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);

        //        // Convert the search text to lowercase for case-insensitive comparison
        //        string lowerCaseSearchText = searchText.ToLower();

        //        // Search for files that contain the search text in their names
        //        var foundFiles = files.Where(file => Path.GetFileName(file).ToLower().Contains(lowerCaseSearchText)).ToList();

        //        if (foundFiles.Count > 0)
        //        {
        //            foreach (string foundFile in foundFiles)
        //            {
        //                // Create a new folder in the same directory as the file
        //                string fileDirectory = Path.GetDirectoryName(foundFile);
        //                string newFolderPath = Path.Combine(fileDirectory, "Match");
        //                Directory.CreateDirectory(newFolderPath);

        //                // Get the destination file path
        //                string destinationFile = Path.Combine(newFolderPath, Path.GetFileName(foundFile));

        //                // Check if the destination file already exists
        //                int count = 1;
        //                while (File.Exists(destinationFile))
        //                {
        //                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(foundFile);
        //                    string fileExtension = Path.GetExtension(foundFile);
        //                    destinationFile = Path.Combine(newFolderPath, $"{fileNameWithoutExtension}_{count++}{fileExtension}");
        //                }

        //                // Move the file
        //                File.Move(foundFile, destinationFile);
        //            }
        //        }
        //        else
        //        {
        //            // Show a message box indicating that no files were found
        //            MessageBox.Show("No files found with the name: " + searchText);
        //        }
        //    }
        //}

        //private void sortAlphabetical(string path)
        //{
        //    // Get all files in the directory and its subdirectories
        //    string[] files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);

        //    // Sort the files alphabetically by name
        //    var sortedFiles = files.OrderBy(file => Path.GetFileName(file)).ToList();

        //    if (sortedFiles.Count > 0)
        //    {
        //        // Create a dictionary to store the files grouped by the first letter of their names
        //        var filesGroupedByFirstLetter = new Dictionary<string, List<string>>();

        //        foreach (var file in sortedFiles)
        //        {
        //            string fileName = Path.GetFileName(file);
        //            string firstLetter = fileName.Substring(0, 1).ToUpper();

        //            if (!filesGroupedByFirstLetter.ContainsKey(firstLetter))
        //            {
        //                filesGroupedByFirstLetter[firstLetter] = new List<string>();
        //            }

        //            filesGroupedByFirstLetter[firstLetter].Add(file);
        //        }

        //        // Move the files to new folders based on the first letter of their names
        //        foreach (var group in filesGroupedByFirstLetter)
        //        {
        //            foreach (string file in group.Value)
        //            {
        //                // Create a new folder in the same directory as the file
        //                string fileDirectory = Path.GetDirectoryName(file);
        //                string newFolderPath = Path.Combine(fileDirectory, "Alphabetical", group.Key);
        //                Directory.CreateDirectory(newFolderPath);

        //                // Get the destination file path
        //                string destinationFile = Path.Combine(newFolderPath, Path.GetFileName(file));

        //                // Check if the destination file already exists
        //                int count = 1;
        //                while (File.Exists(destinationFile))
        //                {
        //                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file);
        //                    string fileExtension = Path.GetExtension(file);
        //                    destinationFile = Path.Combine(newFolderPath, $"{fileNameWithoutExtension}_{count++}{fileExtension}");
        //                }

        //                // Move the file
        //                File.Move(file, destinationFile);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        // Show a message box indicating that no files were found
        //        MessageBox.Show("No files found in the directory: " + path);
        //    }
        //}

        //private void sortSize(string path)
        //{
        //    if (File.Exists("Sizes.json"))
        //    {
        //        string json = File.ReadAllText("Sizes.json");

        //        // Read the JSON file
        //        var sizeDict = JsonConvert.DeserializeObject<Dictionary<string, int>>(json);

        //        // Get all files in the directory and its subdirectories
        //        string[] files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);

        //        foreach (var file in files)
        //        {
        //            var fileInfo = new FileInfo(file);
        //            var fileSizeMB = fileInfo.Length / (1024.0 * 1024.0); // Convert bytes to MB

        //            string folderName = null;

        //            // Sort the dictionary by value in descending order
        //            var sortedSizeDict = sizeDict.OrderByDescending(x => x.Value);

        //            // Find the appropriate folder for the file
        //            foreach (var entry in sortedSizeDict)
        //            {
        //                if (fileSizeMB > entry.Value)
        //                {
        //                    folderName = entry.Key;
        //                    break;
        //                }
        //            }

        //            // If no appropriate folder was found, use a default folder name
        //            if (folderName == null)
        //            {
        //                folderName = "Less than 250MB";
        //            }

        //            // Create the directory if it doesn't exist
        //            var directoryPath = Path.Combine(fileInfo.DirectoryName, folderName);
        //            Directory.CreateDirectory(directoryPath);

        //            // Move the file to the new directory
        //            var destinationPath = Path.Combine(directoryPath, fileInfo.Name);
        //            File.Move(file, destinationPath);
        //        }
        //    }
        //}

        //private void sortResolution(string path)
        //{
        //    // Create a new instance of the FFProbe class
        //    var ffProbe = new NReco.VideoInfo.FFProbe();

        //    // Get the path of the "Videos" directory
        //    string videosPath = Path.Combine(path, "Videos");

        //    // Check if the "Videos" directory exists
        //    if (!Directory.Exists(videosPath))
        //    {
        //        MessageBox.Show("No 'Videos' folder or video files found in the directory: " + path);
        //        return;
        //    }

        //    // Get all video files in the "Videos" directory and its subdirectories
        //    string[] videoFiles = Directory.GetFiles(videosPath, "*.*", SearchOption.AllDirectories);

        //    foreach (string videoFile in videoFiles)
        //    {
        //        try
        //        {
        //            // Get the media information of the video file
        //            var videoInfo = ffProbe.GetMediaInfo(videoFile);

        //            // Get the resolution of the video
        //            string resolution = videoInfo.Streams[0].Width + "x" + videoInfo.Streams[0].Height;

        //            // Create the directory if it doesn't exist
        //            var directoryPath = Path.Combine(new FileInfo(videoFile).DirectoryName, resolution);
        //            Directory.CreateDirectory(directoryPath);

        //            // Move the file to the new directory
        //            var destinationPath = Path.Combine(directoryPath, Path.GetFileName(videoFile));
        //            File.Move(videoFile, destinationPath);
        //        }
        //        catch
        //        {
        //            // If the file doesn't have a resolution or is damaged, move it to a separate folder
        //            var errorDirectoryPath = Path.Combine(new FileInfo(videoFile).DirectoryName, "Error");
        //            Directory.CreateDirectory(errorDirectoryPath);
        //            var errorDestinationPath = Path.Combine(errorDirectoryPath, Path.GetFileName(videoFile));
        //            File.Move(videoFile, errorDestinationPath);
        //        }
        //    }
        //}

        //private void sortDuration(string path)
        //{
        //    // Create a new instance of the FFProbe class
        //    var ffProbe = new NReco.VideoInfo.FFProbe();

        //    // Get the path of the "Videos" directory
        //    string videosPath = Path.Combine(path, "Videos");

        //    // Get all video files in the "Videos" directory and its subdirectories
        //    string[] videoFiles = Directory.GetFiles(videosPath, "*.*", SearchOption.AllDirectories);

        //    // Create a dictionary to store the duration and file paths of each video
        //    var videoDurations = new Dictionary<TimeSpan, List<string>>();

        //    foreach (string videoFile in videoFiles)
        //    {
        //        // Get the media information of the video file
        //        var videoInfo = ffProbe.GetMediaInfo(videoFile);

        //        // Get the duration of the video
        //        TimeSpan duration = videoInfo.Duration;

        //        // Add the duration and file path to the dictionary
        //        if (!videoDurations.ContainsKey(duration))
        //        {
        //            videoDurations[duration] = new List<string>();
        //        }
        //        videoDurations[duration].Add(videoFile);
        //    }

        //    // Sort the dictionary by key (duration)
        //    var sortedVideoDurations = videoDurations.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

        //    // Create a string to display the sorted video files
        //    StringBuilder sb = new StringBuilder();
        //    foreach (var video in sortedVideoDurations)
        //    {
        //        sb.AppendLine($"Duration: {video.Key}");
        //        foreach (var filePath in video.Value)
        //        {
        //            sb.AppendLine($"File: {filePath}");
        //        }
        //        sb.AppendLine();
        //    }

        //    // Show the sorted video files in a message box
        //    MessageBox.Show(sb.ToString());
        //}

        //private void DeleteDirectories(string path)
        //{
        //    // Get all directories on this directory.
        //    var directories = Directory.GetDirectories(path);

        //    // Loop through all subdirectories
        //    foreach (string directory in directories)
        //    {
        //        // Call this method recursively.
        //        DeleteDirectories(directory);
        //    }

        //    // If directory is empty, delete it
        //    if (Directory.GetFiles(path).Length == 0 && Directory.GetDirectories(path).Length == 0)
        //    {
        //        Directory.Delete(path, false);
        //    }
        //}
    }
}