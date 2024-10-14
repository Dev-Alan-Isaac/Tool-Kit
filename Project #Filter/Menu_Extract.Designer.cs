namespace Project__Filter
{
    partial class Menu_Extract
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
            components = new System.ComponentModel.Container();
            panel4 = new Panel();
            label1 = new Label();
            panel3 = new Panel();
            panel1 = new Panel();
            bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(components);
            button_Saved = new Button();
            panel10 = new Panel();
            checkBox_Delete = new CheckBox();
            checkBox_Subfolders = new CheckBox();
            panel5 = new Panel();
            panel6 = new Panel();
            panel8 = new Panel();
            label4 = new Label();
            radioButton_Folder = new RadioButton();
            radioButton_RootDecompress = new RadioButton();
            radioButton_Hash = new RadioButton();
            radioButton_Name = new RadioButton();
            panel7 = new Panel();
            radioButton_Group = new RadioButton();
            label3 = new Label();
            radioButton_Split = new RadioButton();
            radioButton_Root = new RadioButton();
            label2 = new Label();
            panel2 = new Panel();
            panel4.SuspendLayout();
            panel10.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel8.SuspendLayout();
            panel7.SuspendLayout();
            SuspendLayout();
            // 
            // panel4
            // 
            panel4.Controls.Add(label1);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 32);
            panel4.Name = "panel4";
            panel4.Size = new Size(579, 44);
            panel4.TabIndex = 70;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(316, 37);
            label1.TabIndex = 0;
            label1.Text = "ADDITIONAL OPTIONS:";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(0, 64, 64);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 482);
            panel3.Name = "panel3";
            panel3.Size = new Size(579, 32);
            panel3.TabIndex = 69;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 64, 64);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(579, 32);
            panel1.TabIndex = 67;
            // 
            // bunifuElipse1
            // 
            bunifuElipse1.ElipseRadius = 5;
            bunifuElipse1.TargetControl = button_Saved;
            // 
            // button_Saved
            // 
            button_Saved.BackColor = Color.Teal;
            button_Saved.BackgroundImage = Properties.Resources.Button_Icon_Save;
            button_Saved.BackgroundImageLayout = ImageLayout.Zoom;
            button_Saved.Dock = DockStyle.Fill;
            button_Saved.FlatAppearance.BorderSize = 0;
            button_Saved.FlatStyle = FlatStyle.Flat;
            button_Saved.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            button_Saved.ForeColor = Color.White;
            button_Saved.Location = new Point(0, 0);
            button_Saved.Margin = new Padding(3, 2, 3, 2);
            button_Saved.Name = "button_Saved";
            button_Saved.Size = new Size(570, 43);
            button_Saved.TabIndex = 52;
            button_Saved.UseVisualStyleBackColor = false;
            button_Saved.Click += button_Saved_Click;
            // 
            // panel10
            // 
            panel10.Controls.Add(button_Saved);
            panel10.Dock = DockStyle.Bottom;
            panel10.Location = new Point(0, 351);
            panel10.Name = "panel10";
            panel10.Size = new Size(570, 43);
            panel10.TabIndex = 57;
            // 
            // checkBox_Delete
            // 
            checkBox_Delete.AutoSize = true;
            checkBox_Delete.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            checkBox_Delete.ForeColor = SystemColors.Control;
            checkBox_Delete.Location = new Point(3, 3);
            checkBox_Delete.Name = "checkBox_Delete";
            checkBox_Delete.Size = new Size(214, 29);
            checkBox_Delete.TabIndex = 58;
            checkBox_Delete.Text = "Delete Empty Folders";
            checkBox_Delete.UseVisualStyleBackColor = true;
            // 
            // checkBox_Subfolders
            // 
            checkBox_Subfolders.AutoSize = true;
            checkBox_Subfolders.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            checkBox_Subfolders.ForeColor = SystemColors.Control;
            checkBox_Subfolders.Location = new Point(3, 49);
            checkBox_Subfolders.Name = "checkBox_Subfolders";
            checkBox_Subfolders.Size = new Size(255, 29);
            checkBox_Subfolders.TabIndex = 59;
            checkBox_Subfolders.Text = "Process Files in Subfolders";
            checkBox_Subfolders.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel5.Controls.Add(checkBox_Delete);
            panel5.Controls.Add(checkBox_Subfolders);
            panel5.Controls.Add(panel6);
            panel5.Controls.Add(panel10);
            panel5.Location = new Point(3, 82);
            panel5.Name = "panel5";
            panel5.Size = new Size(570, 394);
            panel5.TabIndex = 71;
            // 
            // panel6
            // 
            panel6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel6.Controls.Add(panel8);
            panel6.Controls.Add(radioButton_Hash);
            panel6.Controls.Add(radioButton_Name);
            panel6.Controls.Add(panel7);
            panel6.Controls.Add(label2);
            panel6.Location = new Point(3, 92);
            panel6.Name = "panel6";
            panel6.Size = new Size(564, 254);
            panel6.TabIndex = 60;
            // 
            // panel8
            // 
            panel8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel8.Controls.Add(label4);
            panel8.Controls.Add(radioButton_Folder);
            panel8.Controls.Add(radioButton_RootDecompress);
            panel8.Location = new Point(3, 161);
            panel8.Name = "panel8";
            panel8.Size = new Size(558, 84);
            panel8.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Top;
            label4.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            label4.ForeColor = SystemColors.Control;
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Size = new Size(152, 32);
            label4.TabIndex = 3;
            label4.Text = "Decompress:";
            // 
            // radioButton_Folder
            // 
            radioButton_Folder.AutoSize = true;
            radioButton_Folder.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            radioButton_Folder.ForeColor = SystemColors.Control;
            radioButton_Folder.Location = new Point(123, 44);
            radioButton_Folder.Name = "radioButton_Folder";
            radioButton_Folder.Size = new Size(84, 29);
            radioButton_Folder.TabIndex = 4;
            radioButton_Folder.TabStop = true;
            radioButton_Folder.Text = "Folder";
            radioButton_Folder.UseVisualStyleBackColor = true;
            // 
            // radioButton_RootDecompress
            // 
            radioButton_RootDecompress.AutoSize = true;
            radioButton_RootDecompress.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            radioButton_RootDecompress.ForeColor = SystemColors.Control;
            radioButton_RootDecompress.Location = new Point(3, 44);
            radioButton_RootDecompress.Name = "radioButton_RootDecompress";
            radioButton_RootDecompress.Size = new Size(70, 29);
            radioButton_RootDecompress.TabIndex = 3;
            radioButton_RootDecompress.TabStop = true;
            radioButton_RootDecompress.Text = "Root";
            radioButton_RootDecompress.UseVisualStyleBackColor = true;
            // 
            // radioButton_Hash
            // 
            radioButton_Hash.AutoSize = true;
            radioButton_Hash.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            radioButton_Hash.ForeColor = SystemColors.Control;
            radioButton_Hash.Location = new Point(155, 36);
            radioButton_Hash.Name = "radioButton_Hash";
            radioButton_Hash.Size = new Size(134, 29);
            radioButton_Hash.TabIndex = 9;
            radioButton_Hash.TabStop = true;
            radioButton_Hash.Text = "By File Hash";
            radioButton_Hash.UseVisualStyleBackColor = true;
            radioButton_Hash.CheckedChanged += radioButton_CheckedChanged;
            // 
            // radioButton_Name
            // 
            radioButton_Name.AutoSize = true;
            radioButton_Name.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            radioButton_Name.ForeColor = SystemColors.Control;
            radioButton_Name.Location = new Point(3, 35);
            radioButton_Name.Name = "radioButton_Name";
            radioButton_Name.Size = new Size(143, 29);
            radioButton_Name.TabIndex = 6;
            radioButton_Name.TabStop = true;
            radioButton_Name.Text = "By File Name";
            radioButton_Name.UseVisualStyleBackColor = true;
            radioButton_Name.CheckedChanged += radioButton_CheckedChanged;
            // 
            // panel7
            // 
            panel7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel7.Controls.Add(radioButton_Group);
            panel7.Controls.Add(label3);
            panel7.Controls.Add(radioButton_Split);
            panel7.Controls.Add(radioButton_Root);
            panel7.Location = new Point(3, 71);
            panel7.Name = "panel7";
            panel7.Size = new Size(558, 84);
            panel7.TabIndex = 4;
            // 
            // radioButton_Group
            // 
            radioButton_Group.AutoSize = true;
            radioButton_Group.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            radioButton_Group.ForeColor = SystemColors.Control;
            radioButton_Group.Location = new Point(241, 44);
            radioButton_Group.Name = "radioButton_Group";
            radioButton_Group.Size = new Size(83, 29);
            radioButton_Group.TabIndex = 5;
            radioButton_Group.TabStop = true;
            radioButton_Group.Text = "Group";
            radioButton_Group.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(113, 32);
            label3.TabIndex = 3;
            label3.Text = "Location:";
            // 
            // radioButton_Split
            // 
            radioButton_Split.AutoSize = true;
            radioButton_Split.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            radioButton_Split.ForeColor = SystemColors.Control;
            radioButton_Split.Location = new Point(123, 44);
            radioButton_Split.Name = "radioButton_Split";
            radioButton_Split.Size = new Size(68, 29);
            radioButton_Split.TabIndex = 4;
            radioButton_Split.TabStop = true;
            radioButton_Split.Text = "Split";
            radioButton_Split.UseVisualStyleBackColor = true;
            // 
            // radioButton_Root
            // 
            radioButton_Root.AutoSize = true;
            radioButton_Root.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            radioButton_Root.ForeColor = SystemColors.Control;
            radioButton_Root.Location = new Point(3, 44);
            radioButton_Root.Name = "radioButton_Root";
            radioButton_Root.Size = new Size(70, 29);
            radioButton_Root.TabIndex = 3;
            radioButton_Root.TabStop = true;
            radioButton_Root.Text = "Root";
            radioButton_Root.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(89, 32);
            label2.TabIndex = 0;
            label2.Text = "Extract";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 64, 64);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(579, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(32, 514);
            panel2.TabIndex = 68;
            // 
            // Menu_Extract
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(panel5);
            Controls.Add(panel2);
            Name = "Menu_Extract";
            Size = new Size(611, 514);
            Load += Menu_Extract_Load;
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel10.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel4;
        private Label label1;
        private Panel panel3;
        private Panel panel1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Button button_Saved;
        private Panel panel10;
        private CheckBox checkBox_Delete;
        private CheckBox checkBox_Subfolders;
        private Panel panel5;
        private Panel panel2;
        private Panel panel6;
        private Panel panel7;
        private RadioButton radioButton_Group;
        private Label label3;
        private RadioButton radioButton_Split;
        private RadioButton radioButton_Root;
        private Label label2;
        private RadioButton radioButton_Hash;
        private RadioButton radioButton_Name;
        private Panel panel8;
        private Label label4;
        private RadioButton radioButton_Folder;
        private RadioButton radioButton_RootDecompress;
    }
}
