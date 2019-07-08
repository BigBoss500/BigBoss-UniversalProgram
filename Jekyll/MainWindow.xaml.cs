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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            frame.Navigate(new globalPage()); // открытие страницы
        }

        private void MessageFunction(object sender, RoutedEventArgs e) //в случае, если функция ещё не внедрена
        {
            MessageBox.Show("В данный момент функция не работает", "Функция");
        }
        private void Drag(object sender, RoutedEventArgs e) //перемещение
        {
            this.DragMove();
        }
        private void Global(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new globalPage());
        }
        private void Info(object sender, RoutedEventArgs e)
        {
            Info subWindow = new Info();
            subWindow.Show();
        }
        private void Close(object sender, RoutedEventArgs e) //завершение программы
        {
            System.Windows.Application.Current.Shutdown();
        }
        private void Rollup(object sender, RoutedEventArgs e) //свернуть программу
        {
            WindowState = WindowState.Minimized;
        }

        private void Frame_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
