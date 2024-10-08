namespace Project__Filter
{
    partial class Opt_Sort
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            panel_Top = new Panel();
            button_Path = new Button();
            panel_Bottom = new Panel();
            panel_Right = new Panel();
            label1 = new Label();
            textBox_Path = new TextBox();
            button_Filter = new Button();
            progressBar_Time = new ProgressBar();
            label_Warning = new Label();
            panel_Header = new Panel();
            panel2 = new Panel();
            panel_Footer = new Panel();
            panel3 = new Panel();
            treeView1 = new TreeView();
            panel4 = new Panel();
            File_Count = new Label();
            label4 = new Label();
            panel_Options = new Panel();
            panel1 = new Panel();
            label3 = new Label();
            checkBox9 = new CheckBox();
            checkBox7 = new CheckBox();
            checkBox8 = new CheckBox();
            checkBox6 = new CheckBox();
            checkBox5 = new CheckBox();
            checkBox4 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox1 = new CheckBox();
            panel_Top.SuspendLayout();
            panel_Header.SuspendLayout();
            panel_Footer.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel_Options.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
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
            panel_Top.TabIndex = 4;
            // 
            // button_Path
            // 
            button_Path.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_Path.BackColor = Color.FromArgb(0, 64, 64);
            button_Path.BackgroundImage = Properties.Resources.Button_Icon_AddFile;
            button_Path.BackgroundImageLayout = ImageLayout.Zoom;
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
            // panel_Bottom
            // 
            panel_Bottom.BackColor = Color.FromArgb(0, 64, 64);
            panel_Bottom.Dock = DockStyle.Bottom;
            panel_Bottom.Location = new Point(0, 530);
            panel_Bottom.Margin = new Padding(3, 2, 3, 2);
            panel_Bottom.Name = "panel_Bottom";
            panel_Bottom.Size = new Size(699, 32);
            panel_Bottom.TabIndex = 5;
            // 
            // panel_Right
            // 
            panel_Right.BackColor = Color.FromArgb(0, 64, 64);
            panel_Right.Dock = DockStyle.Right;
            panel_Right.Location = new Point(667, 32);
            panel_Right.Margin = new Padding(3, 2, 3, 2);
            panel_Right.Name = "panel_Right";
            panel_Right.Size = new Size(32, 498);
            panel_Right.TabIndex = 7;
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
            // button_Filter
            // 
            button_Filter.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button_Filter.BackColor = Color.Teal;
            button_Filter.BackgroundImage = Properties.Resources.Button_Icon_Start;
            button_Filter.BackgroundImageLayout = ImageLayout.Zoom;
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
            button_Filter.Click += button_Filter_Click_1;
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
            // label_Warning
            // 
            label_Warning.Anchor = AnchorStyles.Top;
            label_Warning.AutoSize = true;
            label_Warning.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            label_Warning.ForeColor = Color.FromArgb(255, 128, 0);
            label_Warning.Location = new Point(3, 43);
            label_Warning.Name = "label_Warning";
            label_Warning.Size = new Size(0, 21);
            label_Warning.TabIndex = 29;
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
            panel_Header.TabIndex = 30;
            // 
            // panel2
            // 
            panel2.Location = new Point(332, 49);
            panel2.Name = "panel2";
            panel2.Size = new Size(329, 380);
            panel2.TabIndex = 59;
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
            panel_Footer.TabIndex = 32;
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
            // panel_Options
            // 
            panel_Options.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_Options.Controls.Add(panel1);
            panel_Options.Controls.Add(panel3);
            panel_Options.Location = new Point(0, 81);
            panel_Options.Margin = new Padding(3, 2, 3, 2);
            panel_Options.Name = "panel_Options";
            panel_Options.Size = new Size(667, 385);
            panel_Options.TabIndex = 33;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(checkBox9);
            panel1.Controls.Add(checkBox7);
            panel1.Controls.Add(checkBox8);
            panel1.Controls.Add(checkBox6);
            panel1.Controls.Add(checkBox5);
            panel1.Controls.Add(checkBox4);
            panel1.Controls.Add(checkBox3);
            panel1.Controls.Add(checkBox2);
            panel1.Controls.Add(checkBox1);
            panel1.Location = new Point(3, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(323, 380);
            panel1.TabIndex = 60;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(267, 32);
            label3.TabIndex = 10;
            label3.Text = "Select the sort option:";
            // 
            // checkBox9
            // 
            checkBox9.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            checkBox9.AutoSize = true;
            checkBox9.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            checkBox9.ForeColor = SystemColors.Control;
            checkBox9.Location = new Point(94, 348);
            checkBox9.Name = "checkBox9";
            checkBox9.Size = new Size(173, 29);
            checkBox9.TabIndex = 7;
            checkBox9.Text = "Media Metadata";
            checkBox9.UseVisualStyleBackColor = true;
            checkBox9.CheckedChanged += checkBox_CheckedChanged;
            // 
            // checkBox7
            // 
            checkBox7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            checkBox7.AutoSize = true;
            checkBox7.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            checkBox7.ForeColor = SystemColors.Control;
            checkBox7.Location = new Point(181, 313);
            checkBox7.Name = "checkBox7";
            checkBox7.Size = new Size(139, 29);
            checkBox7.TabIndex = 6;
            checkBox7.Text = "Custom Tags";
            checkBox7.UseVisualStyleBackColor = true;
            checkBox7.CheckedChanged += checkBox_CheckedChanged;
            // 
            // checkBox8
            // 
            checkBox8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            checkBox8.AutoSize = true;
            checkBox8.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            checkBox8.ForeColor = SystemColors.Control;
            checkBox8.Location = new Point(5, 313);
            checkBox8.Name = "checkBox8";
            checkBox8.Size = new Size(163, 29);
            checkBox8.TabIndex = 9;
            checkBox8.Text = "Folder Location";
            checkBox8.UseVisualStyleBackColor = true;
            checkBox8.CheckedChanged += checkBox_CheckedChanged;
            // 
            // checkBox6
            // 
            checkBox6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            checkBox6.AutoSize = true;
            checkBox6.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            checkBox6.ForeColor = SystemColors.Control;
            checkBox6.Location = new Point(5, 268);
            checkBox6.Name = "checkBox6";
            checkBox6.Size = new Size(166, 29);
            checkBox6.TabIndex = 5;
            checkBox6.Text = "File Permissions";
            checkBox6.UseVisualStyleBackColor = true;
            checkBox6.CheckedChanged += checkBox_CheckedChanged;
            // 
            // checkBox5
            // 
            checkBox5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            checkBox5.AutoSize = true;
            checkBox5.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            checkBox5.ForeColor = SystemColors.Control;
            checkBox5.Location = new Point(5, 223);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new Size(109, 29);
            checkBox5.TabIndex = 11;
            checkBox5.Text = "File Hash";
            checkBox5.UseVisualStyleBackColor = true;
            checkBox5.CheckedChanged += checkBox_CheckedChanged;
            // 
            // checkBox4
            // 
            checkBox4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            checkBox4.AutoSize = true;
            checkBox4.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            checkBox4.ForeColor = SystemColors.Control;
            checkBox4.Location = new Point(5, 178);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(118, 29);
            checkBox4.TabIndex = 3;
            checkBox4.Text = "File Name";
            checkBox4.UseVisualStyleBackColor = true;
            checkBox4.CheckedChanged += checkBox_CheckedChanged;
            // 
            // checkBox3
            // 
            checkBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            checkBox3.AutoSize = true;
            checkBox3.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            checkBox3.ForeColor = SystemColors.Control;
            checkBox3.Location = new Point(5, 133);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(107, 29);
            checkBox3.TabIndex = 2;
            checkBox3.Text = "File Date";
            checkBox3.UseVisualStyleBackColor = true;
            checkBox3.CheckedChanged += checkBox_CheckedChanged;
            // 
            // checkBox2
            // 
            checkBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            checkBox2.AutoSize = true;
            checkBox2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            checkBox2.ForeColor = SystemColors.Control;
            checkBox2.Location = new Point(5, 88);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(100, 29);
            checkBox2.TabIndex = 1;
            checkBox2.Text = "File Size";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox_CheckedChanged;
            // 
            // checkBox1
            // 
            checkBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            checkBox1.ForeColor = SystemColors.Control;
            checkBox1.Location = new Point(5, 43);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(106, 29);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "File Type";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox_CheckedChanged;
            // 
            // Opt_Sort
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
            Margin = new Padding(3, 2, 3, 2);
            Name = "Opt_Sort";
            Size = new Size(699, 562);
            panel_Top.ResumeLayout(false);
            panel_Header.ResumeLayout(false);
            panel_Header.PerformLayout();
            panel_Footer.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel_Options.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel_Top;
        private Panel panel_Bottom;
        private Panel panel_Header;
        private Panel panel_Right;
        private Button button_Path;
        private Label label1;
        private TextBox textBox_Path;
        private Button button_Filter;
        private ProgressBar progressBar_Time;
        private Label label_Warning;
        private Panel panel_Footer;
        private Panel panel2;
        private Panel panel3;
        private TreeView treeView1;
        private Panel panel4;
        private Label File_Count;
        private Label label4;
        private Panel panel_Options;
        private Panel panel1;
        private Label label3;
        private CheckBox checkBox9;
        private CheckBox checkBox8;
        private CheckBox checkBox7;
        private CheckBox checkBox6;
        private CheckBox checkBox5;
        private CheckBox checkBox4;
        private CheckBox checkBox3;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
    }
}
