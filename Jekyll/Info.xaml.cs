using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;

namespace Jekyll
{
    /// <summary>
    /// Логика взаимодействия для Info.xaml
    /// </summary>
    public partial class Info : Window
    {
        private string s;
        public Info()
        {
            InitializeComponent();
            EasterEgg.DisplayNameEgg(NameE);
            EasterEgg.Version(data);
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            Version.Content = "Jekyll v" + version.ToString();
            new Thread(() =>
            {
                using (WebClient wb = new WebClient())
                {
                    s = wb.DownloadString($"https://raw.githubusercontent.com/BigBoss500/Jekyll/master/Jekyll/version/version.xml");
                }
                Match vers = Regex.Match(s, "<version>(.*?)</version>");
                float latest = float.Parse(vers.Groups[1].Value.Replace(".", ""), new CultureInfo("en-US"));
                float current = float.Parse(Assembly.GetExecutingAssembly().GetName().Version.ToString().Replace(".", ""), new CultureInfo("en-US"));
                if (latest > current)
                    Dispatcher.Invoke(() =>
                    {
                        TextUpd.Content = "Доступно обновление до v" + vers.Groups[1].Value;
                        Download.Visibility = Visibility.Visible;
                    });
                else Dispatcher.Invoke(() => TextUpd.Content = "Установлена последняя версия программы");
            }).Start();

        }
        private void Close(object sender, RoutedEventArgs e) => Close();
        private void Drag(object sender, RoutedEventArgs e) => DragMove();
        private void VK(object sender, RoutedEventArgs e) => Process.Start("https://vk.com/jekyll_app");
        private void GitHub(object sender, RoutedEventArgs e) => Process.Start("https://github.com/BigBoss500/Jekyll");

        private void Update(object sender, RoutedEventArgs e)
        {
            Download.Visibility = Visibility.Hidden;
            progressBar1.Visibility = Visibility.Visible;
            TextUpd.Content = "Скачивание...";
            Match url1 = Regex.Match(s, "<url>(.*?)</url>");
            string fileName = "SetupJekyll.exe";//к примеру... файл.zip замените названием того что скачиваете
            if (File.Exists(fileName))
                File.Delete(fileName);
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("User-Agent", "Mozilla/4.0 (compatible; MSIE 8.0)");
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(Client_DownloadProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(Client_DownloadFileCompleted);
                try
                {
                    client.DownloadFileAsync(new Uri(url1.Groups[1].Value), fileName);
                }
                catch (WebException)
                {
                    TextUpd.Content = "Не удалось загрузить обновление";
                    progressBar1.Visibility = Visibility.Hidden;
                    Download.Visibility = Visibility.Visible;
                }
                catch (ArgumentNullException)
                {
                    TextUpd.Content = "Не удалось загрузить обновление";
                    progressBar1.Visibility = Visibility.Hidden;
                    Download.Visibility = Visibility.Visible;
                }
                catch (InvalidOperationException)
                {
                    TextUpd.Content = "Не удалось загрузить обновление";
                    progressBar1.Visibility = Visibility.Hidden;
                    Download.Visibility = Visibility.Visible;
                }
            }
        }

        private void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {

            progressBar1.Visibility = Visibility.Hidden;
            TextUpd.Content = "Загрузка завершена, идёт запуск...";
            Process.Start("SetupJekyll.exe");
            Application.Current.Shutdown();
        }

        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Maximum = e.TotalBytesToReceive / 100;
            progressBar1.Value = e.BytesReceived / 100;
        }


        private void NameR(object sender, RoutedEventArgs e)
        {
            RdmGlobal.Visibility = Visibility.Visible;
            CloseButton_Copy.Visibility = Visibility.Visible;
        }
        private void CloseButton_Copy_Click(object sender, RoutedEventArgs e)
        {
            RdmGlobal.Visibility = Visibility.Hidden;
            CloseButton_Copy.Visibility = Visibility.Hidden;
        }
        private void Button_Click(object sender, RoutedEventArgs e) => Process.Start("https://vk.com/jekyll_app?w=app6471849_-182154976");
    }
}
