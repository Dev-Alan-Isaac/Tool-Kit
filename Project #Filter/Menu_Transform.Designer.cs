namespace Project__Filter
{
    partial class Menu_Transform
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
            panel2 = new Panel();
            panel1 = new Panel();
            bunifuElipse3 = new Bunifu.Framework.UI.BunifuElipse(components);
            bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(components);
            button_Saved = new Button();
            label2 = new Label();
            treeView1 = new TreeView();
            panel8 = new Panel();
            panel10 = new Panel();
            panel7 = new Panel();
            bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(components);
            panel5 = new Panel();
            panel6 = new Panel();
            label4 = new Label();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            checkBox_Subfolders = new CheckBox();
            checkBox_Delete = new CheckBox();
            label1 = new Label();
            panel4 = new Panel();
            panel8.SuspendLayout();
            panel10.SuspendLayout();
            panel7.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
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
            panel3.TabIndex = 68;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 64, 64);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(633, 32);
            panel2.Name = "panel2";
            panel2.Size = new Size(32, 482);
            panel2.TabIndex = 67;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 64, 64);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(665, 32);
            panel1.TabIndex = 66;
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
            // button_Saved
            // 
            button_Saved.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button_Saved.BackColor = Color.Teal;
            button_Saved.BackgroundImage = Properties.Resources.Button_Icon_Save;
            button_Saved.BackgroundImageLayout = ImageLayout.Zoom;
            button_Saved.FlatAppearance.BorderSize = 0;
            button_Saved.FlatStyle = FlatStyle.Flat;
            button_Saved.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            button_Saved.ForeColor = Color.White;
            button_Saved.Location = new Point(0, 0);
            button_Saved.Margin = new Padding(3, 2, 3, 2);
            button_Saved.Name = "button_Saved";
            button_Saved.Size = new Size(381, 43);
            button_Saved.TabIndex = 52;
            button_Saved.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(134, 25);
            label2.TabIndex = 0;
            label2.Text = "Extension List:";
            // 
            // treeView1
            // 
            treeView1.Dock = DockStyle.Fill;
            treeView1.Location = new Point(0, 42);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(234, 352);
            treeView1.TabIndex = 57;
            // 
            // panel8
            // 
            panel8.Controls.Add(label2);
            panel8.Dock = DockStyle.Top;
            panel8.Location = new Point(0, 0);
            panel8.Name = "panel8";
            panel8.Size = new Size(234, 42);
            panel8.TabIndex = 0;
            // 
            // panel10
            // 
            panel10.Controls.Add(button_Saved);
            panel10.Dock = DockStyle.Bottom;
            panel10.Location = new Point(0, 351);
            panel10.Name = "panel10";
            panel10.Size = new Size(384, 43);
            panel10.TabIndex = 57;
            // 
            // panel7
            // 
            panel7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panel7.Controls.Add(treeView1);
            panel7.Controls.Add(panel8);
            panel7.Location = new Point(393, 82);
            panel7.Name = "panel7";
            panel7.Size = new Size(234, 394);
            panel7.TabIndex = 71;
            // 
            // bunifuElipse2
            // 
            bunifuElipse2.ElipseRadius = 5;
            bunifuElipse2.TargetControl = this;
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel5.Controls.Add(panel6);
            panel5.Controls.Add(checkBox_Subfolders);
            panel5.Controls.Add(checkBox_Delete);
            panel5.Controls.Add(panel10);
            panel5.Location = new Point(3, 82);
            panel5.Name = "panel5";
            panel5.Size = new Size(384, 394);
            panel5.TabIndex = 70;
            // 
            // panel6
            // 
            panel6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel6.Controls.Add(label4);
            panel6.Controls.Add(radioButton2);
            panel6.Controls.Add(radioButton1);
            panel6.Location = new Point(3, 98);
            panel6.Name = "panel6";
            panel6.Size = new Size(378, 133);
            panel6.TabIndex = 63;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.Control;
            label4.Location = new Point(3, 0);
            label4.Name = "label4";
            label4.Size = new Size(113, 25);
            label4.TabIndex = 64;
            label4.Text = "Documents";
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            radioButton2.ForeColor = SystemColors.Control;
            radioButton2.Location = new Point(3, 101);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(142, 29);
            radioButton2.TabIndex = 63;
            radioButton2.TabStop = true;
            radioButton2.Text = "Without Title";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            radioButton1.ForeColor = SystemColors.Control;
            radioButton1.Location = new Point(3, 54);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(113, 29);
            radioButton1.TabIndex = 62;
            radioButton1.TabStop = true;
            radioButton1.Text = "With Title";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // checkBox_Subfolders
            // 
            checkBox_Subfolders.AutoSize = true;
            checkBox_Subfolders.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            checkBox_Subfolders.ForeColor = SystemColors.Control;
            checkBox_Subfolders.Location = new Point(3, 56);
            checkBox_Subfolders.Name = "checkBox_Subfolders";
            checkBox_Subfolders.Size = new Size(317, 36);
            checkBox_Subfolders.TabIndex = 61;
            checkBox_Subfolders.Text = "Process Files in Subfolders";
            checkBox_Subfolders.UseVisualStyleBackColor = true;
            // 
            // checkBox_Delete
            // 
            checkBox_Delete.AutoSize = true;
            checkBox_Delete.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            checkBox_Delete.ForeColor = SystemColors.Control;
            checkBox_Delete.Location = new Point(3, 6);
            checkBox_Delete.Name = "checkBox_Delete";
            checkBox_Delete.Size = new Size(264, 36);
            checkBox_Delete.TabIndex = 60;
            checkBox_Delete.Text = "Delete Empty Folders";
            checkBox_Delete.UseVisualStyleBackColor = true;
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
            panel4.TabIndex = 69;
            // 
            // Menu_Transform
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            Controls.Add(panel7);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Menu_Transform";
            Size = new Size(665, 514);
            Load += Menu_Transform_Load;
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel10.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel3;
        private Panel panel2;
        private Panel panel1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse3;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Button button_Saved;
        private Label label2;
        private TreeView treeView1;
        private Panel panel8;
        private Panel panel10;
        private Panel panel7;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private Panel panel5;
        private Label label1;
        private Panel panel4;
        private Panel panel6;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private CheckBox checkBox_Subfolders;
        private CheckBox checkBox_Delete;
        private Label label4;
    }
}
