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
            panel6 = new Panel();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            label2 = new Label();
            checkBox_Subfolders = new CheckBox();
            checkBox_Delete = new CheckBox();
            panel10 = new Panel();
            button_Saved = new Button();
            bunifuElipse3 = new Bunifu.Framework.UI.BunifuElipse(components);
            bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(components);
            bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(components);
            label1 = new Label();
            panel4 = new Panel();
            panel3 = new Panel();
            panel2 = new Panel();
            panel1 = new Panel();
            label3 = new Label();
            panel7 = new Panel();
            radioButton3 = new RadioButton();
            radioButton4 = new RadioButton();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel10.SuspendLayout();
            panel4.SuspendLayout();
            panel7.SuspendLayout();
            SuspendLayout();
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel5.Controls.Add(panel6);
            panel5.Controls.Add(checkBox_Subfolders);
            panel5.Controls.Add(checkBox_Delete);
            panel5.Controls.Add(panel10);
            panel5.Location = new Point(3, 82);
            panel5.Name = "panel5";
            panel5.Size = new Size(624, 394);
            panel5.TabIndex = 66;
            // 
            // panel6
            // 
            panel6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel6.Controls.Add(panel7);
            panel6.Controls.Add(label3);
            panel6.Controls.Add(radioButton2);
            panel6.Controls.Add(radioButton1);
            panel6.Controls.Add(label2);
            panel6.Location = new Point(3, 97);
            panel6.Name = "panel6";
            panel6.Size = new Size(618, 179);
            panel6.TabIndex = 60;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            radioButton2.ForeColor = SystemColors.Control;
            radioButton2.Location = new Point(171, 40);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(160, 25);
            radioButton2.TabIndex = 2;
            radioButton2.TabStop = true;
            radioButton2.Text = "Custom File Name";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            radioButton1.ForeColor = SystemColors.Control;
            radioButton1.Location = new Point(3, 40);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(162, 25);
            radioButton1.TabIndex = 1;
            radioButton1.TabStop = true;
            radioButton1.Text = "Original FIle Name";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(110, 25);
            label2.TabIndex = 0;
            label2.Text = "Documents";
            // 
            // checkBox_Subfolders
            // 
            checkBox_Subfolders.AutoSize = true;
            checkBox_Subfolders.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            checkBox_Subfolders.ForeColor = SystemColors.Control;
            checkBox_Subfolders.Location = new Point(3, 55);
            checkBox_Subfolders.Name = "checkBox_Subfolders";
            checkBox_Subfolders.Size = new Size(317, 36);
            checkBox_Subfolders.TabIndex = 59;
            checkBox_Subfolders.Text = "Process Files in Subfolders";
            checkBox_Subfolders.UseVisualStyleBackColor = true;
            // 
            // checkBox_Delete
            // 
            checkBox_Delete.AutoSize = true;
            checkBox_Delete.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            checkBox_Delete.ForeColor = SystemColors.Control;
            checkBox_Delete.Location = new Point(3, 3);
            checkBox_Delete.Name = "checkBox_Delete";
            checkBox_Delete.Size = new Size(264, 36);
            checkBox_Delete.TabIndex = 58;
            checkBox_Delete.Text = "Delete Empty Folders";
            checkBox_Delete.UseVisualStyleBackColor = true;
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
            // 
            // bunifuElipse3
            // 
            bunifuElipse3.ElipseRadius = 5;
            bunifuElipse3.TargetControl = this;
            // 
            // bunifuElipse1
            // 
            bunifuElipse1.ElipseRadius = 5;
            bunifuElipse1.TargetControl = button_Saved;
            // 
            // bunifuElipse2
            // 
            bunifuElipse2.ElipseRadius = 5;
            bunifuElipse2.TargetControl = this;
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
            panel4.Size = new Size(633, 44);
            panel4.TabIndex = 65;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(0, 64, 64);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 482);
            panel3.Name = "panel3";
            panel3.Size = new Size(633, 32);
            panel3.TabIndex = 64;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 64, 64);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(633, 32);
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
            panel1.Size = new Size(665, 32);
            panel1.TabIndex = 62;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(3, 80);
            label3.Name = "label3";
            label3.Size = new Size(213, 25);
            label3.TabIndex = 3;
            label3.Text = "Sort images to convert:";
            // 
            // panel7
            // 
            panel7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel7.Controls.Add(radioButton3);
            panel7.Controls.Add(radioButton4);
            panel7.Location = new Point(3, 108);
            panel7.Name = "panel7";
            panel7.Size = new Size(612, 68);
            panel7.TabIndex = 4;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            radioButton3.ForeColor = SystemColors.Control;
            radioButton3.Location = new Point(171, 3);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(160, 25);
            radioButton3.TabIndex = 4;
            radioButton3.TabStop = true;
            radioButton3.Text = "Custom File Name";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            radioButton4.ForeColor = SystemColors.Control;
            radioButton4.Location = new Point(3, 3);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(162, 25);
            radioButton4.TabIndex = 3;
            radioButton4.TabStop = true;
            radioButton4.Text = "Original FIle Name";
            radioButton4.UseVisualStyleBackColor = true;
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
            Size = new Size(665, 514);
            Load += Menu_Transform_Load;
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel10.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel5;
        private CheckBox checkBox_Subfolders;
        private CheckBox checkBox_Delete;
        private Panel panel10;
        private Button button_Saved;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse3;
        private Panel panel4;
        private Label label1;
        private Panel panel3;
        private Panel panel2;
        private Panel panel1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private Panel panel6;
        private Label label2;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Label label3;
        private Panel panel7;
        private RadioButton radioButton3;
        private RadioButton radioButton4;
    }
}
