namespace Project__Filter
{
    partial class Menu_Video
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
            panel3 = new Panel();
            panel1 = new Panel();
            label1 = new Label();
            bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(components);
            button_Saved = new Button();
            panel10 = new Panel();
            panel2 = new Panel();
            panel5 = new Panel();
            radioButton8 = new RadioButton();
            radioButton7 = new RadioButton();
            radioButton6 = new RadioButton();
            radioButton5 = new RadioButton();
            radioButton4 = new RadioButton();
            radioButton3 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            panel4 = new Panel();
            panel10.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(0, 64, 64);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 482);
            panel3.Name = "panel3";
            panel3.Size = new Size(633, 32);
            panel3.TabIndex = 69;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 64, 64);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(665, 32);
            panel1.TabIndex = 67;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(360, 37);
            label1.TabIndex = 0;
            label1.Text = "CONVERT VIDEO OPTIONS:";
            // 
            // bunifuElipse1
            // 
            bunifuElipse1.ElipseRadius = 5;
            bunifuElipse1.TargetControl = button_Saved;
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
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 64, 64);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(633, 32);
            panel2.Name = "panel2";
            panel2.Size = new Size(32, 482);
            panel2.TabIndex = 68;
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel5.Controls.Add(radioButton8);
            panel5.Controls.Add(radioButton7);
            panel5.Controls.Add(radioButton6);
            panel5.Controls.Add(radioButton5);
            panel5.Controls.Add(radioButton4);
            panel5.Controls.Add(radioButton3);
            panel5.Controls.Add(radioButton2);
            panel5.Controls.Add(radioButton1);
            panel5.Controls.Add(panel10);
            panel5.Location = new Point(3, 82);
            panel5.Name = "panel5";
            panel5.Size = new Size(624, 394);
            panel5.TabIndex = 71;
            // 
            // radioButton8
            // 
            radioButton8.AutoSize = true;
            radioButton8.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            radioButton8.ForeColor = SystemColors.Control;
            radioButton8.Location = new Point(3, 267);
            radioButton8.Name = "radioButton8";
            radioButton8.Size = new Size(72, 29);
            radioButton8.TabIndex = 65;
            radioButton8.TabStop = true;
            radioButton8.Text = "MKV";
            radioButton8.UseVisualStyleBackColor = true;
            // 
            // radioButton7
            // 
            radioButton7.AutoSize = true;
            radioButton7.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            radioButton7.ForeColor = SystemColors.Control;
            radioButton7.Location = new Point(3, 223);
            radioButton7.Name = "radioButton7";
            radioButton7.Size = new Size(74, 29);
            radioButton7.TabIndex = 64;
            radioButton7.TabStop = true;
            radioButton7.Text = "MOV";
            radioButton7.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            radioButton6.AutoSize = true;
            radioButton6.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            radioButton6.ForeColor = SystemColors.Control;
            radioButton6.Location = new Point(3, 179);
            radioButton6.Name = "radioButton6";
            radioButton6.Size = new Size(60, 29);
            radioButton6.TabIndex = 63;
            radioButton6.TabStop = true;
            radioButton6.Text = "FLV";
            radioButton6.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            radioButton5.AutoSize = true;
            radioButton5.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            radioButton5.ForeColor = SystemColors.Control;
            radioButton5.Location = new Point(3, 135);
            radioButton5.Name = "radioButton5";
            radioButton5.Size = new Size(70, 29);
            radioButton5.TabIndex = 62;
            radioButton5.TabStop = true;
            radioButton5.Text = "MP4";
            radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            radioButton4.ForeColor = SystemColors.Control;
            radioButton4.Location = new Point(0, 311);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(90, 29);
            radioButton4.TabIndex = 61;
            radioButton4.TabStop = true;
            radioButton4.Text = "AUDIO";
            radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            radioButton3.ForeColor = SystemColors.Control;
            radioButton3.Location = new Point(3, 91);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(60, 29);
            radioButton3.TabIndex = 60;
            radioButton3.TabStop = true;
            radioButton3.Text = "AVI";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            radioButton2.ForeColor = SystemColors.Control;
            radioButton2.Location = new Point(3, 47);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(87, 29);
            radioButton2.TabIndex = 59;
            radioButton2.TabStop = true;
            radioButton2.Text = "WEBM";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            radioButton1.ForeColor = SystemColors.Control;
            radioButton1.Location = new Point(3, 3);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(59, 29);
            radioButton1.TabIndex = 58;
            radioButton1.TabStop = true;
            radioButton1.Text = "GIF";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            panel4.Controls.Add(label1);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 32);
            panel4.Name = "panel4";
            panel4.Size = new Size(633, 44);
            panel4.TabIndex = 70;
            // 
            // Menu_Video
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Menu_Video";
            Size = new Size(665, 514);
            panel10.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel3;
        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Panel panel5;
        private Panel panel4;
        private Panel panel10;
        private Button button_Saved;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private RadioButton radioButton4;
        private RadioButton radioButton7;
        private RadioButton radioButton6;
        private RadioButton radioButton5;
        private RadioButton radioButton8;
    }
}
