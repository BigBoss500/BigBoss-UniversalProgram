using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;

namespace updater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Thread t = new Thread(Download);
            t.Start();
        }
        private string s;
        private void Download()
        {
            try
            {
                foreach (Process proc in Process.GetProcessesByName("Jekyll"))
                    proc.Kill();
                Thread.Sleep(2000);
                
                File.Delete("Jekyll.exe");
                File.Delete("Jekyll.exe.config");
                using (WebClient wb = new WebClient())
                {
                    string[] url = { "https://raw.githubusercontent.com/BigBoss500/Jekyll/master/Jekyll/bin/Release/Jekyll.exe.config", "https://raw.githubusercontent.com/BigBoss500/Jekyll/master/Jekyll/bin/Release/Jekyll.exe" };
                    string[] filename = { "Jekyll.exe.config", "Jekyll.exe" };
                    wb.Headers.Add("User-Agent", "Mozilla/4.0 (compatible; MSIE 8.0)");
                    for (int k = 0; k < 2; k++)
                    {
                        wb.DownloadFile(new Uri(url[k]), filename[k]);
                    }
                    wb.DownloadFile("https://github.com/BigBoss500/Jekyll/raw/master/Jekyll/bin/Release/ru-RU/Jekyll.resources.dll", @"ru-RU\Jekyll.resources.dll");
                    wb.DownloadFile("https://github.com/BigBoss500/Jekyll/raw/master/Jekyll/bin/Release/fr-FR/Jekyll.resources.dll", @"fr-FR\Jekyll.resources.dll");
                    s = wb.DownloadString($"https://raw.githubusercontent.com/BigBoss500/Jekyll/master/Jekyll/version/version.xml");

                    RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\Jekyll", true);
                    key.SetValue("DisplayVersion", Regex.Match(s, "<version>(.*?)</version>").Groups[1].Value);
                    Completed();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Completed()
        {
            Process.Start("Jekyll.exe");
            Process.Start(new ProcessStartInfo { FileName = "cmd", Arguments = "/C ping 1.1.1.1 -n 1 -w 3000 > Nul & Del " + Application.ExecutablePath, WindowStyle = ProcessWindowStyle.Hidden });
            Application.Exit();
        }
    }
}
