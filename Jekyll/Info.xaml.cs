using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
    /// Логика взаимодействия для Info.xaml
    /// </summary>
    public partial class Info : Window
    {
        public Info()
        {
            InitializeComponent();
            Download.Visibility = Visibility.Hidden;

        }
        private void Close(object sender, RoutedEventArgs e) //завершение программы
        {
            Close();
        }
        private void Drag(object sender, RoutedEventArgs e) //перемещение
        {
            DragMove();
        }
        private void VK(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://vk.com/dmitriyzhutkov");
        }
        private void GitHub(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/BigBoss500/Jekyll");
        }
        private void Update(object sender, RoutedEventArgs e)
        {
            
        }
    }

}
