using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

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
            Window9.Opacity = 0;
            Poss();
            NavigDelete();
        }
        private async void NavigDelete()
        {
            while (true)
            {
                await Task.Delay(300000);
                while (frame.NavigationService.CanGoBack)
                    frame.NavigationService.RemoveBackEntry();
            }
        }
        private async void Poss()
        {
            for (double i = 0; i < 1; i += 0.1)
            {
                Window9.Opacity = i;
                await Task.Delay(1);
            }
        }
        private void Drag(object sender, RoutedEventArgs e) => DragMove(); //перемещение
        private void Global(object sender, RoutedEventArgs e)
        {
            App.Sound();
            frame.NavigationService.Navigate(new Uri("globalPage.xaml", UriKind.Relative));
        }

        private void Info(object sender, RoutedEventArgs e)
        {
            App.Sound();
            _ = new Info();
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            for (double i = 1; i < 0; i -= 0.1)
            {
                Window9.Opacity = i;
                await Task.Delay(1);
            }
            Application.Current.Shutdown();
        }

        private async void Close(object sender, RoutedEventArgs e)
        {
            App.Sound();
            Properties.Settings.Default.Save();
            for (double i = 1; i > 0; i -= 0.1)
            {
                Window9.Opacity = i;
                await Task.Delay(1);
            }
            Application.Current.Shutdown();
        }
        private async void Rollup(object sender, RoutedEventArgs e)
        {
            App.Sound();
            for (double i = 1; i > 0; i -= 0.1)
            {
                Window9.Opacity = i;
                await Task.Delay(1);
            }
            WindowState = WindowState.Minimized;
            Window9.Opacity = 1;
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            App.Sound();
            if (frame.NavigationService.CanGoBack)
                frame.NavigationService.GoBack();
        }

        private void Frame_Unloaded(object sender, RoutedEventArgs e) => frame.Content = null;

        private void Frame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (((Page)e.Content).Title == "Главная")
                cont.Content = "Jekyll";
            else cont.Content = "Jekyll: " + ((Page)e.Content).Title;
        }
    }
}
