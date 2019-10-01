using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Diagnostics;

namespace OlibUpdater.Core
{
    static class Update
    {
        private static string str;
        public static void CheckUpdate(Button b)
        {
            using (var wb = new WebClient())
            {
                wb.DownloadStringCompleted += (s,e) => str = e.Result;
                wb.DownloadStringAsync(new Uri($"https://raw.githubusercontent.com/BigBoss500/Jekyll/master/Jekyll/version/version.xml"));
            }
            Match vers = Regex.Match(str, "<version>(.*?)</version>");
            float latest = float.Parse(vers.Groups[1].Value.Replace(".", ""));
            float current = float.Parse(Assembly.GetExecutingAssembly().GetName().Version.ToString().Replace(".", ""));
            if (latest > current)
            {
                b.Visibility = Visibility.Visible;
                b.Click += InstallUpdate;
            }
        }

        private static void InstallUpdate(object sender, RoutedEventArgs e)
        {
            Process.Start("OlibUpdater.exe");
            Application.Current.Shutdown();
        }
    }
}
