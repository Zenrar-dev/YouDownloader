using System;
using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace YtDLP_WinForms
{
    internal class YtDlpEngine
    {
        
        public event EventHandler<string>? OnWrapperMessage;

        
        public event EventHandler<int>? OnProgressDownload;

        private string ytDlpExecutablePath;
        private string cookiesTextablePath;


        
        public void SetExecutablePath(string ytDlpPath)
        {
           
            if (!File.Exists(ytDlpPath))
                OnWrapperMessage?.Invoke(this, "Приложение не может получить доступ к исполняемому файлу YtDLP.");

            else
            {
                ytDlpExecutablePath = ytDlpPath;
                OnWrapperMessage?.Invoke(this, "Приложение успешно получило доступ к исполняемому файлу YtDLP.");
            }
        }

        
        public void SetCookiesPath(string cookiesPath)
        {
            
            if (!File.Exists(cookiesPath))
                OnWrapperMessage?.Invoke(this, "Приложение не может получить доступ к файлу с Cookies.");

            else
            {
                cookiesTextablePath = cookiesPath;
                OnWrapperMessage?.Invoke(this, "Приложение успешно получило доступ к файлу с Cookies.");
            }
        }

        
        private async Task<string> RunCommandAsync(string arguments)
        {
            
            string output = "";
            string errors = "";

            var startInfo = new ProcessStartInfo
            {
                FileName = ytDlpExecutablePath,
                Arguments = $"--cookies {cookiesTextablePath} {arguments}",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            
            using (var process = new Process { StartInfo = startInfo, EnableRaisingEvents = true })
            {
               
                process.OutputDataReceived += (sender, e) =>
                {
                    if (!string.IsNullOrWhiteSpace(e.Data))
                    {
                        output += e.Data + Environment.NewLine;
                        TryParseProgress(e.Data);
                    }

                };

                process.ErrorDataReceived += (sender, e) =>
                {
                    if (!string.IsNullOrWhiteSpace(e.Data))
                    {
                        errors += e.Data + Environment.NewLine;
                    }
                };

                process.Start();

                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                await process.WaitForExitAsync();


                if (process.ExitCode != 0)
                {
                    OnWrapperMessage?.Invoke(this, "Выполнение консольной команды завершилось ошибкой!");
                    throw new Exception("Выполнение консольной команды завершилось ошибкой!");
                }

                return output;
            }
        }

        
        private void TryParseProgress(string? line)
        {
            if (string.IsNullOrWhiteSpace(line))
                return;

            var match = Regex.Match(line, @"\[download\]\s+([\d.]+)%");

            if (!match.Success)
                return;

            string percentText = match.Groups[1].Value;

            if (!double.TryParse(percentText, NumberStyles.Any, CultureInfo.InvariantCulture, out double percent))
                return;

            int progress = (int)Math.Round(percent);
            OnProgressDownload?.Invoke(this, progress);
        }

        
        public async Task<List<List<Format>>> GetAvailableFormatsAsync(string url)
        {
            string output = "";

            
            try
            {
                output = await RunCommandAsync($"--list-formats {url}");
            }
            catch (Exception ex)
            {
                OnWrapperMessage?.Invoke(this, $"Не удалось получить доступные форматы. Проверьте корректность введённого URL или попробуйте обновить Cookies.");
                return new List<List<Format>>();
            }


           
            var audioFormats = new List<Format>();
            audioFormats.Add(new Format("noFormat", "Без аудио"));

            var videoFormats = new List<Format>();
            videoFormats.Add(new Format("noFormat", "Без видео"));

            
            var lines = output.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith("ID") || line.StartsWith("[youtube]") || line.StartsWith("[info]") || line.StartsWith("─") || line.StartsWith("-"))
                    continue;

               
                var parts = line.Replace("│", " ").Replace("|", " ").Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

               
                if (parts[5].Equals("images"))
                    continue;

                
                if (parts[8].Equals("audio")) {
                    string displayInfo = "";

                    
                    displayInfo += parts[1] + " | " + parts[5] + " | " + parts[10] + string.Join(" ", parts.Skip(12));

                    audioFormats.Add(new Format(parts[0], displayInfo));    
                    continue;
                }

                
                if (parts[9].Equals("video")) {
                    string displayInfo = "";

                   
                    displayInfo += parts[1] + " | " + parts[2] + " | " + parts[4] + " | " + parts[7];

                    videoFormats.Add(new Format(parts[0], displayInfo));    
                    continue;
                }
            }

            var formats = new List<List<Format>>();
            formats.Add(audioFormats);
            formats.Add(videoFormats);

            return formats;
        }

        public async Task DownloadAsync(string url, string folderPath, string formatId)
        {
            
            try
            {
                await RunCommandAsync($"-f {formatId} -o \"{folderPath}/%(title)s.%(ext)s\" --progress {url}");
            }
            catch (Exception ex)
            {
                OnWrapperMessage?.Invoke(this, $"Не удалось скачать файл/файлы: {ex.Message}");
                throw new Exception($"Не удалось скачать файл/файлы: {ex.Message}", ex);
            }
        }
    }
}