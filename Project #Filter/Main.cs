using Newtonsoft.Json;

namespace Project__Filter
{
    public partial class Main : Form
    {
        public Dictionary<string, List<string>> dict;

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

        private void button_Config_Click(object sender, EventArgs e)
        {
            config1.BringToFront();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if (!File.Exists("Config.json"))
            {
                dict = new Dictionary<string, List<string>>
                {
                    { "video", new List<string>() { "mp4", "m4v", "avi", "mkv" } },
                    { "document", new List<string>() { "txt", "docx", "pdf", "pptx" } },
                    { "image", new List<string>() { "jpg", "png", "gif", "bmp" } }
                };

                string json = JsonConvert.SerializeObject(dict, Formatting.Indented);
                File.WriteAllText("Config.json", json);
            }
            else
            {
                string json = File.ReadAllText("Config.json");
                dict = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(json);
            }
        }

    }
}