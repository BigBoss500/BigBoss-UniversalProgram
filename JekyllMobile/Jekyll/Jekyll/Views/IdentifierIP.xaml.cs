using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jekyll.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IdentifierIP : ContentPage
    {
        public IdentifierIP()
        {
            InitializeComponent();
        }

        private void CheckText(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(IDtext.Text, "[^0-9-.]"))
            {
                IDtext.Text = IDtext.Text.Remove(IDtext.Text.Length - 1);
                IDtext.SelectionLength = IDtext.Text.Length;
            }
        }
        private string s;

        private async void IPParcer(object sender, EventArgs e)
        {
            Button.IsEnabled = false;
            Indicator.IsRunning = true;
            try
            {
                if (IDtext.Text.Length == 0)
                {
                    ParseXML.Text = "Нельзя ввести пустое поле";
                    Indicator.IsRunning = false;
                    Button.IsEnabled = true;
                    return;
                }
                string st, country, sity, region, continent, latitude, longitude, timezone;
                string line = Environment.NewLine;

                st = IDtext.Text;
                using (WebClient wc = new WebClient())
                {
                    wc.Encoding = Encoding.UTF8;
                    await Task.Run(() => s = wc.DownloadString($"http://free.ipwhois.io/xml/{st}?lang=ru")).ConfigureAwait(true);
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
            catch (Exception ex)
            {
                ParseXML.Text = $"Исключение: {ex}";
            }
            Indicator.IsRunning = false;
            Button.IsEnabled = true;
        }
    }
}