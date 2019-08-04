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
            Download.Visibility = Visibility.Hidden;
            progressBar1.Visibility = Visibility.Visible;
            TextUpd.Content = "Скачивание...";
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load("https://raw.githubusercontent.com/BigBoss500/Jekyll/master/Jekyll/version/version.xml");
            }
            catch
            {
                TextUpd.Content = "Ошибка сервера";
                progressBar1.Visibility = Visibility.Hidden;
                Download.Visibility = Visibility.Visible;

            }
            XmlNamespaceManager obj = new XmlNamespaceManager(doc.NameTable);
            string url = doc.DocumentElement.SelectSingleNode("url", obj).InnerText;
            string fileName = "SetupJekyll.exe";
            if (File.Exists(fileName))
                File.Delete(fileName);
            using (WebClient client = new WebClient())
            {
                try
                {
                    client.DownloadFileAsync(new Uri("https://github-production-release-asset-2e65be.s3.amazonaws.com/177377031/6841aa00-b173-11e9-9038-470ac214f857?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Credential=AKIAIWNJYAX4CSVEH53A%2F20190804%2Fus-east-1%2Fs3%2Faws4_request&X-Amz-Date=20190804T061205Z&X-Amz-Expires=300&X-Amz-Signature=a6c1878a2af6ec2438fd8482bd46d2c852f5ab2c300244586f58e6ddf9857efa&X-Amz-SignedHeaders=host&actor_id=44552715&response-content-disposition=attachment%3B%20filename%3DSetupJekyll.exe&response-content-type=application%2Foctet-stream"), fileName);
                }
                catch
                {
                    TextUpd.Content = "Не удалось загрузить обновление";
                    progressBar1.Visibility = Visibility.Hidden;
                    Download.Visibility = Visibility.Visible;
                }
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(Client_DownloadProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(Client_DownloadFileCompleted);
            }
        }

        private void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {

            progressBar1.Visibility = Visibility.Hidden;
            TextUpd.Content = "Запуск...";

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
