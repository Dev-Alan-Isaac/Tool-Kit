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
    public partial class Menu_Convert : UserControl
    {
        public Menu_Convert()
        {
            InitializeComponent();
        }

        private void Menu_Transform_Load(object sender, EventArgs e)
        {
            while (true)
            {
                if (!File.Exists("Config_Transform.json"))
                {
                    // Create the JSON object
                    var jsonContent = new JObject(
                         new JProperty("Extensions", new JObject(
                             new JProperty("Images", new JArray("jpg", "png", "gif", "bmp", "jpeg")),
                             new JProperty("Videos", new JArray("mp4", "m4v", "avi", "mkv", "3gp", "mov", "wmv", "webm", "ts", "mpg", "asf", "flv", "mpeg")),
                             new JProperty("Documents", new JArray("txt", "docx", "pdf", "pptx")),
                             new JProperty("Audio", new JArray("mp3", "wav", "aac", "flac", "ogg", "m4a", "wma", "alac", "aiff")),
                             new JProperty("Archives", new JArray("zip", "rar", "7z", "tar", "gz", "bz2", "iso", "xz")),
                             new JProperty("Executables", new JArray("exe", "bat", "sh", "msi", "bin", "cmd", "apk", "com", "jar"))
                         )),
                         new JProperty("Allow", new JObject(
                             new JProperty("Documents", true),
                             new JProperty("Images", true),
                             new JProperty("Audio", true),
                             new JProperty("Videos", true),
                             new JProperty("Archives", true),
                             new JProperty("Executables", true)
                         ))
                    );

                    // Save to a file (e.g., "Extensions.json")
                    File.WriteAllText("Config_Transform.json", jsonContent.ToString());
                }
                break;
            }
        }

    }
}
