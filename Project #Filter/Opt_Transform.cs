﻿using System.Data;
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

        private void askTitle()
        {

        }

        private void askContent()
        {

        }

        private async Task PDFBuilder()
        {

        }
    }
}