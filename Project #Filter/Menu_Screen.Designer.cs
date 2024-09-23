namespace Project__Filter
{
    partial class Menu_Screen
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
            Panel_Index_Config = new Panel();
            button_Size = new Button();
            button_Folder = new Button();
            config_Folders1 = new Menu_Type();
            config_Sizes1 = new Menu_Sizes();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            panel_Menu_Config.SuspendLayout();
            SuspendLayout();
            // 
            // panel_Menu_Config
            // 
            panel_Menu_Config.BackColor = Color.FromArgb(0, 64, 64);
            panel_Menu_Config.Controls.Add(button5);
            panel_Menu_Config.Controls.Add(button6);
            panel_Menu_Config.Controls.Add(button3);
            panel_Menu_Config.Controls.Add(button4);
            panel_Menu_Config.Controls.Add(button1);
            panel_Menu_Config.Controls.Add(button2);
            panel_Menu_Config.Controls.Add(Panel_Index_Config);
            panel_Menu_Config.Controls.Add(button_Size);
            panel_Menu_Config.Controls.Add(button_Folder);
            panel_Menu_Config.Dock = DockStyle.Left;
            panel_Menu_Config.Location = new Point(0, 0);
            panel_Menu_Config.Margin = new Padding(3, 2, 3, 2);
            panel_Menu_Config.Name = "panel_Menu_Config";
            panel_Menu_Config.Size = new Size(160, 422);
            panel_Menu_Config.TabIndex = 1;
            // 
            // Panel_Index_Config
            // 
            Panel_Index_Config.BackColor = Color.Teal;
            Panel_Index_Config.Location = new Point(3, 26);
            Panel_Index_Config.Margin = new Padding(3, 2, 3, 2);
            Panel_Index_Config.Name = "Panel_Index_Config";
            Panel_Index_Config.Size = new Size(22, 40);
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
            button_Size.Image = Properties.Resources.Button_Icon_Aspect;
            button_Size.Location = new Point(30, 70);
            button_Size.Margin = new Padding(3, 2, 3, 2);
            button_Size.Name = "button_Size";
            button_Size.Size = new Size(120, 40);
            button_Size.TabIndex = 2;
            button_Size.Text = "    Size";
            button_Size.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_Size.UseVisualStyleBackColor = false;
            button_Size.Click += button_Size_Click;
            // 
            // button_Folder
            // 
            button_Folder.BackColor = Color.Transparent;
            button_Folder.Cursor = Cursors.Hand;
            button_Folder.FlatAppearance.BorderSize = 0;
            button_Folder.FlatStyle = FlatStyle.Flat;
            button_Folder.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            button_Folder.ForeColor = Color.White;
            button_Folder.Image = Properties.Resources.Button_Icon_Folder;
            button_Folder.Location = new Point(30, 26);
            button_Folder.Margin = new Padding(3, 2, 3, 2);
            button_Folder.Name = "button_Folder";
            button_Folder.Size = new Size(120, 40);
            button_Folder.TabIndex = 0;
            button_Folder.Text = "    Type";
            button_Folder.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_Folder.UseVisualStyleBackColor = false;
            button_Folder.Click += button_Folder_Click;
            // 
            // config_Folders1
            // 
            config_Folders1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            config_Folders1.BackColor = Color.FromArgb(64, 64, 64);
            config_Folders1.Dock = DockStyle.Fill;
            config_Folders1.ForeColor = Color.White;
            config_Folders1.Location = new Point(160, 0);
            config_Folders1.Margin = new Padding(3, 4, 3, 4);
            config_Folders1.Name = "config_Folders1";
            config_Folders1.Size = new Size(516, 422);
            config_Folders1.TabIndex = 2;
            // 
            // config_Sizes1
            // 
            config_Sizes1.BackColor = Color.FromArgb(64, 64, 64);
            config_Sizes1.Dock = DockStyle.Fill;
            config_Sizes1.Location = new Point(160, 0);
            config_Sizes1.Margin = new Padding(3, 4, 3, 4);
            config_Sizes1.Name = "config_Sizes1";
            config_Sizes1.Size = new Size(516, 422);
            config_Sizes1.TabIndex = 3;
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Image = Properties.Resources.Button_Icon_Aspect;
            button1.Location = new Point(30, 158);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(120, 40);
            button1.TabIndex = 4;
            button1.Text = "   WIP";
            button1.TextImageRelation = TextImageRelation.ImageBeforeText;
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.Cursor = Cursors.Hand;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            button2.ForeColor = Color.White;
            button2.Image = Properties.Resources.Button_Icon_Folder;
            button2.Location = new Point(30, 114);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(120, 40);
            button2.TabIndex = 3;
            button2.Text = "   WIP";
            button2.TextImageRelation = TextImageRelation.ImageBeforeText;
            button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.Transparent;
            button3.Cursor = Cursors.Hand;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            button3.ForeColor = Color.White;
            button3.Image = Properties.Resources.Button_Icon_Aspect;
            button3.Location = new Point(30, 246);
            button3.Margin = new Padding(3, 2, 3, 2);
            button3.Name = "button3";
            button3.Size = new Size(120, 40);
            button3.TabIndex = 6;
            button3.Text = "   WIP";
            button3.TextImageRelation = TextImageRelation.ImageBeforeText;
            button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.Transparent;
            button4.Cursor = Cursors.Hand;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            button4.ForeColor = Color.White;
            button4.Image = Properties.Resources.Button_Icon_Folder;
            button4.Location = new Point(30, 202);
            button4.Margin = new Padding(3, 2, 3, 2);
            button4.Name = "button4";
            button4.Size = new Size(120, 40);
            button4.TabIndex = 5;
            button4.Text = "   WIP";
            button4.TextImageRelation = TextImageRelation.ImageBeforeText;
            button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            button5.BackColor = Color.Transparent;
            button5.Cursor = Cursors.Hand;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            button5.ForeColor = Color.White;
            button5.Image = Properties.Resources.Button_Icon_Aspect;
            button5.Location = new Point(30, 334);
            button5.Margin = new Padding(3, 2, 3, 2);
            button5.Name = "button5";
            button5.Size = new Size(120, 40);
            button5.TabIndex = 8;
            button5.Text = "   WIP";
            button5.TextImageRelation = TextImageRelation.ImageBeforeText;
            button5.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            button6.BackColor = Color.Transparent;
            button6.Cursor = Cursors.Hand;
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            button6.ForeColor = Color.White;
            button6.Image = Properties.Resources.Button_Icon_Folder;
            button6.Location = new Point(30, 290);
            button6.Margin = new Padding(3, 2, 3, 2);
            button6.Name = "button6";
            button6.Size = new Size(120, 40);
            button6.TabIndex = 7;
            button6.Text = "   WIP";
            button6.TextImageRelation = TextImageRelation.ImageBeforeText;
            button6.UseVisualStyleBackColor = false;
            // 
            // Menu_Config
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            Controls.Add(config_Folders1);
            Controls.Add(config_Sizes1);
            Controls.Add(panel_Menu_Config);
            Name = "Menu_Config";
            Size = new Size(676, 422);
            panel_Menu_Config.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_Menu_Config;
        private Panel Panel_Index_Config;
        private Button button_Size;
        private Button button_Folder;
        private Menu_Type config_Folders1;
        private Menu_Sizes config_Sizes1;
        private Button button5;
        private Button button6;
        private Button button3;
        private Button button4;
        private Button button1;
        private Button button2;
    }
}
