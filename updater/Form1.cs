﻿using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

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

        private void Download()
        {
            try
            {
                string path = @"ru-RU\";
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
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);
                    wb.DownloadFile("https://github.com/BigBoss500/Jekyll/raw/master/Jekyll/bin/Release/ru-RU/Jekyll.resources.dll", path + "Jekyll.resources.dll");
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
