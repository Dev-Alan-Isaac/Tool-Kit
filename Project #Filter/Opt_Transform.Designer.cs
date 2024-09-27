namespace Project__Filter
{
    partial class Opt_Transform
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            panel_R = new Panel();
            panel_B = new Panel();
            panel_T = new Panel();
            button_Path = new Button();
            panel_button = new Panel();
            label2 = new Label();
            progressBar_Time = new ProgressBar();
            checkBox_Delete = new CheckBox();
            button_Convert = new Button();
            panel_Path = new Panel();
            textBox_Path = new TextBox();
            panel_Middle = new Panel();
            panel_Action = new Panel();
            label_Warning = new Label();
            radioButton1 = new RadioButton();
            label3 = new Label();
            panel2 = new Panel();
            radioButton2 = new RadioButton();
            radioButton3 = new RadioButton();
            radioButton4 = new RadioButton();
            radioButton5 = new RadioButton();
            panel1 = new Panel();
            panel3 = new Panel();
            treeView1 = new TreeView();
            panel4 = new Panel();
            label5 = new Label();
            label4 = new Label();
            panel_T.SuspendLayout();
            panel_button.SuspendLayout();
            panel_Path.SuspendLayout();
            panel_Middle.SuspendLayout();
            panel_Action.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
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
            label1.TabIndex = 17;
            label1.Text = "Path:";
            // 
            // panel_R
            // 
            panel_R.BackColor = Color.FromArgb(0, 64, 64);
            panel_R.Dock = DockStyle.Right;
            panel_R.Location = new Point(624, 32);
            panel_R.Margin = new Padding(3, 2, 3, 2);
            panel_R.Name = "panel_R";
            panel_R.Size = new Size(32, 478);
            panel_R.TabIndex = 26;
            // 
            // panel_B
            // 
            panel_B.BackColor = Color.FromArgb(0, 64, 64);
            panel_B.Dock = DockStyle.Bottom;
            panel_B.Location = new Point(0, 510);
            panel_B.Margin = new Padding(3, 2, 3, 2);
            panel_B.Name = "panel_B";
            panel_B.Size = new Size(656, 32);
            panel_B.TabIndex = 24;
            // 
            // panel_T
            // 
            panel_T.BackColor = Color.FromArgb(0, 64, 64);
            panel_T.Controls.Add(button_Path);
            panel_T.Dock = DockStyle.Top;
            panel_T.Location = new Point(0, 0);
            panel_T.Margin = new Padding(3, 2, 3, 2);
            panel_T.Name = "panel_T";
            panel_T.Size = new Size(656, 32);
            panel_T.TabIndex = 23;
            // 
            // button_Path
            // 
            button_Path.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_Path.BackColor = Color.FromArgb(0, 64, 64);
            button_Path.BackgroundImage = Properties.Resources.Button_Icon_AddFile;
            button_Path.BackgroundImageLayout = ImageLayout.Zoom;
            button_Path.FlatAppearance.BorderSize = 0;
            button_Path.FlatStyle = FlatStyle.Flat;
            button_Path.Location = new Point(592, 4);
            button_Path.Margin = new Padding(3, 2, 3, 2);
            button_Path.Name = "button_Path";
            button_Path.Size = new Size(25, 25);
            button_Path.TabIndex = 0;
            button_Path.UseVisualStyleBackColor = false;
            // 
            // panel_button
            // 
            panel_button.Controls.Add(label2);
            panel_button.Controls.Add(progressBar_Time);
            panel_button.Controls.Add(checkBox_Delete);
            panel_button.Controls.Add(button_Convert);
            panel_button.Dock = DockStyle.Bottom;
            panel_button.Location = new Point(0, 446);
            panel_button.Margin = new Padding(3, 2, 3, 2);
            panel_button.Name = "panel_button";
            panel_button.Size = new Size(624, 64);
            panel_button.TabIndex = 39;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(64, 64, 64);
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(3, 10);
            label2.Name = "label2";
            label2.Size = new Size(307, 19);
            label2.TabIndex = 43;
            label2.Text = "Would you like to delete unused directories?";
            // 
            // progressBar_Time
            // 
            progressBar_Time.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressBar_Time.Location = new Point(3, 38);
            progressBar_Time.Margin = new Padding(3, 2, 3, 2);
            progressBar_Time.Name = "progressBar_Time";
            progressBar_Time.Size = new Size(616, 22);
            progressBar_Time.Step = 1;
            progressBar_Time.TabIndex = 42;
            // 
            // checkBox_Delete
            // 
            checkBox_Delete.AutoSize = true;
            checkBox_Delete.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            checkBox_Delete.ForeColor = Color.White;
            checkBox_Delete.Location = new Point(334, 13);
            checkBox_Delete.Margin = new Padding(3, 2, 3, 2);
            checkBox_Delete.Name = "checkBox_Delete";
            checkBox_Delete.Size = new Size(15, 14);
            checkBox_Delete.TabIndex = 44;
            checkBox_Delete.UseVisualStyleBackColor = true;
            // 
            // button_Convert
            // 
            button_Convert.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_Convert.BackColor = Color.Teal;
            button_Convert.BackgroundImage = Properties.Resources.Button_Icon_Start;
            button_Convert.BackgroundImageLayout = ImageLayout.Zoom;
            button_Convert.Cursor = Cursors.Hand;
            button_Convert.Enabled = false;
            button_Convert.FlatAppearance.BorderSize = 0;
            button_Convert.FlatStyle = FlatStyle.Flat;
            button_Convert.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            button_Convert.ForeColor = Color.White;
            button_Convert.Location = new Point(386, 6);
            button_Convert.Margin = new Padding(3, 2, 3, 2);
            button_Convert.Name = "button_Convert";
            button_Convert.Size = new Size(233, 26);
            button_Convert.TabIndex = 45;
            button_Convert.UseVisualStyleBackColor = false;
            button_Convert.Click += button_Convert_Click;
            // 
            // panel_Path
            // 
            panel_Path.Controls.Add(textBox_Path);
            panel_Path.Controls.Add(label1);
            panel_Path.Dock = DockStyle.Top;
            panel_Path.Location = new Point(0, 32);
            panel_Path.Margin = new Padding(3, 2, 3, 2);
            panel_Path.Name = "panel_Path";
            panel_Path.Size = new Size(624, 53);
            panel_Path.TabIndex = 40;
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
            textBox_Path.ReadOnly = true;
            textBox_Path.Size = new Size(529, 33);
            textBox_Path.TabIndex = 26;
            // 
            // panel_Middle
            // 
            panel_Middle.BackColor = Color.FromArgb(64, 64, 64);
            panel_Middle.Controls.Add(panel_Action);
            panel_Middle.Dock = DockStyle.Fill;
            panel_Middle.Location = new Point(0, 85);
            panel_Middle.Margin = new Padding(3, 2, 3, 2);
            panel_Middle.Name = "panel_Middle";
            panel_Middle.Size = new Size(624, 361);
            panel_Middle.TabIndex = 41;
            // 
            // panel_Action
            // 
            panel_Action.Controls.Add(panel3);
            panel_Action.Controls.Add(panel1);
            panel_Action.Controls.Add(label_Warning);
            panel_Action.Dock = DockStyle.Fill;
            panel_Action.ForeColor = SystemColors.Control;
            panel_Action.Location = new Point(0, 0);
            panel_Action.Name = "panel_Action";
            panel_Action.Size = new Size(624, 361);
            panel_Action.TabIndex = 41;
            // 
            // label_Warning
            // 
            label_Warning.AutoSize = true;
            label_Warning.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_Warning.ForeColor = Color.FromArgb(255, 128, 0);
            label_Warning.Location = new Point(3, 103);
            label_Warning.Name = "label_Warning";
            label_Warning.Size = new Size(0, 25);
            label_Warning.TabIndex = 0;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            radioButton1.ForeColor = SystemColors.Control;
            radioButton1.Location = new Point(3, 47);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(108, 29);
            radioButton1.TabIndex = 44;
            radioButton1.TabStop = true;
            radioButton1.Text = "Text Files";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(318, 32);
            label3.TabIndex = 45;
            label3.Text = " Select File Type to Convert:";
            // 
            // panel2
            // 
            panel2.Controls.Add(label3);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(334, 41);
            panel2.TabIndex = 46;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            radioButton2.ForeColor = SystemColors.Control;
            radioButton2.Location = new Point(3, 100);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(127, 29);
            radioButton2.TabIndex = 48;
            radioButton2.TabStop = true;
            radioButton2.Text = "Image Files";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            radioButton3.ForeColor = SystemColors.Control;
            radioButton3.Location = new Point(3, 153);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(124, 29);
            radioButton3.TabIndex = 49;
            radioButton3.TabStop = true;
            radioButton3.Text = "Audio Files";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            radioButton4.ForeColor = SystemColors.Control;
            radioButton4.Location = new Point(3, 206);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(122, 29);
            radioButton4.TabIndex = 50;
            radioButton4.TabStop = true;
            radioButton4.Text = "Video Files";
            radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            radioButton5.AutoSize = true;
            radioButton5.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            radioButton5.ForeColor = SystemColors.Control;
            radioButton5.Location = new Point(3, 259);
            radioButton5.Name = "radioButton5";
            radioButton5.Size = new Size(277, 29);
            radioButton5.TabIndex = 51;
            radioButton5.TabStop = true;
            radioButton5.Text = "Documents (PDF, Word, etc.)";
            radioButton5.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(radioButton1);
            panel1.Controls.Add(radioButton5);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(radioButton2);
            panel1.Controls.Add(radioButton4);
            panel1.Controls.Add(radioButton3);
            panel1.Location = new Point(3, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(334, 351);
            panel1.TabIndex = 52;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel3.AutoScroll = true;
            panel3.Controls.Add(treeView1);
            panel3.Controls.Add(panel4);
            panel3.Location = new Point(343, 5);
            panel3.Name = "panel3";
            panel3.Size = new Size(274, 351);
            panel3.TabIndex = 60;
            // 
            // treeView1
            // 
            treeView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            treeView1.Location = new Point(76, 67);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(195, 281);
            treeView1.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.Controls.Add(label5);
            panel4.Controls.Add(label4);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(274, 61);
            panel4.TabIndex = 0;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.Control;
            label5.Location = new Point(76, 30);
            label5.Name = "label5";
            label5.Size = new Size(23, 25);
            label5.TabIndex = 1;
            label5.Text = "0";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.Control;
            label4.Location = new Point(76, 0);
            label4.Name = "label4";
            label4.Size = new Size(119, 30);
            label4.TabIndex = 0;
            label4.Text = "File Count:";
            // 
            // Opt_Transform
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            Controls.Add(panel_Middle);
            Controls.Add(panel_Path);
            Controls.Add(panel_button);
            Controls.Add(panel_R);
            Controls.Add(panel_B);
            Controls.Add(panel_T);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Opt_Transform";
            Size = new Size(656, 542);
            panel_T.ResumeLayout(false);
            panel_button.ResumeLayout(false);
            panel_button.PerformLayout();
            panel_Path.ResumeLayout(false);
            panel_Path.PerformLayout();
            panel_Middle.ResumeLayout(false);
            panel_Action.ResumeLayout(false);
            panel_Action.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private Panel panel_R;
        private Panel panel_B;
        private Panel panel_T;
        private Button button_Path;
        private Panel panel_button;
        private Panel panel_Path;
        private TextBox textBox_Path;
        private Panel panel_Middle;
        private Label label2;
        private ProgressBar progressBar_Time;
        private CheckBox checkBox_Delete;
        private Button button_Convert;
        private Panel panel_Action;
        private Label label_Warning;
        private RadioButton radioButton5;
        private RadioButton radioButton4;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Panel panel2;
        private Label label3;
        private Panel panel1;
        private Panel panel3;
        private TreeView treeView1;
        private Panel panel4;
        private Label label5;
        private Label label4;
    }
}
