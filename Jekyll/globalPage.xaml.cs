using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Jekyll
{
    /// <summary>
    /// Логика взаимодействия для globalPage.xaml
    /// </summary>
    public partial class globalPage : Page
    {
        public globalPage()
        {
            InitializeComponent();
        }
        private void Open(object sender, RoutedEventArgs e) //открыть файл
        {
            Window1 win = new Window1();
        }
        private void Page_Convert(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Convert.xaml", UriKind.Relative));
        }
        private void Page_Random(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Random.xaml", UriKind.Relative));
        }
        private void Page_News(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("News.xaml", UriKind.Relative));
        }
    }
}
