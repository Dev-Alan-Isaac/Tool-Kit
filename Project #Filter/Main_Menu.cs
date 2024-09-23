namespace Project__Filter
{
    public partial class Main_Menu : UserControl
    {
        public Main_Menu()
        {
            InitializeComponent();
        }

        private void FollowButton(Button button)
        {
            // Adjust the position of Panel_Index_Config to follow the clicked button
            Panel_Index_Config.Height = button.Height;
            Panel_Index_Config.Top = button.Top;
        }

        private void button_Folder_Click(object sender, EventArgs e)
        {
            config_Folders1.BringToFront();
            FollowButton(sender as Button);
        }

        private void button_Size_Click(object sender, EventArgs e)
        {
            config_Sizes1.BringToFront();
            FollowButton(sender as Button);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            config_Sizes1.BringToFront();
            FollowButton(sender as Button);
        }

        private void button_Date_Click(object sender, EventArgs e)
        {
            menu_Date1.BringToFront();
            FollowButton(sender as Button);
        }
    }
}
