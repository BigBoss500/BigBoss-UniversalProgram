using Microsoft.Win32;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xml;

namespace Olib.Pages
{
    /// <summary>
    /// Логика взаимодействия для dataParser.xaml
    /// </summary>
    public partial class dataParser : Page
    {
        public dataParser()
        {
            InitializeComponent();
            Combo.SelectedIndex = 0;
            Core.Animations.AnimationText(Warning);
        }

        private async void Parsing(object sender, RoutedEventArgs e)
        {
            Bar.IsIndeterminate = true;
            Completed.Content = null;
            if (ValueText.Text == "")
            {
                ParseX.Text = (string)Application.Current.Resources["NoParse"];
                Bar.IsIndeterminate = false;
                return;
            }

            Parser.ID_and_IP = ValueText.Text;

            switch (Combo.SelectedIndex)
            {
                case 0:
                    ParseX.Text = await Parser.VKData();
                    break;
                case 1:
                    ParseX.Text = await Parser.IPParsing();
                    break;
                case 2:
                    ParseX.Text = await Parser.PhoneNumber();
                    break;
            }
            Bar.IsIndeterminate = false;
        }

        private void Combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (Combo.SelectedIndex)
            {
                case 0:
                    LText.Content = (string)Application.Current.Resources["IDVK"];
                    break;
                case 1:
                    LText.Content = (string)Application.Current.Resources["IP-A"];
                    break;
                case 2:
                    LText.Content = (string)Application.Current.Resources["NumberT"];
                    break;
            }
        }

        private void Clear(object sender, RoutedEventArgs e) => ParseX.Clear();

        private void SaveFile(object sender, RoutedEventArgs e)
        {
            if (ParseX.Text == "")
            {
                ParseX.Text = (string)Application.Current.Resources["NoListS"];
                return;
            }
            SaveFileDialog save = new SaveFileDialog { Filter = "TXT-files (*.txt)|*.txt" };
            if ((bool)save.ShowDialog())
            {
                using (StreamWriter stream = new StreamWriter(save.FileName, false))
                {
                    stream.WriteLine(ParseX.Text);
                }
            }
            Completed.Content = (string)Application.Current.Resources["SaveF"];
        }

