namespace Project__Filter
{
    partial class Opt_Merge
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
            panel_Footer = new Panel();
            label2 = new Label();
            checkBox_Delete = new CheckBox();
            button_Merge = new Button();
            progressBar_Time = new ProgressBar();
            panel_Header = new Panel();
            label1 = new Label();
            textBox_Path = new TextBox();
            label_Warning = new Label();
            panel_Right = new Panel();
            panel_Bottom = new Panel();
            panel_Top = new Panel();
            button_Path = new Button();
            panel1 = new Panel();
            checkBox_Date = new CheckBox();
            checkBox_Size = new CheckBox();
            checkBox_Name = new CheckBox();
            label6 = new Label();
            radioButton_Folder = new RadioButton();
            radioButton_Custom = new RadioButton();
            label3 = new Label();
            comboBox_Select = new ComboBox();
            panel2 = new Panel();
            label_Count = new Label();
            label4 = new Label();
            listBox_File = new ListBox();
            panel_Footer.SuspendLayout();
            panel_Header.SuspendLayout();
            panel_Top.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel_Footer
            // 
            panel_Footer.Controls.Add(label2);
            panel_Footer.Controls.Add(checkBox_Delete);
            panel_Footer.Controls.Add(button_Merge);
            panel_Footer.Controls.Add(progressBar_Time);
            panel_Footer.Dock = DockStyle.Bottom;
            panel_Footer.Location = new Point(0, 412);
            panel_Footer.Name = "panel_Footer";
            panel_Footer.Size = new Size(762, 85);
            panel_Footer.TabIndex = 42;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(64, 64, 64);
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(3, 13);
            label2.Name = "label2";
            label2.Size = new Size(367, 23);
            label2.TabIndex = 26;
            label2.Text = "Would you like to delete unused directories?";
            // 
            // checkBox_Delete
            // 
            checkBox_Delete.AutoSize = true;
            checkBox_Delete.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            checkBox_Delete.ForeColor = Color.White;
            checkBox_Delete.Location = new Point(382, 17);
            checkBox_Delete.Name = "checkBox_Delete";
            checkBox_Delete.Size = new Size(18, 17);
            checkBox_Delete.TabIndex = 27;
            checkBox_Delete.UseVisualStyleBackColor = true;
            // 
            // button_Merge
            // 
            button_Merge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_Merge.BackColor = Color.Teal;
            button_Merge.Enabled = false;
            button_Merge.FlatAppearance.BorderSize = 0;
            button_Merge.FlatStyle = FlatStyle.Flat;
            button_Merge.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            button_Merge.ForeColor = Color.White;
            button_Merge.Location = new Point(490, 8);
            button_Merge.Name = "button_Merge";
            button_Merge.Size = new Size(266, 35);
            button_Merge.TabIndex = 28;
            button_Merge.Text = "Merge";
            button_Merge.UseVisualStyleBackColor = false;
            button_Merge.Click += button_Merge_Click;
            // 
            // progressBar_Time
            // 
            progressBar_Time.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressBar_Time.Location = new Point(3, 51);
            progressBar_Time.Name = "progressBar_Time";
            progressBar_Time.Size = new Size(753, 29);
            progressBar_Time.Step = 1;
            progressBar_Time.TabIndex = 24;
            // 
            // panel_Header
            // 
            panel_Header.Controls.Add(label1);
            panel_Header.Controls.Add(textBox_Path);
            panel_Header.Controls.Add(label_Warning);
            panel_Header.Dock = DockStyle.Top;
            panel_Header.Location = new Point(0, 43);
            panel_Header.Name = "panel_Header";
            panel_Header.Size = new Size(762, 96);
            panel_Header.TabIndex = 41;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(64, 64, 64);
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(89, 41);
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
            textBox_Path.Location = new Point(98, 5);
            textBox_Path.Name = "textBox_Path";
            textBox_Path.ReadOnly = true;
            textBox_Path.Size = new Size(653, 39);
            textBox_Path.TabIndex = 25;
            // 
            // label_Warning
            // 
            label_Warning.Anchor = AnchorStyles.Top;
            label_Warning.AutoSize = true;
            label_Warning.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            label_Warning.ForeColor = Color.FromArgb(255, 128, 0);
            label_Warning.Location = new Point(270, 57);
            label_Warning.Name = "label_Warning";
            label_Warning.Size = new Size(0, 28);
            label_Warning.TabIndex = 29;
            // 
            // panel_Right
            // 
            panel_Right.BackColor = Color.FromArgb(0, 64, 64);
            panel_Right.Dock = DockStyle.Right;
            panel_Right.Location = new Point(762, 43);
            panel_Right.Name = "panel_Right";
            panel_Right.Size = new Size(37, 454);
            panel_Right.TabIndex = 40;
            // 
            // panel_Bottom
            // 
            panel_Bottom.BackColor = Color.FromArgb(0, 64, 64);
            panel_Bottom.Dock = DockStyle.Bottom;
            panel_Bottom.Location = new Point(0, 497);
            panel_Bottom.Name = "panel_Bottom";
            panel_Bottom.Size = new Size(799, 43);
            panel_Bottom.TabIndex = 39;
            // 
            // panel_Top
            // 
            panel_Top.BackColor = Color.FromArgb(0, 64, 64);
            panel_Top.Controls.Add(button_Path);
            panel_Top.Dock = DockStyle.Top;
            panel_Top.Location = new Point(0, 0);
            panel_Top.Name = "panel_Top";
            panel_Top.Size = new Size(799, 43);
            panel_Top.TabIndex = 38;
            // 
            // button_Path
            // 
            button_Path.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_Path.BackColor = Color.FromArgb(0, 64, 64);
            button_Path.BackgroundImage = Properties.Resources.Add_File;
            button_Path.BackgroundImageLayout = ImageLayout.Zoom;
            button_Path.FlatAppearance.BorderSize = 0;
            button_Path.FlatStyle = FlatStyle.Flat;
            button_Path.Location = new Point(726, 5);
            button_Path.Name = "button_Path";
            button_Path.Size = new Size(29, 33);
            button_Path.TabIndex = 0;
            button_Path.UseVisualStyleBackColor = false;
            button_Path.Click += button_Path_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(checkBox_Date);
            panel1.Controls.Add(checkBox_Size);
            panel1.Controls.Add(checkBox_Name);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(radioButton_Folder);
            panel1.Controls.Add(radioButton_Custom);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(comboBox_Select);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 139);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(762, 273);
            panel1.TabIndex = 50;
            // 
            // checkBox_Date
            // 
            checkBox_Date.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            checkBox_Date.AutoSize = true;
            checkBox_Date.Enabled = false;
            checkBox_Date.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            checkBox_Date.ForeColor = Color.White;
            checkBox_Date.Location = new Point(333, 197);
            checkBox_Date.Margin = new Padding(3, 4, 3, 4);
            checkBox_Date.Name = "checkBox_Date";
            checkBox_Date.Size = new Size(154, 32);
            checkBox_Date.TabIndex = 48;
            checkBox_Date.Text = "Sort by Date";
            checkBox_Date.UseVisualStyleBackColor = true;
            // 
            // checkBox_Size
            // 
            checkBox_Size.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            checkBox_Size.AutoSize = true;
            checkBox_Size.Enabled = false;
            checkBox_Size.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            checkBox_Size.ForeColor = Color.White;
            checkBox_Size.Location = new Point(182, 197);
            checkBox_Size.Margin = new Padding(3, 4, 3, 4);
            checkBox_Size.Name = "checkBox_Size";
            checkBox_Size.Size = new Size(147, 32);
            checkBox_Size.TabIndex = 47;
            checkBox_Size.Text = "Sort by Size";
            checkBox_Size.UseVisualStyleBackColor = true;
            // 
            // checkBox_Name
            // 
            checkBox_Name.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            checkBox_Name.AutoSize = true;
            checkBox_Name.Enabled = false;
            checkBox_Name.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            checkBox_Name.ForeColor = Color.White;
            checkBox_Name.Location = new Point(14, 197);
            checkBox_Name.Margin = new Padding(3, 4, 3, 4);
            checkBox_Name.Name = "checkBox_Name";
            checkBox_Name.Size = new Size(165, 32);
            checkBox_Name.TabIndex = 46;
            checkBox_Name.Text = "Sort by Name";
            checkBox_Name.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(3, 85);
            label6.Name = "label6";
            label6.Size = new Size(100, 32);
            label6.TabIndex = 44;
            label6.Text = "Actions";
            // 
            // radioButton_Folder
            // 
            radioButton_Folder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            radioButton_Folder.AutoSize = true;
            radioButton_Folder.Enabled = false;
            radioButton_Folder.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            radioButton_Folder.ForeColor = Color.White;
            radioButton_Folder.Location = new Point(184, 140);
            radioButton_Folder.Margin = new Padding(3, 4, 3, 4);
            radioButton_Folder.Name = "radioButton_Folder";
            radioButton_Folder.Size = new Size(141, 32);
            radioButton_Folder.TabIndex = 45;
            radioButton_Folder.TabStop = true;
            radioButton_Folder.Text = "Folder Title";
            radioButton_Folder.UseVisualStyleBackColor = true;
            // 
            // radioButton_Custom
            // 
            radioButton_Custom.AutoSize = true;
            radioButton_Custom.Enabled = false;
            radioButton_Custom.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            radioButton_Custom.ForeColor = Color.White;
            radioButton_Custom.Location = new Point(14, 140);
            radioButton_Custom.Margin = new Padding(3, 4, 3, 4);
            radioButton_Custom.Name = "radioButton_Custom";
            radioButton_Custom.Size = new Size(153, 32);
            radioButton_Custom.TabIndex = 43;
            radioButton_Custom.TabStop = true;
            radioButton_Custom.Text = "Custom Title";
            radioButton_Custom.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(64, 64, 64);
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(3, 7);
            label3.Name = "label3";
            label3.Size = new Size(130, 41);
            label3.TabIndex = 41;
            label3.Text = "Options";
            // 
            // comboBox_Select
            // 
            comboBox_Select.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBox_Select.BackColor = Color.FromArgb(64, 64, 64);
            comboBox_Select.Enabled = false;
            comboBox_Select.FlatStyle = FlatStyle.Flat;
            comboBox_Select.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            comboBox_Select.ForeColor = Color.White;
            comboBox_Select.FormattingEnabled = true;
            comboBox_Select.Items.AddRange(new object[] { "FILES TEXT", "FILES WORD", "FILES PDF", "FILES HTML" });
            comboBox_Select.Location = new Point(139, 9);
            comboBox_Select.Name = "comboBox_Select";
            comboBox_Select.Size = new Size(333, 36);
            comboBox_Select.TabIndex = 42;
            comboBox_Select.SelectedIndexChanged += comboBox_Select_SelectedIndexChanged;
            // 
            // panel2
            // 
            panel2.Controls.Add(label_Count);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(listBox_File);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(480, 0);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(282, 273);
            panel2.TabIndex = 0;
            // 
            // label_Count
            // 
            label_Count.AutoSize = true;
            label_Count.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_Count.ForeColor = Color.White;
            label_Count.Location = new Point(165, 7);
            label_Count.Name = "label_Count";
            label_Count.Size = new Size(84, 28);
            label_Count.TabIndex = 3;
            label_Count.Text = "File List";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(3, 7);
            label4.Name = "label4";
            label4.Size = new Size(162, 28);
            label4.TabIndex = 2;
            label4.Text = "File List           #";
            // 
            // listBox_File
            // 
            listBox_File.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBox_File.FormattingEnabled = true;
            listBox_File.Location = new Point(10, 49);
            listBox_File.Margin = new Padding(3, 4, 3, 4);
            listBox_File.Name = "listBox_File";
            listBox_File.SelectionMode = SelectionMode.MultiExtended;
            listBox_File.Size = new Size(266, 224);
            listBox_File.TabIndex = 1;
            // 
            // Opt_Merge
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            Controls.Add(panel1);
            Controls.Add(panel_Footer);
            Controls.Add(panel_Header);
            Controls.Add(panel_Right);
            Controls.Add(panel_Bottom);
            Controls.Add(panel_Top);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Opt_Merge";
            Size = new Size(799, 540);
            panel_Footer.ResumeLayout(false);
            panel_Footer.PerformLayout();
            panel_Header.ResumeLayout(false);
            panel_Header.PerformLayout();
            panel_Top.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel_Footer;
        private Label label2;
        private CheckBox checkBox_Delete;
        private Button button_Merge;
        private ProgressBar progressBar_Time;
        private Panel panel_Header;
        private Label label1;
        private TextBox textBox_Path;
        private Label label_Warning;
        private Panel panel_Right;
        private Panel panel_Bottom;
        private Panel panel_Top;
        private Button button_Path;
        private Panel panel2;
        private Label label_Count;
        private Label label4;
        private ListBox listBox_File;
        private Panel panel1;
        private Label label3;
        private ComboBox comboBox_Select;
        private CheckBox checkBox_Date;
        private CheckBox checkBox_Size;
        private CheckBox checkBox_Name;
        private Label label6;
        private RadioButton radioButton_Folder;
        private RadioButton radioButton_Custom;
    }
}
