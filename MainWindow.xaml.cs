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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OlibUpdater
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private bool OpenSideBar = false;
        private void Drag(object sender, MouseButtonEventArgs e) => DragMove();
        private void Full(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal;
        }
        private void Back(object sender, RoutedEventArgs e)
        {
            if (frame.NavigationService.CanGoBack)
                frame.NavigationService.GoBack();
        }

        private void Navigated(object sender, NavigationEventArgs e) => textHeader.Content = ((Page)e.Content).Title;
        private void Close(object sender, EventArgs e) => Application.Current.Shutdown();
        private void Hide(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;
        private void SideBar(object sender, RoutedEventArgs e) => HidenSideBar();

        private async void HidenSideBar()
        {
            GlobalButton.IsEnabled = false;
            var anim = new DoubleAnimation();
            var anim1 = new DoubleAnimation();
            anim.Duration = TimeSpan.FromSeconds(0.5);
            anim1.Duration = TimeSpan.FromSeconds(0.5);
            anim.DecelerationRatio = 1;
            anim1.DecelerationRatio = 1;
            if (!OpenSideBar)
            {
                anim.To = 260;
                anim1.To = 0.5;
                borderHide.Visibility = Visibility.Visible;
                borderHide.IsEnabled = true;
                Author.Text = Core.EasterEggs.Author;
            }
            else
            {
                anim.To = 0;
                anim1.To = 0;
                anim1.Completed += Anim1_Completed;
                borderHide.IsEnabled = false;
            }
            sideBar.BeginAnimation(WidthProperty, anim);
            borderHide.BeginAnimation(OpacityProperty, anim1);
            OpenSideBar = !OpenSideBar;
            await Task.Delay(500);
            GlobalButton.IsEnabled = true;
        }

        private void Anim1_Completed(object sender, EventArgs e) => borderHide.Visibility = Visibility.Hidden;
        private void ClickHideBorder(object sender, MouseButtonEventArgs e) => HidenSideBar();

        private void Autoclicker(object sender, RoutedEventArgs e)
        {
            var win = new Windows.autoclicker();
            win.Show();
            HidenSideBar();
        }

        private void MainPage(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Uri("Pages/main.xaml", UriKind.Relative));
            HidenSideBar();
        }

        private void DataParser(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Uri("Pages/dataParser.xaml", UriKind.Relative));
            HidenSideBar();
        }

        private void Roulette(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Uri("Pages/roulette.xaml", UriKind.Relative));
            HidenSideBar();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Uri("Pages/converter.xaml", UriKind.Relative));
            HidenSideBar();
        }
    }
}
