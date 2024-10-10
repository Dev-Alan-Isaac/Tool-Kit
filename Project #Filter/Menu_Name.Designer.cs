namespace Project__Filter
{
    partial class Menu_Name
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
            panel9 = new Panel();
            label3 = new Label();
            panel4 = new Panel();
            label1 = new Label();
            button_Saved = new Button();
            panel10 = new Panel();
            panel5 = new Panel();
            panel6 = new Panel();
            checkBox_IgnoreSpecialChar = new CheckBox();
            checkBox_CapsSens = new CheckBox();
            label4 = new Label();
            radioButton_FileExtension = new RadioButton();
            radioButton_FileName = new RadioButton();
            panel3 = new Panel();
            panel2 = new Panel();
            panel1 = new Panel();
            panel9.SuspendLayout();
            panel4.SuspendLayout();
            panel10.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // panel9
            // 
            panel9.Controls.Add(label3);
            panel9.Dock = DockStyle.Top;
            panel9.Location = new Point(0, 0);
            panel9.Name = "panel9";
            panel9.Size = new Size(624, 42);
            panel9.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(328, 25);
            label3.TabIndex = 0;
            label3.Text = "Select file types to include in sorting:";
            // 
            // panel4
            // 
            panel4.Controls.Add(label1);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 32);
            panel4.Name = "panel4";
            panel4.Size = new Size(633, 44);
            panel4.TabIndex = 63;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(211, 37);
            label1.TabIndex = 0;
            label1.Text = "SORT BY NAME";
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
            button_Saved.Size = new Size(624, 43);
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
            panel10.Size = new Size(624, 43);
            panel10.TabIndex = 57;
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel5.Controls.Add(panel6);
            panel5.Controls.Add(radioButton_FileExtension);
            panel5.Controls.Add(radioButton_FileName);
            panel5.Controls.Add(panel10);
            panel5.Controls.Add(panel9);
            panel5.Location = new Point(3, 82);
            panel5.Name = "panel5";
            panel5.Size = new Size(624, 394);
            panel5.TabIndex = 64;
            // 
            // panel6
            // 
            panel6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel6.Controls.Add(checkBox_IgnoreSpecialChar);
            panel6.Controls.Add(checkBox_CapsSens);
            panel6.Controls.Add(label4);
            panel6.Location = new Point(3, 134);
            panel6.Name = "panel6";
            panel6.Size = new Size(618, 112);
            panel6.TabIndex = 62;
            // 
            // checkBox_IgnoreSpecialChar
            // 
            checkBox_IgnoreSpecialChar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            checkBox_IgnoreSpecialChar.AutoSize = true;
            checkBox_IgnoreSpecialChar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            checkBox_IgnoreSpecialChar.ForeColor = SystemColors.Control;
            checkBox_IgnoreSpecialChar.Location = new Point(13, 69);
            checkBox_IgnoreSpecialChar.Name = "checkBox_IgnoreSpecialChar";
            checkBox_IgnoreSpecialChar.Size = new Size(215, 25);
            checkBox_IgnoreSpecialChar.TabIndex = 2;
            checkBox_IgnoreSpecialChar.Text = "Ignore Special Characters";
            checkBox_IgnoreSpecialChar.UseVisualStyleBackColor = true;
            // 
            // checkBox_CapsSens
            // 
            checkBox_CapsSens.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            checkBox_CapsSens.AutoSize = true;
            checkBox_CapsSens.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            checkBox_CapsSens.ForeColor = SystemColors.Control;
            checkBox_CapsSens.Location = new Point(13, 28);
            checkBox_CapsSens.Name = "checkBox_CapsSens";
            checkBox_CapsSens.Size = new Size(192, 25);
            checkBox_CapsSens.TabIndex = 1;
            checkBox_CapsSens.Text = "Case-Sensitive Sorting";
            checkBox_CapsSens.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Top;
            label4.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.Control;
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Size = new Size(178, 25);
            label4.TabIndex = 0;
            label4.Text = "Additional Options:";
            // 
            // radioButton_FileExtension
            // 
            radioButton_FileExtension.AutoSize = true;
            radioButton_FileExtension.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            radioButton_FileExtension.ForeColor = SystemColors.Control;
            radioButton_FileExtension.Location = new Point(3, 79);
            radioButton_FileExtension.Name = "radioButton_FileExtension";
            radioButton_FileExtension.Size = new Size(171, 25);
            radioButton_FileExtension.TabIndex = 60;
            radioButton_FileExtension.TabStop = true;
            radioButton_FileExtension.Text = "File Extension (A-Z) ";
            radioButton_FileExtension.UseVisualStyleBackColor = true;
            // 
            // radioButton_FileName
            // 
            radioButton_FileName.AutoSize = true;
            radioButton_FileName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            radioButton_FileName.ForeColor = SystemColors.Control;
            radioButton_FileName.Location = new Point(3, 48);
            radioButton_FileName.Name = "radioButton_FileName";
            radioButton_FileName.Size = new Size(144, 25);
            radioButton_FileName.TabIndex = 58;
            radioButton_FileName.TabStop = true;
            radioButton_FileName.Text = "File Name (A-Z) ";
            radioButton_FileName.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(0, 64, 64);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 482);
            panel3.Name = "panel3";
            panel3.Size = new Size(633, 32);
            panel3.TabIndex = 62;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 64, 64);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(633, 32);
            panel2.Name = "panel2";
            panel2.Size = new Size(32, 482);
            panel2.TabIndex = 61;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 64, 64);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(665, 32);
            panel1.TabIndex = 60;
            // 
            // Menu_Name
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            Controls.Add(panel4);
            Controls.Add(panel5);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Menu_Name";
            Size = new Size(665, 514);
            Load += Menu_Load;
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel10.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel9;
        private Label label3;
        private Panel panel4;
        private Label label1;
        private Button button_Saved;
        private Panel panel10;
        private Panel panel5;
        private Panel panel3;
        private Panel panel2;
        private Panel panel1;
        private RadioButton radioButton_FileExtension;
        private RadioButton radioButton_FileName;
        private Panel panel6;
        private CheckBox checkBox_IgnoreSpecialChar;
        private CheckBox checkBox_CapsSens;
        private Label label4;
    }
}
