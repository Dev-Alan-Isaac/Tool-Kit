﻿namespace Project__Filter
{
    partial class Menu_Date
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
            panel10 = new Panel();
            button_Saved = new Button();
            radioButton_Accessed = new RadioButton();
            radioButton_Modified = new RadioButton();
            radioButton_Creation = new RadioButton();
            panel9 = new Panel();
            label3 = new Label();
            panel4 = new Panel();
            label1 = new Label();
            panel3 = new Panel();
            panel2 = new Panel();
            panel1 = new Panel();
            bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(components);
            panel5.SuspendLayout();
            panel10.SuspendLayout();
            panel9.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel5.Controls.Add(panel10);
            panel5.Controls.Add(radioButton_Accessed);
            panel5.Controls.Add(radioButton_Modified);
            panel5.Controls.Add(radioButton_Creation);
            panel5.Controls.Add(panel9);
            panel5.Location = new Point(3, 82);
            panel5.Name = "panel5";
            panel5.Size = new Size(570, 394);
            panel5.TabIndex = 69;
            // 
            // panel10
            // 
            panel10.Controls.Add(button_Saved);
            panel10.Dock = DockStyle.Bottom;
            panel10.Location = new Point(0, 351);
            panel10.Name = "panel10";
            panel10.Size = new Size(570, 43);
            panel10.TabIndex = 62;
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
            button_Saved.Click += button_Saved_Click_1;
            // 
            // radioButton_Accessed
            // 
            radioButton_Accessed.AutoSize = true;
            radioButton_Accessed.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            radioButton_Accessed.ForeColor = SystemColors.Control;
            radioButton_Accessed.Location = new Point(0, 147);
            radioButton_Accessed.Name = "radioButton_Accessed";
            radioButton_Accessed.Size = new Size(193, 29);
            radioButton_Accessed.TabIndex = 61;
            radioButton_Accessed.TabStop = true;
            radioButton_Accessed.Text = "Last Accessed Date";
            radioButton_Accessed.UseVisualStyleBackColor = true;
            // 
            // radioButton_Modified
            // 
            radioButton_Modified.AutoSize = true;
            radioButton_Modified.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            radioButton_Modified.ForeColor = SystemColors.Control;
            radioButton_Modified.Location = new Point(0, 96);
            radioButton_Modified.Name = "radioButton_Modified";
            radioButton_Modified.Size = new Size(193, 29);
            radioButton_Modified.TabIndex = 60;
            radioButton_Modified.TabStop = true;
            radioButton_Modified.Text = "Last Modified Date";
            radioButton_Modified.UseVisualStyleBackColor = true;
            // 
            // radioButton_Creation
            // 
            radioButton_Creation.AutoSize = true;
            radioButton_Creation.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            radioButton_Creation.ForeColor = SystemColors.Control;
            radioButton_Creation.Location = new Point(0, 45);
            radioButton_Creation.Name = "radioButton_Creation";
            radioButton_Creation.Size = new Size(149, 29);
            radioButton_Creation.TabIndex = 59;
            radioButton_Creation.TabStop = true;
            radioButton_Creation.Text = "Creation Date";
            radioButton_Creation.UseVisualStyleBackColor = true;
            // 
            // panel9
            // 
            panel9.Controls.Add(label3);
            panel9.Dock = DockStyle.Top;
            panel9.Location = new Point(0, 0);
            panel9.Name = "panel9";
            panel9.Size = new Size(570, 39);
            panel9.TabIndex = 1;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(570, 39);
            label3.TabIndex = 0;
            label3.Text = "Select an option to sort based on the available date attributes.";
            // 
            // panel4
            // 
            panel4.Controls.Add(label1);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 32);
            panel4.Name = "panel4";
            panel4.Size = new Size(579, 44);
            panel4.TabIndex = 68;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(198, 37);
            label1.TabIndex = 0;
            label1.Text = "SORT BY DATE";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(0, 64, 64);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 482);
            panel3.Name = "panel3";
            panel3.Size = new Size(579, 32);
            panel3.TabIndex = 67;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 64, 64);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(579, 32);
            panel2.Name = "panel2";
            panel2.Size = new Size(32, 482);
            panel2.TabIndex = 66;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 64, 64);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(611, 32);
            panel1.TabIndex = 65;
            // 
            // bunifuElipse1
            // 
            bunifuElipse1.ElipseRadius = 5;
            bunifuElipse1.TargetControl = button_Saved;
            // 
            // Menu_Date
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Menu_Date";
            Size = new Size(611, 514);
            Load += Menu_Date_Load;
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel10.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel5;
        private RadioButton radioButton_Modified;
        private RadioButton radioButton_Creation;
        private Panel panel9;
        private Label label3;
        private Panel panel4;
        private Label label1;
        private Panel panel3;
        private Panel panel2;
        private Panel panel1;
        private RadioButton radioButton_Accessed;
        private Panel panel10;
        private Button button_Saved;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
    }
}
