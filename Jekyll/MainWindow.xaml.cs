using System;
using System.Windows;
using System.Windows.Forms;

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

        private void Drag(object sender, RoutedEventArgs e) => DragMove(); //перемещение
        private void Global(object sender, RoutedEventArgs e) => frame.Navigate(new globalPage());
        private void Info(object sender, RoutedEventArgs e)
        {
            Info subWindow = new Info();
            subWindow.Show();
        }
        private void Close(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Save();
            Environment.Exit(1);
        }
        private void Rollup(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;
        private void Back(object sender, RoutedEventArgs e)
        {
            if (frame.NavigationService.CanGoBack)
                frame.NavigationService.GoBack();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) => Environment.Exit(1);
    }
}
