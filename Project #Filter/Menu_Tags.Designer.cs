namespace Project__Filter
{
    partial class Menu_Tags
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu_Tags));
            panel4 = new Panel();
            label1 = new Label();
            panel5 = new Panel();
            panel6 = new Panel();
            label3 = new Label();
            textBox_Tag = new TextBox();
            label4 = new Label();
            panel11 = new Panel();
            button_Remove = new Button();
            button_Add = new Button();
            panel3 = new Panel();
            panel2 = new Panel();
            panel1 = new Panel();
            panel7 = new Panel();
            treeView_Tags = new TreeView();
            panel8 = new Panel();
            label2 = new Label();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel11.SuspendLayout();
            panel7.SuspendLayout();
            panel8.SuspendLayout();
            SuspendLayout();
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
            label1.Size = new Size(198, 37);
            label1.TabIndex = 0;
            label1.Text = "SORT BY TAGS";
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel5.Controls.Add(panel6);
            panel5.Location = new Point(3, 82);
            panel5.Name = "panel5";
            panel5.Size = new Size(387, 394);
            panel5.TabIndex = 64;
            // 
            // panel6
            // 
            panel6.Controls.Add(label3);
            panel6.Controls.Add(textBox_Tag);
            panel6.Controls.Add(label4);
            panel6.Controls.Add(panel11);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(387, 394);
            panel6.TabIndex = 59;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label3.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(-3, 106);
            label3.Name = "label3";
            label3.Size = new Size(384, 151);
            label3.TabIndex = 58;
            label3.Text = resources.GetString("label3.Text");
            // 
            // textBox_Tag
            // 
            textBox_Tag.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox_Tag.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox_Tag.Location = new Point(3, 42);
            textBox_Tag.Name = "textBox_Tag";
            textBox_Tag.Size = new Size(384, 33);
            textBox_Tag.TabIndex = 57;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Top;
            label4.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.Control;
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Size = new Size(187, 32);
            label4.TabIndex = 0;
            label4.Text = "Add Tags Here:";
            // 
            // panel11
            // 
            panel11.Controls.Add(button_Remove);
            panel11.Controls.Add(button_Add);
            panel11.Dock = DockStyle.Bottom;
            panel11.Location = new Point(0, 351);
            panel11.Name = "panel11";
            panel11.Size = new Size(387, 43);
            panel11.TabIndex = 56;
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
            button_Remove.Location = new Point(296, 0);
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
            button_Add.Location = new Point(3, 0);
            button_Add.Margin = new Padding(3, 2, 3, 2);
            button_Add.Name = "button_Add";
            button_Add.Size = new Size(88, 41);
            button_Add.TabIndex = 52;
            button_Add.UseVisualStyleBackColor = false;
            button_Add.Click += button_Add_Click;
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
            // panel7
            // 
            panel7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panel7.Controls.Add(treeView_Tags);
            panel7.Controls.Add(panel8);
            panel7.Location = new Point(399, 82);
            panel7.Name = "panel7";
            panel7.Size = new Size(234, 394);
            panel7.TabIndex = 65;
            // 
            // treeView_Tags
            // 
            treeView_Tags.Dock = DockStyle.Fill;
            treeView_Tags.Location = new Point(0, 42);
            treeView_Tags.Name = "treeView_Tags";
            treeView_Tags.Size = new Size(234, 352);
            treeView_Tags.TabIndex = 57;
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
            label2.Size = new Size(88, 25);
            label2.TabIndex = 0;
            label2.Text = "Tags List:";
            // 
            // Menu_Tags
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            Controls.Add(panel7);
            Controls.Add(panel4);
            Controls.Add(panel5);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Menu_Tags";
            Size = new Size(665, 514);
            Load += Menu_Load;
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel11.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel4;
        private Label label1;
        private Panel panel5;
        private Panel panel3;
        private Panel panel2;
        private Panel panel1;
        private Panel panel6;
        private Label label4;
        private Panel panel7;
        private TreeView treeView_Tags;
        private Panel panel8;
        private Label label2;
        private Panel panel11;
        private Button button_Remove;
        private Button button_Add;
        private TextBox textBox_Tag;
        private Label label3;
    }
}
