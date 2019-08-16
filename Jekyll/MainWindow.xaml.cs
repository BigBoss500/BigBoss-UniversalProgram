using System;
using System.Windows;

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
        private void Info(object sender, RoutedEventArgs e) => _ = new Info();
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) => Application.Current.Shutdown();
        private void Close(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Save();
            Application.Current.Shutdown();
        }
        private void Rollup(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;
        private void Back(object sender, RoutedEventArgs e)
        {
            if (frame.NavigationService.CanGoBack)
                frame.NavigationService.GoBack();
        }
    }
}
