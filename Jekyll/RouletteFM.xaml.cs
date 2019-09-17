using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Xml.Linq;
using Path = System.IO.Path;

namespace Jekyll
{
    /// <summary>
    /// Логика взаимодействия для RouletteFM.xaml
    /// </summary>
    public partial class RouletteFM : Page
    {
        public RouletteFM()
        {
            InitializeComponent();
            TextChan.Text = Properties.Settings.Default.ChangeText;
            ListName.Content = Properties.Settings.Default.FileName;
            try
            {
                foreach (string s in Properties.Settings.Default.ListItem)
                {
                    List.Items.Add(s);
                }
            }
            catch { }
            indexs.Content = local.Localization.RouletteFXItems + List.Items.Count;
        }
        private int index, time = 1;
        private readonly string l = Environment.NewLine;
        private const long dot = 100000;
        private float b = 0;

        private void ButtClick(object sender, RoutedEventArgs e)
        {
            AllClear();
            indexs.Content = local.Localization.RouletteFXItems + List.Items.Count;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.Sound();
            Properties.Settings.Default.Save();
            NavigationService.Navigate(new Uri("Random.xaml", UriKind.Relative));
        }
        private void MenuRe_Click(object sender, RoutedEventArgs e)
        {
            App.Sound();
            List.Items.RemoveAt(index);
            Properties.Settings.Default.ListItem.Clear();
            string[] p = (from object item in List.Items select item.ToString()).ToArray();
            for (int k = 0; k < p.Length; k++)
            {
                Properties.Settings.Default.ListItem.Add(p[k]);
            }
            indexs.Content = local.Localization.RouletteFXItems + List.Items.Count;
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            App.Sound();
            RdmGlobal.Text = local.Localization.RouletteFXTwist;
        }

        private void NameR(object sender, RoutedEventArgs e)
        {
            App.Sound();
            AddItems();
        }

        private void ListBoxItem_ContextMenuOpening(object sender, ContextMenuEventArgs e) => index = List.SelectedIndex;



        private void AddItems()
        {
            if (name.Text.Length == 0)
            {
                Error.Content = local.Localization.RouletteFXNullItemAdd;
                return;
            }
            List.Items.Add(name.Text);
            if (Elem.IsChecked == true)
                name.Text = null;
            Error.Content = null;
            Complete.Content = null;
            Properties.Settings.Default.ListItem.Clear();
            string[] p = (from object item in List.Items select item.ToString()).ToArray();
            foreach (var i in p)
            {
                Properties.Settings.Default.ListItem.Add(i);
            }
            indexs.Content = local.Localization.RouletteFXItems + List.Items.Count;
        }

