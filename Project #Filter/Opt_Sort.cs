using System.Text.RegularExpressions;
using Newtonsoft.Json;
using NReco.VideoInfo;

namespace Project__Filter
{
    public partial class Opt_Sort : UserControl
    {
        private string Path;
        private List<string> checkedItems = new List<string>();

        public Opt_Sort()
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

        private async void button_Filter_Click_1(object sender, EventArgs e)
        {
            // Iterate through each item in the checkedItems list
            foreach (string item in checkedItems)
            {
                MessageBox.Show($"Item: {item}");
                switch (item)
                {
                    case "File Type":
                        await Task.Run(() => SortTypes(Path, "Config_Type.json"));
                        break;
                    case "File Size":
                        await Task.Run(() => SortSize(Path, "Config_Size.json"));
                        break;
                    case "File Date":
                        await Task.Run(() => SortDates(Path));
                        break;
                    case "File Name":
                        await Task.Run(() => SortNames(Path, "Config_Names.json"));
                        break;
                    case "File Permissions":
                        await Task.Run(() => SortPermissions(Path, "Config_Permissions.json"));
                        break;
                    case "Custom Tags":
                        await Task.Run(() => SortCustomTags(Path, "Config_Tags.json"));
                        break;
                    case "Folder Location":
                        await Task.Run(() => SortFolderLocation(Path, "Config_Folder.json"));
                        break;
                    case "Media Metadata (Videos/Audio)":
                        await Task.Run(() => SortMedia(Path, "Config_Media.json"));
                        break;
                    default:
                        break;
                }
            }

            // Optionally, you can split the list into sub-lists or do other kinds of processing here.
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

        private async void SortTypes(string Path, string file)
        {
            if (File.Exists(file))
            {
                // Mostrar un mensaje con los parámetros
                string message = $"Función llamada con los siguientes parámetros:\nPath: {Path}\nFile: {file}";
                MessageBox.Show(message);

                // Iniciar un bucle para contar los segundos
                for (int seconds = 0; seconds <= 60; seconds++)
                {
                    // Actualizar la ProgressBar en el hilo principal
                    Invoke((MethodInvoker)(() => progressBar_Time.Value = seconds));

                    await Task.Delay(1000); // Esperar 1 segundo
                }
            }
        }

        private async void SortSize(string Path, string File)
        {

        }

        private async void SortDates(string Path)
        {

        }

        private async void SortNames(string Path, string File)
        {

        }

        private async void SortPermissions(string Path, string File)
        {

        }

        private async void SortCustomTags(string Path, string File)
        {

        }

        private async void SortFolderLocation(string Path, string File)
        {

        }

        private async void SortFileContent(string Path, string File)
        {

        }

        private async void SortMedia(string Path, string File)
        {

        }
    }
}