using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace YtDLP_WinForms
{
    public partial class Form1 : Form
    {
        private readonly YtDlpEngine engine;


        
        public Form1()
        {
            
            InitializeComponent();

            
            engine = new YtDlpEngine();
            engine.OnWrapperMessage += (sender, e) => outputBox.Text += $"\r\n{e}";

            
            engine.OnProgressDownload += (sender, percent) =>
            {
                progressDownload.Invoke(() =>
                {
                    progressDownload.Value = percent;
                });
            };
        }


        private void folderButton_Click(object sender, EventArgs e)
        {
            
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.ShowNewFolderButton = true;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                    folderBox.Text = folderDialog.SelectedPath;
            }
        }

        private void cookiesButton_Click(object sender, EventArgs e)
        {
           
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
                fileDialog.Title = "Выберите файл";
                fileDialog.Multiselect = false;

                if (fileDialog.ShowDialog() == DialogResult.OK)
                    cookiesBox.Text = fileDialog.FileName;

                engine.SetCookiesPath(fileDialog.FileName);
            }
        }

        private void yt_dlpButton_Click(object sender, EventArgs e)
        {
            
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "Исполняемые файлы (*.exe)|*.exe";
                fileDialog.Title = "Выберите файл";
                fileDialog.Multiselect = false;

                if (fileDialog.ShowDialog() == DialogResult.OK)
                    yt_dlpBox.Text = fileDialog.FileName;

                engine.SetExecutablePath(fileDialog.FileName);
            }
        }

        private void urlBox_TextChanged(object sender, EventArgs e)
        {
            if (yt_dlpBox.Text.Equals(""))
            {
                MessageBox.Show("Пожалуйста, выберите exe-файл с YT_DLP", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            mainButton.Text = "Получить форматы";
        }

        private async void mainButton_Click(object sender, EventArgs e)
        {
          
            if (cookiesBox.Text.Equals(""))
            {
                MessageBox.Show("Пожалуйста, выберите txt-файл с Cookies", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (yt_dlpBox.Text.Equals(""))
            {
                MessageBox.Show("Пожалуйста, выберите exe-файл с YT_DLP", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            if (mainButton.Text.Equals("Получить форматы"))
            {

                outputBox.Text += "\r\nНачинаем получение форматов...";
                audioComboBox.DataSource = null;
                audioComboBox.Items.Clear();

                videoComboBox.DataSource = null;
                videoComboBox.Items.Clear();

                
                var formats = await engine.GetAvailableFormatsAsync(urlBox.Text);

                if (formats.Count != 0)
                {
                    audioComboBox.DataSource = formats[0];
                    audioComboBox.ValueMember = "Value";
                    audioComboBox.DisplayMember = "Display";

                    videoComboBox.DataSource = formats[1];
                    videoComboBox.ValueMember = "Value";
                    videoComboBox.DisplayMember = "Display";

                    outputBox.Text += "\r\nФорматы получены и обновлены.";
                    mainButton.Text = "Скачать";
                }
            }

            
            else
            {
                if (folderBox.Text.Equals(""))
                {
                    MessageBox.Show("Пожалуйста, выберите папку, куда будет сохранён файл", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (audioComboBox.SelectedValue.Equals("noFormat") && videoComboBox.SelectedValue.Equals("noFormat"))
                {
                    MessageBox.Show("Нельзя выбрать форматы \"Без аудио\" и \"Без видео\" одновременно", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (audioComboBox.Items.Count == 0 || videoComboBox.Items.Count == 0)
                {
                    MessageBox.Show("Перед скачиванием необходимо ввести ссылку и дождаться получения доступных форматов.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                
                string formatArgs = "";
                if (audioComboBox.SelectedValue.Equals("noFormat"))
                {
                    formatArgs = videoComboBox.SelectedValue.ToString();
                }
                else if (videoComboBox.SelectedValue.Equals("noFormat"))
                {
                    formatArgs = audioComboBox.SelectedValue.ToString();
                }
                else
                {
                    formatArgs = $"\"{audioComboBox.SelectedValue}+{videoComboBox.SelectedValue}\" --merge-output-format mp4";
                }

                progressDownload.Value = 0;

                outputBox.Text += "\r\nЗагрузка началась...";

                await engine.DownloadAsync(urlBox.Text, folderBox.Text, formatArgs);

                outputBox.Text += "\r\nЗагрузка завершена.";

                if (Directory.Exists(folderBox.Text))
                    Process.Start("explorer.exe", folderBox.Text);
            }
        }

        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(yt_dlpBox.Text))
                Properties.Settings.Default.yt_dlpPath = yt_dlpBox.Text;

            if (!string.IsNullOrWhiteSpace(cookiesBox.Text))
                Properties.Settings.Default.cookiesPath = cookiesBox.Text;

            if (!string.IsNullOrWhiteSpace(folderBox.Text))
                Properties.Settings.Default.folderPath = folderBox.Text;

            Properties.Settings.Default.Save();
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.yt_dlpPath))
            {
                yt_dlpBox.Text = Properties.Settings.Default.yt_dlpPath;
                engine.SetExecutablePath(yt_dlpBox.Text);
            }

            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.cookiesPath))
            {
                cookiesBox.Text = Properties.Settings.Default.cookiesPath;
                engine.SetCookiesPath(cookiesBox.Text);
            }

            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.folderPath))
                folderBox.Text = Properties.Settings.Default.folderPath;
        }
    }
}
