namespace Project__Filter
{
    partial class Opt_Encrypt
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
            components = new System.ComponentModel.Container();
            panel_Footer = new Panel();
            button_Filter = new Button();
            progressBar_Time = new ProgressBar();
            radioButton_Decrypt = new RadioButton();
            radioButton_Encrypt = new RadioButton();
            radioButton_Satize = new RadioButton();
            label3 = new Label();
            panel3 = new Panel();
            treeView1 = new TreeView();
            panel4 = new Panel();
            File_Count = new Label();
            label4 = new Label();
            panel_Header = new Panel();
            panel2 = new Panel();
            label1 = new Label();
            textBox_Path = new TextBox();
            label_Warning = new Label();
            panel1 = new Panel();
            panel_Right = new Panel();
            bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(components);
            bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(components);
            button_Path = new Button();
            panel_Top = new Panel();
            panel_Options = new Panel();
            panel_Bottom = new Panel();
            bunifuElipse3 = new Bunifu.Framework.UI.BunifuElipse(components);
            panel_Footer.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel_Header.SuspendLayout();
            panel1.SuspendLayout();
            panel_Top.SuspendLayout();
            panel_Options.SuspendLayout();
            SuspendLayout();
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
            panel_Footer.TabIndex = 50;
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
            // radioButton_Decrypt
            // 
            radioButton_Decrypt.AutoSize = true;
            radioButton_Decrypt.Cursor = Cursors.Hand;
            radioButton_Decrypt.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            radioButton_Decrypt.ForeColor = SystemColors.Control;
            radioButton_Decrypt.Location = new Point(3, 146);
            radioButton_Decrypt.Name = "radioButton_Decrypt";
            radioButton_Decrypt.Size = new Size(99, 29);
            radioButton_Decrypt.TabIndex = 14;
            radioButton_Decrypt.TabStop = true;
            radioButton_Decrypt.Text = "Decrypt";
            radioButton_Decrypt.UseVisualStyleBackColor = true;
            radioButton_Decrypt.CheckedChanged += radioButton_CheckedChanged;
            // 
            // radioButton_Encrypt
            // 
            radioButton_Encrypt.AutoSize = true;
            radioButton_Encrypt.Cursor = Cursors.Hand;
            radioButton_Encrypt.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            radioButton_Encrypt.ForeColor = SystemColors.Control;
            radioButton_Encrypt.Location = new Point(3, 95);
            radioButton_Encrypt.Name = "radioButton_Encrypt";
            radioButton_Encrypt.Size = new Size(96, 29);
            radioButton_Encrypt.TabIndex = 13;
            radioButton_Encrypt.TabStop = true;
            radioButton_Encrypt.Text = "Encrypt";
            radioButton_Encrypt.UseVisualStyleBackColor = true;
            radioButton_Encrypt.CheckedChanged += radioButton_CheckedChanged;
            // 
            // radioButton_Satize
            // 
            radioButton_Satize.AutoSize = true;
            radioButton_Satize.Cursor = Cursors.Hand;
            radioButton_Satize.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            radioButton_Satize.ForeColor = SystemColors.Control;
            radioButton_Satize.Location = new Point(3, 44);
            radioButton_Satize.Name = "radioButton_Satize";
            radioButton_Satize.Size = new Size(102, 29);
            radioButton_Satize.TabIndex = 12;
            radioButton_Satize.TabStop = true;
            radioButton_Satize.Text = "Sanatize";
            radioButton_Satize.UseVisualStyleBackColor = true;
            radioButton_Satize.CheckedChanged += radioButton_CheckedChanged;
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
            label3.Text = "Select the file to convert:";
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
            panel_Header.TabIndex = 49;
            // 
            // panel2
            // 
            panel2.Location = new Point(332, 49);
            panel2.Name = "panel2";
            panel2.Size = new Size(329, 380);
            panel2.TabIndex = 59;
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
            label_Warning.Location = new Point(702, 43);
            label_Warning.Name = "label_Warning";
            label_Warning.Size = new Size(0, 21);
            label_Warning.TabIndex = 29;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(radioButton_Decrypt);
            panel1.Controls.Add(radioButton_Encrypt);
            panel1.Controls.Add(radioButton_Satize);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(3, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(323, 380);
            panel1.TabIndex = 60;
            // 
            // panel_Right
            // 
            panel_Right.BackColor = Color.FromArgb(0, 64, 64);
            panel_Right.Dock = DockStyle.Right;
            panel_Right.Location = new Point(667, 32);
            panel_Right.Margin = new Padding(3, 2, 3, 2);
            panel_Right.Name = "panel_Right";
            panel_Right.Size = new Size(32, 498);
            panel_Right.TabIndex = 48;
            // 
            // bunifuElipse2
            // 
            bunifuElipse2.ElipseRadius = 5;
            bunifuElipse2.TargetControl = progressBar_Time;
            // 
            // bunifuElipse1
            // 
            bunifuElipse1.ElipseRadius = 5;
            bunifuElipse1.TargetControl = button_Filter;
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
            button_Path.Click += button_Path_Click_1;
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
            panel_Top.TabIndex = 46;
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
            panel_Options.TabIndex = 51;
            // 
            // panel_Bottom
            // 
            panel_Bottom.BackColor = Color.FromArgb(0, 64, 64);
            panel_Bottom.Dock = DockStyle.Bottom;
            panel_Bottom.Location = new Point(0, 530);
            panel_Bottom.Margin = new Padding(3, 2, 3, 2);
            panel_Bottom.Name = "panel_Bottom";
            panel_Bottom.Size = new Size(699, 32);
            panel_Bottom.TabIndex = 47;
            // 
            // bunifuElipse3
            // 
            bunifuElipse3.ElipseRadius = 5;
            bunifuElipse3.TargetControl = treeView1;
            // 
            // Opt_Encrypt
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            Controls.Add(panel_Footer);
            Controls.Add(panel_Header);
            Controls.Add(panel_Right);
            Controls.Add(panel_Top);
            Controls.Add(panel_Options);
            Controls.Add(panel_Bottom);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Opt_Encrypt";
            Size = new Size(699, 562);
            panel_Footer.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel_Header.ResumeLayout(false);
            panel_Header.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel_Top.ResumeLayout(false);
            panel_Options.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_Footer;
        private Button button_Filter;
        private ProgressBar progressBar_Time;
        private RadioButton radioButton_Decrypt;
        private RadioButton radioButton_Encrypt;
        private RadioButton radioButton_Satize;
        private Label label3;
        private Panel panel3;
        private TreeView treeView1;
        private Panel panel4;
        private Label File_Count;
        private Label label4;
        private Panel panel_Header;
        private Panel panel2;
        private Label label1;
        private TextBox textBox_Path;
        private Label label_Warning;
        private Panel panel1;
        private Panel panel_Right;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Button button_Path;
        private Panel panel_Top;
        private Panel panel_Options;
        private Panel panel_Bottom;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse3;
    }
}
