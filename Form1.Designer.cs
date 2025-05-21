namespace YtDLP_WinForms
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
            urlBox = new TextBox();
            folderBox = new TextBox();
            folderButton = new Button();
            outputBox = new TextBox();
            mainButton = new Button();
            progressDownload = new ProgressBar();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            cookiesBox = new TextBox();
            cookiesButton = new Button();
            textBox5 = new TextBox();
            yt_dlpBox = new TextBox();
            yt_dlpButton = new Button();
            textBox7 = new TextBox();
            audioComboBox = new ComboBox();
            videoComboBox = new ComboBox();
            textBox4 = new TextBox();
            SuspendLayout();
            // 
            // urlBox
            // 
            urlBox.Location = new Point(12, 38);
            urlBox.Name = "urlBox";
            urlBox.Size = new Size(727, 27);
            urlBox.TabIndex = 0;
            urlBox.TextChanged += urlBox_TextChanged;
            // 
            // folderBox
            // 
            folderBox.Location = new Point(12, 107);
            folderBox.Name = "folderBox";
            folderBox.ReadOnly = true;
            folderBox.Size = new Size(689, 27);
            folderBox.TabIndex = 1;
            // 
            // folderButton
            // 
            folderButton.Location = new Point(707, 107);
            folderButton.Name = "folderButton";
            folderButton.Size = new Size(32, 27);
            folderButton.TabIndex = 2;
            folderButton.Text = "...";
            folderButton.UseVisualStyleBackColor = true;
            folderButton.Click += folderButton_Click;
            // 
            // outputBox
            // 
            outputBox.Location = new Point(761, 12);
            outputBox.Multiline = true;
            outputBox.Name = "outputBox";
            outputBox.ReadOnly = true;
            outputBox.Size = new Size(527, 443);
            outputBox.TabIndex = 5;
            // 
            // mainButton
            // 
            mainButton.Location = new Point(288, 440);
            mainButton.Name = "mainButton";
            mainButton.Size = new Size(170, 37);
            mainButton.TabIndex = 6;
            mainButton.Text = "Получить форматы";
            mainButton.UseVisualStyleBackColor = true;
            mainButton.Click += mainButton_Click;
            // 
            // progressDownload
            // 
            progressDownload.Location = new Point(761, 473);
            progressDownload.Name = "progressDownload";
            progressDownload.Size = new Size(527, 29);
            progressDownload.TabIndex = 7;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.Menu;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Location = new Point(12, 12);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(125, 20);
            textBox1.TabIndex = 8;
            textBox1.Text = "YouTube-ссылка";
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.Menu;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Location = new Point(12, 81);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(333, 20);
            textBox2.TabIndex = 9;
            textBox2.Text = "Папка для сохранения файла/файлов";
            // 
            // textBox3
            // 
            textBox3.BackColor = SystemColors.Menu;
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Location = new Point(12, 157);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(333, 20);
            textBox3.TabIndex = 10;
            textBox3.Text = "Путь к файлу cookies.txt";
            // 
            // cookiesBox
            // 
            cookiesBox.Location = new Point(12, 183);
            cookiesBox.Name = "cookiesBox";
            cookiesBox.ReadOnly = true;
            cookiesBox.Size = new Size(689, 27);
            cookiesBox.TabIndex = 11;
            // 
            // cookiesButton
            // 
            cookiesButton.Location = new Point(707, 183);
            cookiesButton.Name = "cookiesButton";
            cookiesButton.Size = new Size(32, 27);
            cookiesButton.TabIndex = 12;
            cookiesButton.Text = "...";
            cookiesButton.UseVisualStyleBackColor = true;
            cookiesButton.Click += cookiesButton_Click;
            // 
            // textBox5
            // 
            textBox5.BackColor = SystemColors.Menu;
            textBox5.BorderStyle = BorderStyle.None;
            textBox5.Location = new Point(12, 233);
            textBox5.Name = "textBox5";
            textBox5.ReadOnly = true;
            textBox5.Size = new Size(333, 20);
            textBox5.TabIndex = 13;
            textBox5.Text = "Путь к файлу yt_dlp.exe";
            // 
            // yt_dlpBox
            // 
            yt_dlpBox.Location = new Point(12, 259);
            yt_dlpBox.Name = "yt_dlpBox";
            yt_dlpBox.ReadOnly = true;
            yt_dlpBox.Size = new Size(689, 27);
            yt_dlpBox.TabIndex = 14;
            // 
            // yt_dlpButton
            // 
            yt_dlpButton.Location = new Point(707, 259);
            yt_dlpButton.Name = "yt_dlpButton";
            yt_dlpButton.Size = new Size(32, 27);
            yt_dlpButton.TabIndex = 15;
            yt_dlpButton.Text = "...";
            yt_dlpButton.UseVisualStyleBackColor = true;
            yt_dlpButton.Click += yt_dlpButton_Click;
            // 
            // textBox7
            // 
            textBox7.BackColor = SystemColors.Menu;
            textBox7.BorderStyle = BorderStyle.None;
            textBox7.Location = new Point(133, 327);
            textBox7.Name = "textBox7";
            textBox7.ReadOnly = true;
            textBox7.Size = new Size(107, 20);
            textBox7.TabIndex = 16;
            textBox7.Text = "Аудио-формат";
            // 
            // audioComboBox
            // 
            audioComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            audioComboBox.FormattingEnabled = true;
            audioComboBox.Location = new Point(12, 353);
            audioComboBox.Name = "audioComboBox";
            audioComboBox.Size = new Size(333, 28);
            audioComboBox.TabIndex = 17;
            // 
            // videoComboBox
            // 
            videoComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            videoComboBox.FormattingEnabled = true;
            videoComboBox.Location = new Point(398, 353);
            videoComboBox.Name = "videoComboBox";
            videoComboBox.Size = new Size(341, 28);
            videoComboBox.TabIndex = 18;
            // 
            // textBox4
            // 
            textBox4.BackColor = SystemColors.Menu;
            textBox4.BorderStyle = BorderStyle.None;
            textBox4.Location = new Point(514, 327);
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.Size = new Size(107, 20);
            textBox4.TabIndex = 19;
            textBox4.Text = "Видео-формат";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1300, 514);
            Controls.Add(textBox4);
            Controls.Add(videoComboBox);
            Controls.Add(audioComboBox);
            Controls.Add(textBox7);
            Controls.Add(yt_dlpButton);
            Controls.Add(yt_dlpBox);
            Controls.Add(textBox5);
            Controls.Add(cookiesButton);
            Controls.Add(cookiesBox);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(progressDownload);
            Controls.Add(mainButton);
            Controls.Add(outputBox);
            Controls.Add(folderButton);
            Controls.Add(folderBox);
            Controls.Add(urlBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            Text = "YouDownloader";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox urlBox;
        private TextBox folderBox;
        private Button folderButton;
        private TextBox outputBox;
        private Button mainButton;
        private ProgressBar progressDownload;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox cookiesBox;
        private Button cookiesButton;
        private TextBox textBox5;
        private TextBox yt_dlpBox;
        private Button yt_dlpButton;
        private TextBox textBox7;
        private ComboBox audioComboBox;
        private ComboBox videoComboBox;
        private TextBox textBox4;
    }
}
