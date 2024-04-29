﻿using System;
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
    public partial class Menu_Config : UserControl
    {
        public Menu_Config()
        {
            InitializeComponent();
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

        private void FollowButton(Button button)
        {
            // Adjust the position of Panel_Index_Config to follow the clicked button
            Panel_Index_Config.Height = button.Height;
            Panel_Index_Config.Top = button.Top;
        }
    }
}
