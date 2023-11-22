﻿namespace Project__Filter
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel_Menu = new Panel();
            button6 = new Button();
            button_Credits = new Button();
            button_Help = new Button();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            Panel_Index = new Panel();
            button1 = new Button();
            panel_Accent = new Panel();
            Panel_Banner = new Panel();
            pictureBox1 = new PictureBox();
            button_Exit = new Button();
            home1 = new Home();
            filter1 = new Filter();
            panel_Menu.SuspendLayout();
            Panel_Banner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel_Menu
            // 
            panel_Menu.BackColor = Color.FromArgb(64, 64, 64);
            panel_Menu.Controls.Add(button6);
            panel_Menu.Controls.Add(button_Credits);
            panel_Menu.Controls.Add(button_Help);
            panel_Menu.Controls.Add(button5);
            panel_Menu.Controls.Add(button4);
            panel_Menu.Controls.Add(button3);
            panel_Menu.Controls.Add(button2);
            panel_Menu.Controls.Add(Panel_Index);
            panel_Menu.Controls.Add(button1);
            panel_Menu.Dock = DockStyle.Left;
            panel_Menu.Location = new Point(0, 0);
            panel_Menu.Name = "panel_Menu";
            panel_Menu.Size = new Size(250, 683);
            panel_Menu.TabIndex = 0;
            // 
            // button6
            // 
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button6.ForeColor = Color.White;
            button6.Image = Properties.Resources.icons8_fingerprint_30;
            button6.Location = new Point(34, 334);
            button6.Name = "button6";
            button6.Size = new Size(213, 53);
            button6.TabIndex = 8;
            button6.Text = "    Encipher";
            button6.TextImageRelation = TextImageRelation.ImageBeforeText;
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button_Credits
            // 
            button_Credits.FlatAppearance.BorderSize = 0;
            button_Credits.FlatStyle = FlatStyle.Flat;
            button_Credits.Image = Properties.Resources.icons8_movie_ticket_30;
            button_Credits.Location = new Point(207, 645);
            button_Credits.Name = "button_Credits";
            button_Credits.Size = new Size(35, 35);
            button_Credits.TabIndex = 7;
            button_Credits.UseVisualStyleBackColor = true;
            // 
            // button_Help
            // 
            button_Help.FlatAppearance.BorderSize = 0;
            button_Help.FlatStyle = FlatStyle.Flat;
            button_Help.Image = Properties.Resources.icons8_help_30;
            button_Help.Location = new Point(3, 645);
            button_Help.Name = "button_Help";
            button_Help.Size = new Size(35, 35);
            button_Help.TabIndex = 6;
            button_Help.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button5.ForeColor = Color.White;
            button5.Image = Properties.Resources.icons8_merge_30;
            button5.Location = new Point(34, 274);
            button5.Name = "button5";
            button5.Size = new Size(213, 53);
            button5.TabIndex = 5;
            button5.Text = "    Merge";
            button5.TextImageRelation = TextImageRelation.ImageBeforeText;
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button4.ForeColor = Color.White;
            button4.Image = Properties.Resources.icons8_undo_30;
            button4.Location = new Point(34, 214);
            button4.Name = "button4";
            button4.Size = new Size(213, 53);
            button4.TabIndex = 4;
            button4.Text = "    Extract";
            button4.TextImageRelation = TextImageRelation.ImageBeforeText;
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button3.ForeColor = Color.White;
            button3.Image = Properties.Resources.icons8_convert_30;
            button3.Location = new Point(34, 154);
            button3.Name = "button3";
            button3.Size = new Size(213, 53);
            button3.TabIndex = 3;
            button3.Text = "    Transform";
            button3.TextImageRelation = TextImageRelation.ImageBeforeText;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = Color.White;
            button2.Image = Properties.Resources.icons8_filter_30;
            button2.Location = new Point(34, 94);
            button2.Name = "button2";
            button2.Size = new Size(213, 53);
            button2.TabIndex = 2;
            button2.Text = "    Filter";
            button2.TextImageRelation = TextImageRelation.ImageBeforeText;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Panel_Index
            // 
            Panel_Index.BackColor = Color.Teal;
            Panel_Index.Location = new Point(3, 34);
            Panel_Index.Name = "Panel_Index";
            Panel_Index.Size = new Size(25, 53);
            Panel_Index.TabIndex = 1;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.Image = Properties.Resources.icons8_windows_30;
            button1.Location = new Point(34, 34);
            button1.Name = "button1";
            button1.Size = new Size(213, 53);
            button1.TabIndex = 0;
            button1.Text = "    Home";
            button1.TextImageRelation = TextImageRelation.ImageBeforeText;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // panel_Accent
            // 
            panel_Accent.BackColor = Color.FromArgb(0, 64, 64);
            panel_Accent.Dock = DockStyle.Top;
            panel_Accent.Location = new Point(250, 0);
            panel_Accent.Name = "panel_Accent";
            panel_Accent.Size = new Size(791, 28);
            panel_Accent.TabIndex = 1;
            // 
            // Panel_Banner
            // 
            Panel_Banner.BackColor = Color.FromArgb(0, 64, 64);
            Panel_Banner.Controls.Add(pictureBox1);
            Panel_Banner.Location = new Point(281, 2);
            Panel_Banner.Name = "Panel_Banner";
            Panel_Banner.Size = new Size(69, 101);
            Panel_Banner.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Martin_Berube_Animal_Sheep_256;
            pictureBox1.Location = new Point(3, 32);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(63, 62);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // button_Exit
            // 
            button_Exit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_Exit.FlatAppearance.BorderSize = 0;
            button_Exit.FlatStyle = FlatStyle.Flat;
            button_Exit.Image = Properties.Resources.icons8_power_30;
            button_Exit.Location = new Point(1003, 34);
            button_Exit.Name = "button_Exit";
            button_Exit.Size = new Size(35, 35);
            button_Exit.TabIndex = 3;
            button_Exit.UseVisualStyleBackColor = true;
            button_Exit.Click += button_Exit_Click;
            // 
            // home1
            // 
            home1.Location = new Point(250, 110);
            home1.Name = "home1";
            home1.Size = new Size(791, 573);
            home1.TabIndex = 4;
            // 
            // filter1
            // 
            filter1.Location = new Point(250, 110);
            filter1.Name = "filter1";
            filter1.Size = new Size(791, 573);
            filter1.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(1041, 683);
            Controls.Add(filter1);
            Controls.Add(home1);
            Controls.Add(button_Exit);
            Controls.Add(Panel_Banner);
            Controls.Add(panel_Accent);
            Controls.Add(panel_Menu);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            Text = "Form1";
            panel_Menu.ResumeLayout(false);
            Panel_Banner.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_Menu;
        private Panel panel_Accent;
        private Panel Panel_Banner;
        private PictureBox pictureBox1;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
        private Panel Panel_Index;
        private Button button1;
        private Button button_Exit;
        private Button button_Help;
        private Button button_Credits;
        private Home home1;
        private Filter filter1;
        private Button button6;
    }
}