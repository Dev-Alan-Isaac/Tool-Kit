namespace Project__Filter
{
    partial class Menu_Folders
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
            listBox_Folders = new ListBox();
            listBox_Extension = new ListBox();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            radioButton_Extension = new RadioButton();
            radioButton_Folder = new RadioButton();
            button_Add = new Button();
            button_Remove = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // listBox_Folders
            // 
            listBox_Folders.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listBox_Folders.BackColor = Color.Gray;
            listBox_Folders.BorderStyle = BorderStyle.None;
            listBox_Folders.Cursor = Cursors.Hand;
            listBox_Folders.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            listBox_Folders.ForeColor = Color.White;
            listBox_Folders.FormattingEnabled = true;
            listBox_Folders.ItemHeight = 24;
            listBox_Folders.Location = new Point(3, 32);
            listBox_Folders.Margin = new Padding(3, 4, 3, 4);
            listBox_Folders.Name = "listBox_Folders";
            listBox_Folders.Size = new Size(440, 288);
            listBox_Folders.TabIndex = 40;
            listBox_Folders.SelectedIndexChanged += listBox_Folders_SelectedIndexChanged;
            // 
            // listBox_Extension
            // 
            listBox_Extension.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            listBox_Extension.BackColor = Color.Gray;
            listBox_Extension.BorderStyle = BorderStyle.None;
            listBox_Extension.Cursor = Cursors.Hand;
            listBox_Extension.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            listBox_Extension.ForeColor = Color.White;
            listBox_Extension.FormattingEnabled = true;
            listBox_Extension.ItemHeight = 24;
            listBox_Extension.Location = new Point(449, 32);
            listBox_Extension.Margin = new Padding(3, 4, 3, 4);
            listBox_Extension.Name = "listBox_Extension";
            listBox_Extension.Size = new Size(209, 288);
            listBox_Extension.TabIndex = 41;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 64, 64);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(698, 43);
            panel1.TabIndex = 51;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 64, 64);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(661, 43);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(37, 450);
            panel2.TabIndex = 52;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(0, 64, 64);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 450);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(661, 43);
            panel3.TabIndex = 53;
            // 
            // groupBox1
            // 
            groupBox1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(listBox_Folders);
            groupBox1.Controls.Add(listBox_Extension);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(0, 43);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(661, 407);
            groupBox1.TabIndex = 54;
            groupBox1.TabStop = false;
            groupBox1.Text = "Folder / Extension";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(radioButton_Extension);
            groupBox2.Controls.Add(radioButton_Folder);
            groupBox2.Controls.Add(button_Add);
            groupBox2.Controls.Add(button_Remove);
            groupBox2.Dock = DockStyle.Bottom;
            groupBox2.ForeColor = Color.White;
            groupBox2.Location = new Point(3, 324);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(655, 80);
            groupBox2.TabIndex = 53;
            groupBox2.TabStop = false;
            groupBox2.Text = "Merge";
            // 
            // radioButton_Extension
            // 
            radioButton_Extension.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            radioButton_Extension.AutoSize = true;
            radioButton_Extension.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            radioButton_Extension.ForeColor = Color.White;
            radioButton_Extension.Location = new Point(529, 34);
            radioButton_Extension.Margin = new Padding(3, 4, 3, 4);
            radioButton_Extension.Name = "radioButton_Extension";
            radioButton_Extension.Size = new Size(120, 29);
            radioButton_Extension.TabIndex = 49;
            radioButton_Extension.TabStop = true;
            radioButton_Extension.Text = "Extension";
            radioButton_Extension.UseVisualStyleBackColor = true;
            // 
            // radioButton_Folder
            // 
            radioButton_Folder.AutoSize = true;
            radioButton_Folder.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            radioButton_Folder.ForeColor = Color.White;
            radioButton_Folder.Location = new Point(19, 34);
            radioButton_Folder.Margin = new Padding(3, 4, 3, 4);
            radioButton_Folder.Name = "radioButton_Folder";
            radioButton_Folder.Size = new Size(90, 29);
            radioButton_Folder.TabIndex = 48;
            radioButton_Folder.TabStop = true;
            radioButton_Folder.Text = "Folder";
            radioButton_Folder.UseVisualStyleBackColor = true;
            // 
            // button_Add
            // 
            button_Add.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button_Add.BackColor = Color.Teal;
            button_Add.BackgroundImage = Properties.Resources.icons8_add_50;
            button_Add.BackgroundImageLayout = ImageLayout.Zoom;
            button_Add.FlatAppearance.BorderSize = 0;
            button_Add.FlatStyle = FlatStyle.Flat;
            button_Add.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            button_Add.ForeColor = Color.White;
            button_Add.Location = new Point(191, 22);
            button_Add.Name = "button_Add";
            button_Add.Size = new Size(146, 52);
            button_Add.TabIndex = 52;
            button_Add.UseVisualStyleBackColor = false;
            button_Add.Click += button_Add_Click_1;
            // 
            // button_Remove
            // 
            button_Remove.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button_Remove.BackColor = Color.Teal;
            button_Remove.BackgroundImage = Properties.Resources.icons8_remove_50;
            button_Remove.BackgroundImageLayout = ImageLayout.Zoom;
            button_Remove.FlatAppearance.BorderSize = 0;
            button_Remove.FlatStyle = FlatStyle.Flat;
            button_Remove.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            button_Remove.ForeColor = Color.White;
            button_Remove.Location = new Point(349, 22);
            button_Remove.Name = "button_Remove";
            button_Remove.Size = new Size(146, 52);
            button_Remove.TabIndex = 51;
            button_Remove.UseVisualStyleBackColor = false;
            button_Remove.Click += button_Remove_Click_1;
            // 
            // Menu_Folders
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            Controls.Add(groupBox1);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            ForeColor = Color.White;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Menu_Folders";
            Size = new Size(698, 493);
            Load += Config_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private ListBox listBox_Folders;
        private ListBox listBox_Extension;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private RadioButton radioButton_Extension;
        private RadioButton radioButton_Folder;
        private Button button_Remove;
        private Button button_Add;
    }
}
