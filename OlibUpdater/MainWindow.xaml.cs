using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Olib
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private string str;
        private string t;
        private void ClosedW(object sender, EventArgs e) => Application.Current.Shutdown();
        private void Drag(object sender, MouseButtonEventArgs e) => DragMove();

        private async Task InstallUpdate()
        {
            Dictionary<Uri, string> dict = new Dictionary<Uri, string>();
            using (var wb = new WebClient())
            {
                wb.DownloadStringCompleted += (s, b) => str = b.Result;
                await wb.DownloadStringTaskAsync(new Uri("https://raw.githubusercontent.com/BigBoss500/Olib/master/versions/version.xml"));
            }
            using (var wb = new WebClient())
            {
                wb.DownloadStringCompleted += (s, b) => t = b.Result;
                await wb.DownloadStringTaskAsync(new Uri("https://raw.githubusercontent.com/BigBoss500/Olib/master/versions/version.xml"));
            }
            MatchCollection match1 = Regex.Matches(str, "<file>(.*?)</file>");
            MatchCollection match2 = Regex.Matches(str, "<filename>(.*?)</filename>");
            MatchCollection match3 = Regex.Matches(str, "<directory>(.*?)</directory>");
            for (int i = 0; i < match1.Count; i++)
            {
                dict.Add(new Uri(match1[i].Groups[1].Value), match2[i].Groups[1].Value);
            }
            foreach (Match v in match3)
            {
                if (!Directory.Exists(v.Groups[1].Value))
                    Directory.CreateDirectory(v.Groups[1].Value);
            }
            using (var wb = new WebClient())
            {
                wb.DownloadProgressChanged += (s, b) => Bar.Value = b.ProgressPercentage;
                foreach (KeyValuePair<Uri, string> pair in dict)
                {
                    await wb.DownloadFileTaskAsync(pair.Key, pair.Value);
                }
            }
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\Olib", true);
                key.SetValue("DisplayVersion", Regex.Match(t, "<version>(.*?)</version>").Groups[1].Value);
            }
            catch{}
            Process.Start("Olib.exe");
            Application.Current.Shutdown();
        }

        private async void DoubleAnimation_Completed(object sender, EventArgs e)
        {
            await InstallUpdate();
        }
    }
}
