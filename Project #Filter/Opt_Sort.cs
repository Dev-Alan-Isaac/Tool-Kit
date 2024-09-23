﻿using System.Text.RegularExpressions;
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
                        await Task.Run(() => SortTypes(Path, "Json"));
                        break;
                    case "File Size":
                        break;
                    case "File Date":
                        break;
                    case "File Name":
                        break;
                    case "File Usage":
                        break;
                    case "File Permissions":
                        break;
                    case "Custom Tags":
                        break;
                    case "Folder Location":
                        break;
                    case "File Content (Text/Docs)":
                        break;
                    case "Media Metadata (Videos/Audio)":
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
            button_Filter.Enabled = true;
        }


        private async void SortTypes(string Path, string File)
        {
            // Mostrar un mensaje con los parámetros
            string message = $"Función llamada con los siguientes parámetros:\nPath: {Path}\nFile: {File}";
            MessageBox.Show(message);

            // Iniciar un bucle para contar los segundos
            for (int seconds = 0; seconds <= 60; seconds++)
            {
                // Actualizar la ProgressBar en el hilo principal
                Invoke((MethodInvoker)(() => progressBar_Time.Value = seconds));

                await Task.Delay(1000); // Esperar 1 segundo
            }
        }

        private async void SortSize(string Path, string File)
        {

        }

        private async void SortDates(string Path, string File)
        {

        }

        private async void SortNames(string Path, string File)
        {

        }

        private async void SortUsages(string Path, string File)
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