using Newtonsoft.Json;

namespace Project__Filter
{
    public partial class Main : Form
    {

        public Main()
        {
            InitializeComponent();
            // Index
            Panel_Index.Height = button_Home.Height;
            Panel_Index.Top = button_Home.Top;
            home1.BringToFront();
            this.Text = "Tool Kit 2.0";
            loadJsonfiles();
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
            config_Menu1.BringToFront();
            Panel_Index.Height = button_Home.Height;
            Panel_Index.Top = button_Home.Top;
        }

        private void loadJsonfiles()
        {
            if (!File.Exists("Folders.json"))
            {
                var dictsort = new Dictionary<string, List<string>>
                {
                    { "Videos", new List<string>() { "mp4", "m4v", "avi", "mkv" } },
                    { "Documents", new List<string>() { "txt", "docx", "pdf", "pptx" } },
                    { "Images", new List<string>() { "jpg", "png", "gif", "bmp" } }
                };

                string sort = JsonConvert.SerializeObject(dictsort, Formatting.Indented);
                File.WriteAllText("Folders.json", sort);
            }
            if (!File.Exists("Duration.json"))
            {

                var dictduration = new Dictionary<string, Tuple<int, int>>
                {
                    { "Less than 5 Min", new Tuple<int, int>(1, 299)},
                    { "5 Min to 10 Min", new Tuple<int, int>(300, 600) },
                    { "10 Min to 20 Min", new Tuple<int, int>(601, 1200) },
                    { "20 Min to 30 Min", new Tuple<int, int>(1201, 1800) },
                    { "30 Min to 40 Min", new Tuple<int, int>(1801, 2400) },
                    { "40 Min to 50 Min", new Tuple<int, int>(2401, 3000) },
                    { "50 Min to 1 Hr", new Tuple<int, int>(3001, 3600) },
                    { "More than 1 Hr", new Tuple<int, int>(3601,284018400) }
                };


                string durationJson = JsonConvert.SerializeObject(dictduration, Formatting.Indented);
                File.WriteAllText("Duration.json", durationJson);
            }
        }
    }
}