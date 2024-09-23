using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project__Filter
{
    public partial class Menu_Sizes : UserControl
    {
        public Menu_Sizes()
        {
            InitializeComponent();
        }

        private void Menu_Sizes_Load(object sender, EventArgs e)
        {
            while (true)
            {
                if (!File.Exists("Size.json"))
                {
                    // Create the JSON object
                    var jsonContent = new JObject(
                         new JProperty("Extensions", new JObject(
                             new JProperty("Small", new JArray("jpg", "png", "gif", "bmp", "jpeg")),
                             new JProperty("Medium", new JArray("mp4", "m4v", "avi", "mkv", "3gp", "mov", "wmv", "webm", "ts", "mpg", "asf", "flv", "mpeg")),
                             new JProperty("Documents", new JArray("txt", "docx", "pdf", "pptx")),
                             new JProperty("Audio", new JArray("mp3", "wav", "aac", "flac", "ogg", "m4a", "wma", "alac", "aiff")),
                             new JProperty("Archives", new JArray("zip", "rar", "7z", "tar", "gz", "bz2", "iso", "xz")),
                             new JProperty("Executables", new JArray("exe", "bat", "sh", "msi", "bin", "cmd", "apk", "com", "jar"))
                         ))
                    );

                    // Save to a file (e.g., "Extensions.json")
                    File.WriteAllText("Size.json", jsonContent.ToString());
                }

                // File already exists; get the filepath
                //string filePath = Path.GetFullPath("Extensions.json");
                //PopulateTree(filePath);
                break;
            }
        }
    }
}
