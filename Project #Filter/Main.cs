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
            pictureBox1.Image = Properties.Resources.Home_BreadCrumb;
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
            pictureBox1.Image = Properties.Resources.Home_BreadCrumb;
        }

        private void button_Filter_Click_1(object sender, EventArgs e)
        {
            Panel_Index.Height = button_Filter.Height;
            Panel_Index.Top = button_Filter.Top;
            filter1.BringToFront();
            pictureBox1.Image = Properties.Resources.Sort_BreadCrumb;
        }

        private void button_Convert_Click(object sender, EventArgs e)
        {
            Panel_Index.Height = button_Convert.Height;
            Panel_Index.Top = button_Convert.Top;
            convert1.BringToFront();
            pictureBox1.Image = Properties.Resources.Transform_BreadCrumb;
        }

        private void button_Extract_Click(object sender, EventArgs e)
        {
            Panel_Index.Height = button_Extract.Height;
            Panel_Index.Top = button_Extract.Top;
            extract1.BringToFront();
            pictureBox1.Image = Properties.Resources.Extract_BreadCrumb;
        }

        private void button_Merge_Click(object sender, EventArgs e)
        {
            Panel_Index.Height = button_Merge.Height;
            Panel_Index.Top = button_Merge.Top;
            merge1.BringToFront();
            pictureBox1.Image = Properties.Resources.Merge_BreadCrumb;
        }

        private void button_Privacy_Click(object sender, EventArgs e)
        {
            Panel_Index.Height = button_Privacy.Height;
            Panel_Index.Top = button_Privacy.Top;
            privacy1.BringToFront();
            pictureBox1.Image = Properties.Resources.Security_BreadCrumb;
        }

        private void button_Config_Click(object sender, EventArgs e)
        {
            config_Menu1.BringToFront();
            Panel_Index.Height = button_Home.Height;
            Panel_Index.Top = button_Home.Top;
            pictureBox1.Image = Properties.Resources.Config_BreadCrumb;
        }
    }
}