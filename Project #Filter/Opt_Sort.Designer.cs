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
            checkBox_Delete = new CheckBox();
            button_Filter = new Button();
            progressBar_Time = new ProgressBar();
            label2 = new Label();
            label_Warning = new Label();
            panel_Header = new Panel();
            panel_Footer = new Panel();
            panel_Options = new Panel();
            checkBox_Duration = new CheckBox();
            checkBox_Resolution = new CheckBox();
            checkBox_Alphabet = new CheckBox();
            checkBox_Size = new CheckBox();
            checkBox_Include = new CheckBox();
            label5 = new Label();
            panel2 = new Panel();
            treeView1 = new TreeView();
            label_Count = new Label();
            label4 = new Label();
            panel_Top.SuspendLayout();
            panel_Header.SuspendLayout();
            panel_Footer.SuspendLayout();
            panel_Options.SuspendLayout();
            panel2.SuspendLayout();
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
            button_Path.BackgroundImage = Properties.Resources.Add_File;
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
            panel_Bottom.Location = new Point(0, 373);
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
            panel_Right.Size = new Size(32, 341);
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
            // checkBox_Delete
            // 
            checkBox_Delete.AutoSize = true;
            checkBox_Delete.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            checkBox_Delete.ForeColor = Color.White;
            checkBox_Delete.Location = new Point(334, 13);
            checkBox_Delete.Margin = new Padding(3, 2, 3, 2);
            checkBox_Delete.Name = "checkBox_Delete";
            checkBox_Delete.Size = new Size(15, 14);
            checkBox_Delete.TabIndex = 27;
            checkBox_Delete.UseVisualStyleBackColor = true;
            // 
            // button_Filter
            // 
            button_Filter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_Filter.BackColor = Color.Teal;
            button_Filter.Enabled = false;
            button_Filter.FlatAppearance.BorderSize = 0;
            button_Filter.FlatStyle = FlatStyle.Flat;
            button_Filter.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            button_Filter.ForeColor = Color.White;
            button_Filter.Location = new Point(429, 6);
            button_Filter.Margin = new Padding(3, 2, 3, 2);
            button_Filter.Name = "button_Filter";
            button_Filter.Size = new Size(233, 26);
            button_Filter.TabIndex = 28;
            button_Filter.Text = "Filter";
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
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(64, 64, 64);
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(3, 10);
            label2.Name = "label2";
            label2.Size = new Size(307, 19);
            label2.TabIndex = 26;
            label2.Text = "Would you like to delete unused directories?";
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
            panel_Header.Controls.Add(label1);
            panel_Header.Controls.Add(textBox_Path);
            panel_Header.Controls.Add(label_Warning);
            panel_Header.Dock = DockStyle.Top;
            panel_Header.Location = new Point(0, 32);
            panel_Header.Margin = new Padding(3, 2, 3, 2);
            panel_Header.Name = "panel_Header";
            panel_Header.Size = new Size(667, 72);
            panel_Header.TabIndex = 30;
            // 
            // panel_Footer
            // 
            panel_Footer.Controls.Add(label2);
            panel_Footer.Controls.Add(checkBox_Delete);
            panel_Footer.Controls.Add(button_Filter);
            panel_Footer.Controls.Add(progressBar_Time);
            panel_Footer.Dock = DockStyle.Bottom;
            panel_Footer.Location = new Point(0, 309);
            panel_Footer.Margin = new Padding(3, 2, 3, 2);
            panel_Footer.Name = "panel_Footer";
            panel_Footer.Size = new Size(667, 64);
            panel_Footer.TabIndex = 32;
            // 
            // panel_Options
            // 
            panel_Options.Controls.Add(checkBox_Duration);
            panel_Options.Controls.Add(checkBox_Resolution);
            panel_Options.Controls.Add(checkBox_Alphabet);
            panel_Options.Controls.Add(checkBox_Size);
            panel_Options.Controls.Add(checkBox_Include);
            panel_Options.Controls.Add(label5);
            panel_Options.Controls.Add(panel2);
            panel_Options.Dock = DockStyle.Fill;
            panel_Options.Location = new Point(0, 104);
            panel_Options.Margin = new Padding(3, 2, 3, 2);
            panel_Options.Name = "panel_Options";
            panel_Options.Size = new Size(667, 205);
            panel_Options.TabIndex = 33;
            // 
            // checkBox_Duration
            // 
            checkBox_Duration.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            checkBox_Duration.AutoSize = true;
            checkBox_Duration.Enabled = false;
            checkBox_Duration.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            checkBox_Duration.ForeColor = Color.White;
            checkBox_Duration.Location = new Point(177, 64);
            checkBox_Duration.Name = "checkBox_Duration";
            checkBox_Duration.Size = new Size(120, 25);
            checkBox_Duration.TabIndex = 56;
            checkBox_Duration.Text = "By Duration";
            checkBox_Duration.UseVisualStyleBackColor = true;
            checkBox_Duration.CheckedChanged += checkBox_CheckedChanged;
            // 
            // checkBox_Resolution
            // 
            checkBox_Resolution.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            checkBox_Resolution.AutoSize = true;
            checkBox_Resolution.Enabled = false;
            checkBox_Resolution.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            checkBox_Resolution.ForeColor = Color.White;
            checkBox_Resolution.Location = new Point(19, 64);
            checkBox_Resolution.Name = "checkBox_Resolution";
            checkBox_Resolution.Size = new Size(134, 25);
            checkBox_Resolution.TabIndex = 55;
            checkBox_Resolution.Text = "By Resolution";
            checkBox_Resolution.UseVisualStyleBackColor = true;
            checkBox_Resolution.CheckedChanged += checkBox_CheckedChanged;
            // 
            // checkBox_Alphabet
            // 
            checkBox_Alphabet.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            checkBox_Alphabet.AutoSize = true;
            checkBox_Alphabet.Enabled = false;
            checkBox_Alphabet.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            checkBox_Alphabet.ForeColor = Color.White;
            checkBox_Alphabet.Location = new Point(280, 135);
            checkBox_Alphabet.Name = "checkBox_Alphabet";
            checkBox_Alphabet.Size = new Size(122, 25);
            checkBox_Alphabet.TabIndex = 54;
            checkBox_Alphabet.Text = "By Alphabet";
            checkBox_Alphabet.UseVisualStyleBackColor = true;
            checkBox_Alphabet.CheckedChanged += checkBox_CheckedChanged;
            // 
            // checkBox_Size
            // 
            checkBox_Size.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            checkBox_Size.AutoSize = true;
            checkBox_Size.Enabled = false;
            checkBox_Size.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            checkBox_Size.ForeColor = Color.White;
            checkBox_Size.Location = new Point(161, 135);
            checkBox_Size.Name = "checkBox_Size";
            checkBox_Size.Size = new Size(83, 25);
            checkBox_Size.TabIndex = 53;
            checkBox_Size.Text = "By Size";
            checkBox_Size.UseVisualStyleBackColor = true;
            checkBox_Size.CheckedChanged += checkBox_CheckedChanged;
            // 
            // checkBox_Include
            // 
            checkBox_Include.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            checkBox_Include.AutoSize = true;
            checkBox_Include.Enabled = false;
            checkBox_Include.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            checkBox_Include.ForeColor = Color.White;
            checkBox_Include.Location = new Point(19, 135);
            checkBox_Include.Name = "checkBox_Include";
            checkBox_Include.Size = new Size(98, 25);
            checkBox_Include.TabIndex = 52;
            checkBox_Include.Text = "By Name";
            checkBox_Include.UseVisualStyleBackColor = true;
            checkBox_Include.CheckedChanged += checkBox_CheckedChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.FromArgb(64, 64, 64);
            label5.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(3, 5);
            label5.Name = "label5";
            label5.Size = new Size(104, 32);
            label5.TabIndex = 41;
            label5.Text = "Options";
            // 
            // panel2
            // 
            panel2.Controls.Add(treeView1);
            panel2.Controls.Add(label_Count);
            panel2.Controls.Add(label4);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(420, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(247, 205);
            panel2.TabIndex = 27;
            // 
            // treeView1
            // 
            treeView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            treeView1.Location = new Point(9, 37);
            treeView1.Margin = new Padding(3, 2, 3, 2);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(233, 169);
            treeView1.TabIndex = 4;
            // 
            // label_Count
            // 
            label_Count.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label_Count.AutoSize = true;
            label_Count.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_Count.ForeColor = Color.White;
            label_Count.Location = new Point(144, 5);
            label_Count.Name = "label_Count";
            label_Count.Size = new Size(67, 21);
            label_Count.TabIndex = 3;
            label_Count.Text = "File List";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(3, 5);
            label4.Name = "label4";
            label4.Size = new Size(120, 21);
            label4.TabIndex = 2;
            label4.Text = "File List           #";
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
            Size = new Size(699, 405);
            panel_Top.ResumeLayout(false);
            panel_Header.ResumeLayout(false);
            panel_Header.PerformLayout();
            panel_Footer.ResumeLayout(false);
            panel_Footer.PerformLayout();
            panel_Options.ResumeLayout(false);
            panel_Options.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
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
        private CheckBox checkBox_Delete;
        private Button button_Filter;
        private ProgressBar progressBar_Time;
        private Label label2;
        private Label label_Warning;
        private Panel panel_Footer;
        private Panel panel_Options;
        private Panel panel2;
        private Label label_Count;
        private Label label4;
        private Label label5;
        private CheckBox checkBox_Alphabet;
        private CheckBox checkBox_Duration;
        private CheckBox checkBox_Resolution;
        private CheckBox checkBox_Size;
        private CheckBox checkBox_Include;
        private TreeView treeView1;
    }
}
