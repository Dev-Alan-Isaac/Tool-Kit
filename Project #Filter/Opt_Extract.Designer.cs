namespace Project__Filter
{
    partial class Opt_Extract
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
            label3 = new Label();
            panel_Options = new Panel();
            panel1 = new Panel();
            radioButton_Locate = new RadioButton();
            radioButton_Split = new RadioButton();
            radioButton_Zip = new RadioButton();
            radioButton_Tar = new RadioButton();
            radioButton_Rar = new RadioButton();
            radioButton_Relocate = new RadioButton();
            panel3 = new Panel();
            treeView1 = new TreeView();
            panel4 = new Panel();
            File_Count = new Label();
            label4 = new Label();
            panel_Footer = new Panel();
            button_Filter = new Button();
            progressBar_Time = new ProgressBar();
            panel2 = new Panel();
            panel_Header = new Panel();
            label1 = new Label();
            textBox_Path = new TextBox();
            label_Warning = new Label();
            panel_Right = new Panel();
            panel_Bottom = new Panel();
            button_Path = new Button();
            panel_Top = new Panel();
            bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(components);
            bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(components);
            bunifuElipse3 = new Bunifu.Framework.UI.BunifuElipse(components);
            panel_Options.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel_Footer.SuspendLayout();
            panel_Header.SuspendLayout();
            panel_Top.SuspendLayout();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(300, 32);
            label3.TabIndex = 10;
            label3.Text = "Select the extract option:";
            // 
            // panel_Options
            // 
            panel_Options.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_Options.Controls.Add(panel1);
            panel_Options.Controls.Add(panel3);
            panel_Options.Location = new Point(0, 81);
            panel_Options.Margin = new Padding(3, 2, 3, 2);
            panel_Options.Name = "panel_Options";
            panel_Options.Size = new Size(667, 385);
            panel_Options.TabIndex = 39;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(radioButton_Locate);
            panel1.Controls.Add(radioButton_Split);
            panel1.Controls.Add(radioButton_Zip);
            panel1.Controls.Add(radioButton_Tar);
            panel1.Controls.Add(radioButton_Rar);
            panel1.Controls.Add(radioButton_Relocate);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(3, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(323, 380);
            panel1.TabIndex = 60;
            // 
            // radioButton_Locate
            // 
            radioButton_Locate.AutoSize = true;
            radioButton_Locate.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            radioButton_Locate.ForeColor = SystemColors.Control;
            radioButton_Locate.Location = new Point(3, 53);
            radioButton_Locate.Name = "radioButton_Locate";
            radioButton_Locate.Size = new Size(129, 29);
            radioButton_Locate.TabIndex = 16;
            radioButton_Locate.TabStop = true;
            radioButton_Locate.Text = "Locate Files";
            radioButton_Locate.UseVisualStyleBackColor = true;
            radioButton_Locate.CheckedChanged += radioButton_CheckedChanged;
            // 
            // radioButton_Split
            // 
            radioButton_Split.AutoSize = true;
            radioButton_Split.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            radioButton_Split.ForeColor = SystemColors.Control;
            radioButton_Split.Location = new Point(3, 123);
            radioButton_Split.Name = "radioButton_Split";
            radioButton_Split.Size = new Size(209, 29);
            radioButton_Split.TabIndex = 15;
            radioButton_Split.TabStop = true;
            radioButton_Split.Text = "Locate and Split Files";
            radioButton_Split.UseVisualStyleBackColor = true;
            radioButton_Split.CheckedChanged += radioButton_CheckedChanged;
            // 
            // radioButton_Zip
            // 
            radioButton_Zip.AutoSize = true;
            radioButton_Zip.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            radioButton_Zip.ForeColor = SystemColors.Control;
            radioButton_Zip.Location = new Point(3, 292);
            radioButton_Zip.Name = "radioButton_Zip";
            radioButton_Zip.Size = new Size(208, 29);
            radioButton_Zip.TabIndex = 14;
            radioButton_Zip.TabStop = true;
            radioButton_Zip.Text = "Decompress ZIP files";
            radioButton_Zip.UseVisualStyleBackColor = true;
            radioButton_Zip.CheckedChanged += radioButton_CheckedChanged;
            // 
            // radioButton_Tar
            // 
            radioButton_Tar.AutoSize = true;
            radioButton_Tar.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            radioButton_Tar.ForeColor = SystemColors.Control;
            radioButton_Tar.Location = new Point(3, 343);
            radioButton_Tar.Name = "radioButton_Tar";
            radioButton_Tar.Size = new Size(214, 29);
            radioButton_Tar.TabIndex = 13;
            radioButton_Tar.TabStop = true;
            radioButton_Tar.Text = "Decompress TAR files";
            radioButton_Tar.UseVisualStyleBackColor = true;
            radioButton_Tar.CheckedChanged += radioButton_CheckedChanged;
            // 
            // radioButton_Rar
            // 
            radioButton_Rar.AutoSize = true;
            radioButton_Rar.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            radioButton_Rar.ForeColor = SystemColors.Control;
            radioButton_Rar.Location = new Point(3, 241);
            radioButton_Rar.Name = "radioButton_Rar";
            radioButton_Rar.Size = new Size(217, 29);
            radioButton_Rar.TabIndex = 12;
            radioButton_Rar.TabStop = true;
            radioButton_Rar.Text = "Decompress RAR files";
            radioButton_Rar.UseVisualStyleBackColor = true;
            radioButton_Rar.CheckedChanged += radioButton_CheckedChanged;
            // 
            // radioButton_Relocate
            // 
            radioButton_Relocate.AutoSize = true;
            radioButton_Relocate.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            radioButton_Relocate.ForeColor = SystemColors.Control;
            radioButton_Relocate.Location = new Point(3, 88);
            radioButton_Relocate.Name = "radioButton_Relocate";
            radioButton_Relocate.Size = new Size(244, 29);
            radioButton_Relocate.TabIndex = 11;
            radioButton_Relocate.TabStop = true;
            radioButton_Relocate.Text = "Locate and Relocate Files";
            radioButton_Relocate.UseVisualStyleBackColor = true;
            radioButton_Relocate.CheckedChanged += radioButton_CheckedChanged;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel3.AutoScroll = true;
            panel3.Controls.Add(treeView1);
            panel3.Controls.Add(panel4);
            panel3.Location = new Point(332, 5);
            panel3.Name = "panel3";
            panel3.Size = new Size(330, 375);
            panel3.TabIndex = 59;
            // 
            // treeView1
            // 
            treeView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            treeView1.Location = new Point(76, 67);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(250, 305);
            treeView1.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.Controls.Add(File_Count);
            panel4.Controls.Add(label4);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(330, 61);
            panel4.TabIndex = 0;
            // 
            // File_Count
            // 
            File_Count.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            File_Count.AutoSize = true;
            File_Count.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            File_Count.ForeColor = SystemColors.Control;
            File_Count.Location = new Point(76, 30);
            File_Count.Name = "File_Count";
            File_Count.Size = new Size(23, 25);
            File_Count.TabIndex = 1;
            File_Count.Text = "0";
            File_Count.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.Control;
            label4.Location = new Point(76, 0);
            label4.Name = "label4";
            label4.Size = new Size(119, 30);
            label4.TabIndex = 0;
            label4.Text = "File Count:";
            // 
            // panel_Footer
            // 
            panel_Footer.Controls.Add(button_Filter);
            panel_Footer.Controls.Add(progressBar_Time);
            panel_Footer.Dock = DockStyle.Bottom;
            panel_Footer.Location = new Point(0, 466);
            panel_Footer.Margin = new Padding(3, 2, 3, 2);
            panel_Footer.Name = "panel_Footer";
            panel_Footer.Size = new Size(667, 64);
            panel_Footer.TabIndex = 38;
            // 
            // button_Filter
            // 
            button_Filter.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button_Filter.BackColor = Color.Teal;
            button_Filter.BackgroundImage = Properties.Resources.Button_Icon_Start;
            button_Filter.BackgroundImageLayout = ImageLayout.Zoom;
            button_Filter.Cursor = Cursors.Hand;
            button_Filter.Enabled = false;
            button_Filter.FlatAppearance.BorderSize = 0;
            button_Filter.FlatStyle = FlatStyle.Flat;
            button_Filter.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            button_Filter.ForeColor = Color.White;
            button_Filter.Location = new Point(3, 6);
            button_Filter.Margin = new Padding(3, 2, 3, 2);
            button_Filter.Name = "button_Filter";
            button_Filter.Size = new Size(659, 26);
            button_Filter.TabIndex = 28;
            button_Filter.UseVisualStyleBackColor = false;
            button_Filter.Click += button_Filter_Click;
            // 
            // progressBar_Time
            // 
            progressBar_Time.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressBar_Time.Location = new Point(3, 38);
            progressBar_Time.Margin = new Padding(3, 2, 3, 2);
            progressBar_Time.Name = "progressBar_Time";
            progressBar_Time.Size = new Size(659, 22);
            progressBar_Time.Step = 1;
            progressBar_Time.TabIndex = 24;
            // 
            // panel2
            // 
            panel2.Location = new Point(332, 49);
            panel2.Name = "panel2";
            panel2.Size = new Size(329, 380);
            panel2.TabIndex = 59;
            // 
            // panel_Header
            // 
            panel_Header.Controls.Add(panel2);
            panel_Header.Controls.Add(label1);
            panel_Header.Controls.Add(textBox_Path);
            panel_Header.Controls.Add(label_Warning);
            panel_Header.Dock = DockStyle.Top;
            panel_Header.Location = new Point(0, 32);
            panel_Header.Margin = new Padding(3, 2, 3, 2);
            panel_Header.Name = "panel_Header";
            panel_Header.Size = new Size(667, 49);
            panel_Header.TabIndex = 37;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(64, 64, 64);
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(71, 32);
            label1.TabIndex = 23;
            label1.Text = "Path:";
            // 
            // textBox_Path
            // 
            textBox_Path.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox_Path.BackColor = Color.FromArgb(64, 64, 64);
            textBox_Path.BorderStyle = BorderStyle.FixedSingle;
            textBox_Path.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            textBox_Path.ForeColor = Color.White;
            textBox_Path.Location = new Point(86, 4);
            textBox_Path.Margin = new Padding(3, 2, 3, 2);
            textBox_Path.Name = "textBox_Path";
            textBox_Path.ReadOnly = true;
            textBox_Path.Size = new Size(572, 33);
            textBox_Path.TabIndex = 25;
            // 
            // label_Warning
            // 
            label_Warning.Anchor = AnchorStyles.Top;
            label_Warning.AutoSize = true;
            label_Warning.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            label_Warning.ForeColor = Color.FromArgb(255, 128, 0);
            label_Warning.Location = new Point(236, 43);
            label_Warning.Name = "label_Warning";
            label_Warning.Size = new Size(0, 21);
            label_Warning.TabIndex = 29;
            // 
            // panel_Right
            // 
            panel_Right.BackColor = Color.FromArgb(0, 64, 64);
            panel_Right.Dock = DockStyle.Right;
            panel_Right.Location = new Point(667, 32);
            panel_Right.Margin = new Padding(3, 2, 3, 2);
            panel_Right.Name = "panel_Right";
            panel_Right.Size = new Size(32, 498);
            panel_Right.TabIndex = 36;
            // 
            // panel_Bottom
            // 
            panel_Bottom.BackColor = Color.FromArgb(0, 64, 64);
            panel_Bottom.Dock = DockStyle.Bottom;
            panel_Bottom.Location = new Point(0, 530);
            panel_Bottom.Margin = new Padding(3, 2, 3, 2);
            panel_Bottom.Name = "panel_Bottom";
            panel_Bottom.Size = new Size(699, 32);
            panel_Bottom.TabIndex = 35;
            // 
            // button_Path
            // 
            button_Path.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_Path.BackColor = Color.FromArgb(0, 64, 64);
            button_Path.BackgroundImage = Properties.Resources.Button_Icon_AddFile;
            button_Path.BackgroundImageLayout = ImageLayout.Zoom;
            button_Path.Cursor = Cursors.Hand;
            button_Path.FlatAppearance.BorderSize = 0;
            button_Path.FlatStyle = FlatStyle.Flat;
            button_Path.Location = new Point(635, 4);
            button_Path.Margin = new Padding(3, 2, 3, 2);
            button_Path.Name = "button_Path";
            button_Path.Size = new Size(25, 25);
            button_Path.TabIndex = 0;
            button_Path.UseVisualStyleBackColor = false;
            button_Path.Click += button_Path_Click;
            // 
            // panel_Top
            // 
            panel_Top.BackColor = Color.FromArgb(0, 64, 64);
            panel_Top.Controls.Add(button_Path);
            panel_Top.Dock = DockStyle.Top;
            panel_Top.Location = new Point(0, 0);
            panel_Top.Margin = new Padding(3, 2, 3, 2);
            panel_Top.Name = "panel_Top";
            panel_Top.Size = new Size(699, 32);
            panel_Top.TabIndex = 34;
            // 
            // bunifuElipse1
            // 
            bunifuElipse1.ElipseRadius = 5;
            bunifuElipse1.TargetControl = button_Filter;
            // 
            // bunifuElipse2
            // 
            bunifuElipse2.ElipseRadius = 5;
            bunifuElipse2.TargetControl = progressBar_Time;
            // 
            // bunifuElipse3
            // 
            bunifuElipse3.ElipseRadius = 5;
            bunifuElipse3.TargetControl = treeView1;
            // 
            // Opt_Extract
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            Controls.Add(panel_Options);
            Controls.Add(panel_Footer);
            Controls.Add(panel_Header);
            Controls.Add(panel_Right);
            Controls.Add(panel_Bottom);
            Controls.Add(panel_Top);
            Name = "Opt_Extract";
            Size = new Size(699, 562);
            panel_Options.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel_Footer.ResumeLayout(false);
            panel_Header.ResumeLayout(false);
            panel_Header.PerformLayout();
            panel_Top.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label3;
        private Panel panel_Options;
        private Panel panel1;
        private Panel panel3;
        private TreeView treeView1;
        private Panel panel4;
        private Label File_Count;
        private Label label4;
        private Panel panel_Footer;
        private Button button_Filter;
        private ProgressBar progressBar_Time;
        private Panel panel2;
        private Panel panel_Header;
        private Label label1;
        private TextBox textBox_Path;
        private Label label_Warning;
        private Panel panel_Right;
        private Panel panel_Bottom;
        private Button button_Path;
        private Panel panel_Top;
        private RadioButton radioButton_Relocate;
        private RadioButton radioButton_Rar;
        private RadioButton radioButton_Zip;
        private RadioButton radioButton_Tar;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse3;
        private RadioButton radioButton_Split;
        private RadioButton radioButton_Locate;
    }
}
