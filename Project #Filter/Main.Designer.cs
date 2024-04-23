﻿namespace Project__Filter
{
    partial class Main
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            panel_Menu = new Panel();
            Panel_Index = new Panel();
            button_Privacy = new Button();
            button_Merge = new Button();
            button_Git = new Button();
            button_Extract = new Button();
            button_Convert = new Button();
            button_Filter = new Button();
            button_Home = new Button();
            panel_Accent = new Panel();
            button_Config = new Button();
            label_Title = new Label();
            button_Exit = new Button();
            Panel_Banner = new Panel();
            pictureBox1 = new PictureBox();
            home1 = new Home();
            filter1 = new Sort();
            convert1 = new Convert();
            extract1 = new Extract();
            merge1 = new Merge();
            privacy1 = new Privacy();
            DragControl_Accent = new Bunifu.Framework.UI.BunifuDragControl(components);
            DragControl_Tittle = new Bunifu.Framework.UI.BunifuDragControl(components);
            DragControl_Menu = new Bunifu.Framework.UI.BunifuDragControl(components);
            DragControl_Banner = new Bunifu.Framework.UI.BunifuDragControl(components);
            DragControl_Main = new Bunifu.Framework.UI.BunifuDragControl(components);
            panel1 = new Panel();
            config_Menu1 = new Config_Menu();
            bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(components);
            panel_Menu.SuspendLayout();
            panel_Accent.SuspendLayout();
            Panel_Banner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel_Menu
            // 
            panel_Menu.BackColor = Color.FromArgb(0, 64, 64);
            panel_Menu.Controls.Add(Panel_Index);
            panel_Menu.Controls.Add(button_Privacy);
            panel_Menu.Controls.Add(button_Merge);
            panel_Menu.Controls.Add(button_Git);
            panel_Menu.Controls.Add(button_Extract);
            panel_Menu.Controls.Add(button_Convert);
            panel_Menu.Controls.Add(button_Filter);
            panel_Menu.Controls.Add(button_Home);
            panel_Menu.Dock = DockStyle.Left;
            panel_Menu.Location = new Point(0, 0);
            panel_Menu.Name = "panel_Menu";
            panel_Menu.Size = new Size(250, 683);
            panel_Menu.TabIndex = 0;
            // 
            // Panel_Index
            // 
            Panel_Index.BackColor = Color.Teal;
            Panel_Index.Location = new Point(2, 35);
            Panel_Index.Name = "Panel_Index";
            Panel_Index.Size = new Size(25, 53);
            Panel_Index.TabIndex = 1;
            // 
            // button_Privacy
            // 
            button_Privacy.BackColor = Color.FromArgb(0, 64, 64);
            button_Privacy.Cursor = Cursors.Hand;
            button_Privacy.FlatAppearance.BorderSize = 0;
            button_Privacy.FlatStyle = FlatStyle.Flat;
            button_Privacy.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            button_Privacy.ForeColor = Color.White;
            button_Privacy.Image = Properties.Resources.FingerPrint;
            button_Privacy.Location = new Point(31, 328);
            button_Privacy.Name = "button_Privacy";
            button_Privacy.Size = new Size(213, 53);
            button_Privacy.TabIndex = 8;
            button_Privacy.Text = "    ENCRYPT";
            button_Privacy.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_Privacy.UseVisualStyleBackColor = false;
            button_Privacy.Click += button_Privacy_Click;
            // 
            // button_Merge
            // 
            button_Merge.BackColor = Color.FromArgb(0, 64, 64);
            button_Merge.Cursor = Cursors.Hand;
            button_Merge.FlatAppearance.BorderSize = 0;
            button_Merge.FlatStyle = FlatStyle.Flat;
            button_Merge.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            button_Merge.ForeColor = Color.White;
            button_Merge.Image = Properties.Resources.Merge;
            button_Merge.Location = new Point(31, 269);
            button_Merge.Name = "button_Merge";
            button_Merge.Size = new Size(213, 53);
            button_Merge.TabIndex = 5;
            button_Merge.Text = "    MERGE";
            button_Merge.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_Merge.UseVisualStyleBackColor = false;
            button_Merge.Click += button_Merge_Click;
            // 
            // button_Git
            // 
            button_Git.BackgroundImage = Properties.Resources.icons8_github_50;
            button_Git.BackgroundImageLayout = ImageLayout.Zoom;
            button_Git.Cursor = Cursors.Hand;
            button_Git.FlatAppearance.BorderSize = 0;
            button_Git.FlatStyle = FlatStyle.Flat;
            button_Git.Location = new Point(0, 643);
            button_Git.Name = "button_Git";
            button_Git.Size = new Size(40, 40);
            button_Git.TabIndex = 7;
            button_Git.UseVisualStyleBackColor = true;
            button_Git.Click += button_Git_Click;
            // 
            // button_Extract
            // 
            button_Extract.BackColor = Color.FromArgb(0, 64, 64);
            button_Extract.Cursor = Cursors.Hand;
            button_Extract.FlatAppearance.BorderSize = 0;
            button_Extract.FlatStyle = FlatStyle.Flat;
            button_Extract.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            button_Extract.ForeColor = Color.White;
            button_Extract.Image = Properties.Resources.Undo;
            button_Extract.Location = new Point(31, 211);
            button_Extract.Name = "button_Extract";
            button_Extract.Size = new Size(213, 53);
            button_Extract.TabIndex = 4;
            button_Extract.Text = "    EXTRACT";
            button_Extract.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_Extract.UseVisualStyleBackColor = false;
            button_Extract.Click += button_Extract_Click;
            // 
            // button_Convert
            // 
            button_Convert.BackColor = Color.FromArgb(0, 64, 64);
            button_Convert.Cursor = Cursors.Hand;
            button_Convert.FlatAppearance.BorderSize = 0;
            button_Convert.FlatStyle = FlatStyle.Flat;
            button_Convert.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            button_Convert.ForeColor = Color.White;
            button_Convert.Image = Properties.Resources.Convert;
            button_Convert.Location = new Point(31, 152);
            button_Convert.Name = "button_Convert";
            button_Convert.Size = new Size(213, 53);
            button_Convert.TabIndex = 3;
            button_Convert.Text = "    TRANSFROM";
            button_Convert.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_Convert.UseVisualStyleBackColor = false;
            button_Convert.Click += button_Convert_Click;
            // 
            // button_Filter
            // 
            button_Filter.BackColor = Color.FromArgb(0, 64, 64);
            button_Filter.Cursor = Cursors.Hand;
            button_Filter.FlatAppearance.BorderSize = 0;
            button_Filter.FlatStyle = FlatStyle.Flat;
            button_Filter.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            button_Filter.ForeColor = Color.White;
            button_Filter.Image = Properties.Resources.Filter;
            button_Filter.Location = new Point(31, 93);
            button_Filter.Name = "button_Filter";
            button_Filter.Size = new Size(213, 53);
            button_Filter.TabIndex = 2;
            button_Filter.Text = "    SORT";
            button_Filter.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_Filter.UseVisualStyleBackColor = false;
            button_Filter.Click += button_Filter_Click_1;
            // 
            // button_Home
            // 
            button_Home.BackColor = Color.FromArgb(0, 64, 64);
            button_Home.Cursor = Cursors.Hand;
            button_Home.FlatAppearance.BorderSize = 0;
            button_Home.FlatStyle = FlatStyle.Flat;
            button_Home.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            button_Home.ForeColor = Color.White;
            button_Home.Image = Properties.Resources.Windows;
            button_Home.Location = new Point(31, 35);
            button_Home.Name = "button_Home";
            button_Home.Size = new Size(213, 53);
            button_Home.TabIndex = 0;
            button_Home.Text = "    HOME";
            button_Home.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_Home.UseVisualStyleBackColor = false;
            button_Home.Click += button_Home_Click;
            // 
            // panel_Accent
            // 
            panel_Accent.BackColor = Color.FromArgb(0, 64, 64);
            panel_Accent.Controls.Add(button_Config);
            panel_Accent.Controls.Add(label_Title);
            panel_Accent.Controls.Add(button_Exit);
            panel_Accent.Dock = DockStyle.Top;
            panel_Accent.Location = new Point(250, 0);
            panel_Accent.Name = "panel_Accent";
            panel_Accent.Size = new Size(885, 53);
            panel_Accent.TabIndex = 1;
            // 
            // button_Config
            // 
            button_Config.Anchor = AnchorStyles.Right;
            button_Config.Cursor = Cursors.Hand;
            button_Config.FlatAppearance.BorderSize = 0;
            button_Config.FlatStyle = FlatStyle.Flat;
            button_Config.Image = Properties.Resources.Config;
            button_Config.Location = new Point(806, 11);
            button_Config.Name = "button_Config";
            button_Config.Size = new Size(29, 33);
            button_Config.TabIndex = 8;
            button_Config.UseVisualStyleBackColor = true;
            button_Config.Click += button_Config_Click;
            // 
            // label_Title
            // 
            label_Title.Anchor = AnchorStyles.None;
            label_Title.AutoSize = true;
            label_Title.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            label_Title.ForeColor = Color.White;
            label_Title.Location = new Point(93, 15);
            label_Title.Name = "label_Title";
            label_Title.Size = new Size(143, 24);
            label_Title.TabIndex = 6;
            label_Title.Text = "TOOL KIT 2.0";
            // 
            // button_Exit
            // 
            button_Exit.Anchor = AnchorStyles.Right;
            button_Exit.Cursor = Cursors.Hand;
            button_Exit.FlatAppearance.BorderSize = 0;
            button_Exit.FlatStyle = FlatStyle.Flat;
            button_Exit.Image = Properties.Resources.Power;
            button_Exit.Location = new Point(848, 11);
            button_Exit.Name = "button_Exit";
            button_Exit.Size = new Size(29, 33);
            button_Exit.TabIndex = 3;
            button_Exit.UseVisualStyleBackColor = true;
            button_Exit.Click += button_Exit_Click;
            // 
            // Panel_Banner
            // 
            Panel_Banner.BackColor = Color.FromArgb(0, 64, 64);
            Panel_Banner.Controls.Add(pictureBox1);
            Panel_Banner.Location = new Point(265, 8);
            Panel_Banner.Name = "Panel_Banner";
            Panel_Banner.Size = new Size(69, 103);
            Panel_Banner.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Logo;
            pictureBox1.Location = new Point(3, 35);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(63, 61);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // home1
            // 
            home1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            home1.Location = new Point(250, 109);
            home1.Name = "home1";
            home1.Size = new Size(885, 573);
            home1.TabIndex = 4;
            // 
            // filter1
            // 
            filter1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            filter1.BackColor = Color.FromArgb(64, 64, 64);
            filter1.Location = new Point(250, 109);
            filter1.Name = "filter1";
            filter1.Size = new Size(885, 573);
            filter1.TabIndex = 5;
            // 
            // convert1
            // 
            convert1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            convert1.BackColor = Color.FromArgb(64, 64, 64);
            convert1.Location = new Point(250, 109);
            convert1.Name = "convert1";
            convert1.Size = new Size(885, 573);
            convert1.TabIndex = 8;
            // 
            // extract1
            // 
            extract1.BackColor = Color.FromArgb(64, 64, 64);
            extract1.Location = new Point(250, 109);
            extract1.Margin = new Padding(3, 4, 3, 4);
            extract1.Name = "extract1";
            extract1.Size = new Size(885, 573);
            extract1.TabIndex = 9;
            // 
            // merge1
            // 
            merge1.BackColor = Color.FromArgb(64, 64, 64);
            merge1.Location = new Point(250, 109);
            merge1.Margin = new Padding(3, 5, 3, 5);
            merge1.Name = "merge1";
            merge1.Size = new Size(885, 573);
            merge1.TabIndex = 10;
            // 
            // privacy1
            // 
            privacy1.BackColor = Color.FromArgb(64, 64, 64);
            privacy1.Location = new Point(250, 109);
            privacy1.Name = "privacy1";
            privacy1.Size = new Size(885, 573);
            privacy1.TabIndex = 11;
            // 
            // DragControl_Accent
            // 
            DragControl_Accent.Fixed = true;
            DragControl_Accent.Horizontal = true;
            DragControl_Accent.TargetControl = panel_Accent;
            DragControl_Accent.Vertical = true;
            // 
            // DragControl_Tittle
            // 
            DragControl_Tittle.Fixed = true;
            DragControl_Tittle.Horizontal = true;
            DragControl_Tittle.TargetControl = label_Title;
            DragControl_Tittle.Vertical = true;
            // 
            // DragControl_Menu
            // 
            DragControl_Menu.Fixed = true;
            DragControl_Menu.Horizontal = true;
            DragControl_Menu.TargetControl = panel_Menu;
            DragControl_Menu.Vertical = true;
            // 
            // DragControl_Banner
            // 
            DragControl_Banner.Fixed = true;
            DragControl_Banner.Horizontal = true;
            DragControl_Banner.TargetControl = Panel_Banner;
            DragControl_Banner.Vertical = true;
            // 
            // DragControl_Main
            // 
            DragControl_Main.Fixed = true;
            DragControl_Main.Horizontal = true;
            DragControl_Main.TargetControl = this;
            DragControl_Main.Vertical = true;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(0, 64, 64);
            panel1.Location = new Point(1098, 51);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(37, 60);
            panel1.TabIndex = 13;
            // 
            // config_Menu1
            // 
            config_Menu1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            config_Menu1.BackColor = Color.FromArgb(64, 64, 64);
            config_Menu1.Location = new Point(250, 109);
            config_Menu1.Margin = new Padding(3, 5, 3, 5);
            config_Menu1.Name = "config_Menu1";
            config_Menu1.Size = new Size(885, 573);
            config_Menu1.TabIndex = 14;
            // 
            // bunifuElipse1
            // 
            bunifuElipse1.ElipseRadius = 30;
            bunifuElipse1.TargetControl = this;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(1135, 683);
            ControlBox = false;
            Controls.Add(panel1);
            Controls.Add(home1);
            Controls.Add(filter1);
            Controls.Add(convert1);
            Controls.Add(extract1);
            Controls.Add(merge1);
            Controls.Add(privacy1);
            Controls.Add(config_Menu1);
            Controls.Add(Panel_Banner);
            Controls.Add(panel_Accent);
            Controls.Add(panel_Menu);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Load += Main_Load;
            panel_Menu.ResumeLayout(false);
            panel_Accent.ResumeLayout(false);
            panel_Accent.PerformLayout();
            Panel_Banner.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_Menu;
        private Panel panel_Accent;
        private Panel Panel_Banner;
        private PictureBox pictureBox1;
        private Button button_Merge;
        private Button button_Extract;
        private Button button_Convert;
        private Button button_Filter;
        private Panel Panel_Index;
        private Button button_Home;
        private Button button_Exit;
        private Home home1;
        private Sort filter1;
        private Button button_Privacy;
        private Label label_Title;
        private Button button_Git;
        private Convert convert1;
        private Extract extract1;
        private Merge merge1;
        private Privacy privacy1;
        private Button button_Config;
        private Bunifu.Framework.UI.BunifuDragControl DragControl_Accent;
        private Bunifu.Framework.UI.BunifuDragControl DragControl_Tittle;
        private Bunifu.Framework.UI.BunifuDragControl DragControl_Menu;
        private Bunifu.Framework.UI.BunifuDragControl DragControl_Banner;
        private Bunifu.Framework.UI.BunifuDragControl DragControl_Main;
        private Panel panel1;
        private Config_Menu config_Menu1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
    }
}