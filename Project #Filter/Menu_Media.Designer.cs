namespace Project__Filter
{
    partial class Menu_Media
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
            radioButton_AspectRatio = new RadioButton();
            radioButton_Codec = new RadioButton();
            radioButton_Frames = new RadioButton();
            radioButton_Resolution = new RadioButton();
            radioButton_Duration = new RadioButton();
            panel3 = new Panel();
            panel2 = new Panel();
            panel1 = new Panel();
            panel9.SuspendLayout();
            panel4.SuspendLayout();
            panel10.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // panel9
            // 
            panel9.Controls.Add(label3);
            panel9.Dock = DockStyle.Top;
            panel9.Location = new Point(0, 0);
            panel9.Name = "panel9";
            panel9.Size = new Size(570, 42);
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
            panel4.Size = new Size(579, 44);
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
            label1.Size = new Size(219, 37);
            label1.TabIndex = 0;
            label1.Text = "SORT BY MEDIA";
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
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel5.Controls.Add(radioButton_AspectRatio);
            panel5.Controls.Add(radioButton_Codec);
            panel5.Controls.Add(radioButton_Frames);
            panel5.Controls.Add(radioButton_Resolution);
            panel5.Controls.Add(radioButton_Duration);
            panel5.Controls.Add(panel10);
            panel5.Controls.Add(panel9);
            panel5.Location = new Point(3, 82);
            panel5.Name = "panel5";
            panel5.Size = new Size(570, 394);
            panel5.TabIndex = 64;
            // 
            // radioButton_AspectRatio
            // 
            radioButton_AspectRatio.AutoSize = true;
            radioButton_AspectRatio.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            radioButton_AspectRatio.ForeColor = SystemColors.Control;
            radioButton_AspectRatio.Location = new Point(4, 248);
            radioButton_AspectRatio.Name = "radioButton_AspectRatio";
            radioButton_AspectRatio.Size = new Size(121, 25);
            radioButton_AspectRatio.TabIndex = 65;
            radioButton_AspectRatio.TabStop = true;
            radioButton_AspectRatio.Text = "Aspect Ratio";
            radioButton_AspectRatio.UseVisualStyleBackColor = true;
            // 
            // radioButton_Codec
            // 
            radioButton_Codec.AutoSize = true;
            radioButton_Codec.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            radioButton_Codec.ForeColor = SystemColors.Control;
            radioButton_Codec.Location = new Point(4, 198);
            radioButton_Codec.Name = "radioButton_Codec";
            radioButton_Codec.Size = new Size(75, 25);
            radioButton_Codec.TabIndex = 63;
            radioButton_Codec.TabStop = true;
            radioButton_Codec.Text = "Codec";
            radioButton_Codec.UseVisualStyleBackColor = true;
            // 
            // radioButton_Frames
            // 
            radioButton_Frames.AutoSize = true;
            radioButton_Frames.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            radioButton_Frames.ForeColor = SystemColors.Control;
            radioButton_Frames.Location = new Point(4, 148);
            radioButton_Frames.Name = "radioButton_Frames";
            radioButton_Frames.Size = new Size(110, 25);
            radioButton_Frames.TabIndex = 62;
            radioButton_Frames.TabStop = true;
            radioButton_Frames.Text = "Frame Rate";
            radioButton_Frames.UseVisualStyleBackColor = true;
            // 
            // radioButton_Resolution
            // 
            radioButton_Resolution.AutoSize = true;
            radioButton_Resolution.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            radioButton_Resolution.ForeColor = SystemColors.Control;
            radioButton_Resolution.Location = new Point(3, 98);
            radioButton_Resolution.Name = "radioButton_Resolution";
            radioButton_Resolution.Size = new Size(110, 25);
            radioButton_Resolution.TabIndex = 61;
            radioButton_Resolution.TabStop = true;
            radioButton_Resolution.Text = "Resolution ";
            radioButton_Resolution.UseVisualStyleBackColor = true;
            // 
            // radioButton_Duration
            // 
            radioButton_Duration.AutoSize = true;
            radioButton_Duration.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            radioButton_Duration.ForeColor = SystemColors.Control;
            radioButton_Duration.Location = new Point(3, 48);
            radioButton_Duration.Name = "radioButton_Duration";
            radioButton_Duration.Size = new Size(91, 25);
            radioButton_Duration.TabIndex = 59;
            radioButton_Duration.TabStop = true;
            radioButton_Duration.Text = "Duration";
            radioButton_Duration.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(0, 64, 64);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 482);
            panel3.Name = "panel3";
            panel3.Size = new Size(579, 32);
            panel3.TabIndex = 62;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 64, 64);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(579, 32);
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
            panel1.Size = new Size(611, 32);
            panel1.TabIndex = 60;
            // 
            // Menu_Media
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            Controls.Add(panel4);
            Controls.Add(panel5);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Menu_Media";
            Size = new Size(611, 514);
            Load += Menu_Load;
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel10.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
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
        private RadioButton radioButton_Resolution;
        private RadioButton radioButton_Duration;
        private RadioButton radioButton_AspectRatio;
        private RadioButton radioButton_Codec;
        private RadioButton radioButton_Frames;
    }
}
