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
            radioButton_Custom = new RadioButton();
            radioButton_Original = new RadioButton();
            panel7 = new Panel();
            radioButton_Size = new RadioButton();
            label3 = new Label();
            radioButton_Name = new RadioButton();
            radioButton_Date = new RadioButton();
            label2 = new Label();
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
            panel7.SuspendLayout();
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
            checkBox_Subfolders.Location = new Point(3, 57);
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
            checkBox_Keep.Location = new Point(3, 111);
            checkBox_Keep.Name = "checkBox_Keep";
            checkBox_Keep.Size = new Size(215, 29);
            checkBox_Keep.TabIndex = 61;
            checkBox_Keep.Text = "Keep the Original File";
            checkBox_Keep.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            panel6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel6.Controls.Add(radioButton_Custom);
            panel6.Controls.Add(radioButton_Original);
            panel6.Controls.Add(panel7);
            panel6.Controls.Add(label2);
            panel6.Location = new Point(3, 147);
            panel6.Name = "panel6";
            panel6.Size = new Size(564, 199);
            panel6.TabIndex = 60;
            // 
            // radioButton_Custom
            // 
            radioButton_Custom.AutoSize = true;
            radioButton_Custom.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            radioButton_Custom.ForeColor = SystemColors.Control;
            radioButton_Custom.Location = new Point(207, 47);
            radioButton_Custom.Name = "radioButton_Custom";
            radioButton_Custom.Size = new Size(188, 29);
            radioButton_Custom.TabIndex = 7;
            radioButton_Custom.TabStop = true;
            radioButton_Custom.Text = "Custom File Name";
            radioButton_Custom.UseVisualStyleBackColor = true;
            // 
            // radioButton_Original
            // 
            radioButton_Original.AutoSize = true;
            radioButton_Original.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            radioButton_Original.ForeColor = SystemColors.Control;
            radioButton_Original.Location = new Point(3, 47);
            radioButton_Original.Name = "radioButton_Original";
            radioButton_Original.Size = new Size(190, 29);
            radioButton_Original.TabIndex = 6;
            radioButton_Original.TabStop = true;
            radioButton_Original.Text = "Original File Name";
            radioButton_Original.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            panel7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel7.Controls.Add(radioButton_Size);
            panel7.Controls.Add(label3);
            panel7.Controls.Add(radioButton_Name);
            panel7.Controls.Add(radioButton_Date);
            panel7.Location = new Point(3, 103);
            panel7.Name = "panel7";
            panel7.Size = new Size(558, 93);
            panel7.TabIndex = 4;
            // 
            // radioButton_Size
            // 
            radioButton_Size.AutoSize = true;
            radioButton_Size.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            radioButton_Size.ForeColor = SystemColors.Control;
            radioButton_Size.Location = new Point(322, 48);
            radioButton_Size.Name = "radioButton_Size";
            radioButton_Size.Size = new Size(131, 29);
            radioButton_Size.TabIndex = 5;
            radioButton_Size.TabStop = true;
            radioButton_Size.Text = "Sort by Size";
            radioButton_Size.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(270, 32);
            label3.TabIndex = 3;
            label3.Text = "Sort images to convert:";
            // 
            // radioButton_Name
            // 
            radioButton_Name.AutoSize = true;
            radioButton_Name.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            radioButton_Name.ForeColor = SystemColors.Control;
            radioButton_Name.Location = new Point(157, 48);
            radioButton_Name.Name = "radioButton_Name";
            radioButton_Name.Size = new Size(149, 29);
            radioButton_Name.TabIndex = 4;
            radioButton_Name.TabStop = true;
            radioButton_Name.Text = "Sort by Name";
            radioButton_Name.UseVisualStyleBackColor = true;
            // 
            // radioButton_Date
            // 
            radioButton_Date.AutoSize = true;
            radioButton_Date.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            radioButton_Date.ForeColor = SystemColors.Control;
            radioButton_Date.Location = new Point(3, 48);
            radioButton_Date.Name = "radioButton_Date";
            radioButton_Date.Size = new Size(138, 29);
            radioButton_Date.TabIndex = 3;
            radioButton_Date.TabStop = true;
            radioButton_Date.Text = "Sort by Date";
            radioButton_Date.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(137, 32);
            label2.TabIndex = 0;
            label2.Text = "Documents";
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
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
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
        private Label label2;
        private Label label3;
        private Panel panel7;
        private RadioButton radioButton_Name;
        private RadioButton radioButton_Date;
        private RadioButton radioButton_Size;
        private RadioButton radioButton_Custom;
        private RadioButton radioButton_Original;
        private CheckBox checkBox_Keep;
    }
}
