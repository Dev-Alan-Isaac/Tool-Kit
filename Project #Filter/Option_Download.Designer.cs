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
            panel_Top.SuspendLayout();
            panel_Footer.SuspendLayout();
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
            // Option_Download
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            Controls.Add(panel_Footer);
            Controls.Add(panel_Right);
            Controls.Add(panel_Top);
            Controls.Add(panel_Bottom);
            Name = "Option_Download";
            Size = new Size(699, 562);
            panel_Top.ResumeLayout(false);
            panel_Footer.ResumeLayout(false);
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
    }
}
