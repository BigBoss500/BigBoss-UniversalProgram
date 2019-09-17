using System;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml;
using System.Windows.Forms;
using System.IO;

namespace Jekyll
{
    /// <summary>
    /// Логика взаимодействия для ParserXML.xaml
    /// </summary>
    public partial class ParserXML : Window
    {
        public ParserXML()
        {
            InitializeComponent();
            Combo.SelectedIndex = 0;
        }
        private void Rollup(object sender, RoutedEventArgs e)
        {
            App.Sound();
            WindowState = WindowState.Minimized;
        }

        private void Drag(object sender, MouseButtonEventArgs e) => DragMove();
        private void Closedw(object sender, RoutedEventArgs e)
        {
            App.Sound();
            Close();
        }

        private void ClearList(object sender, RoutedEventArgs e)
        {
            App.Sound();
            ParseX.Clear();
        }

        private void MaxButton_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private async void Parsing(object sender, RoutedEventArgs e)
        {
            App.Sound();
            Bar.IsIndeterminate = true;
            Completed.Content = null;
            if (ValueText.Text == "")
            {
                ParseX.Text = local.Localization.ParseXMLNoParse;
                Bar.IsIndeterminate = false;
                return;
            }

            Parser.ID_and_IP = ValueText.Text;
            
            if (Combo.SelectedIndex == 0)
                ParseX.Text = await Parser.VKData();
            else if (Combo.SelectedIndex == 1)
                ParseX.Text = await Parser.IPParsing();
            else if (Combo.SelectedIndex == 2)
                ParseX.Text = await Parser.PhoneNumber();
            Bar.IsIndeterminate = false;
        }

