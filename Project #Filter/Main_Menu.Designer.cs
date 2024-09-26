namespace Project__Filter
{
    partial class Main_Menu
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel_Menu_Config = new Panel();
            button_Media = new Button();
            button_Folders = new Button();
            button_Tags = new Button();
            button_Auth = new Button();
            button_Name = new Button();
            Panel_Index_Config = new Panel();
            button_Size = new Button();
            button_Type = new Button();
            menu_Type1 = new Menu_Type();
            menu_Sizes1 = new Menu_Sizes();
            menu_Name1 = new Menu_Name();
            menu_Auth1 = new Menu_Auth();
            menu_Tags1 = new Menu_Tags();
            menu_Folder1 = new Menu_Folder();
            menu_Media1 = new Menu_Media();
            panel_Menu_Config.SuspendLayout();
            SuspendLayout();
            // 
            // panel_Menu_Config
            // 
            panel_Menu_Config.AutoScroll = true;
            panel_Menu_Config.BackColor = Color.FromArgb(0, 64, 64);
            panel_Menu_Config.Controls.Add(button_Media);
            panel_Menu_Config.Controls.Add(button_Folders);
            panel_Menu_Config.Controls.Add(button_Tags);
            panel_Menu_Config.Controls.Add(button_Auth);
            panel_Menu_Config.Controls.Add(button_Name);
            panel_Menu_Config.Controls.Add(Panel_Index_Config);
            panel_Menu_Config.Controls.Add(button_Size);
            panel_Menu_Config.Controls.Add(button_Type);
            panel_Menu_Config.Dock = DockStyle.Left;
            panel_Menu_Config.Location = new Point(0, 0);
            panel_Menu_Config.Margin = new Padding(3, 2, 3, 2);
            panel_Menu_Config.Name = "panel_Menu_Config";
            panel_Menu_Config.Size = new Size(171, 541);
            panel_Menu_Config.TabIndex = 1;
            // 
            // button_Media
            // 
            button_Media.BackColor = Color.Transparent;
            button_Media.Cursor = Cursors.Hand;
            button_Media.FlatAppearance.BorderSize = 0;
            button_Media.FlatStyle = FlatStyle.Flat;
            button_Media.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            button_Media.ForeColor = Color.White;
            button_Media.Image = Properties.Resources.Button_Icon_Media;
            button_Media.Location = new Point(25, 422);
            button_Media.Margin = new Padding(3, 2, 3, 2);
            button_Media.Name = "button_Media";
            button_Media.Size = new Size(120, 40);
            button_Media.TabIndex = 11;
            button_Media.Text = "   Media";
            button_Media.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_Media.UseVisualStyleBackColor = false;
            button_Media.Click += button_Media_Click;
            // 
            // button_Folders
            // 
            button_Folders.BackColor = Color.Transparent;
            button_Folders.Cursor = Cursors.Hand;
            button_Folders.FlatAppearance.BorderSize = 0;
            button_Folders.FlatStyle = FlatStyle.Flat;
            button_Folders.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            button_Folders.ForeColor = Color.White;
            button_Folders.Image = Properties.Resources.Button_Icon_Tree;
            button_Folders.Location = new Point(25, 356);
            button_Folders.Margin = new Padding(3, 2, 3, 2);
            button_Folders.Name = "button_Folders";
            button_Folders.Size = new Size(120, 40);
            button_Folders.TabIndex = 8;
            button_Folders.Text = "   Folder";
            button_Folders.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_Folders.UseVisualStyleBackColor = false;
            button_Folders.Click += button_Folders_Click;
            // 
            // button_Tags
            // 
            button_Tags.BackColor = Color.Transparent;
            button_Tags.Cursor = Cursors.Hand;
            button_Tags.FlatAppearance.BorderSize = 0;
            button_Tags.FlatStyle = FlatStyle.Flat;
            button_Tags.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            button_Tags.ForeColor = Color.White;
            button_Tags.Image = Properties.Resources.Button_Icon_Tags;
            button_Tags.Location = new Point(25, 290);
            button_Tags.Margin = new Padding(3, 2, 3, 2);
            button_Tags.Name = "button_Tags";
            button_Tags.Size = new Size(120, 40);
            button_Tags.TabIndex = 7;
            button_Tags.Text = "   Tags";
            button_Tags.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_Tags.UseVisualStyleBackColor = false;
            button_Tags.Click += button_Tags_Click;
            // 
            // button_Auth
            // 
            button_Auth.BackColor = Color.Transparent;
            button_Auth.Cursor = Cursors.Hand;
            button_Auth.FlatAppearance.BorderSize = 0;
            button_Auth.FlatStyle = FlatStyle.Flat;
            button_Auth.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            button_Auth.ForeColor = Color.White;
            button_Auth.Image = Properties.Resources.Button_Icon_Auth;
            button_Auth.Location = new Point(25, 224);
            button_Auth.Margin = new Padding(3, 2, 3, 2);
            button_Auth.Name = "button_Auth";
            button_Auth.Size = new Size(120, 40);
            button_Auth.TabIndex = 6;
            button_Auth.Text = "   Auth";
            button_Auth.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_Auth.UseVisualStyleBackColor = false;
            button_Auth.Click += button_Auth_Click;
            // 
            // button_Name
            // 
            button_Name.BackColor = Color.Transparent;
            button_Name.Cursor = Cursors.Hand;
            button_Name.FlatAppearance.BorderSize = 0;
            button_Name.FlatStyle = FlatStyle.Flat;
            button_Name.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            button_Name.ForeColor = Color.White;
            button_Name.Image = Properties.Resources.Button_Icon_Name;
            button_Name.Location = new Point(25, 158);
            button_Name.Margin = new Padding(3, 2, 3, 2);
            button_Name.Name = "button_Name";
            button_Name.Size = new Size(120, 40);
            button_Name.TabIndex = 4;
            button_Name.Text = "   Name";
            button_Name.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_Name.UseVisualStyleBackColor = false;
            button_Name.Click += button_Name_Click;
            // 
            // Panel_Index_Config
            // 
            Panel_Index_Config.BackColor = Color.Teal;
            Panel_Index_Config.Location = new Point(3, 26);
            Panel_Index_Config.Margin = new Padding(3, 2, 3, 2);
            Panel_Index_Config.Name = "Panel_Index_Config";
            Panel_Index_Config.Size = new Size(13, 40);
            Panel_Index_Config.TabIndex = 1;
            // 
            // button_Size
            // 
            button_Size.BackColor = Color.Transparent;
            button_Size.Cursor = Cursors.Hand;
            button_Size.FlatAppearance.BorderSize = 0;
            button_Size.FlatStyle = FlatStyle.Flat;
            button_Size.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            button_Size.ForeColor = Color.White;
            button_Size.Image = Properties.Resources.Button_Icon_Size;
            button_Size.Location = new Point(25, 92);
            button_Size.Margin = new Padding(3, 2, 3, 2);
            button_Size.Name = "button_Size";
            button_Size.Size = new Size(120, 40);
            button_Size.TabIndex = 2;
            button_Size.Text = "   Size";
            button_Size.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_Size.UseVisualStyleBackColor = false;
            button_Size.Click += button_Size_Click;
            // 
            // button_Type
            // 
            button_Type.BackColor = Color.Transparent;
            button_Type.Cursor = Cursors.Hand;
            button_Type.FlatAppearance.BorderSize = 0;
            button_Type.FlatStyle = FlatStyle.Flat;
            button_Type.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            button_Type.ForeColor = Color.White;
            button_Type.Image = Properties.Resources.Button_Icon_Folder;
            button_Type.Location = new Point(25, 26);
            button_Type.Margin = new Padding(3, 2, 3, 2);
            button_Type.Name = "button_Type";
            button_Type.Size = new Size(120, 40);
            button_Type.TabIndex = 0;
            button_Type.Text = "   Type";
            button_Type.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_Type.UseVisualStyleBackColor = false;
            button_Type.Click += button_Type_Click;
            // 
            // menu_Type1
            // 
            menu_Type1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            menu_Type1.BackColor = Color.FromArgb(64, 64, 64);
            menu_Type1.Dock = DockStyle.Fill;
            menu_Type1.ForeColor = Color.White;
            menu_Type1.Location = new Point(171, 0);
            menu_Type1.Margin = new Padding(3, 4, 3, 4);
            menu_Type1.Name = "menu_Type1";
            menu_Type1.Size = new Size(594, 541);
            menu_Type1.TabIndex = 2;
            // 
            // menu_Sizes1
            // 
            menu_Sizes1.BackColor = Color.FromArgb(64, 64, 64);
            menu_Sizes1.Dock = DockStyle.Fill;
            menu_Sizes1.Location = new Point(171, 0);
            menu_Sizes1.Margin = new Padding(3, 4, 3, 4);
            menu_Sizes1.Name = "menu_Sizes1";
            menu_Sizes1.Size = new Size(594, 541);
            menu_Sizes1.TabIndex = 3;
            // 
            // menu_Name1
            // 
            menu_Name1.BackColor = Color.FromArgb(64, 64, 64);
            menu_Name1.Dock = DockStyle.Fill;
            menu_Name1.Location = new Point(171, 0);
            menu_Name1.Name = "menu_Name1";
            menu_Name1.Size = new Size(594, 541);
            menu_Name1.TabIndex = 16;
            // 
            // menu_Auth1
            // 
            menu_Auth1.BackColor = Color.FromArgb(64, 64, 64);
            menu_Auth1.Dock = DockStyle.Fill;
            menu_Auth1.Location = new Point(171, 0);
            menu_Auth1.Name = "menu_Auth1";
            menu_Auth1.Size = new Size(594, 541);
            menu_Auth1.TabIndex = 16;
            // 
            // menu_Tags1
            // 
            menu_Tags1.BackColor = Color.FromArgb(64, 64, 64);
            menu_Tags1.Dock = DockStyle.Fill;
            menu_Tags1.Location = new Point(171, 0);
            menu_Tags1.Name = "menu_Tags1";
            menu_Tags1.Size = new Size(594, 541);
            menu_Tags1.TabIndex = 16;
            // 
            // menu_Folder1
            // 
            menu_Folder1.BackColor = Color.FromArgb(64, 64, 64);
            menu_Folder1.Dock = DockStyle.Fill;
            menu_Folder1.Location = new Point(171, 0);
            menu_Folder1.Name = "menu_Folder1";
            menu_Folder1.Size = new Size(594, 541);
            menu_Folder1.TabIndex = 16;
            // 
            // menu_Media1
            // 
            menu_Media1.BackColor = Color.FromArgb(64, 64, 64);
            menu_Media1.Dock = DockStyle.Fill;
            menu_Media1.Location = new Point(171, 0);
            menu_Media1.Name = "menu_Media1";
            menu_Media1.Size = new Size(594, 541);
            menu_Media1.TabIndex = 16;
            // 
            // Main_Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            Controls.Add(menu_Media1);
            Controls.Add(menu_Folder1);
            Controls.Add(menu_Tags1);
            Controls.Add(menu_Auth1);
            Controls.Add(menu_Name1);
            Controls.Add(menu_Type1);
            Controls.Add(menu_Sizes1);
            Controls.Add(panel_Menu_Config);
            Name = "Main_Menu";
            Size = new Size(765, 541);
            panel_Menu_Config.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_Menu_Config;
        private Panel Panel_Index_Config;
        private Button button_Size;
        private Button button_Type;
        private Menu_Type menu_Type1;
        private Menu_Sizes menu_Sizes1;
        private Button button_Folders;
        private Button button_Tags;
        private Button button_Auth;
        private Button button_Name;
        private Button button_Media;
        private Menu_Name menu_Name1;
        private Menu_Auth menu_Auth1;
        private Menu_Tags menu_Tags1;
        private Menu_Folder menu_Folder1;
        private Menu_Media menu_Media1;
    }
}
