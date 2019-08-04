using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Jekyll
{
    /// <summary>
    /// Логика взаимодействия для IdentifierIP.xaml
    /// </summary>
    public partial class IdentifierIP : Window
    {
        public IdentifierIP()
        {
            InitializeComponent();
        }

        private void IDtext_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(IDtext.Text, "[^0-9-.]"))
            {
                IDtext.Text = IDtext.Text.Remove(IDtext.Text.Length - 1);
                IDtext.SelectionStart = IDtext.Text.Length;
            }
        }
        private void Close(object sender, RoutedEventArgs e) => Close();
        private void Drag(object sender, RoutedEventArgs e) => DragMove();
        private void Rollup(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;

        void IPParcer()
        {
            try
            {
            string st, s, country, sity, region, continent, latitude, longitude, timezone;
            string line = Environment.NewLine;

            st = IDtext.Text;
            using (WebClient wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                s = wc.DownloadString($"http://free.ipwhois.io/xml/{st}?lang=ru");
            }
            Match _1 = Regex.Match(s, "<country>(.*?)</country>");
            Match _2 = Regex.Match(s, "<city>(.*?)</city>");
            Match _3 = Regex.Match(s, "<region>(.*?)</region>");
            Match _4 = Regex.Match(s, "<continent>(.*?)</continent>");
            Match _5 = Regex.Match(s, "<latitude>(.*?)</latitude>");
            Match _6 = Regex.Match(s, "<longitude>(.*?)</longitude>");
            Match _7 = Regex.Match(s, "<timezone_gmt>(.*?)</timezone_gmt>");
            country = "Страна: " + _1.Groups[1].Value + line;
            sity = "Город: " + _2.Groups[1].Value + line;
            region = "Регион: " + _3.Groups[1].Value + line;
            continent = "Континент: " + _4.Groups[1].Value + line;
            latitude = "Ширина: " + _5.Groups[1].Value + line;
            longitude = "Долгота: " + _6.Groups[1].Value + line;
            timezone = "Часовой пояс: " + _7.Groups[1].Value + line;
            ParseXML.Text = continent + country + sity + region + latitude + longitude + timezone;
            }
            catch(Exception ex)
            {
                ParseXML.Text = $"Исключение: {ex}";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IPParcer();
        }

        private void IDtext_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) IPParcer();
        }
    }
}
