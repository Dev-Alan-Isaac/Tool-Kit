namespace Project__Filter
{
    partial class Option_Download
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
            bunifuElipse4 = new Bunifu.Framework.UI.BunifuElipse(components);
            button_Path = new Button();
            panel_Top = new Panel();
            panel_Bottom = new Panel();
            bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(components);
            button_Filter = new Button();
            bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(components);
            progressBar_Time = new ProgressBar();
            panel_Right = new Panel();
            bunifuElipse3 = new Bunifu.Framework.UI.BunifuElipse(components);
            panel_Footer = new Panel();
            panel2 = new Panel();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            panel_Header = new Panel();
            panel1 = new Panel();
            label1 = new Label();
            textBox_Path = new TextBox();
            label_Warning = new Label();
            panel_Top.SuspendLayout();
            panel_Footer.SuspendLayout();
            panel2.SuspendLayout();
            panel_Header.SuspendLayout();
            SuspendLayout();
            // 
            // bunifuElipse4
            // 
            bunifuElipse4.ElipseRadius = 5;
            bunifuElipse4.TargetControl = button_Path;
            // 
            // button_Path
            // 
            button_Path.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_Path.BackColor = Color.FromArgb(17, 88, 106);
            button_Path.BackgroundImage = Properties.Resources.Button_Icon_AddFile;
            button_Path.BackgroundImageLayout = ImageLayout.Zoom;
            button_Path.Cursor = Cursors.Hand;
            button_Path.FlatAppearance.BorderSize = 0;
            button_Path.FlatAppearance.MouseOverBackColor = SystemColors.ActiveBorder;
            button_Path.FlatStyle = FlatStyle.Flat;
            button_Path.Location = new Point(1092, 3);
            button_Path.Margin = new Padding(3, 2, 3, 2);
            button_Path.Name = "button_Path";
            button_Path.Size = new Size(67, 25);
            button_Path.TabIndex = 0;
            button_Path.UseVisualStyleBackColor = false;
            // 
            // panel_Top
            // 
            panel_Top.BackColor = Color.FromArgb(17, 88, 106);
            panel_Top.Controls.Add(button_Path);
            panel_Top.Dock = DockStyle.Top;
            panel_Top.Location = new Point(0, 0);
            panel_Top.Margin = new Padding(3, 2, 3, 2);
            panel_Top.Name = "panel_Top";
            panel_Top.Size = new Size(699, 32);
            panel_Top.TabIndex = 52;
            // 
            // panel_Bottom
            // 
            panel_Bottom.BackColor = Color.FromArgb(17, 88, 106);
            panel_Bottom.Dock = DockStyle.Bottom;
            panel_Bottom.Location = new Point(0, 530);
            panel_Bottom.Margin = new Padding(3, 2, 3, 2);
            panel_Bottom.Name = "panel_Bottom";
            panel_Bottom.Size = new Size(699, 32);
            panel_Bottom.TabIndex = 53;
            // 
            // bunifuElipse1
            // 
            bunifuElipse1.ElipseRadius = 5;
            bunifuElipse1.TargetControl = button_Filter;
            // 
            // button_Filter
            // 
            button_Filter.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button_Filter.BackColor = SystemColors.ActiveBorder;
            button_Filter.BackgroundImage = Properties.Resources.Button_Icon_Download_2;
            button_Filter.BackgroundImageLayout = ImageLayout.Zoom;
            button_Filter.Cursor = Cursors.Hand;
            button_Filter.Enabled = false;
            button_Filter.FlatAppearance.BorderSize = 0;
            button_Filter.FlatStyle = FlatStyle.Flat;
            button_Filter.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            button_Filter.ForeColor = Color.White;
            button_Filter.Location = new Point(3, 6);
            button_Filter.Margin = new Padding(3, 2, 3, 2);
            button_Filter.Name = "button_Filter";
            button_Filter.Size = new Size(659, 26);
            button_Filter.TabIndex = 28;
            button_Filter.UseVisualStyleBackColor = false;
            button_Filter.Click += button_Filter_Click;
            // 
            // bunifuElipse2
            // 
            bunifuElipse2.ElipseRadius = 5;
            bunifuElipse2.TargetControl = progressBar_Time;
            // 
            // progressBar_Time
            // 
            progressBar_Time.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressBar_Time.Location = new Point(3, 38);
            progressBar_Time.Margin = new Padding(3, 2, 3, 2);
            progressBar_Time.Name = "progressBar_Time";
            progressBar_Time.Size = new Size(659, 22);
            progressBar_Time.Step = 1;
            progressBar_Time.TabIndex = 24;
            // 
            // panel_Right
            // 
            panel_Right.BackColor = Color.FromArgb(17, 88, 106);
            panel_Right.Dock = DockStyle.Right;
            panel_Right.Location = new Point(667, 32);
            panel_Right.Margin = new Padding(3, 2, 3, 2);
            panel_Right.Name = "panel_Right";
            panel_Right.Size = new Size(32, 498);
            panel_Right.TabIndex = 54;
            // 
            // bunifuElipse3
            // 
            bunifuElipse3.ElipseRadius = 5;
            bunifuElipse3.TargetControl = this;
            // 
            // panel_Footer
            // 
            panel_Footer.Controls.Add(button_Filter);
            panel_Footer.Controls.Add(progressBar_Time);
            panel_Footer.Dock = DockStyle.Bottom;
            panel_Footer.Location = new Point(0, 466);
            panel_Footer.Margin = new Padding(3, 2, 3, 2);
            panel_Footer.Name = "panel_Footer";
            panel_Footer.Size = new Size(667, 64);
            panel_Footer.TabIndex = 56;
            // 
            // panel2
            // 
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(3, 86);
            panel2.Name = "panel2";
            panel2.Size = new Size(658, 375);
            panel2.TabIndex = 58;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 205);
            label5.Name = "label5";
            label5.Size = new Size(38, 15);
            label5.TabIndex = 3;
            label5.Text = "label5";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 75);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 2;
            label4.Text = "label4";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 172);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 1;
            label3.Text = "label3";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 44);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 0;
            label2.Text = "label2";
            // 
            // panel_Header
            // 
            panel_Header.Controls.Add(panel1);
            panel_Header.Controls.Add(label1);
            panel_Header.Controls.Add(textBox_Path);
            panel_Header.Controls.Add(label_Warning);
            panel_Header.Dock = DockStyle.Top;
            panel_Header.Location = new Point(0, 32);
            panel_Header.Margin = new Padding(3, 2, 3, 2);
            panel_Header.Name = "panel_Header";
            panel_Header.Size = new Size(667, 49);
            panel_Header.TabIndex = 50;
            // 
            // panel1
            // 
            panel1.Location = new Point(332, 49);
            panel1.Name = "panel1";
            panel1.Size = new Size(329, 380);
            panel1.TabIndex = 59;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(64, 64, 64);
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(71, 32);
            label1.TabIndex = 23;
            label1.Text = "Path:";
            // 
            // textBox_Path
            // 
            textBox_Path.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox_Path.BackColor = Color.FromArgb(64, 64, 64);
            textBox_Path.BorderStyle = BorderStyle.FixedSingle;
            textBox_Path.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            textBox_Path.ForeColor = Color.White;
            textBox_Path.Location = new Point(86, 4);
            textBox_Path.Margin = new Padding(3, 2, 3, 2);
            textBox_Path.Name = "textBox_Path";
            textBox_Path.Size = new Size(572, 33);
            textBox_Path.TabIndex = 25;
            // 
            // label_Warning
            // 
            label_Warning.Anchor = AnchorStyles.Top;
            label_Warning.AutoSize = true;
            label_Warning.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            label_Warning.ForeColor = Color.FromArgb(255, 128, 0);
            label_Warning.Location = new Point(935, 43);
            label_Warning.Name = "label_Warning";
            label_Warning.Size = new Size(0, 21);
            label_Warning.TabIndex = 29;
            // 
            // Option_Download
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            Controls.Add(panel_Header);
            Controls.Add(panel2);
            Controls.Add(panel_Footer);
            Controls.Add(panel_Right);
            Controls.Add(panel_Top);
            Controls.Add(panel_Bottom);
            Name = "Option_Download";
            Size = new Size(699, 562);
            panel_Top.ResumeLayout(false);
            panel_Footer.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel_Header.ResumeLayout(false);
            panel_Header.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse4;
        private Button button_Path;
        private Panel panel_Top;
        private Panel panel_Bottom;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Button button_Filter;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private ProgressBar progressBar_Time;
        private Panel panel_Right;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse3;
        private Panel panel_Footer;
        private Panel panel2;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Panel panel_Header;
        private Panel panel1;
        private Label label1;
        private TextBox textBox_Path;
        private Label label_Warning;
    }
}
