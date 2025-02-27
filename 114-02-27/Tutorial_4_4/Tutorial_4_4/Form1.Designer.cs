namespace Tutorial_4_4
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            distancetextBox1 = new TextBox();
            gastextBox = new TextBox();
            label4 = new Label();
            averagelabel = new Label();
            calculatebutton1 = new Button();
            exitButton1 = new Button();
            logListBox = new ListBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 20F);
            label1.Location = new Point(64, 74);
            label1.Name = "label1";
            label1.Size = new Size(204, 35);
            label1.TabIndex = 0;
            label1.Text = "輸入行駛里程數";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft JhengHei UI", 20F);
            label2.Location = new Point(64, 159);
            label2.Name = "label2";
            label2.Size = new Size(204, 35);
            label2.TabIndex = 1;
            label2.Text = "消耗油量公升數";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft JhengHei UI", 20F);
            label3.Location = new Point(64, 234);
            label3.Name = "label3";
            label3.Size = new Size(177, 35);
            label3.TabIndex = 2;
            label3.Text = "你的平均油耗";
            // 
            // distancetextBox1
            // 
            distancetextBox1.Font = new Font("Microsoft JhengHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 136);
            distancetextBox1.Location = new Point(274, 77);
            distancetextBox1.Name = "distancetextBox1";
            distancetextBox1.Size = new Size(135, 32);
            distancetextBox1.TabIndex = 3;
            // 
            // gastextBox
            // 
            gastextBox.Font = new Font("Microsoft JhengHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 136);
            gastextBox.Location = new Point(274, 165);
            gastextBox.Name = "gastextBox";
            gastextBox.Size = new Size(135, 32);
            gastextBox.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft JhengHei UI", 20F);
            label4.Location = new Point(274, 234);
            label4.Name = "label4";
            label4.Size = new Size(0, 35);
            label4.TabIndex = 5;
            // 
            // averagelabel
            // 
            averagelabel.AutoSize = true;
            averagelabel.BorderStyle = BorderStyle.Fixed3D;
            averagelabel.Font = new Font("Microsoft JhengHei UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 136);
            averagelabel.Location = new Point(274, 234);
            averagelabel.Name = "averagelabel";
            averagelabel.Size = new Size(115, 37);
            averagelabel.TabIndex = 6;
            averagelabel.Text = "              ";
            averagelabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // calculatebutton1
            // 
            calculatebutton1.Location = new Point(147, 300);
            calculatebutton1.Name = "calculatebutton1";
            calculatebutton1.Size = new Size(121, 72);
            calculatebutton1.TabIndex = 7;
            calculatebutton1.Text = "計算";
            calculatebutton1.UseVisualStyleBackColor = true;
            calculatebutton1.Click += calculatebutton1_Click;
            // 
            // exitButton1
            // 
            exitButton1.Location = new Point(316, 300);
            exitButton1.Name = "exitButton1";
            exitButton1.Size = new Size(118, 72);
            exitButton1.TabIndex = 8;
            exitButton1.Text = "離開";
            exitButton1.UseVisualStyleBackColor = true;
            exitButton1.Click += exitButton1_Click;
            // 
            // logListBox
            // 
            logListBox.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 136);
            logListBox.FormattingEnabled = true;
            logListBox.ItemHeight = 20;
            logListBox.Location = new Point(488, 52);
            logListBox.Name = "logListBox";
            logListBox.Size = new Size(189, 164);
            logListBox.TabIndex = 9;
            // 
            // button1
            // 
            button1.Location = new Point(499, 300);
            button1.Name = "button1";
            button1.Size = new Size(121, 72);
            button1.TabIndex = 10;
            button1.Text = "總平均油耗";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(logListBox);
            Controls.Add(exitButton1);
            Controls.Add(calculatebutton1);
            Controls.Add(averagelabel);
            Controls.Add(label4);
            Controls.Add(gastextBox);
            Controls.Add(distancetextBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox distancetextBox1;
        private TextBox gastextBox;
        private Label label4;
        private Label averagelabel;
        private Button calculatebutton1;
        private Button exitButton1;
        private ListBox logListBox;
        private Button button1;
    }
}