        private void TextCh(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(ValueText.Text, "[^0-9-.]"))
            {
                ValueText.Text = ValueText.Text.Remove(ValueText.Text.Length - 1);
                ValueText.SelectionStart = ValueText.Text.Length;
            }
        }
        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Combo.SelectedIndex == 0)
                TextGlobal.Content = local.Localization.ParseXMLLabelComboBox1;
            else if (Combo.SelectedIndex == 1)
                TextGlobal.Content = local.Localization.ParseXMLLabelComboBox2;
            else if (Combo.SelectedIndex == 2)
                TextGlobal.Content = local.Localization.ParseXMLLabelComboBox3;
        }

        private void SaveFile(object sender, RoutedEventArgs e)
        {
            App.Sound();
            if (ParseX.Text == "")
            {
                ParseX.Text = local.Localization.ParseXMLNoList;
                return;
            }
            using (SaveFileDialog save = new SaveFileDialog { Filter = "TXT-files (*.txt)|*.txt" })
            {
                if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    using (StreamWriter stream = new StreamWriter(save.FileName, false))
                    {
                        stream.WriteLine(ParseX.Text);
                    }
                }
            }
            Completed.Content = local.Localization.ParseXMLListSave;
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
            string line = Environment.NewLine, notext = local.Localization_Parsing.StringNo;
            try//пользователь
            {
                XmlNode NameP = doc.DocumentElement.SelectSingleNode("foaf:Person/foaf:name", objNSMan);
                NameText = local.Localization_Parsing.StringPerson + NameP.InnerText + line;
            }
            catch
            {
                return local.Localization_Parsing.StringNoPerson + line;
            }
            try//дата создания страницы
            {
                XmlNode pars = doc.DocumentElement.SelectSingleNode("foaf:Person/ya:created/@dc:date", objNSMan);
                created = local.Localization_Parsing.StringPage + pars.InnerText.Replace("T", " | ").Replace("-", ".").Replace("+03:00", "") + line;
            }
            catch
            {
                created = local.Localization_Parsing.StringPage + notext + line;
            }
            try//дата изменения
            {
                XmlNode pars = doc.DocumentElement.SelectSingleNode("foaf:Person/ya:modified/@dc:date", objNSMan);
                modifed = local.Localization_Parsing.StringPageChanged + pars.InnerText.Replace("T", " | ").Replace("-", ".").Replace("+03:00", "") + line;
            }
            catch
            {
                modifed = local.Localization_Parsing.StringPageChanged + notext + line;
            }
            try//последний вход
            {
                XmlNode pars = doc.DocumentElement.SelectSingleNode("foaf:Person/ya:lastLoggedIn/@dc:date", objNSMan);
                Out = local.Localization_Parsing.StringLastOnline + pars.InnerText.Replace("T", " | ").Replace("-", ".").Replace("+03:00", "") + line;
            }
            catch
            {
                Out = local.Localization_Parsing.StringLastOnline + notext + line;
            }
            try//ссылка на страницу
            {
                XmlNode pars = doc.DocumentElement.SelectSingleNode("foaf:Person/foaf:weblog/@rdf:resource", objNSMan);
                weblock = local.Localization_Parsing.StringLink + pars.InnerText + line;
            }
            catch
            {
                weblock = local.Localization_Parsing.StringLink + notext + line;
            }
            try//день рождение
            {
                XmlNode pars = doc.DocumentElement.SelectSingleNode("foaf:Person/foaf:dateOfBirth", objNSMan);
                bdata = local.Localization_Parsing.StringDateOfBirth + pars.InnerText.Replace("-", ".") + line;
            }
            catch
            {
                bdata = local.Localization_Parsing.StringDateOfBirth + notext + line;
            }
            try//кол-во подписчиков
            {
                XmlNode pars = doc.DocumentElement.SelectSingleNode("foaf:Person/ya:subscribersCount", objNSMan);
                sub = local.Localization_Parsing.StringNumberSubs + pars.InnerText + line;
            }
            catch
            {
                sub = local.Localization_Parsing.StringNumberSubs + notext + line;
            }
            try//кол-во друзей
            {
                XmlNode pars = doc.DocumentElement.SelectSingleNode("foaf:Person/ya:friendsCount", objNSMan);
                fr = local.Localization_Parsing.StringFriends + pars.InnerText + line;
            }
            catch
            {
                fr = local.Localization_Parsing.StringFriends + notext + line;
            }
            try//пол
            {
                XmlNode pars = doc.DocumentElement.SelectSingleNode("foaf:Person/foaf:gender", objNSMan);
                gen = local.Localization_Parsing.StringFloor + pars.InnerText + line;
            }
            catch
            {
                gen = local.Localization_Parsing.StringFloor + notext + line;
            }
            try//страна
            {
                XmlNode pars = doc.DocumentElement.SelectSingleNode("foaf:Person/ya:location/@ya:country", objNSMan);
                land = local.Localization_Parsing.StringCountry + pars.InnerText + line;
            }
            catch
            {
                land = local.Localization_Parsing.StringCountry + notext + line;
            }
            try//город
            {
                XmlNode pars = doc.DocumentElement.SelectSingleNode("foaf:Person/ya:location/@ya:city", objNSMan);
                city = local.Localization_Parsing.StringCity + pars.InnerText + line;
            }
            catch
            {
                city = local.Localization_Parsing.StringCity + notext + line;
            }
            try//характеристики
            {
                XmlNode pars = doc.DocumentElement.SelectSingleNode("foaf:Person/foaf:interest", objNSMan);
                inter = pars.InnerText + line;
            }
            catch
            {
                inter = local.Localization_Parsing.StringSpecification + notext + line;
            }
            try//сайт
            {
                XmlNode pars = doc.DocumentElement.SelectSingleNode("foaf:Person/foaf:homepage", objNSMan);
                site = local.Localization_Parsing.StringSite + pars.InnerText + line;
            }
            catch
            {
                site = local.Localization_Parsing.StringSite + notext + line;
            }
            try//о себе
            {
                XmlNode pars = doc.DocumentElement.SelectSingleNode("foaf:Person/ya:bio", objNSMan);
                bio = local.Localization_Parsing.StringAbout + pars.InnerText + line;
            }
            catch
            {
                bio = local.Localization_Parsing.StringAbout + notext + line;
            }
            try//статус
            {
                XmlNode pars = doc.DocumentElement.SelectSingleNode("foaf:Person/foaf:weblog/@dc:title", objNSMan);
                title = $"{local.Localization_Parsing.StringStatus}{pars.InnerText}" + line;
            }
            catch
            {
                title = local.Localization_Parsing.StringStatus + notext + line;
            }
            try//ник
            {
                XmlNode pars = doc.DocumentElement.SelectSingleNode("foaf:Person/foaf:nick", objNSMan);
                nick = $"{local.Localization_Parsing.StringNick}{pars.InnerText}" + line;
            }
            catch
            {
                nick = local.Localization_Parsing.StringNick + notext + line;
            }
            try//статус профиля
            {
                XmlNode pars = doc.DocumentElement.SelectSingleNode("foaf:Person/ya:profileState", objNSMan);
                stat = $"{local.Localization_Parsing.StringProfileStatus}{pars.InnerText}" + line;
            }
            catch
            {
                stat = local.Localization_Parsing.StringProfileStatus + notext + line;
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
                    await Task.Run(() => s = wc.DownloadString($"http://free.ipwhois.io/xml/{ID_and_IP}?lang={local.Localization_Parsing.LinkIPAdress}"));
                }
                country = local.Localization_Parsing.StringCountry + Regex.Match(s, "<country>(.*?)</country>").Groups[1].Value + line;
                sity = local.Localization_Parsing.StringCity + Regex.Match(s, "<city>(.*?)</city>").Groups[1].Value + line;
                region = local.Localization_Parsing.Region + Regex.Match(s, "<region>(.*?)</region>").Groups[1].Value + line;
                continent = local.Localization_Parsing.Continent + Regex.Match(s, "<continent>(.*?)</continent>").Groups[1].Value + line;
                latitude = local.Localization_Parsing.Width + Regex.Match(s, "<latitude>(.*?)</latitude>").Groups[1].Value + line;
                longitude = local.Localization_Parsing.Longitude + Regex.Match(s, "<longitude>(.*?)</longitude>").Groups[1].Value + line;
                timezone = local.Localization_Parsing.Timezone + Regex.Match(s, "<timezone_gmt>(.*?)</timezone_gmt>").Groups[1].Value + line;
                org = local.Localization_Parsing.Organization + Regex.Match(s, "<org>(.*?)</org>").Groups[1].Value + line;
                isp = local.Localization_Parsing.InternetServiceProvider + Regex.Match(s, "<isp>(.*?)</isp>").Groups[1].Value + line;
                currency = local.Localization_Parsing.Currency + Regex.Match(s, "<currency>(.*?)</currency>").Groups[1].Value + line;
                return continent + country + sity + region + latitude + longitude + timezone + org + isp + currency;
            }
            catch (Exception ex)
            {
                return $"{local.Localization.StringException}{ex.Message}";
            }
        }
        public static async Task<string> PhoneNumber()
        {
            try
            {
                string obl, oper, id_obl, id_oper ,line = Environment.NewLine;
                using (WebClient wc = new WebClient())
                {
                    wc.Encoding = Encoding.UTF8;
                    await Task.Run(() => s = wc.DownloadString($"http://www.megafon.ru/api/mfn/info?msisdn={ID_and_IP}"));
                }
                obl = local.Localization_Parsing.Operator + Regex.Match(s, "\"region\":\"(.*?)\"").Groups[1].Value + line;
                oper = local.Localization_Parsing.Region + Regex.Match(s, "\"operator\":\"(.*?)\"").Groups[1].Value + line;
                id_obl = local.Localization_Parsing.RegionID + Regex.Match(s, "\"region_id\":(.*?)}").Groups[1].Value + line;
                id_oper = local.Localization_Parsing.OperatorID + Regex.Match(s, "\"operator_id\":(.*?),").Groups[1].Value + line;
                return obl + oper + id_obl + id_oper;
            }
            catch (Exception ex)
            {
                return $"{local.Localization.StringException}{ex.Message}";
            }
        }
    }
}