        private void Name_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter) AddItems();
        }

        private void AllClear()
        {
            App.Sound();
            ListName.Content = local.Localization.RouletteFXListName;
            List.Items.Clear();
            Properties.Settings.Default.ListItem.Clear();
            Properties.Settings.Default.FileName = local.Localization.RouletteFXListName;
            indexs.Content = local.Localization.RouletteFXItems + List.Items.Count;
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            App.Sound();
            Options.Visibility = Visibility.Hidden;
            NoVis.Visibility = Visibility.Hidden;
            time = int.Parse(TimeS.Text);
        }

        private void OpenOptions(object sender, RoutedEventArgs e)
        {
            App.Sound();
            Options.Visibility = Visibility.Visible;
            NoVis.Visibility = Visibility.Visible;
        }



        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            App.Sound();
            List<string> list = new List<string>();
            System.Random rmd = new System.Random();
            Complete.Content = null;
            RdmGlobal.Text = local.Localization.RandomButtonTwistExpectation;
            Error.Content = null;
            await Task.Delay(time * 1000 + 1);
            string[] string_array = (from object item in List.Items select item.ToString()).ToArray();
            b = 0;
            try
            {
                for (int i = 0; i < int.Parse(elements.Text); i++)
                {
                Random:
                    list.Add(string_array[rmd.Next(0, string_array.Length)] + Environment.NewLine);
                    if (Dublicate.IsChecked == true)
                    {

                        if (list.GroupBy(s => s).SelectMany(grp => grp.Skip(1)).Any())
                        {
                            string duplicate = list.GroupBy(s => s).SelectMany(grp => grp.Skip(1)).First();
                            if (list.Contains(duplicate))
                            {
                                if (b < dot)
                                {
                                    list.Remove(duplicate);
                                    b++;
                                    goto Random;
                                }
                                else
                                {
                                    list.RemoveAt(list.Count - 1);
                                }
                            }
                        }
                        b = 0;
                    }
                }
                if (int.Parse(elements.Text) > List.Items.Count)
                {
                    if (list.Count > List.Items.Count)
                    {
                        int Y = int.Parse(elements.Text) - List.Items.Count;
                        list.RemoveRange(List.Items.Count, Y);
                    }
                }
                RdmGlobal.Text = local.Localization.RandomButtonTwistOut + l + l;
                foreach (var i in list)
                {
                    RdmGlobal.Text += i;
                }
            }
            catch (Exception ex)
            {
                Error.Content = $"{local.Localization.StringException}{ex.Message}";
                RdmGlobal.Text = local.Localization.RouletteFXTwist;
            }

        }


        private void SaveXML(object sender, RoutedEventArgs e)
        {
            App.Sound();
            Complete.Content = null;
            Error.Content = null;
            using (SaveFileDialog d = new SaveFileDialog
            {
                Filter = "XML-files (*.xml)|*.xml|TXT-files (*.txt)|*.txt"
            })
            {
                if (d.ShowDialog() == DialogResult.OK)
                {
                    if (Path.GetExtension(d.FileName) == ".txt")
                    {
                        try
                        {
                            string[] string_array = (from object item in List.Items select item.ToString()).ToArray();
                            List<string> list = new List<string>();
                            foreach (var i in string_array)
                            {
                                list.Add(i);
                            }
                            File.AppendAllLines(d.FileName, list.ToArray());
                            Complete.Content = $"{local.Localization.RouletteFXFileSave}{d.FileName}";
                        }
                        catch (Exception ex)
                        {
                            Error.Content = $"{local.Localization.StringException}{ex.Message}";
                        }
                    }
                    else if (Path.GetExtension(d.FileName) == ".xml")
                    {
                        try
                        {
                            string[] string_array = (from object item in List.Items select item.ToString()).ToArray();
                            XDocument doc = new XDocument(
                            new XElement("Elements",
                                from n in string_array select new XElement("Element", n)
                            ));
                            doc.Save(d.FileName);
                            Complete.Content = $"{local.Localization.RouletteFXFileSave}{d.FileName}";
                        }
                        catch (Exception ex)
                        {
                            Error.Content = $"{local.Localization.StringException}{ex.Message}";
                        }
                    }
                }
            }
        }
        private void OpenXML(object sender, RoutedEventArgs e)
        {
            App.Sound();
            Complete.Content = null;
            Error.Content = null;
            using (OpenFileDialog d = new OpenFileDialog
            {
                Filter = "XML-files (*.xml)|*.xml|TXT-files (*.txt)|*.txt"
            })
            {
                if (d.ShowDialog() == DialogResult.OK)
                {
                    if (Path.GetExtension(d.FileName) == ".txt")
                    {
                        try
                        {
                            if (TrueImp.IsChecked == true) AllClear();
                            foreach (var i in File.ReadAllLines(d.FileName))
                            {
                                List.Items.Add(i);
                            }
                            Properties.Settings.Default.FileName = ListName.Content.ToString();
                            Properties.Settings.Default.ListItem.Clear();
                            string[] p = (from object item in List.Items select item.ToString()).ToArray();
                            foreach (var i in p)
                            {
                                Properties.Settings.Default.ListItem.Add(i);
                            }
                            Complete.Content = local.Localization.RouletteFXFileLoad;
                            if (TrueImp.IsChecked == true) ListName.Content = Path.GetFileNameWithoutExtension(d.FileName);
                        }
                        catch (Exception ex)
                        {
                            Error.Content = $"{local.Localization.StringException}{ex.Message}";
                        }
                    }
                    else if (Path.GetExtension(d.FileName) == ".xml")
                    {
                        try
                        {
                            string[] list = XDocument.Load(d.FileName).Root.Elements("Element").Select(elem => elem.Value).ToArray();
                            if (TrueImp.IsChecked == true) AllClear();
                            foreach (var i in list)
                            {
                                List.Items.Add(i);
                            }
                            Properties.Settings.Default.FileName = ListName.Content.ToString();
                            Properties.Settings.Default.ListItem.Clear();
                            string[] p = (from object item in List.Items select item.ToString()).ToArray();
                            foreach (var i in p)
                            {
                                Properties.Settings.Default.ListItem.Add(i);
                            }
                            Complete.Content = local.Localization.RouletteFXFileLoad;
                            if (TrueImp.IsChecked == true) ListName.Content = Path.GetFileNameWithoutExtension(d.FileName);
                        }
                        catch (Exception ex)
                        {
                            Error.Content = $"{local.Localization.StringException}{ex.Message}";
                        }
                    }
                }
            }
            indexs.Content = local.Localization.RouletteFXItems + List.Items.Count;
        }

        private void CloseRename(object sender, RoutedEventArgs e)
        {
            App.Sound();
            Rename.Visibility = Visibility.Hidden;
            NoVis.Visibility = Visibility.Hidden;
        }

        private void OpenRename(object sender, RoutedEventArgs e)
        {
            App.Sound();
            name_Copy.Text = List.Items[index].ToString();
            Rename.Visibility = Visibility.Visible;
            NoVis.Visibility = Visibility.Visible;
        }
        

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            App.Sound();
            RenameN();
        }

        private void RenameN()
        {
            App.Sound();
            if (name_Copy.Text.Length == 0)
            {
                Error.Content = local.Localization.RouletteFXNullItem;
                return;
            }
            List.Items[index] = name_Copy.Text;
            Properties.Settings.Default.ListItem.Clear();
            string[] p = (from object item in List.Items select item.ToString()).ToArray();
            foreach (var i in p)
            {
                Properties.Settings.Default.ListItem.Add(i);
            }
            Error.Content = null;
            Rename.Visibility = Visibility.Hidden;
            NoVis.Visibility = Visibility.Hidden;
        }

        private void TextChan_TextChanged(object sender, TextChangedEventArgs e)
        {
            Properties.Settings.Default.ChangeText = TextChan.Text;
            Properties.Settings.Default.Save();
        }
        private void Name_Copy_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter) RenameN();
        }

        private void MenuCopy(object sender, RoutedEventArgs e)
        {
            App.Sound();
            System.Windows.Clipboard.Clear();
            System.Windows.Clipboard.SetText(List.Items[index].ToString());
        }

        private void IDtext_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(elements.Text, "[^0-9]"))
            {
                elements.Text = elements.Text.Remove(elements.Text.Length - 1);
                elements.SelectionStart = elements.Text.Length;
            }
        }
    }
}
