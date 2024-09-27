namespace Project__Filter
{
    partial class Menu_Type
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
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            label1 = new Label();
            panel5 = new Panel();
            panel6 = new Panel();
            button_Remove = new Button();
            button_Add = new Button();
            panel10 = new Panel();
            button_Saved = new Button();
            checkBox_Executables = new CheckBox();
            checkBox_Archives = new CheckBox();
            checkBox_Videos = new CheckBox();
            checkBox_Audio = new CheckBox();
            checkBox_Images = new CheckBox();
            checkBox_Documents = new CheckBox();
            panel9 = new Panel();
            label3 = new Label();
            panel7 = new Panel();
            treeView1 = new TreeView();
            panel8 = new Panel();
            label2 = new Label();
            bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(components);
            bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(components);
            bunifuElipse3 = new Bunifu.Framework.UI.BunifuElipse(components);
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel10.SuspendLayout();
            panel9.SuspendLayout();
            panel7.SuspendLayout();
            panel8.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 64, 64);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(611, 32);
            panel1.TabIndex = 51;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 64, 64);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(579, 32);
            panel2.Name = "panel2";
            panel2.Size = new Size(32, 482);
            panel2.TabIndex = 52;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(0, 64, 64);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 482);
            panel3.Name = "panel3";
            panel3.Size = new Size(579, 32);
            panel3.TabIndex = 53;
            // 
            // panel4
            // 
            panel4.Controls.Add(label1);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 32);
            panel4.Name = "panel4";
            panel4.Size = new Size(579, 44);
            panel4.TabIndex = 54;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(253, 37);
            label1.TabIndex = 0;
            label1.Text = "SORT BY FILE TYPE";
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel5.Controls.Add(panel6);
            panel5.Controls.Add(panel10);
            panel5.Controls.Add(checkBox_Executables);
            panel5.Controls.Add(checkBox_Archives);
            panel5.Controls.Add(checkBox_Videos);
            panel5.Controls.Add(checkBox_Audio);
            panel5.Controls.Add(checkBox_Images);
            panel5.Controls.Add(checkBox_Documents);
            panel5.Controls.Add(panel9);
            panel5.Location = new Point(3, 82);
            panel5.Name = "panel5";
            panel5.Size = new Size(333, 394);
            panel5.TabIndex = 55;
            // 
            // panel6
            // 
            panel6.Controls.Add(button_Remove);
            panel6.Controls.Add(button_Add);
            panel6.Dock = DockStyle.Bottom;
            panel6.Location = new Point(0, 305);
            panel6.Name = "panel6";
            panel6.Size = new Size(333, 46);
            panel6.TabIndex = 56;
            // 
            // button_Remove
            // 
            button_Remove.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            button_Remove.BackColor = Color.Teal;
            button_Remove.BackgroundImage = Properties.Resources.Button_Icon_Remove;
            button_Remove.BackgroundImageLayout = ImageLayout.Zoom;
            button_Remove.FlatAppearance.BorderSize = 0;
            button_Remove.FlatStyle = FlatStyle.Flat;
            button_Remove.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            button_Remove.ForeColor = Color.White;
            button_Remove.Location = new Point(242, 3);
            button_Remove.Margin = new Padding(3, 2, 3, 2);
            button_Remove.Name = "button_Remove";
            button_Remove.Size = new Size(88, 41);
            button_Remove.TabIndex = 51;
            button_Remove.UseVisualStyleBackColor = false;
            button_Remove.Click += button_Remove_Click;
            // 
            // button_Add
            // 
            button_Add.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            button_Add.BackColor = Color.Teal;
            button_Add.BackgroundImage = Properties.Resources.Button_Icon_Add;
            button_Add.BackgroundImageLayout = ImageLayout.Zoom;
            button_Add.FlatAppearance.BorderSize = 0;
            button_Add.FlatStyle = FlatStyle.Flat;
            button_Add.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            button_Add.ForeColor = Color.White;
            button_Add.Location = new Point(0, 3);
            button_Add.Margin = new Padding(3, 2, 3, 2);
            button_Add.Name = "button_Add";
            button_Add.Size = new Size(88, 41);
            button_Add.TabIndex = 52;
            button_Add.UseVisualStyleBackColor = false;
            button_Add.Click += button_Add_Click;
            // 
            // panel10
            // 
            panel10.Controls.Add(button_Saved);
            panel10.Dock = DockStyle.Bottom;
            panel10.Location = new Point(0, 351);
            panel10.Name = "panel10";
            panel10.Size = new Size(333, 43);
            panel10.TabIndex = 57;
            // 
            // button_Saved
            // 
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
            button_Saved.Size = new Size(330, 43);
            button_Saved.TabIndex = 52;
            button_Saved.UseVisualStyleBackColor = false;
            button_Saved.Click += button_Saved_Click;
            // 
            // checkBox_Executables
            // 
            checkBox_Executables.AutoSize = true;
            checkBox_Executables.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            checkBox_Executables.Location = new Point(3, 220);
            checkBox_Executables.Name = "checkBox_Executables";
            checkBox_Executables.Size = new Size(115, 25);
            checkBox_Executables.TabIndex = 7;
            checkBox_Executables.Text = "Executables";
            checkBox_Executables.UseVisualStyleBackColor = true;
            checkBox_Executables.CheckedChanged += checkBox_CheckedChanged;
            // 
            // checkBox_Archives
            // 
            checkBox_Archives.AutoSize = true;
            checkBox_Archives.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            checkBox_Archives.Location = new Point(3, 186);
            checkBox_Archives.Name = "checkBox_Archives";
            checkBox_Archives.Size = new Size(91, 25);
            checkBox_Archives.TabIndex = 6;
            checkBox_Archives.Text = "Archives";
            checkBox_Archives.UseVisualStyleBackColor = true;
            checkBox_Archives.CheckedChanged += checkBox_CheckedChanged;
            // 
            // checkBox_Videos
            // 
            checkBox_Videos.AutoSize = true;
            checkBox_Videos.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            checkBox_Videos.Location = new Point(3, 152);
            checkBox_Videos.Name = "checkBox_Videos";
            checkBox_Videos.Size = new Size(79, 25);
            checkBox_Videos.TabIndex = 5;
            checkBox_Videos.Text = "Videos";
            checkBox_Videos.UseVisualStyleBackColor = true;
            checkBox_Videos.CheckedChanged += checkBox_CheckedChanged;
            // 
            // checkBox_Audio
            // 
            checkBox_Audio.AutoSize = true;
            checkBox_Audio.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            checkBox_Audio.Location = new Point(3, 118);
            checkBox_Audio.Name = "checkBox_Audio";
            checkBox_Audio.Size = new Size(73, 25);
            checkBox_Audio.TabIndex = 4;
            checkBox_Audio.Text = "Audio";
            checkBox_Audio.UseVisualStyleBackColor = true;
            checkBox_Audio.CheckedChanged += checkBox_CheckedChanged;
            // 
            // checkBox_Images
            // 
            checkBox_Images.AutoSize = true;
            checkBox_Images.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            checkBox_Images.Location = new Point(3, 84);
            checkBox_Images.Name = "checkBox_Images";
            checkBox_Images.Size = new Size(82, 25);
            checkBox_Images.TabIndex = 3;
            checkBox_Images.Text = "Images";
            checkBox_Images.UseVisualStyleBackColor = true;
            checkBox_Images.CheckedChanged += checkBox_CheckedChanged;
            // 
            // checkBox_Documents
            // 
            checkBox_Documents.AutoSize = true;
            checkBox_Documents.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            checkBox_Documents.Location = new Point(3, 50);
            checkBox_Documents.Name = "checkBox_Documents";
            checkBox_Documents.Size = new Size(112, 25);
            checkBox_Documents.TabIndex = 2;
            checkBox_Documents.Text = "Documents";
            checkBox_Documents.UseVisualStyleBackColor = true;
            checkBox_Documents.CheckedChanged += checkBox_CheckedChanged;
            // 
            // panel9
            // 
            panel9.Controls.Add(label3);
            panel9.Dock = DockStyle.Top;
            panel9.Location = new Point(0, 0);
            panel9.Name = "panel9";
            panel9.Size = new Size(333, 42);
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
            // panel7
            // 
            panel7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panel7.Controls.Add(treeView1);
            panel7.Controls.Add(panel8);
            panel7.Location = new Point(342, 82);
            panel7.Name = "panel7";
            panel7.Size = new Size(234, 394);
            panel7.TabIndex = 56;
            // 
            // treeView1
            // 
            treeView1.Dock = DockStyle.Fill;
            treeView1.Location = new Point(0, 42);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(234, 352);
            treeView1.TabIndex = 57;
            treeView1.AfterSelect += treeView1_AfterSelect;
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
            // bunifuElipse1
            // 
            bunifuElipse1.ElipseRadius = 5;
            bunifuElipse1.TargetControl = button_Saved;
            // 
            // bunifuElipse2
            // 
            bunifuElipse2.ElipseRadius = 5;
            bunifuElipse2.TargetControl = button_Add;
            // 
            // bunifuElipse3
            // 
            bunifuElipse3.ElipseRadius = 5;
            bunifuElipse3.TargetControl = button_Remove;
            // 
            // Menu_Type
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
            ForeColor = Color.White;
            Name = "Menu_Type";
            Size = new Size(611, 514);
            Load += UserControl1_Load;
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel10.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel7.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Label label1;
        private Panel panel5;
        private Panel panel9;
        private Label label3;
        private Panel panel7;
        private Panel panel8;
        private Label label2;
        private CheckBox checkBox_Videos;
        private CheckBox checkBox_Audio;
        private CheckBox checkBox_Images;
        private CheckBox checkBox_Documents;
        private TreeView treeView1;
        private Panel panel10;
        private Button button_Saved;
        private CheckBox checkBox_Executables;
        private CheckBox checkBox_Archives;
        private Panel panel6;
        private Button button_Remove;
        private Button button_Add;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse3;
    }
}
