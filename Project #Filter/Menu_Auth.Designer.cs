namespace Project__Filter
{
    partial class Menu_Auth
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
            radioButton_Executable = new RadioButton();
            radioButton_Writable = new RadioButton();
            radioButton_Readable = new RadioButton();
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
            panel9.Size = new Size(619, 42);
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
            panel4.Size = new Size(628, 44);
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
            label1.Size = new Size(310, 37);
            label1.TabIndex = 0;
            label1.Text = "SORT BY PERMISSIONS";
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
            button_Saved.Size = new Size(619, 43);
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
            panel10.Size = new Size(619, 43);
            panel10.TabIndex = 57;
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel5.Controls.Add(radioButton_Executable);
            panel5.Controls.Add(radioButton_Writable);
            panel5.Controls.Add(radioButton_Readable);
            panel5.Controls.Add(panel10);
            panel5.Controls.Add(panel9);
            panel5.Location = new Point(3, 82);
            panel5.Name = "panel5";
            panel5.Size = new Size(619, 394);
            panel5.TabIndex = 64;
            // 
            // radioButton_Executable
            // 
            radioButton_Executable.AutoSize = true;
            radioButton_Executable.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            radioButton_Executable.ForeColor = SystemColors.Control;
            radioButton_Executable.Location = new Point(3, 146);
            radioButton_Executable.Name = "radioButton_Executable";
            radioButton_Executable.Size = new Size(166, 29);
            radioButton_Executable.TabIndex = 61;
            radioButton_Executable.TabStop = true;
            radioButton_Executable.Text = "Executable Files";
            radioButton_Executable.UseVisualStyleBackColor = true;
            // 
            // radioButton_Writable
            // 
            radioButton_Writable.AutoSize = true;
            radioButton_Writable.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            radioButton_Writable.ForeColor = SystemColors.Control;
            radioButton_Writable.Location = new Point(3, 97);
            radioButton_Writable.Name = "radioButton_Writable";
            radioButton_Writable.Size = new Size(146, 29);
            radioButton_Writable.TabIndex = 60;
            radioButton_Writable.TabStop = true;
            radioButton_Writable.Text = "Writable Files";
            radioButton_Writable.UseVisualStyleBackColor = true;
            // 
            // radioButton_Readable
            // 
            radioButton_Readable.AutoSize = true;
            radioButton_Readable.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            radioButton_Readable.ForeColor = SystemColors.Control;
            radioButton_Readable.Location = new Point(3, 48);
            radioButton_Readable.Name = "radioButton_Readable";
            radioButton_Readable.Size = new Size(151, 29);
            radioButton_Readable.TabIndex = 59;
            radioButton_Readable.TabStop = true;
            radioButton_Readable.Text = "Readable Files";
            radioButton_Readable.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(0, 64, 64);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 482);
            panel3.Name = "panel3";
            panel3.Size = new Size(628, 32);
            panel3.TabIndex = 62;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 64, 64);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(628, 32);
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
            panel1.Size = new Size(660, 32);
            panel1.TabIndex = 60;
            // 
            // Menu_Auth
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            Controls.Add(panel4);
            Controls.Add(panel5);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Menu_Auth";
            Size = new Size(660, 514);
            Load += Menu_Auth_Load;
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
        private RadioButton radioButton_Executable;
        private RadioButton radioButton_Writable;
        private RadioButton radioButton_Readable;
    }
}
