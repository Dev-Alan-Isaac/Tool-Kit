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

        private void button_Type_Click(object sender, EventArgs e)
        {
            menu_Type1.BringToFront();
            FollowButton(sender as Button);
        }

        private void button_Size_Click(object sender, EventArgs e)
        {
            menu_Sizes1.BringToFront();
            FollowButton(sender as Button);
        }

        private void button_Date_Click(object sender, EventArgs e)
        {
            menu_Date1.BringToFront();
            FollowButton(sender as Button);
        }

        private void button_Name_Click(object sender, EventArgs e)
        {
            FollowButton(sender as Button);
        }

        private void button_Usage_Click(object sender, EventArgs e)
        {
            FollowButton(sender as Button);
        }

        private void button_Auth_Click(object sender, EventArgs e)
        {
            FollowButton(sender as Button);
        }

        private void button_Tags_Click(object sender, EventArgs e)
        {
            FollowButton(sender as Button);
        }

        private void button_Folders_Click(object sender, EventArgs e)
        {
            FollowButton(sender as Button);
        }

        private void button_Content_Click(object sender, EventArgs e)
        {
            FollowButton(sender as Button);
        }

        private void button_Media_Click(object sender, EventArgs e)
        {
            FollowButton(sender as Button);
        }
    }
}
