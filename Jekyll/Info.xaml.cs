using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
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
            In.Opacity = 0;
            EasterEgg.DisplayNameEgg(NameE);
            EasterEgg.Version(data);
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            Version.Content = "Jekyll v" + version.ToString();
            Poss();
            new Thread(() =>
            {
                using (WebClient wb = new WebClient())
                {
                    s = wb.DownloadString($"https://raw.githubusercontent.com/BigBoss500/Jekyll/master/Jekyll/version/version.xml");
                }
                Match vers = Regex.Match(s, "<version>(.*?)</version>");
                float latest = float.Parse(vers.Groups[1].Value.Replace(".", ""));
                float current = float.Parse(Assembly.GetExecutingAssembly().GetName().Version.ToString().Replace(".", ""));
                if (latest > current)
                    Dispatcher.Invoke(() =>
                    {
                        TextUpd.Content = local.Localization.InfoNewUpdate + vers.Groups[1].Value;
                        Download.Visibility = Visibility.Visible;
                    });
                else Dispatcher.Invoke(() => TextUpd.Content = local.Localization.InfoLatestUpdate);
            }).Start();

        }
        private async void Poss()
        {
            for (double i = 0; i < 1; i += 0.1)
            {
                In.Opacity = i;
                await Task.Delay(1);
            }
        }
        private async void Close(object sender, RoutedEventArgs e)
        {
            App.Sound();
            for (double i = 1; i > 0; i -= 0.1)
            {
                In.Opacity = i;
                await Task.Delay(1);
            }
            Close();
        }

        private void Drag(object sender, RoutedEventArgs e) => DragMove();
        private void VK(object sender, RoutedEventArgs e)
        {
            App.Sound();
            Process.Start("https://vk.com/jekyll_app");
        }

        private void GitHub(object sender, RoutedEventArgs e)
        {
            App.Sound();
            Process.Start("https://github.com/BigBoss500/Jekyll");
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            App.Sound();
            Download.Visibility = Visibility.Hidden;
            progressBar1.Visibility = Visibility.Visible;
            TextUpd.Content = local.Localization.InfoDownloadingUpdate;
            Match url1 = Regex.Match(s, "<url>(.*?)</url>");
            string fileName = "updater.exe";
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
                catch
                {
                    TextUpd.Content = local.Localization.InfoErrorDownload;
                    progressBar1.Visibility = Visibility.Hidden;
                    Download.Visibility = Visibility.Visible;
                }
            }
        }

        private void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {

            progressBar1.Visibility = Visibility.Hidden;
            TextUpd.Content = local.Localization.InfoDownloadCompleted;
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
            App.Sound();
            RdmGlobal.Visibility = Visibility.Visible;
            CloseButton_Copy.Visibility = Visibility.Visible;
        }
        private void CloseButton_Copy_Click(object sender, RoutedEventArgs e)
        {
            App.Sound();
            RdmGlobal.Visibility = Visibility.Hidden;
            CloseButton_Copy.Visibility = Visibility.Hidden;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.Sound();
            Process.Start("https://vk.com/jekyll_app?w=app6471849_-182154976");
        }
    }
}
