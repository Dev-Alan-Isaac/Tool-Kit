namespace Project__Filter
{
    partial class Menu_Config
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
            config_Folders1 = new Menu_Folders();
            config_Sizes1 = new Menu_Sizes();
            panel_Menu_Config.SuspendLayout();
            SuspendLayout();
            // 
            // panel_Menu_Config
            // 
            panel_Menu_Config.BackColor = Color.FromArgb(0, 64, 64);
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
            button_Size.Text = "    WIP";
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
            button_Folder.Text = "    Folder";
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
        private Menu_Folders config_Folders1;
        private Menu_Sizes config_Sizes1;
    }
}
