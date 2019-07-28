using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Xml;

namespace Jekyll
{
    /// <summary>
    /// Логика взаимодействия для Info.xaml
    /// </summary>
    public partial class Info : Window
    {
        public Info()
        {
            InitializeComponent();
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            Version.Content = "Jekyll v" + version.ToString();
            new Thread(() =>
            {
                XmlDocument doc = new XmlDocument();
                try
                {
                    doc.Load("https://raw.githubusercontent.com/BigBoss500/Jekyll/master/Jekyll/version/version.xml");
                }
                catch
                {
                    Dispatcher.Invoke(() => TextUpd.Content = "Возникли проблемы, проверьте подключение к сети");
                    return;
                }
                XmlNamespaceManager obj = new XmlNamespaceManager(doc.NameTable);
                float latest = float.Parse(doc.DocumentElement.SelectSingleNode("version", obj).InnerText.Replace(".", ""));
                float current = float.Parse(Assembly.GetExecutingAssembly().GetName().Version.ToString().Replace(".", ""));
                if (latest > current)
                    Dispatcher.Invoke(() =>
                    {
                        TextUpd.Content = "Доступно обновление до v" + doc.DocumentElement.SelectSingleNode("version", obj).InnerText;
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
            new Thread(() =>
            {
                Dispatcher.Invoke(() =>
                {
                    Download.Visibility = Visibility.Hidden;
                    progressBar1.Visibility = Visibility.Visible;
                    TextUpd.Content = "Скачивание...";
                });
                XmlDocument doc = new XmlDocument();
                try
                {
                    doc.Load("https://raw.githubusercontent.com/BigBoss500/Jekyll/master/Jekyll/version/version.xml");
                }
                catch
                {
                    Dispatcher.Invoke(() =>
                    {
                        TextUpd.Content = "Ошибка сервера";
                        progressBar1.Visibility = Visibility.Hidden;
                        Download.Visibility = Visibility.Visible;
                    });
                }
                XmlNamespaceManager obj = new XmlNamespaceManager(doc.NameTable);
                string url = doc.DocumentElement.SelectSingleNode("url", obj).InnerText;
                string fileName = "SetupJekyll.exe";//к примеру... файл.zip замените названием того что скачиваете
                if (File.Exists(fileName))
                    File.Delete(fileName);
                WebClient client = new WebClient();
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(Client_DownloadProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(Client_DownloadFileCompleted);
                try
                {
                    client.DownloadFileAsync(new Uri(url), "SetupJekyll.exe");
                }
                catch
                {
                    Dispatcher.Invoke(() =>
                    {
                        TextUpd.Content = "Не удалось загрузить обновление";
                        progressBar1.Visibility = Visibility.Hidden;
                        Download.Visibility = Visibility.Visible;
                    });
                }
            }).Start();
        }

        private void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                progressBar1.Visibility = Visibility.Hidden;
                TextUpd.Content = "Запуск...";
            });
            Process.Start("SetupJekyll.exe");
            Application.Current.Shutdown();
        }

        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e) =>
            Dispatcher.Invoke(() => 
            {
                progressBar1.Maximum = (int)e.TotalBytesToReceive / 100;
                progressBar1.Value = (int)e.BytesReceived / 100;
            });
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
