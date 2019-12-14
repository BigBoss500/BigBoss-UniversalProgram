using System;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Olib.Core
{
    internal static class Update
    {
        private static string str;
        public static async Task CheckUpdate(Button b)
        {
            using (WebClient wb = new WebClient())
            {
                wb.DownloadStringCompleted += (s, e) => str = e.Result;
                await wb.DownloadStringTaskAsync(new Uri($"https://raw.githubusercontent.com/BigBoss500/Olib/master/versions/version.xml"));
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
