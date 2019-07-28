using System;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Xml.Linq;

namespace Jekyll
{
    /// <summary>
    /// Логика взаимодействия для Random_FM.xaml
    /// </summary>
    public partial class Random_FM : Page
    {
        public Random_FM()
        {
            InitializeComponent();
            TextChan.Text = Properties.Settings.Default.ChangeText;
            ListName.Content = Properties.Settings.Default.FileName;
            try
            {
                for (int k = 0; k < Properties.Settings.Default.ListItem.Cast<string>().ToArray().Length; k++)
                {
                    List.Items.Add(Properties.Settings.Default.ListItem[k]);
                }
            }
            catch { }
        }

        public int index, time = 1;

        private void ButtClick(object sender, RoutedEventArgs e) => AllClear();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Save();
            NavigationService.Navigate(new Uri("Random.xaml", UriKind.Relative));
        }
        private void MenuRe_Click(object sender, RoutedEventArgs e)
        {
            List.Items.RemoveAt(index);
            Properties.Settings.Default.ListItem.Clear();
            string[] p = (from object item in List.Items select item.ToString()).ToArray();
            for (int k = 0; k < p.Length; k++)
            {
                Properties.Settings.Default.ListItem.Add(p[k]);
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e) => RdmGlobal.Text = "Нажмите \"Крутить\"";
        private void ChangeText(object sender, TextChangedEventArgs e) => TextChan.Text = "Привет!";
        private void NameR(object sender, RoutedEventArgs e) => AddItems();
        private void ListBoxItem_ContextMenuOpening(object sender, ContextMenuEventArgs e) => index = List.SelectedIndex;



        void AddItems()
        {
            if (name.Text == "")
            {
                Error.Content = "Нельзя добавить пустой элемент";
                return;
            }
            List.Items.Add(name.Text);
            if (Elem.IsChecked == true)
                name.Text = null;
            Error.Content = null;
            Complete.Content = null;
            Properties.Settings.Default.ListItem.Clear();
            string[] p = (from object item in List.Items select item.ToString()).ToArray();
            for (int k = 0; k < p.Length; k++)
            {
                Properties.Settings.Default.ListItem.Add(p[k]);
            }
        }

        private void Name_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter) AddItems();
        }

        private void AllClear()
        {
            ListName.Content = "Без имени";
            List.Items.Clear();
            Properties.Settings.Default.ListItem.Clear();
            Properties.Settings.Default.FileName = "Без имени";
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Options.Visibility = Visibility.Hidden;
            NoVis.Visibility = Visibility.Hidden;
            time = int.Parse(TimeS.Text);
        }

        private void OpenOptions(object sender, RoutedEventArgs e)
        {
            Options.Visibility = Visibility.Visible;
            NoVis.Visibility = Visibility.Visible;
        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Complete.Content = null;
            RdmGlobal.Text = "Пожалуйста, подождите...";
            Error.Content = null;
            new Thread(() =>
            {
                Thread.Sleep(time * 1000);
                try
                {
                    string[] string_array = (from object item in List.Items select item.ToString()).ToArray();
                    Dispatcher.Invoke(() => RdmGlobal.Text = "Выпадает: " + Environment.NewLine + string_array[new System.Random().Next(0, string_array.Length)]);
                }
                catch (Exception ex)
                {
                    Dispatcher.Invoke(() =>
                    {
                        Error.Content = $"Исключение: {ex.Message}";
                        RdmGlobal.Text = "Нажмите \"Крутить\"";
                    });
                }
            }).Start();
        }


        private void SaveXML(object sender, RoutedEventArgs e)
        {
            Complete.Content = null;
            Error.Content = null;
            SaveFileDialog d = new SaveFileDialog
            {
                Filter = "XML-файлы (*.xml)|*.xml"
            };
            if (d.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string[] string_array = (from object item in List.Items select item.ToString()).ToArray();
                    XDocument doc = new XDocument(
                    new XElement("Elements",
                        from n in string_array select new XElement("Element", n)
                    ));
                    doc.Save(d.FileName);
                    Complete.Content = $"Файл успешно сохранен! Путь: {d.FileName}";
                    ListName.Content = System.IO.Path.GetFileNameWithoutExtension(d.FileName);
                }
                catch (Exception ex)
                {
                    Error.Content = $"Исключение: {ex.Message}";
                }
            }
        }
        private void OpenXML(object sender, RoutedEventArgs e)
        {
            Complete.Content = null;
            Error.Content = null;
            OpenFileDialog d = new OpenFileDialog
            {
                Filter = "XML-файлы (*.xml)|*.xml"
            };
            if (d.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string[] list = XDocument.Load(d.FileName).Root.Elements("Element").Select(elem => elem.Value).ToArray();
                    if (TrueImp.IsChecked == true) AllClear();
                    for (int k = 0; k < list.Length; k++)
                    {
                        List.Items.Add(list[k]);
                    }
                    ListName.Content = System.IO.Path.GetFileNameWithoutExtension(d.FileName);
                    Properties.Settings.Default.FileName = ListName.Content.ToString();
                    Properties.Settings.Default.ListItem.Clear();
                    string[] p = (from object item in List.Items select item.ToString()).ToArray();
                    for (int k = 0; k < p.Length; k++)
                    {
                        Properties.Settings.Default.ListItem.Add(p[k]);
                    }
                    Complete.Content = "Файл успешно загружен!";
                }
                catch (Exception ex)
                {
                    Error.Content = $"Исключение: {ex.Message}";
                }

            }
        }

        private void CloseRename(object sender, RoutedEventArgs e)
        {
            Rename.Visibility = Visibility.Hidden;
            NoVis.Visibility = Visibility.Hidden;
        }

        private void OpenRename(object sender, RoutedEventArgs e)
        {
            name_Copy.Text = List.Items[index].ToString();
            Rename.Visibility = Visibility.Visible;
            NoVis.Visibility = Visibility.Visible;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e) => RenameN();
        void RenameN()
        {
            if (name_Copy.Text == "")
            {
                Error.Content = "Нельзя изменить элемент на пустой!";
                return;
            }
            List.Items[index] = name_Copy.Text;
            Properties.Settings.Default.ListItem.Clear();
            string[] p = (from object item in List.Items select item.ToString()).ToArray();
            for (int k = 0; k < p.Length; k++)
            {
                Properties.Settings.Default.ListItem.Add(p[k]);
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


    }
}