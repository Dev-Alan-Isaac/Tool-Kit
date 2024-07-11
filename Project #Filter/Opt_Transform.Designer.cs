namespace Project__Filter
{
    partial class Opt_Transform
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
            label1 = new Label();
            panel_R = new Panel();
            panel_B = new Panel();
            panel_T = new Panel();
            button_Path = new Button();
            panel_button = new Panel();
            label2 = new Label();
            progressBar_Time = new ProgressBar();
            checkBox_Delete = new CheckBox();
            button_Convert = new Button();
            panel_Path = new Panel();
            textBox_Path = new TextBox();
            panel_Middle = new Panel();
            panel_Action = new Panel();
            radioButton_Size = new RadioButton();
            radioButton_Date = new RadioButton();
            radioButton_Name = new RadioButton();
            label3 = new Label();
            comboBox_Select = new ComboBox();
            panel1 = new Panel();
            label_Count = new Label();
            label4 = new Label();
            listBox_File = new ListBox();
            label6 = new Label();
            label_Warning = new Label();
            panel_T.SuspendLayout();
            panel_button.SuspendLayout();
            panel_Path.SuspendLayout();
            panel_Middle.SuspendLayout();
            panel_Action.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
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
            label1.TabIndex = 17;
            label1.Text = "Path:";
            // 
            // panel_R
            // 
            panel_R.BackColor = Color.FromArgb(0, 64, 64);
            panel_R.Dock = DockStyle.Right;
            panel_R.Location = new Point(762, 43);
            panel_R.Name = "panel_R";
            panel_R.Size = new Size(37, 454);
            panel_R.TabIndex = 26;
            // 
            // panel_B
            // 
            panel_B.BackColor = Color.FromArgb(0, 64, 64);
            panel_B.Dock = DockStyle.Bottom;
            panel_B.Location = new Point(0, 497);
            panel_B.Name = "panel_B";
            panel_B.Size = new Size(799, 43);
            panel_B.TabIndex = 24;
            // 
            // panel_T
            // 
            panel_T.BackColor = Color.FromArgb(0, 64, 64);
            panel_T.Controls.Add(button_Path);
            panel_T.Dock = DockStyle.Top;
            panel_T.Location = new Point(0, 0);
            panel_T.Name = "panel_T";
            panel_T.Size = new Size(799, 43);
            panel_T.TabIndex = 23;
            // 
            // button_Path
            // 
            button_Path.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_Path.BackColor = Color.FromArgb(0, 64, 64);
            button_Path.BackgroundImage = Properties.Resources.icons8_add_file_50;
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
            // panel_button
            // 
            panel_button.Controls.Add(label2);
            panel_button.Controls.Add(progressBar_Time);
            panel_button.Controls.Add(checkBox_Delete);
            panel_button.Controls.Add(button_Convert);
            panel_button.Dock = DockStyle.Bottom;
            panel_button.Location = new Point(0, 412);
            panel_button.Name = "panel_button";
            panel_button.Size = new Size(762, 85);
            panel_button.TabIndex = 39;
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
            label2.TabIndex = 43;
            label2.Text = "Would you like to delete unused directories?";
            // 
            // progressBar_Time
            // 
            progressBar_Time.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressBar_Time.Location = new Point(3, 51);
            progressBar_Time.Name = "progressBar_Time";
            progressBar_Time.Size = new Size(753, 29);
            progressBar_Time.Step = 1;
            progressBar_Time.TabIndex = 42;
            // 
            // checkBox_Delete
            // 
            checkBox_Delete.AutoSize = true;
            checkBox_Delete.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            checkBox_Delete.ForeColor = Color.White;
            checkBox_Delete.Location = new Point(382, 17);
            checkBox_Delete.Name = "checkBox_Delete";
            checkBox_Delete.Size = new Size(18, 17);
            checkBox_Delete.TabIndex = 44;
            checkBox_Delete.UseVisualStyleBackColor = true;
            // 
            // button_Convert
            // 
            button_Convert.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_Convert.BackColor = Color.Teal;
            button_Convert.Enabled = false;
            button_Convert.FlatAppearance.BorderSize = 0;
            button_Convert.FlatStyle = FlatStyle.Flat;
            button_Convert.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            button_Convert.ForeColor = Color.White;
            button_Convert.Location = new Point(490, 8);
            button_Convert.Name = "button_Convert";
            button_Convert.Size = new Size(266, 35);
            button_Convert.TabIndex = 45;
            button_Convert.Text = "Convert";
            button_Convert.UseVisualStyleBackColor = false;
            button_Convert.Click += button_Convert_Click;
            // 
            // panel_Path
            // 
            panel_Path.Controls.Add(textBox_Path);
            panel_Path.Controls.Add(label1);
            panel_Path.Dock = DockStyle.Top;
            panel_Path.Location = new Point(0, 43);
            panel_Path.Name = "panel_Path";
            panel_Path.Size = new Size(762, 96);
            panel_Path.TabIndex = 40;
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
            textBox_Path.TabIndex = 26;
            // 
            // panel_Middle
            // 
            panel_Middle.BackColor = Color.FromArgb(64, 64, 64);
            panel_Middle.Controls.Add(panel_Action);
            panel_Middle.Dock = DockStyle.Fill;
            panel_Middle.Location = new Point(0, 139);
            panel_Middle.Name = "panel_Middle";
            panel_Middle.Size = new Size(762, 273);
            panel_Middle.TabIndex = 41;
            // 
            // panel_Action
            // 
            panel_Action.Controls.Add(radioButton_Size);
            panel_Action.Controls.Add(radioButton_Date);
            panel_Action.Controls.Add(radioButton_Name);
            panel_Action.Controls.Add(label3);
            panel_Action.Controls.Add(comboBox_Select);
            panel_Action.Controls.Add(panel1);
            panel_Action.Controls.Add(label6);
            panel_Action.Controls.Add(label_Warning);
            panel_Action.Dock = DockStyle.Fill;
            panel_Action.Location = new Point(0, 0);
            panel_Action.Margin = new Padding(3, 4, 3, 4);
            panel_Action.Name = "panel_Action";
            panel_Action.Size = new Size(762, 273);
            panel_Action.TabIndex = 41;
            // 
            // radioButton_Size
            // 
            radioButton_Size.AutoSize = true;
            radioButton_Size.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            radioButton_Size.ForeColor = Color.White;
            radioButton_Size.Location = new Point(256, 198);
            radioButton_Size.Name = "radioButton_Size";
            radioButton_Size.Size = new Size(144, 32);
            radioButton_Size.TabIndex = 46;
            radioButton_Size.TabStop = true;
            radioButton_Size.Text = "Sort by size";
            radioButton_Size.UseVisualStyleBackColor = true;
            // 
            // radioButton_Date
            // 
            radioButton_Date.AutoSize = true;
            radioButton_Date.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            radioButton_Date.ForeColor = Color.White;
            radioButton_Date.Location = new Point(20, 198);
            radioButton_Date.Name = "radioButton_Date";
            radioButton_Date.Size = new Size(150, 32);
            radioButton_Date.TabIndex = 45;
            radioButton_Date.TabStop = true;
            radioButton_Date.Text = "Sort by date";
            radioButton_Date.UseVisualStyleBackColor = true;
            // 
            // radioButton_Name
            // 
            radioButton_Name.AutoSize = true;
            radioButton_Name.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            radioButton_Name.ForeColor = Color.White;
            radioButton_Name.Location = new Point(20, 131);
            radioButton_Name.Name = "radioButton_Name";
            radioButton_Name.Size = new Size(160, 32);
            radioButton_Name.TabIndex = 44;
            radioButton_Name.TabStop = true;
            radioButton_Name.Text = "Sort by name";
            radioButton_Name.UseVisualStyleBackColor = true;
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
            label3.TabIndex = 39;
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
            comboBox_Select.Items.AddRange(new object[] { "IMAGE To PDF [TITLE]", "IMAGE To PDF [NO TITLE]", "IMAGE To ICO", "IMAGE To WEBP", "IMAGE To BMP", "VIDEO To GIF", "VIDEO To WEBM", "VIDEO To AVI", "VIDEO To AUDIO", "AUDIO To WAV" });
            comboBox_Select.Location = new Point(139, 9);
            comboBox_Select.Name = "comboBox_Select";
            comboBox_Select.Size = new Size(333, 36);
            comboBox_Select.TabIndex = 40;
            comboBox_Select.SelectedIndexChanged += comboBox_Select_SelectedIndexChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(label_Count);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(listBox_File);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(480, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(282, 273);
            panel1.TabIndex = 43;
            // 
            // label_Count
            // 
            label_Count.AutoSize = true;
            label_Count.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_Count.ForeColor = Color.White;
            label_Count.Location = new Point(165, 7);
            label_Count.Name = "label_Count";
            label_Count.Size = new Size(84, 28);
            label_Count.TabIndex = 5;
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
            label4.TabIndex = 4;
            label4.Text = "File List           #";
            // 
            // listBox_File
            // 
            listBox_File.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBox_File.FormattingEnabled = true;
            listBox_File.Location = new Point(10, 49);
            listBox_File.Margin = new Padding(3, 4, 3, 4);
            listBox_File.Name = "listBox_File";
            listBox_File.Size = new Size(266, 224);
            listBox_File.TabIndex = 0;
            listBox_File.SelectedIndexChanged += listBox_File_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(3, 85);
            label6.Name = "label6";
            label6.Size = new Size(100, 32);
            label6.TabIndex = 2;
            label6.Text = "Actions";
            // 
            // label_Warning
            // 
            label_Warning.AutoSize = true;
            label_Warning.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_Warning.ForeColor = Color.FromArgb(255, 128, 0);
            label_Warning.Location = new Point(3, 137);
            label_Warning.Name = "label_Warning";
            label_Warning.Size = new Size(0, 32);
            label_Warning.TabIndex = 0;
            // 
            // Opt_Transform
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            Controls.Add(panel_Middle);
            Controls.Add(panel_Path);
            Controls.Add(panel_button);
            Controls.Add(panel_R);
            Controls.Add(panel_B);
            Controls.Add(panel_T);
            Name = "Opt_Transform";
            Size = new Size(799, 540);
            panel_T.ResumeLayout(false);
            panel_button.ResumeLayout(false);
            panel_button.PerformLayout();
            panel_Path.ResumeLayout(false);
            panel_Path.PerformLayout();
            panel_Middle.ResumeLayout(false);
            panel_Action.ResumeLayout(false);
            panel_Action.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private Panel panel_R;
        private Panel panel_B;
        private Panel panel_T;
        private Button button_Path;
        private Panel panel_button;
        private Panel panel_Path;
        private TextBox textBox_Path;
        private Panel panel_Middle;
        private Label label3;
        private Label label2;
        private ProgressBar progressBar_Time;
        private CheckBox checkBox_Delete;
        private Button button_Convert;
        private ComboBox comboBox_Select;
        private Panel panel_Action;
        private Label label_Warning;
        private ListBox listBox_File;
        private Label label6;
        private Panel panel1;
        private Label label_Count;
        private Label label4;
        private RadioButton radioButton_Date;
        private RadioButton radioButton_Name;
        private RadioButton radioButton_Size;
    }
}
