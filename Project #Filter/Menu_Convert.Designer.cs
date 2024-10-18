namespace Project__Filter
{
    partial class Menu_Convert
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
            panel5 = new Panel();
            checkBox_Delete = new CheckBox();
            checkBox_Subfolders = new CheckBox();
            checkBox_Keep = new CheckBox();
            panel6 = new Panel();
            label2 = new Label();
            label7 = new Label();
            comboBox_Document = new ComboBox();
            label6 = new Label();
            comboBox_Video = new ComboBox();
            label5 = new Label();
            comboBox_Image = new ComboBox();
            label4 = new Label();
            comboBox_Audio = new ComboBox();
            panel10 = new Panel();
            button_Saved = new Button();
            bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(components);
            label1 = new Label();
            panel4 = new Panel();
            panel3 = new Panel();
            panel2 = new Panel();
            panel1 = new Panel();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel10.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel5.Controls.Add(checkBox_Delete);
            panel5.Controls.Add(checkBox_Subfolders);
            panel5.Controls.Add(checkBox_Keep);
            panel5.Controls.Add(panel6);
            panel5.Controls.Add(panel10);
            panel5.Location = new Point(3, 82);
            panel5.Name = "panel5";
            panel5.Size = new Size(570, 394);
            panel5.TabIndex = 66;
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
            checkBox_Subfolders.Location = new Point(3, 41);
            checkBox_Subfolders.Name = "checkBox_Subfolders";
            checkBox_Subfolders.Size = new Size(255, 29);
            checkBox_Subfolders.TabIndex = 59;
            checkBox_Subfolders.Text = "Process Files in Subfolders";
            checkBox_Subfolders.UseVisualStyleBackColor = true;
            // 
            // checkBox_Keep
            // 
            checkBox_Keep.AutoSize = true;
            checkBox_Keep.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            checkBox_Keep.ForeColor = SystemColors.Control;
            checkBox_Keep.Location = new Point(3, 79);
            checkBox_Keep.Name = "checkBox_Keep";
            checkBox_Keep.Size = new Size(215, 29);
            checkBox_Keep.TabIndex = 61;
            checkBox_Keep.Text = "Keep the Original File";
            checkBox_Keep.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            panel6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel6.Controls.Add(label2);
            panel6.Controls.Add(label7);
            panel6.Controls.Add(comboBox_Document);
            panel6.Controls.Add(label6);
            panel6.Controls.Add(comboBox_Video);
            panel6.Controls.Add(label5);
            panel6.Controls.Add(comboBox_Image);
            panel6.Controls.Add(label4);
            panel6.Controls.Add(comboBox_Audio);
            panel6.Location = new Point(3, 114);
            panel6.Name = "panel6";
            panel6.Size = new Size(564, 232);
            panel6.TabIndex = 60;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(3, 111);
            label2.Name = "label2";
            label2.Size = new Size(556, 69);
            label2.TabIndex = 16;
            label2.Text = "Selected value in the dropdown is the output format for the chosen conversion option";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            label7.ForeColor = SystemColors.Control;
            label7.Location = new Point(441, 24);
            label7.Name = "label7";
            label7.Size = new Size(107, 25);
            label7.TabIndex = 15;
            label7.Text = "Document:";
            // 
            // comboBox_Document
            // 
            comboBox_Document.FormattingEnabled = true;
            comboBox_Document.Items.AddRange(new object[] { "DOC", "DOCX", "XLSX", "XLS", "PDF", "TXT" });
            comboBox_Document.Location = new Point(441, 52);
            comboBox_Document.Name = "comboBox_Document";
            comboBox_Document.Size = new Size(118, 23);
            comboBox_Document.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            label6.ForeColor = SystemColors.Control;
            label6.Location = new Point(295, 24);
            label6.Name = "label6";
            label6.Size = new Size(66, 25);
            label6.TabIndex = 13;
            label6.Text = "Video:";
            // 
            // comboBox_Video
            // 
            comboBox_Video.FormattingEnabled = true;
            comboBox_Video.Items.AddRange(new object[] { "MP4", "WEBM", "AVI", "WAV", "GIF", "MP3" });
            comboBox_Video.Location = new Point(295, 52);
            comboBox_Video.Name = "comboBox_Video";
            comboBox_Video.Size = new Size(118, 23);
            comboBox_Video.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            label5.ForeColor = SystemColors.Control;
            label5.Location = new Point(3, 24);
            label5.Name = "label5";
            label5.Size = new Size(71, 25);
            label5.TabIndex = 11;
            label5.Text = "Image:";
            // 
            // comboBox_Image
            // 
            comboBox_Image.FormattingEnabled = true;
            comboBox_Image.Items.AddRange(new object[] { "BMP", "JPEG", "PNG", "TIFF", "JIFF", "ICO" });
            comboBox_Image.Location = new Point(3, 52);
            comboBox_Image.Name = "comboBox_Image";
            comboBox_Image.Size = new Size(118, 23);
            comboBox_Image.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            label4.ForeColor = SystemColors.Control;
            label4.Location = new Point(149, 24);
            label4.Name = "label4";
            label4.Size = new Size(68, 25);
            label4.TabIndex = 9;
            label4.Text = "Audio:";
            // 
            // comboBox_Audio
            // 
            comboBox_Audio.FormattingEnabled = true;
            comboBox_Audio.Items.AddRange(new object[] { "MP3", "WAV", "AAC", "FLAC" });
            comboBox_Audio.Location = new Point(149, 52);
            comboBox_Audio.Name = "comboBox_Audio";
            comboBox_Audio.Size = new Size(118, 23);
            comboBox_Audio.TabIndex = 8;
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
            // bunifuElipse1
            // 
            bunifuElipse1.ElipseRadius = 5;
            bunifuElipse1.TargetControl = button_Saved;
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
            // panel4
            // 
            panel4.Controls.Add(label1);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 32);
            panel4.Name = "panel4";
            panel4.Size = new Size(579, 44);
            panel4.TabIndex = 65;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(0, 64, 64);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 482);
            panel3.Name = "panel3";
            panel3.Size = new Size(579, 32);
            panel3.TabIndex = 64;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 64, 64);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(579, 32);
            panel2.Name = "panel2";
            panel2.Size = new Size(32, 482);
            panel2.TabIndex = 63;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 64, 64);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(611, 32);
            panel1.TabIndex = 62;
            // 
            // Menu_Convert
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Menu_Convert";
            Size = new Size(611, 514);
            Load += Menu_Transform_Load;
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel10.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel5;
        private CheckBox checkBox_Subfolders;
        private CheckBox checkBox_Delete;
        private Panel panel10;
        private Button button_Saved;
        private Panel panel4;
        private Label label1;
        private Panel panel3;
        private Panel panel2;
        private Panel panel1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Panel panel6;
        private CheckBox checkBox_Keep;
        private ComboBox comboBox_Audio;
        private Label label4;
        private Label label7;
        private ComboBox comboBox_Document;
        private Label label6;
        private ComboBox comboBox_Video;
        private Label label5;
        private ComboBox comboBox_Image;
        private Label label2;
    }
}