        private void TextCh(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(ValueText.Text, "[^0-9-.]"))
            {
                ValueText.Text = ValueText.Text.Remove(ValueText.Text.Length - 1);
                ValueText.SelectionStart = ValueText.Text.Length;
            }
        }
    }
    public static class Parser
    {
        public static string ID_and_IP { get; set; }
        private static string s;

        public static async Task<string> VKData()
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                await Task.Run(() => doc.Load("https://vk.com/foaf.php?id=" + ID_and_IP));
            }
            catch
            {
                return "Проверьте подключение к интернету, чтобы использовать эту функцию";
            }
            XmlNamespaceManager objNSMan = new XmlNamespaceManager(doc.NameTable);
            objNSMan.AddNamespace("foaf", "http://xmlns.com/foaf/0.1/");
            objNSMan.AddNamespace("ya", "http://blogs.yandex.ru/schema/foaf/");
            objNSMan.AddNamespace("dc", "http://purl.org/dc/elements/1.1/");
            objNSMan.AddNamespace("rdf", "http://www.w3.org/1999/02/22-rdf-syntax-ns#");
            string NameText, created, modifed, weblock, bdata, Out, sub, fr, gen, land, city, inter, site, bio, title, nick, stat;
            string line = Environment.NewLine, notext = (string)Application.Current.Resources["NoText"];
            try//пользователь
            {
                XmlNode NameP = doc.DocumentElement.SelectSingleNode("foaf:Person/foaf:name", objNSMan);
                NameText = (string)Application.Current.Resources["User"] + " " + NameP.InnerText + line;
            }
            catch
            {
                return (string)Application.Current.Resources["NoPerson"] + line;
            }
            try//дата создания страницы
            {
                XmlNode pars = doc.DocumentElement.SelectSingleNode("foaf:Person/ya:created/@dc:date", objNSMan);
                created = (string)Application.Current.Resources["PageCreate"] + " " + pars.InnerText.Replace("T", " | ").Replace("-", ".").Replace("+03:00", "") + line;
            }
            catch
            {
                created = (string)Application.Current.Resources["PageCreate"] + " " + notext + line;
            }
            try//дата изменения
            {
                XmlNode pars = doc.DocumentElement.SelectSingleNode("foaf:Person/ya:modified/@dc:date", objNSMan);
                modifed = (string)Application.Current.Resources["PageChanged"] + " " + pars.InnerText.Replace("T", " | ").Replace("-", ".").Replace("+03:00", "") + line;
            }
            catch
            {
                modifed = (string)Application.Current.Resources["PageChanged"] + " " + notext + line;
            }
            try//последний вход
            {
                XmlNode pars = doc.DocumentElement.SelectSingleNode("foaf:Person/ya:lastLoggedIn/@dc:date", objNSMan);
                Out = (string)Application.Current.Resources["LastOnline"] + " " + pars.InnerText.Replace("T", " | ").Replace("-", ".").Replace("+03:00", "") + line;
            }
            catch
            {
                Out = (string)Application.Current.Resources["LastOnline"] + " " + notext + line;
            }
            try//ссылка на страницу
            {
                XmlNode pars = doc.DocumentElement.SelectSingleNode("foaf:Person/foaf:weblog/@rdf:resource", objNSMan);
                weblock = (string)Application.Current.Resources["LinkPage"] + " " + pars.InnerText + line;
            }
            catch
            {
                weblock = (string)Application.Current.Resources["LinkPage"] + " " + notext + line;
            }
            try//день рождение
            {
                XmlNode pars = doc.DocumentElement.SelectSingleNode("foaf:Person/foaf:dateOfBirth", objNSMan);
                bdata = (string)Application.Current.Resources["DataBirth"] + " " + pars.InnerText.Replace("-", ".") + line;
            }
            catch
            {
                bdata = (string)Application.Current.Resources["DataBirth"] + " " + notext + line;
            }
            try//кол-во подписчиков
            {
                XmlNode pars = doc.DocumentElement.SelectSingleNode("foaf:Person/ya:subscribersCount", objNSMan);
                sub = (string)Application.Current.Resources["NumSub"] + " " + pars.InnerText + line;
            }
            catch
            {
                sub = (string)Application.Current.Resources["NumSub"] + " " + notext + line;
            }
            try//кол-во друзей
            {
                XmlNode pars = doc.DocumentElement.SelectSingleNode("foaf:Person/ya:friendsCount", objNSMan);
                fr = (string)Application.Current.Resources["Friends"] + " " + pars.InnerText + line;
            }
            catch
            {
                fr = (string)Application.Current.Resources["Friends"] + " " + notext + line;
            }
            try//пол
            {
                XmlNode pars = doc.DocumentElement.SelectSingleNode("foaf:Person/foaf:gender", objNSMan);
                gen = (string)Application.Current.Resources["Floor"] + " " + pars.InnerText + line;
            }
            catch
            {
                gen = (string)Application.Current.Resources["Floor"] + " " + notext + line;
            }
            try//страна
            {
                XmlNode pars = doc.DocumentElement.SelectSingleNode("foaf:Person/ya:location/@ya:country", objNSMan);
                land = (string)Application.Current.Resources["Country"] + " " + pars.InnerText + line;
            }
            catch
            {
                land = (string)Application.Current.Resources["Country"] + " " + notext + line;
            }
            try//город
            {
                XmlNode pars = doc.DocumentElement.SelectSingleNode("foaf:Person/ya:location/@ya:city", objNSMan);
                city = (string)Application.Current.Resources["Sity"] + " " + pars.InnerText + line;
            }
            catch
            {
                city = (string)Application.Current.Resources["Sity"] + " " + notext + line;
            }
            try//характеристики
            {
                XmlNode pars = doc.DocumentElement.SelectSingleNode("foaf:Person/foaf:interest", objNSMan);
                inter = pars.InnerText + line;
            }
            catch
            {
                inter = (string)Application.Current.Resources["Spec"] + " " + notext + line;
            }
            try//сайт
            {
                XmlNode pars = doc.DocumentElement.SelectSingleNode("foaf:Person/foaf:homepage", objNSMan);
                site = (string)Application.Current.Resources["Site"] + " " + pars.InnerText + line;
            }
            catch
            {
                site = (string)Application.Current.Resources["Site"] + " " + notext + line;
            }
            try//о себе
            {
                XmlNode pars = doc.DocumentElement.SelectSingleNode("foaf:Person/ya:bio", objNSMan);
                bio = (string)Application.Current.Resources["About"] + " " + pars.InnerText + line;
            }
            catch
            {
                bio = (string)Application.Current.Resources["About"] + " " + notext + line;
            }
            try//статус
            {
                XmlNode pars = doc.DocumentElement.SelectSingleNode("foaf:Person/foaf:weblog/@dc:title", objNSMan);
                title = $"{(string)Application.Current.Resources["Status"]} {pars.InnerText}" + line;
            }
            catch
            {
                title = (string)Application.Current.Resources["Status"] + " " + notext + line;
            }
            try//ник
            {
                XmlNode pars = doc.DocumentElement.SelectSingleNode("foaf:Person/foaf:nick", objNSMan);
                nick = $"{(string)Application.Current.Resources["Nickname"]} {pars.InnerText}" + line;
            }
            catch
            {
                nick = (string)Application.Current.Resources["Nickname"] + " " + notext + line;
            }
            try//статус профиля
            {
                XmlNode pars = doc.DocumentElement.SelectSingleNode("foaf:Person/ya:profileState", objNSMan);
                stat = $"{(string)Application.Current.Resources["ProfStatus"]} {pars.InnerText}" + line;
            }
            catch
            {
                stat = (string)Application.Current.Resources["ProfStatus"] + " " + notext + line;
            }
            return NameText + nick + stat + weblock + created + modifed + Out + gen + bdata + sub + fr + land + city + site + title + inter + bio;
        }
        public static async Task<string> IPParsing()
        {
            try
            {
                string country, sity, region, continent, latitude, longitude, timezone, org, isp, currency;
                string line = Environment.NewLine;

                using (WebClient wc = new WebClient())
                {
                    wc.Encoding = Encoding.UTF8;
                    await Task.Run(() => s = wc.DownloadString($"http://free.ipwhois.io/xml/{ID_and_IP}?lang={(string)Application.Current.Resources["LangIP"]}"));
                }
                country = (string)Application.Current.Resources["Country"] + " " + Regex.Match(s, "<country>(.*?)</country>").Groups[1].Value + line;
                sity = (string)Application.Current.Resources["Sity"] + " " + Regex.Match(s, "<city>(.*?)</city>").Groups[1].Value + line;
                region = (string)Application.Current.Resources["Region"] + " " + Regex.Match(s, "<region>(.*?)</region>").Groups[1].Value + line;
                continent = (string)Application.Current.Resources["Continent"] + " " + Regex.Match(s, "<continent>(.*?)</continent>").Groups[1].Value + line;
                latitude = (string)Application.Current.Resources["Width"] + " " + Regex.Match(s, "<latitude>(.*?)</latitude>").Groups[1].Value + line;
                longitude = (string)Application.Current.Resources["Longitude"] + " " + Regex.Match(s, "<longitude>(.*?)</longitude>").Groups[1].Value + line;
                timezone = (string)Application.Current.Resources["TimeZone"] + " " + Regex.Match(s, "<timezone_gmt>(.*?)</timezone_gmt>").Groups[1].Value + line;
                org = (string)Application.Current.Resources["Organization"] + " " + Regex.Match(s, "<org>(.*?)</org>").Groups[1].Value + line;
                isp = (string)Application.Current.Resources["Provider"] + " " + Regex.Match(s, "<isp>(.*?)</isp>").Groups[1].Value + line;
                currency = (string)Application.Current.Resources["Currenty"] + " " + Regex.Match(s, "<currency>(.*?)</currency>").Groups[1].Value + line;
                return continent + country + sity + region + latitude + longitude + timezone + org + isp + currency;
            }
            catch (Exception ex)
            {
                return $"{ex.Message}";
            }
        }
        public static async Task<string> PhoneNumber()
        {
            try
            {
                string obl, oper, id_obl, id_oper, line = Environment.NewLine;
                using (WebClient wc = new WebClient())
                {
                    wc.Encoding = Encoding.UTF8;
                    await Task.Run(() => s = wc.DownloadString($"http://www.megafon.ru/api/mfn/info?msisdn={ID_and_IP}"));
                }
                obl = (string)Application.Current.Resources["Operator"] + " " + Regex.Match(s, "\"region\":\"(.*?)\"").Groups[1].Value + line;
                oper = (string)Application.Current.Resources["Region"] + " " + Regex.Match(s, "\"operator\":\"(.*?)\"").Groups[1].Value + line;
                id_obl = (string)Application.Current.Resources["RegionID"] + " " + Regex.Match(s, "\"region_id\":(.*?)}").Groups[1].Value + line;
                id_oper = (string)Application.Current.Resources["OperatorID"] + " " + Regex.Match(s, "\"operator_id\":(.*?),").Groups[1].Value + line;
                return obl + oper + id_obl + id_oper;
            }
            catch (Exception ex)
            {
                return $"{ex.Message}";
            }
        }
    }
}
